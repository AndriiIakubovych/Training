using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Security.Claims;
using Microsoft.Owin.Security;
using ProductsListControl.Models;

namespace ProductsListControl.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            ProductsListUser user;
            IdentityResult result;
            if (UserManager.FindByName(model.UserName) != null)
                ModelState.AddModelError("", "Пользователь с таким именем уже существует!");
            else
            {
                if (ModelState.IsValid)
                {
                    if (UserManager.FindByEmail(model.Email) == null)
                    {
                        user = new ProductsListUser { UserName = model.UserName, Email = model.Email };
                        result = await UserManager.CreateAsync(user, model.Password);
                        if (result.Succeeded)
                        {
                            UserManager.AddToRole(user.Id, "User");
                            return RedirectToAction("Index", "Home");
                        }
                        else
                            foreach (string error in result.Errors)
                                ModelState.AddModelError("", error);
                    }
                    else
                        ModelState.AddModelError("", "Пользователь с таким почтовым адресом уже существует!");
                }
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            string adminId;
            if (RoleManager.FindByName("Admin") == null)
                RoleManager.Create(new ProductsListRole { Name = "Admin" });
            if (RoleManager.FindByName("User") == null)
                RoleManager.Create(new ProductsListRole { Name = "User" });
            if (UserManager.FindByName("Admin") == null)
            {
                UserManager.Create(new ProductsListUser { UserName = "Admin", Email = "andrii.iakubovych@gmail.com" }, "Ghbcwbkkf5981");
                adminId = UserManager.FindByName("Admin").Id;
                UserManager.AddToRole(adminId, "Admin");
            }
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel model, string returnUrl)
        {
            ProductsListUser user;
            ClaimsIdentity claim;
            if (ModelState.IsValid)
            {
                user = await UserManager.FindAsync(model.UserName, model.Password);
                if (user == null)
                    ModelState.AddModelError("", "Неверный логин или пароль!");
                else
                {
                    claim = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties { IsPersistent = true }, claim);
                    if (string.IsNullOrEmpty(returnUrl))
                        return RedirectToAction("Index", "Home");
                    return Redirect(returnUrl);
                }
            }
            ViewBag.returnUrl = returnUrl;
            return View(model);
        }

        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Login");
        }

        private ProductsListUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ProductsListUserManager>();
            }
        }

        private ProductsListRoleManager RoleManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ProductsListRoleManager>();
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