using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProductsApi.Models;
using ProductsApi.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings;

namespace ProductsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : Controller
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        public TokenController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateToken([FromBody]TokenRequest request)
        {
            var user = await _userService.GetUserByUserNameAsync(request.UserName);
            if (user == null || user.Password != request.Password)
            {
                return Unauthorized();
            }

            var claimsList = new List<Claim> {
             new Claim(ClaimTypes.Name, user.FirstName),
             new Claim(ClaimTypes.NameIdentifier, user.UserName),
             new Claim(ClaimTypes.Email, user.Email),
             new Claim(ClaimTypes.GivenName,user.FirstName )
            };

            var keyString = _configuration.GetValue<string>("Security:key");
            var issuer = _configuration.GetValue<string>("Security:issuer");
            var audience = _configuration.GetValue<string>("Security:audience");
            int.TryParse(_configuration.GetValue<string>("Security:tokenLifeTime"), out int tokenLifetime);

            if (tokenLifetime == 0) { tokenLifetime = 15; };

            var keyBytes = Encoding.ASCII.GetBytes(keyString);

            SecurityKey key = new SymmetricSecurityKey(keyBytes);
            SigningCredentials signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            //create token
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claimsList,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(tokenLifetime),
                signingCredentials: signingCredentials);

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            var token = handler.WriteToken(jwtSecurityToken);

            return Ok(new TokenResponse { AccessToken = token});          
        }
    }
}
