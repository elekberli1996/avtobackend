using Core.Entities.Concrete;
using Core.Extention;

using Core.Utilities.Security.Encriptor;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Jwt
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; }
        private TokenOptions _tokenOptions;
        DateTime _accessTpkenExpiration;

        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
         
        }

        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
        {
            _accessTpkenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            var securityKey = SecurityKeyHelper.CreatSecurityKey(_tokenOptions.SecurityKey);
            var signingCredantial = SigningCredantialHelper.CreateSigningCredentials(securityKey);
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredantial, operationClaims);
            var jwtSecurityTokenHandelr = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandelr.WriteToken(jwt);
            return new AccessToken
            {
                Token = token,
                Expiration = _accessTpkenExpiration
            };

        }

        private JwtSecurityToken CreateJwtSecurityToken(
            TokenOptions tokenOptions, 
            User user, 
            SigningCredentials signingCredantial,
            List<OperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTpkenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaims(user, operationClaims),
                signingCredentials: signingCredantial
               );
            return jwt;
        }

        private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.UserId.ToString());
            claims.AddEmail(user.Email.ToString());
            claims.AddName($"{user.FirstName}{user.LastName}");
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());
            return claims;

        }
    }
}
