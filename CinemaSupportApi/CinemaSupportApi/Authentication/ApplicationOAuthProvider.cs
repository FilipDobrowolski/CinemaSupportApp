using System;
using System.Collections.Concurrent;
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
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Infrastructure;
using Microsoft.Owin.Security.OAuth;
using Owin;

using Microsoft.Owin.Security.OAuth;

namespace CinemaSupportApi.Authentication
{
    //public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    //{
    //    private readonly string _publicClientId;

    //    public ApplicationOAuthProvider(string publicClientId)
    //    {
    //        if (publicClientId == null)
    //        {
    //            throw new ArgumentNullException("publicClientId");
    //        }

    //        _publicClientId = publicClientId;
    //    }

    //    //public override Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
    //    //{
    //    //    if (context.ClientId == _publicClientId)
    //    //    {
    //    //        Uri expectedRootUri = new Uri(context.Request.Uri, "/");

    //    //        if (expectedRootUri.AbsoluteUri == context.RedirectUri)
    //    //        {
    //    //            context.Validated();
    //    //        }
    //    //        else if (context.ClientId == "web")
    //    //        {
    //    //            var expectedUri = new Uri(context.Request.Uri, "/");
    //    //            context.Validated(expectedUri.AbsoluteUri);
    //    //        }
    //    //    }

    //    //    return Task.FromResult<object>(null);
    //    //}

    //    public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
    //    {
    //        context.Validated();
    //    }

    //    public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
    //    {
    //        UserManager<IdentityUser> userManager = context.OwinContext.GetUserManager<UserManager<IdentityUser>>();
    //        IdentityUser user;
    //        try
    //        {
    //            user = await userManager.FindAsync(context.UserName, context.Password);
    //        }
    //        catch
    //        {
    //            // Could not retrieve the user due to error.  
    //            context.SetError("server_error");
    //            context.Rejected();
    //            return;
    //        }

    //        if (user != null)
    //        {
    //            ClaimsIdentity identity = await userManager.CreateIdentityAsync(
    //                user,
    //                DefaultAuthenticationTypes.ExternalBearer);
    //            context.Validated(identity);
    //        }
    //        else
    //        {
    //            context.SetError("invalid_grant", "Invalid User Id or password'");
    //            context.Rejected();
    //        }
    //    }

    //    public class RefreshTokenProvider : IAuthenticationTokenProvider
    //    {
    //        private static ConcurrentDictionary<string, AuthenticationTicket> _refreshTokens =
    //            new ConcurrentDictionary<string, AuthenticationTicket>();

    //        public async Task CreateAsync(AuthenticationTokenCreateContext context)
    //        {

    //            var guid = Guid.NewGuid().ToString();

    //            // copy all properties and set the desired lifetime of refresh token  
    //            var refreshTokenProperties = new AuthenticationProperties(context.Ticket.Properties.Dictionary)
    //            {
    //                IssuedUtc = context.Ticket.Properties.IssuedUtc,
    //                ExpiresUtc = DateTime.UtcNow.AddMinutes(60)
    //            };

    //            var refreshTokenTicket = new AuthenticationTicket(context.Ticket.Identity, refreshTokenProperties);

    //            _refreshTokens.TryAdd(guid, refreshTokenTicket);

    //            // consider storing only the hash of the handle  
    //            context.SetToken(guid);
    //        }

    //        public void Create(AuthenticationTokenCreateContext context)
    //        {
    //            throw new NotImplementedException();
    //        }

    //        public void Receive(AuthenticationTokenReceiveContext context)
    //        {
    //            throw new NotImplementedException();
    //        }

    //        public async Task ReceiveAsync(AuthenticationTokenReceiveContext context)
    //        {
    //            // context.DeserializeTicket(context.Token);
    //            AuthenticationTicket ticket;
    //            string header = context.OwinContext.Request.Headers["Authorization"];

    //            if (_refreshTokens.TryRemove(context.Token, out ticket))
    //            {
    //                context.SetTicket(ticket);
    //            }
    //        }
    //    }
    //}

