using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Buffers.Text;

namespace RedResQ_WebApp.Lib.Services
{
    public class TokenService
    {
        public static Claim[] GetClaims(string token)
        {
            JwtSecurityToken jwt = new JwtSecurityToken(token);

            return jwt.Claims.ToArray();
        }
    }
}
