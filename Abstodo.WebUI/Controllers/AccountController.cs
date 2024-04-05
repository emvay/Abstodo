using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Abstodo.Business.Abstract;
using AutoMapper;
using Abstodo.WebUI.Models;

namespace Abstodo.WebUI.Controllers
{
    public class AccountController : Controller
    {
        #region dependency injection
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public AccountController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        #endregion

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string userName, string password)
        {
            if (!string.IsNullOrEmpty(userName) && string.IsNullOrEmpty(password))
            {
                return RedirectToAction("Login");
            }

            //Check the user name and password
            //Here can be implemented checking logic from the database
            ClaimsIdentity identity = null;
            bool isAuthenticated = false;
            UserModel user = _mapper.Map<UserModel>(await _userService.GetMatchingUserAsync(userName, password));
            if (user != null)
            {
                identity = new ClaimsIdentity(new[] 
                {
                    new Claim("ID", user.ID.ToString()),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Email, user.Email),
                    //new Claim(ClaimTypes.Role, "Admin")
                }, CookieAuthenticationDefaults.AuthenticationScheme);

                // Get ID from the claims
                //var IDClaim= identity.Claims.FirstOrDefault(t => t.Type == "ID");

                ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                
                Task login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);


                isAuthenticated = true;
            }

            #region Login testing
            //if (userName == "Admin" && password == "password")
            //{

            //    //Create the identity for the user
            //    identity = new ClaimsIdentity(new[] {
            //        new Claim(ClaimTypes.Name, userName),
            //        new Claim(ClaimTypes.Role, "Admin")
            //    }, CookieAuthenticationDefaults.AuthenticationScheme);

            //    isAuthenticated = true;
            //}

            //if (userName == "Mukesh" && password == "password")
            //{
            //    //Create the identity for the user
            //    identity = new ClaimsIdentity(new[] {
            //        new Claim(ClaimTypes.Name, userName),
            //        new Claim(ClaimTypes.Role, "User")
            //    }, CookieAuthenticationDefaults.AuthenticationScheme);

            //    isAuthenticated = true;
            //}
            #endregion

            if (isAuthenticated)
            {
                var principal = new ClaimsPrincipal(identity);

                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return RedirectToAction("Index", "Task");
            }
            return View();
        }


        public IActionResult Logout()
        {
            var login = HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}
