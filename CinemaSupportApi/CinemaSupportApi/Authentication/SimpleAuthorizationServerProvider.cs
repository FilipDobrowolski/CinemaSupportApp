using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;

namespace CinemaSupportApi.Authentication
{
    //public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    //{
    //    public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
    //    {
    //        context.Validated();
    //    }
    //    public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
    //    {
    //        SetContextHeaders(context);
    //        string userId = context.UserName;
    //        string password = context.Password;

    //        EmployeeAccessBLL chkEmpAccessBLL = new EmployeeAccessBLL();
    //        EmployeeAccessViewModel vmEmployeeAccess = chkEmpAccessBLL.CheckEmployeeAccess(Convert.ToInt32(userId), password);

    //        if (vmEmployeeAccess != null)
    //        {
    //            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
    //            identity.AddClaim(new Claim(, vmEmployeeAccess.EmpName));
    //            context.Validated(identity);
    //        }
    //        else
    //        {
    //            context.SetError("invalid_grant", "Provided username and password is incorrect");
    //            return;
    //        }
    //    }

    //    private void SetContextHeaders(OAuthGrantResourceOwnerCredentialsContext context)
    //    {
    //        context.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
    //        context.Response.Headers.Add("Access-Control-Allow-Methods", new[] { "GET, PUT, DELETE, POST, OPTIONS" });
    //        context.Response.Headers.Add("Access-Control-Allow-Headers", new[] { "Content-Type, Accept, Authorization" });
    //        context.Response.Headers.Add("Access-Control-Max-Age", new[] { "1728000" });
    //    }
    //}

}