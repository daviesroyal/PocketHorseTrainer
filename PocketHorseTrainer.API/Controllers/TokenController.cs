using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PocketHorseTrainer.API.Data;
using PocketHorseTrainer.API.Models;
using PocketHorseTrainer.API.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PocketHorseTrainer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly ApplicationDbContext _context;

        public TokenController(ITokenService tokenService, ApplicationDbContext context)
        {
            _tokenService = tokenService;
            _context = context;
        }

        [HttpPost("Refresh")]
        public IActionResult Refresh([FromBody] TokenModel input)
        {
            if (input.AccessToken != null)
            {
                var principal = _tokenService.GetPrincipalFromExpiredToken(input.AccessToken);

                var user = _context.Users.SingleOrDefault(u => u.UserName == principal.Identity.Name); //this is mapped to the Name claim by default
                if (user == null || user.RefreshToken != input.RefreshToken) return BadRequest();

                return new ObjectResult(new
                {
                    token = _tokenService.GenerateAccessToken(principal.Claims),
                    refreshToken = user.RefreshToken
                });
            }
            return BadRequest();
        }

        [HttpPost("Revoke")]
        [Authorize]
        public async Task<IActionResult> Revoke()
        {
            var username = User.Identity.Name;

            var user = _context.Users.SingleOrDefault(u => u.UserName == username);
            if (user == null) return BadRequest();

            user.RefreshToken = null;

            await _context.SaveChangesAsync().ConfigureAwait(false);

            return NoContent();
        }
    }
}
