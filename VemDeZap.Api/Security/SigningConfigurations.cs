using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VemDeZap.Api.Security
{
    public class SigningConfigurations
    {
        private const string SECRET_KEY = "";

        public SigningCredentials SigningCredentials { get; }
        private readonly SymmetricSecurityKey _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SECRET_KEY));

        public SigningConfigurations()
        {
            SigningCredentials = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256);
        }
    }
}