    //public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    //{
    //    public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
    //    {
    //        context.Validated(); // 
    //    }

    //    public override Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
    //    {

    //        // Change authentication ticket for refresh token requests  
    //        var newIdentity = new ClaimsIdentity(context.Ticket.Identity);
    //        newIdentity.AddClaim(new Claim("newClaim", "newValue"));

    //        var newTicket = new AuthenticationTicket(newIdentity, context.Ticket.Properties);
    //        context.Validated(newTicket);

    //        return Task.FromResult<object>(null);

    //    }


    //    public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
    //    {

    //        var identity = new ClaimsIdentity(context.Options.AuthenticationType);
    //        Actor acc = new Actor();

    //        //Authenticate the user credentials
    //        if (true)
    //        {
    //            identity.AddClaim(new Claim(ClaimTypes.Role, "admin"));
    //            identity.AddClaim(new Claim("username", context.UserName));
    //            identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
    //            context.Validated(identity);
    //        }
    //        else
    //        {
    //            context.SetError("invalid_grant", "Provided username and password is incorrect");
    //            return;
    //        }
    //    }
    //}

    //public class RefreshTokenProvider : IAuthenticationTokenProvider
    //{
    //    private static ConcurrentDictionary<string, AuthenticationTicket> _refreshTokens = new ConcurrentDictionary<string, AuthenticationTicket>();

    //    public async Task CreateAsync(AuthenticationTokenCreateContext context)
    //    {

    //        var guid = Guid.NewGuid().ToString();

    //        // copy all properties and set the desired lifetime of refresh token  
    //        var refreshTokenProperties = new AuthenticationProperties(context.Ticket.Properties.Dictionary)
    //        {
    //            IssuedUtc = context.Ticket.Properties.IssuedUtc,
    //            ExpiresUtc = DateTime.UtcNow.AddMinutes(60)
    //        };

    //        var refreshTokenTicket = new AuthenticationTicket(context.Ticket.Identity, refreshTokenProperties);

    //        _refreshTokens.TryAdd(guid, refreshTokenTicket);

    //        // consider storing only the hash of the handle  
    //        context.SetToken(guid);
    //    }


    //    public void Create(AuthenticationTokenCreateContext context)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Receive(AuthenticationTokenReceiveContext context)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public async Task ReceiveAsync(AuthenticationTokenReceiveContext context)
    //    {
    //        // context.DeserializeTicket(context.Token);
    //        AuthenticationTicket ticket;
    //        string header = context.OwinContext.Request.Headers["Authorization"];

    //        if (_refreshTokens.TryRemove(context.Token, out ticket))
    //        {
    //            context.SetTicket(ticket);
    //        }
    //    }
    //}

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

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var userManager = context.OwinContext.GetUserManager<ApplicationUserManager>();

            Actor user = await userManager.FindAsync(context.UserName, context.Password);

            if (user == null)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return;
            }

            ClaimsIdentity oAuthIdentity = await user.GenerateUserIdentityAsync(userManager,
               OAuthDefaults.AuthenticationType);
            ClaimsIdentity cookiesIdentity = await user.GenerateUserIdentityAsync(userManager,
                CookieAuthenticationDefaults.AuthenticationType);

            AuthenticationProperties properties = CreateProperties(user.UserName);
            AuthenticationTicket ticket = new AuthenticationTicket(oAuthIdentity, properties);
            context.Validated(ticket);
            context.Request.Context.Authentication.SignIn(cookiesIdentity);
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            // Resource owner password credentials does not provide a client ID.
            if (context.ClientId == null)
            {
                context.Validated();
            }

            return Task.FromResult<object>(null);
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
            }

            return Task.FromResult<object>(null);
        }

        public static AuthenticationProperties CreateProperties(string userName)
        {
            IDictionary<string, string> data = new Dictionary<string, string>
            {
                { "userName", userName }
            };
            return new AuthenticationProperties(data);
        }
    }
}