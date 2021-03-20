using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using PocketHorseTrainer.API.Data;
using PocketHorseTrainer.API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Authorization;

namespace PocketHorseTrainer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterModel input)
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
                        new { Id = user.Id, token = emailConfirmationToken },
                        Request.Scheme);

                    await _emailSender.SendEmailAsync(input.Email, "Verify your email", $"Click <a href=\"{tokenVerificationUrl}\">here</a> to verify your email");
                    return Ok($"Registration completed, please verify your email - {input.Email}");
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
            return BadRequest();
        }
        
        public async Task<IActionResult> VerifyEmail(string id, string token)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                throw new InvalidOperationException();
            }

            var emailConfirmationResult = await _userManager.ConfirmEmailAsync(user, token);
            if (!emailConfirmationResult.Succeeded)
            {
                return new RedirectToActionResult("Register", "Account", null);
            }
            return new RedirectResult("http://localhost:62833");
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginModel input)
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
                var signInResult = await _signInManager.PasswordSignInAsync(user, input.Password, isPersistent: Convert.ToBoolean(input.RememberMe), lockoutOnFailure: false);
                if (!signInResult.Succeeded)
                {
                    return BadRequest("Invalid Login");
                }
                return Ok();
            }
            //if we got this far, something went wrong
            return BadRequest();
        }

        [Authorize]
        [HttpPost]
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }
    }
}
