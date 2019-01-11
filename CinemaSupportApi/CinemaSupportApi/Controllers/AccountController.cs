using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using CinemaSupport.Data.Interfaces.Repositories;
using CinemaSupport.Data.Repositories;
using CinemaSupport.Domain.Models;
using CinemaSupport.Domain.RegisteringModels;
using CinemaSupportApi.Authentication;
using CinemaSupportApi.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin;

namespace CinemaSupportApi.Controllers
{
    [Authorize]
    [RoutePrefix("accounts")]
    public class AccountController : ApiController
    {
        private IActorRepository _actorRepository;
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public AccountController(IActorRepository actorRepository)
        {
            _actorRepository = actorRepository;
        }
    

        // POST api/Account/Register
        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public async Task<IHttpActionResult> Register(UserRegisterModel userModel)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            ////var t = HttpContext.Current.Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            ////var g = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            ////var f = HttpContext.Current.GetOwinContext().GetUserManager<UserManager<IdentityUser>>();
            ////var z = HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>();
            ////var m = HttpContext.Current.Request;
            ////var x = HttpContext.Current.GetOwinContext().Request;
            ////var n = HttpContext.Current.Request.GetOwinContext().Get<UserManager<Actor>>();
            ////var d = HttpContext.Current.Request.GetOwinContext().Get<ApplicationUserManager>();
            ////var b = Request.GetOwinContext().Get<ApplicationUserManager>();
            ////var c = Request.GetOwinContext().GetUserManager<UserManager<Actor>>();
            //IdentityResult result = await _actorRepository.RegisterUser(userModel, _userManager );

            //IHttpActionResult errorResult = GetErrorResult(result);

            //if (errorResult != null)
            //{
            //    return errorResult;
            //}
            if (ModelState.IsValid)
            {
                var user = new Actor() { UserName = userModel.UserName };
                var result = await UserManager.CreateAsync(user, userModel.Password);
                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                    // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

                    return Redirect("https://www.codeproject.com/Articles/429166/Basics-of-Single-Sign-on-SSO");
                }
                AddErrors(result);
            }

            return Ok();
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                var t = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
                return _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///
        // The Authorize Action is the end point which gets called when you access any
        // protected Web API. If the user is not logged in then they will be redirected to 
        // the Login page. After a successful login you can call a Web API.
        [HttpGet]
        public IHttpActionResult Authorize()
        {
            var claims = new ClaimsPrincipal(User).Claims.ToArray();
            var identity = new ClaimsIdentity(claims, "Bearer");
            AuthenticationManager.SignIn(identity);
            return Ok();
        }

        // GET: /Account/Login
        [AllowAnonymous]
        public IHttpActionResult Login(string returnUrl)
        {
            return Ok();
        }

        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        //[ValidateAntiForgeryToken]
        public async Task<IHttpActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(model.User, model.Password, model.RememberMe, shouldLockout: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return Redirect("/");
                case SignInStatus.LockedOut:
                    return BadRequest();
                case SignInStatus.RequiresVerification:
                    return BadRequest();
                case SignInStatus.Failure:
                default:
                    return BadRequest("Invalid login attempt.");
                    
            }
        }

        //
        // POST: /Account/LogOff
        [HttpPost]
        [Route("logout")]
        public IHttpActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return Redirect("/");
        }

        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.Current.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private IHttpActionResult RedirectToLocal(string returnUrl)
        {
            //if (Url.IsLocalUrl(returnUrl))
            //{
            //    return Redirect(returnUrl);
            //}
            //return RedirectToAction("Index", "Home");
            return Redirect("/");
        }

        #endregion
    }
}
