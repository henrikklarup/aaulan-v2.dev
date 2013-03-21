using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AAULAN.Models;

namespace AAULAN.Controllers
{
    public class LoginController : Controller
    {
        #region Properties
        //Repository for making database requests
        readonly DatabaseReposity _repo = new DatabaseReposity();
        #endregion

        #region Login
        #region GET
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        #endregion

        #region POST

        /// <summary>
        /// POST: /Login/Login
        /// Login the user to the system
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Login(User user)
        {
            if (user.Username == null || user.Password == null)
            {
                ModelState.AddModelError("Validation", "Login information not valid");
                return View();
            }
            //Encrypt password to MD5
#pragma warning disable 612,618
            string epas = FormsAuthentication.HashPasswordForStoringInConfigFile(user.Password, "MD5");
#pragma warning restore 612,618

            //Check if user is valid in the system
            if (_repo.ValidateUser(user.Username, epas))
            {
                //Assign user role, from system
                string role = _repo.GetUserRoleFromUsername(user.Username).Trim();


                //Assign Form Authentication
                
                #region FormAuthentication
                FormsAuthentication.Initialize();
                var fat = new FormsAuthenticationTicket(1,
                    user.Username,
                    DateTime.Now,
                    DateTime.Now.AddMinutes(30),
                    false,
                    role,
                    FormsAuthentication.FormsCookiePath);
                Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName,
                    FormsAuthentication.Encrypt(fat)));
                #endregion
                
            }


            if (ModelState.IsValid)
            {
                return Redirect(Request["ReturnUrl"] ?? "../Home/Index");
                //return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("Validation","Login information not valid");


            //Never Used   //
            //Return /Home/Index
            return View();
            //-------------//
        }
        #endregion
        #endregion

        #region Restricted
        #region GET
        [HttpGet]
        public ActionResult Restricted()
        {
            return View("../Shared/Restricted");
        }

        #endregion
        #endregion

        #region Logout
        #region POST
        /// <summary>
        /// Logout from the system
        /// </summary>
        /// <returns>Return to Index Page</returns>
        [HttpPost]
        public ActionResult Logout()
        {
            //Abandon Session
            Session.Abandon();
            //Signout form forms authentication
            FormsAuthentication.SignOut();
            //Redirect to ./Home/Index
            return RedirectToAction("Index", "Home");
        }
        #endregion
        #endregion

        #region Edit User
        #region GET
        [HttpGet]
        [Authorize(Roles = "Administrator, Crew, User")]
        public ActionResult Edit()
        {
            var viewModel = _repo.GetUserFromUsername(ControllerContext.HttpContext.User.Identity.Name.Trim());
            viewModel.Password = "";
            return View(viewModel);
        }
        #endregion
        #region POST
        [HttpPost]
        [Authorize(Roles = "Administrator, Crew, User")]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid || user.Password == "")
            {
#pragma warning disable 612,618
                user.Password = FormsAuthentication.HashPasswordForStoringInConfigFile(user.Password, "MD5");
#pragma warning restore 612,618
                _repo.UpdateUser(user);
                RedirectToAction("Edit");
            }

            var viewModel = user;
            return View(viewModel);
        }
        #endregion
        #endregion

        #region Create User
        #region GET
        /// <summary>
        /// GET: /Login/Create
        /// </summary>
        /// <returns>Returns /Login/Create</returns>
        [HttpGet]
        public ActionResult Create()
        {
            var viewModel = new User();

            return View(viewModel);
        }
        #endregion

        #region POST

        /// <summary>
        /// POST: /Login/Create
        /// Encrypts the password with MD5 and Adds the user to the database
        /// </summary>
        /// <returns>Returns /Home/Index</returns>
        [HttpPost]
        public ActionResult Create(User viewModel)
        {
            if (ModelState.IsValid)
            {
                //Encrypt Password With MD5
#pragma warning disable 612,618
                viewModel.Password = FormsAuthentication.HashPasswordForStoringInConfigFile(viewModel.Password, "MD5");
#pragma warning restore 612,618

                //Set to lower role
                viewModel.Role = "User";

                //Add User to database
                _repo.AddUser(viewModel);


                //Return to /Home/Index
                return RedirectToAction("Index", "Home");
            }
            return View("../Login/Create", viewModel);
        }
        #endregion
        #endregion
    }
}
