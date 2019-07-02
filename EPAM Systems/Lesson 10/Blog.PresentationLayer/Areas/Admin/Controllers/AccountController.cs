using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Security.Claims;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.Owin;
using Blog.BusinessLogicLayer.DataTransferObjects;
using Blog.BusinessLogicLayer.Interfaces;
using Blog.PresentationLayer.Areas.Admin.Models;

namespace Blog.PresentationLayer.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel model)
        {
            UserDataTransferObject userDto;
            ClaimsIdentity claim;
            await SetInitialDataAsync();
            if (ModelState.IsValid)
            {
                userDto = new UserDataTransferObject { UserName = model.UserName, Password = model.Password };
                claim = await UserService.Authenticate(userDto);
                if (claim == null)
                    ModelState.AddModelError("", "Incorrect login or password!");
                else
                {
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties { IsPersistent = true }, claim);
                    return RedirectToAction("Index", "Blog");
                }
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Login", "Account");
        }

        private async Task SetInitialDataAsync()
        {
            await UserService.SetInitialData(new UserDataTransferObject { UserName = "Admin", Email = "andrii.iakubovych@gmail.com", Password = "Ghbcwbkkf5981", Role = "Admin" }, new List<string> { "Admin" });
        }

        private IUserService UserService
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<IUserService>();
            }
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
    }
}