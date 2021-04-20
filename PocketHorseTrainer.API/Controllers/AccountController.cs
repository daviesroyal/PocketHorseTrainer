using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using PocketHorseTrainer.API.Models;
using System;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using PocketHorseTrainer.API.Services;
using System.Text.Encodings.Web;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using PocketHorseTrainer.API.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
        private readonly ApplicationDbContext _context;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IConfiguration configuration,
            IEmailSender emailSender,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _emailSender = emailSender;
            _context = context;
        }

        [AllowAnonymous]
        [HttpPost("Register")]
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
                    DOB = input.DOB, 
                    PhoneNumber = input.Phone, 
                    Email = input.Email 
                };
                var result = await _userManager.CreateAsync(user, input.Password);
                if (result.Succeeded)
                {
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var emailConfirmationToken = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var tokenVerificationUrl = Url.Page(
                        "/ConfirmEmail",
                        pageHandler: null,
                        new { userId = user.Id, code = emailConfirmationToken },
                        Request.Scheme,
                        host: "localhost:5000");

                    await _emailSender.SendEmailAsync(input.Email, "Verify your email", $"Click <a href=\"{HtmlEncoder.Default.Encode(tokenVerificationUrl)}\">here</a> to verify your email");
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

        [AllowAnonymous]
        [HttpPost("Login")]
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
                var token = GenerateTokens(user);
                return Ok(token);
            }
            //if we got this far, something went wrong
            return BadRequest(ModelState);
        }

        [AllowAnonymous]
        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
            {
                //Don't reveal that the user does not exist or is not confirmed
                return BadRequest();
            }

            var code = await _userManager.GeneratePasswordResetTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            var passwordResetToken = Url.Page(
                "/ResetPassword",
                pageHandler: null,
                new { code },
                Request.Scheme,
                host: "localhost:5000");
            await _emailSender.SendEmailAsync(
                email,
                "Reset Password",
                $"Please reset your password <a href='{HtmlEncoder.Default.Encode(passwordResetToken)}'>here</a>.");
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("RefreshToken")]
        public IActionResult RefreshToken()
        {
            var token = HttpContext.Request.Cookies["refreshToken"];
            var user = _context.Users.Include(x => x.RefreshTokens)
                .FirstOrDefault(x => x.RefreshTokens.Any(y => y.Token == token && y.UserId == x.Id.ToString()));

            // Get existing refresh token if it is valid and revoke it
            var existingRefreshToken = GetValidRefreshToken(token, user);
            if (existingRefreshToken == null)
            {
                return BadRequest();
            }

            existingRefreshToken.RevokedByIp = HttpContext.Connection.RemoteIpAddress.ToString();
            existingRefreshToken.RevokedOn = DateTime.UtcNow;

            // Generate new tokens
            var newToken = GenerateTokens(user);
            return Ok(newToken);
        }

        [HttpPost]
        [Route("RevokeToken")]
        public IActionResult RevokeToken(string token)
        {
            // If user found, then revoke
            if (RevokeRefreshToken(token))
            {
                return Ok();
            }

            // Otherwise, return error
            return BadRequest();
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            RevokeRefreshToken();
            return Ok();
        }

        #region TokenMethods
        private static RefreshToken GetValidRefreshToken(string token, ApplicationUser user)
        {
            if (user == null)
            {
                return null;
            }

            var existingToken = user.RefreshTokens.FirstOrDefault(x => x.Token == token);
            return IsRefreshTokenValid(existingToken) ? existingToken : null;
        }

        private bool RevokeRefreshToken(string token = null)
        {
            token ??= HttpContext.Request.Cookies["refreshToken"];
            var identityUser = _context.Users.Include(x => x.RefreshTokens)
                .FirstOrDefault(x => x.RefreshTokens.Any(y => y.Token == token && y.UserId == x.Id.ToString()));
            if (identityUser == null)
            {
                return false;
            }

            // Revoke Refresh token
            var existingToken = identityUser.RefreshTokens.FirstOrDefault(x => x.Token == token);
            existingToken.RevokedByIp = HttpContext.Connection.RemoteIpAddress.ToString();
            existingToken.RevokedOn = DateTime.UtcNow;
            _context.Update(identityUser);
            _context.SaveChanges();
            return true;
        }

        private string GenerateTokens(ApplicationUser user)
        {
            // Generate access token
            string accessToken = GenerateAccessToken(user);

            // Generate refresh token and set it to cookie
            var ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            var refreshToken = GenerateRefreshToken(ipAddress, user.Id.ToString());

            // Set Refresh Token Cookie
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(7)
            };
            HttpContext.Response.Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);

            // Save refresh token to database
            if (user.RefreshTokens == null)
            {
                user.RefreshTokens = new List<RefreshToken>();
            }

            user.RefreshTokens.Add(refreshToken);
            _context.Update(user);
            _context.SaveChanges();
            return accessToken;
        }

        private string GenerateAccessToken(ApplicationUser user)
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

        private RefreshToken GenerateRefreshToken(string ipAddress, string userId)
        {
            using var rngCryptoServiceProvider = new RNGCryptoServiceProvider();
            var randomBytes = new byte[64];
            rngCryptoServiceProvider.GetBytes(randomBytes);
            return new RefreshToken
            {
                Token = Convert.ToBase64String(randomBytes),
                ExpiryOn = DateTime.UtcNow.AddDays(_configuration.GetValue<int>("Jwt:Lifetime")),
                CreatedOn = DateTime.UtcNow,
                CreatedByIp = ipAddress,
                UserId = userId
            };
        }

        private static bool IsRefreshTokenValid(RefreshToken existingToken)
        {
            // Is token already revoked, then return false
            if (existingToken.RevokedByIp != null && existingToken.RevokedOn != DateTime.MinValue)
            {
                return false;
            }

            // Token already expired, then return false
            if (existingToken.ExpiryOn <= DateTime.UtcNow)
            {
                return false;
            }

            return true;
        }
        #endregion
    }
}
