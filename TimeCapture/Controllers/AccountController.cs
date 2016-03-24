using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TimeCapture.Models;
using TimeCapture.Service;

namespace TimeCapture.Controllers
{
    public class AccountController : Controller
    {

        private static AderantEntities5 _db;

        public AccountController()
        {
            _db = new AderantEntities5();
        }

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            ViewBag.SuggestBrowser = false;
            try
            {
                if (ModelState.IsValid)
                {
                    if (ValidateUser(model.UserName, model.Password))
                    {
                        var user = FindUserFromEmailAddress(model.UserName);
                        FormsAuthentication.SetAuthCookie(user.Username.ToLower(), true);
                        if ((Url == null || Url.IsLocalUrl(returnUrl))
                            && returnUrl.Length > 1
                            && returnUrl.StartsWith("/")
                            && !returnUrl.StartsWith("//")
                            && !returnUrl.StartsWith("/\\"))
                        {
                            // initialises session
                            ResetCurrentUserSession(user.Username);
                            return Redirect(returnUrl);
                        }
                        else
                        {
                            // initialises session
                            ResetCurrentUserSession(user.Username);
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "The Email or Password provided is incorrect.");
                    }
                }

                // If we got this far, something failed, redisplay form
                return View(model);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "You account has been removed from Ceritifi");
                return View(model);
            }

        }

        private bool ValidateUser(string emailAddress, string password)
        {
                var user = _db.Users.Where(x => x.Username == emailAddress).FirstOrDefault();
                if (user == null)
                {
                    return false;
                }

                //if (!user.CanLogin)
                //{
                //    throw new Exception("Account has been disabled, please contact support.");
                //}

                // PASSWORDHASH:
                // Compared User's hashed password with incoming password hased by the hashkey which used to hash the password for user at the first place.
                if (user.PasswordHash != null && user.Password == Core.SecurityUtil.CreatePasswordHash(password, user.PasswordHash))
                {
                    //if (user.RetryAttempt < 9 && user.CanLogin)
                    //{
                    //    user.RetryAttempt = 0;
                    //}

                    //user.LastLogedOn = DateTime.Now;
                    return true;
                }
                else if (user.Password.Equals(Core.SecurityUtil.CreatePasswordHash(password, user.PasswordHash))) // TO be removed 
                {
                    //if (user.RetryAttempt < 9 && user.CanLogin)
                    //{
                    //    user.RetryAttempt = 0;
                    //}

                    //user.LastLogedOn = DateTime.Now;

                    return true;
                }
                else
                {
                    //// increment retry attempts
                    //if (user.RetryAttempt < 9 || !user.RetryAttempt.HasValue)
                    //{
                    //    user.RetryAttempt = user.RetryAttempt.GetValueOrDefault() + 1;
                    //}
                    //else
                    //{
                    //    user.CanLogin = false;
                    //}
                    return true;
                }
        }

        private User FindUserFromEmailAddress(string emailAddress)
        {
            return _db.Users.Where(x => x.Username == emailAddress && x.IsActive).FirstOrDefault();
        }

        public static void ResetCurrentUserSession(string userName = null)
        {
            //var unitOfWork = new UnitOfWork();
            if (string.IsNullOrEmpty(userName))
            {
                userName = System.Web.HttpContext.Current.User.Identity.Name;
            }

            if (string.IsNullOrEmpty(userName))
            {
                return;
            }

            var currentLoggedInuser = _db.Users.Where(x => x.Username == userName && x.IsActive).FirstOrDefault();
            //var currentLoggedInuser = unitOfWork.UserRepository.Get(x => x.Username == userName && x.IsActive).FirstOrDefault();

            // When modified for forgot password
            if (currentLoggedInuser == null)
            {
                // When session is being expired and trying to reset, this will log out the user.
                // Most likely the user has been deleted.
                System.Web.HttpContext.Current.Session.Abandon();
                FormsAuthentication.SignOut();
                System.Web.HttpContext.Current.Response.Redirect("/");
            }
            //else if (!currentLoggedInuser.CanLogin)
            //{
            //    throw new Exception("Account has been disabled. Please contact support.");
            //}
            else
            {
                // Initialise the session vars.
                SiteUtil.CurrentUser = currentLoggedInuser;
                // Set user's owning org
                //var orgUser = unitOfWork.OrgUseRepository.Get(x => x.UserId == currentLoggedInuser.Id).FirstOrDefault();
                //if (orgUser != null)
                //{
                //    SiteUtil.CurrentOrg = orgUser.Org;
                //}
                //else
                //{
                //    throw new Exception(string.Format("Site user {0} does not have owning org. [Org_User]", userName));
                //}

            }

        }
    }
}