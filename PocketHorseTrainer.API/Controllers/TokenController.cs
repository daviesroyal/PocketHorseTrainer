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

        [HttpPost("{user}")]
        public string GenerateTokens([FromRoute] ApplicationUser user)
        {
            var claims = new Claim[]
                {
                                    new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                                    new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
                                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                                    new Claim(JwtRegisteredClaimNames.Iat, ((DateTimeOffset)DateTime.UtcNow).ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64)
                };
            // Generate access token
            string accessToken = _tokenService.GenerateAccessToken(claims);

            // Save refresh token to database
            user.RefreshToken = _tokenService.GenerateRefreshToken();
            _context.Update(user);
            _context.SaveChanges();
            return accessToken;
        }

        [HttpPost]
        public async Task<IActionResult> Refresh(string token, string refreshToken)
        {
            var principal = _tokenService.GetPrincipalFromExpiredToken(token);
            var username = principal.Identity.Name; //this is mapped to the Name claim by default

            var user = _context.Users.SingleOrDefault(u => u.UserName == username);
            if (user == null || user.RefreshToken != refreshToken) return BadRequest();

            var newJwtToken = _tokenService.GenerateAccessToken(principal.Claims);
            var newRefreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = newRefreshToken;
            await _context.SaveChangesAsync().ConfigureAwait(false);

            return new ObjectResult(new
            {
                token = newJwtToken,
                refreshToken = newRefreshToken
            });
        }

        [HttpPost, Authorize]
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
