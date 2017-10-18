﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Course_API.Options;

namespace Course_API.Helpers
{
    public static class JwtEncoder
    {
        public static string EncodeSecurityToken(JwtIssuerOptions jwtIssuerOptions, ClaimsPrincipal claimsPrincipal)
        {
            var jwt = new JwtSecurityToken(jwtIssuerOptions.Issuer, jwtIssuerOptions.Audience, claimsPrincipal.Claims,
                jwtIssuerOptions.NotBefore, jwtIssuerOptions.Expiration, jwtIssuerOptions.SigningCredentials);

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}
