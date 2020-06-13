using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RoadToAPI.Model;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoadToAPI.Auth
{
    public class AuthToken
    {
        private IConfiguration _config;
        public AuthToken(IConfiguration config)
        {
            _config = config;
        }
        private string GenerateJSONWebToken(Users userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            //var claims = new[]
            //{
            //    new Claim(JwtRegisteredClaimNames.Sub,userInfo.Username),
            //    new Claim(JwtRegisteredClaimNames.Email,userInfo.Email),

            //}

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public string getToken(Users userInfo)
        {
            return GenerateJSONWebToken(userInfo);
        }

        private Users AuthenticateUser(Users login)
        {
            Users user = null;

            //Validate the User Credentials    
            //Demo Purpose, I have Passed HardCoded User Information    
            if (login.Username == "admin")
            {
                user = new Users { Username = "Thanks P", Email = "peepee@hp.com", Role = 1 };
            }
            return user;
        }
        public Users getAuthenticate(Users login)
        {
            return AuthenticateUser(login);
        }
    }
}
