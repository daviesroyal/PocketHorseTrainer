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
                ApplicationUser user = new()
                {
                    FirstName = input.FirstName,
                    LastName = input.LastName,
                    DisplayName = $"{input.FirstName} {input.LastName}",
                    UserName = input.UserName,
                    DOB = input.DOB,
                    PhoneNumber = input.Phone,
                    Email = input.Email
                };
                IdentityResult result = await _userManager.CreateAsync(user, input.Password).ConfigureAwait(false);
                if (result.Succeeded)
                {
                    string emailConfirmationToken = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(await _userManager.GenerateEmailConfirmationTokenAsync(user).ConfigureAwait(false)));
                    string tokenVerificationUrl = Url.Page(
                        "/ConfirmEmail",
                        pageHandler: null,
                        new { userId = user.Id, code = emailConfirmationToken },
                        Request.Scheme,
                        host: "localhost:5000");

                    await _emailSender.SendEmailAsync(input.Email, "Verify your email", $"Click <a href=\"{HtmlEncoder.Default.Encode(tokenVerificationUrl)}\">here</a> to verify your email").ConfigureAwait(false);
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
                ApplicationUser user = await _userManager.FindByNameAsync(input.UserName).ConfigureAwait(false);
                if (user == null)
                {
                    return BadRequest("Invalid Login");
                }
                if (!user.EmailConfirmed)
                {
                    return BadRequest("Email has not been confirmed for this account.");
                }
                Microsoft.AspNetCore.Identity.SignInResult signInResult = await _signInManager.PasswordSignInAsync(user, input.Password, isPersistent: bool.Parse($"{input.RememberMe}"), lockoutOnFailure: false).ConfigureAwait(false);
                if (!signInResult.Succeeded)
                {
                    return BadRequest("Invalid Login");
                }
                return base.Ok(GenerateTokens(user));
            }
            //if we got this far, something went wrong
            return BadRequest(ModelState);
        }

        [AllowAnonymous]
        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            ApplicationUser user = await _userManager.FindByEmailAsync(email).ConfigureAwait(false);
            if (user == null || !(await _userManager.IsEmailConfirmedAsync(user).ConfigureAwait(false)))
            {
                //Don't reveal that the user does not exist or is not confirmed
                return BadRequest();
            }

            string code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(await _userManager.GeneratePasswordResetTokenAsync(user).ConfigureAwait(false)));
            string passwordResetToken = Url.Page(
                "/ResetPassword",
                pageHandler: null,
                values: new { code },
                protocol: Request.Scheme,
                host: "localhost:5000");
            await _emailSender.SendEmailAsync(email, "Reset Password", $"Please reset your password <a href='{HtmlEncoder.Default.Encode(passwordResetToken)}'>here</a>.").ConfigureAwait(false);
            return Ok();
        }

        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword(string oldPassword, string newPassword)
        {
            ApplicationUser user = await _userManager.GetUserAsync(User).ConfigureAwait(false);
            if (user == null)
            {
                return NotFound();
            }

            IdentityResult changePasswordResult = await _userManager.ChangePasswordAsync(user, oldPassword, newPassword).ConfigureAwait(false);
            if (!changePasswordResult.Succeeded)
            {
                foreach (var error in changePasswordResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return BadRequest(ModelState);
            }

            await _signInManager.RefreshSignInAsync(user).ConfigureAwait(false);
            return Ok();
        }

        [HttpPost("ChangeEmail")]
        public async Task<IActionResult> ChangeEmail(string email)
        {
            ApplicationUser user = await _userManager.GetUserAsync(User).ConfigureAwait(false);
            string currentEmail = await _userManager.GetEmailAsync(user).ConfigureAwait(false);
            if (email != currentEmail)
            {
                string userId = await _userManager.GetUserIdAsync(user).ConfigureAwait(false);
                string code = await _userManager.GenerateChangeEmailTokenAsync(user, email).ConfigureAwait(false);
                string changeEmailToken = Url.Page(
                    "/ConfirmEmailChange",
                    pageHandler: null,
                    values: new { userId, email, code},
                    protocol: Request.Scheme);
                await _emailSender.SendEmailAsync(email, "Confirm your email", $"Please verify your email address by clicking <a href='{HtmlEncoder.Default.Encode(changeEmailToken)}'>here</a>").ConfigureAwait(false);
            }
            return Ok();
        }

        [HttpPost("ChangePhone")]
        public async Task<IActionResult> ChangePhone(string phone)
        {
            ApplicationUser user = await _userManager.GetUserAsync(User).ConfigureAwait(false);
            string currentPhone = await _userManager.GetPhoneNumberAsync(user).ConfigureAwait(false);
            return phone != currentPhone && !(await _userManager.SetPhoneNumberAsync(user, phone).ConfigureAwait(false)).Succeeded
                ? BadRequest()
                : Ok();
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("RefreshToken")]
        public IActionResult RefreshToken()
        {
            string token = HttpContext.Request.Cookies["refreshToken"];
            ApplicationUser user = _context.Users.Include(x => x.RefreshTokens)
                .FirstOrDefault(x => x.RefreshTokens.Any(y => y.Token == token && y.UserId == x.Id.ToString()));

            // Get existing refresh token if it is valid and revoke it
            if (GetValidRefreshToken(token, user) == null)
            {
                return BadRequest();
            }
            GetValidRefreshToken(token, user).RevokedByIp = HttpContext.Connection.RemoteIpAddress.ToString();
            GetValidRefreshToken(token, user).RevokedOn = DateTime.UtcNow;

            // Generate new tokens
            return base.Ok(GenerateTokens(user));
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

        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync().ConfigureAwait(false);
            RevokeRefreshToken();
            return Ok();
        }

        #region TokenMethods
        private static RefreshToken GetValidRefreshToken(string token, ApplicationUser user)
        {
            return user == null
                ? null
                : IsRefreshTokenValid(user.RefreshTokens.Find(x => x.Token == token)) ? user.RefreshTokens.Find(x => x.Token == token) : null;
        }

        private bool RevokeRefreshToken(string token = null)
        {
            token ??= HttpContext.Request.Cookies["refreshToken"];
            ApplicationUser identityUser = _context.Users.Include(x => x.RefreshTokens)
                .FirstOrDefault(x => x.RefreshTokens.Any(y => y.Token == token && y.UserId == x.Id.ToString()));
            if (identityUser == null)
            {
                return false;
            }

            // Revoke Refresh token
            identityUser.RefreshTokens.Find(x => x.Token == token).RevokedByIp = HttpContext.Connection.RemoteIpAddress.ToString();
            identityUser.RefreshTokens.Find(x => x.Token == token).RevokedOn = DateTime.UtcNow;
            _context.Update(identityUser);
            _context.SaveChanges();
            return true;
        }

        private string GenerateTokens(ApplicationUser user)
        {
            // Generate access token
            string accessToken = GenerateAccessToken(user);

            // Generate refresh token and set it to cookie
            RefreshToken refreshToken = GenerateRefreshToken(HttpContext.Connection.RemoteIpAddress.ToString(), user.Id.ToString());

            // Set Refresh Token Cookie
            CookieOptions cookieOptions = new()
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(5)
            };
            HttpContext.Response.Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);

            // Save refresh token to database
            (user.RefreshTokens ??= new List<RefreshToken>()).Add(refreshToken);
            _context.Update(user);
            _context.SaveChanges();
            return accessToken;
        }

        private string GenerateAccessToken(ApplicationUser user)
        {
            JwtSecurityToken jwt = new(
                issuer: _configuration.GetValue<string>("Jwt:Issuer"),
                audience: _configuration.GetValue<string>("Jwt:Audience"),
                claims: new Claim[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, ((DateTimeOffset)DateTime.UtcNow).ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64)
                },
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(_configuration.GetValue<int>("Jwt:Lifetime")),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("Jwt:Key"))), SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        private RefreshToken GenerateRefreshToken(string ipAddress, string userId)
        {
            using RNGCryptoServiceProvider rngCryptoServiceProvider = new();
            rngCryptoServiceProvider.GetBytes(new byte[64]);
            return new RefreshToken
            {
                Token = Convert.ToBase64String(new byte[64]),
                ExpiryOn = DateTime.UtcNow.AddDays(_configuration.GetValue<int>("Jwt:Lifetime")),
                CreatedOn = DateTime.UtcNow,
                CreatedByIp = ipAddress,
                UserId = userId
            };
        }

        private static bool IsRefreshTokenValid(RefreshToken existingToken)
        {
            // Is token already revoked, then return false
            return (existingToken.RevokedByIp == null || existingToken.RevokedOn == DateTime.MinValue) && existingToken.ExpiryOn > DateTime.UtcNow;
        }
        #endregion
    }
}
