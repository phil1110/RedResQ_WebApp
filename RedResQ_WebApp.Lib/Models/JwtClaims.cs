using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedResQ_WebApp.Lib.Models
{
    public class JwtClaims
    {
        public string Version { get; set; }

        public string Expiration { get; set; }

        public string NameIdentifier { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }

        public string Exp { get; set; }
    }
}
