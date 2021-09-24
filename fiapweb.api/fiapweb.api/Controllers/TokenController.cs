using fiapweb.api.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace fiapweb.api.Controllers
{
    [ApiController]
    [Route("/token")]
    public class TokenController : Controller
    {
        [HttpPost]
        public IActionResult Create(TokenInfo model)
        {
            if (IsValid(model.UserName, model.Password))
            {
                var token = GenerateToken(model.UserName);
                //salvar no db
                return new ObjectResult(token);
            }
            return BadRequest();

        }

        private string GenerateToken(string userName)
        {
            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Name, userName),
                new Claim(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
                new Claim(JwtRegisteredClaimNames.Exp, new DateTimeOffset(DateTime.Now.AddDays(1)).ToUnixTimeSeconds().ToString()),
            };


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("the secret that needs to be at least 16 characeters long for HmacSha256"));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(credentials);
            var payload = new JwtPayload(claims);

            var token = new JwtSecurityToken(header,payload);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private bool IsValid(string userName, string password)
        {
            return userName == password;
        }
    }
}
