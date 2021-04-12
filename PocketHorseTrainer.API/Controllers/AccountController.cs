using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using PocketHorseTrainer.API.Models;
using System;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;

namespace PocketHorseTrainer.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly IEmailSender _emailSender;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IConfiguration configuration,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _emailSender = emailSender;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]RegisterModel input)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                { 
                    FirstName = input.FirstName, 
                    LastName = input.LastName,
                    DisplayName = $"{input.FirstName} {input.LastName}",
                    UserName = input.UserName, 
                    DOB = Convert.ToDateTime(input.DOB), 
                    PhoneNumber = input.Phone, 
                    Email = input.Email 
                };
                var result = await _userManager.CreateAsync(user, input.Password);
                if (result.Succeeded)
                {
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var emailConfirmationToken = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var tokenVerificationUrl = Url.Action(
                        "VerifyEmail", "Account",
                        new { user.Id, token = emailConfirmationToken },
                        Request.Scheme);

                    await _emailSender.SendEmailAsync(input.Email, "Verify your email", $"Click <a href=\"{tokenVerificationUrl}\">here</a> to verify your email");
                    return Ok();
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return RedirectToAction();
                }
            }
            //if we got this far, something failed, redisplay
            return BadRequest(ModelState);
        }
        
        private async Task<IActionResult> VerifyEmail(string id, string token)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                throw new InvalidOperationException();
            }

            var emailConfirmationResult = await _userManager.ConfirmEmailAsync(user, token);
            if (!emailConfirmationResult.Succeeded)
            {
                return new LocalRedirectResult("api/account/register");
            }
            return new LocalRedirectResult("api/account/login");
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginModel input)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(input.UserName);
                if (user == null)
                {
                    return BadRequest("Invalid Login");
                }
                if (!user.EmailConfirmed)
                {
                    return BadRequest("Email has not been confirmed for this account.");
                }
                var signInResult = await _signInManager.PasswordSignInAsync(user, input.Password, isPersistent: bool.Parse($"{input.RememberMe}"), lockoutOnFailure: false);
                if (!signInResult.Succeeded)
                {
                    return BadRequest("Invalid Login");
                }
                return Ok(GetToken(user));
            }
            //if we got this far, something went wrong
            return BadRequest(ModelState);
        }

        private String GetToken(ApplicationUser user)
        {
            var utcNow = DateTime.UtcNow;

            var claims = new Claim[]
            {
                        new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                        new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, utcNow.ToString())
            };

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<String>("Jwt:Key")));
            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            var jwt = new JwtSecurityToken(
                signingCredentials: signingCredentials,
                claims: claims,
                notBefore: utcNow,
                expires: utcNow.AddMinutes(_configuration.GetValue<int>("Jwt:Lifetime")),
                audience: _configuration.GetValue<String>("Jwt:Audience"),
                issuer: _configuration.GetValue<String>("Jwt:Issuer")
                );

            return new JwtSecurityTokenHandler().WriteToken(jwt);

        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }
    }
}
