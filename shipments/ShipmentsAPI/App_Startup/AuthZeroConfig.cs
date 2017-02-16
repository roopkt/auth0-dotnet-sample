﻿
using System.Collections.Generic;
using System.Configuration;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security.Jwt;
using Owin;

namespace ShipmentsAPI
{
    public partial class Startup
    {
        public void ConfigureAuthZero(IAppBuilder app)
        {
            var issuer = "https://" + ConfigurationManager.AppSettings["auth0:Domain"] + "/";
            var audience = ConfigurationManager.AppSettings["auth0:ClientId"];
            var secret =
                TextEncodings.Base64.Encode(
                    TextEncodings.Base64Url.Decode(ConfigurationManager.AppSettings["auth0:ClientSecret"]));

            app.UseJwtBearerAuthentication(new JwtBearerAuthenticationOptions
            {
                AuthenticationMode =  AuthenticationMode.Active,
                AllowedAudiences = new []{audience},
                IssuerSecurityTokenProviders = new List<IIssuerSecurityTokenProvider> { new SymmetricKeyIssuerSecurityTokenProvider(issuer,secret)
                }
            });
        }
    }
}