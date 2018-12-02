using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using CinemaSupport.Domain.Models;
using CinemaSupport.Domain.Models.Actors;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;

using Microsoft.Owin.Security.OAuth;

namespace CinemaSupportApi.Authentication
{
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        private readonly string _publicClientId;

        public ApplicationOAuthProvider(string publicClientId)
        {
            if (publicClientId == null)
            {
                throw new ArgumentNullException("publicClientId");
            }

            _publicClientId = publicClientId;
        }

        public override Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
        {
            if (context.ClientId == _publicClientId)
            {
                Uri expectedRootUri = new Uri(context.Request.Uri, "/");

                if (expectedRootUri.AbsoluteUri == context.RedirectUri)
                {
                    context.Validated();
                }
                else if (context.ClientId == "web")
                {
                    var expectedUri = new Uri(context.Request.Uri, "/");
                    context.Validated(expectedUri.AbsoluteUri);
                }
            }

            return Task.FromResult<object>(null);
        }

        public override async Task ValidateClientAuthentication(
        OAuthValidateClientAuthenticationContext context)
        {
            string clientId = "1234";
            string clientSecret = "12345";
            context.TryGetFormCredentials(out clientId, out clientSecret);

            if (clientId == "1234" && clientSecret == "12345")
            {
                context.Validated(clientId);
            }
        }

        public override async Task GrantResourceOwnerCredentials(
            OAuthGrantResourceOwnerCredentialsContext context)
        {

            try
            {
                // User is found. Signal this by calling context.Validated
                //ClaimsIdentity identity = await UserManager.CreateIdentityAsync(
                //    context.UserName,
                //    DefaultAuthenticationTypes.ExternalBearer);

                //context.Validated(identity);
            }
            catch
            {
                // The ClaimsIdentity could not be created by the UserManager.
                context.SetError("server_error");
                context.Rejected();
            }

        }
    }
}