using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Microsoft.Owin.Security;
using ProductsListControl.Models;

namespace ProductsListControl.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private ProductsListContext context = new ProductsListContext();

        public ActionResult Index()
        {
            ViewBag.UserName = AuthenticationManager.User.Identity.Name;
            ViewBag.IsAdmin = User.IsInRole("Admin");
            return View(context.Products);
        }

        [HttpGet]
        public ActionResult AddProduct()
        {
            ViewBag.Settings = context.Settings.FirstOrDefault();
            return PartialView();
        }

        [HttpPost]
        public JsonResult AddProduct(Product product, HttpPostedFileBase file)
        {
            bool isFileExists = true;
            string fileName;
            if (file != null)
            {
                fileName = Path.GetFileNameWithoutExtension(file.FileName);
                while (isFileExists)
                {
                    isFileExists = System.IO.File.Exists(Server.MapPath("~/Content/images/" + fileName + Path.GetExtension(file.FileName)));
                    if (!isFileExists)
                        break;
                    fileName += "-1";
                }
                file.SaveAs(Server.MapPath("~/Content/images/" + fileName + Path.GetExtension(file.FileName)));
                product.Photo = fileName + Path.GetExtension(file.FileName);
            }
            product.ProductId = context.Products.Count() > 0 ? context.Products.Select(p => p.ProductId).Max() + 1 : 1;
            context.Products.Add(product);
            context.SaveChanges();
            return Json(product, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult EditProduct(int? productId)
        {
            Product product;
            if (productId == null)
                return HttpNotFound();
            product = context.Products.Find(productId);
            ViewBag.Settings = context.Settings.FirstOrDefault();
            return PartialView(product);
        }

        [HttpPost]
        public JsonResult EditProduct(Product product, HttpPostedFileBase file)
        {
            string productPhoto = product.Photo;
            if (file != null)
            {
                file.SaveAs(Server.MapPath("~/Content/images/" + file.FileName));
                product.Photo = file.FileName;
            }
            context.Entry(product).State = EntityState.Modified;
            context.SaveChanges();
            try
            {
                if (product.Photo != null && !context.Products.Where(p => p.Photo == productPhoto).Any())
                    System.IO.File.Delete(Server.MapPath("~/Content/images/" + productPhoto));
            }
            catch (Exception) { }
            return Json(product, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult DeleteProduct(int? productId)
        {
            Product product;
            if (productId == null)
                return HttpNotFound();
            product = context.Products.Find(productId);
            return PartialView(product);
        }

        [HttpPost]
        public JsonResult DeleteProduct(Product product)
        {
            context.Entry(product).State = EntityState.Deleted;
            context.SaveChanges();
            try
            {
                if (product.Photo != null && !context.Products.Where(p => p.Photo == product.Photo).Any())
                    System.IO.File.Delete(Server.MapPath("~/Content/images/" + product.Photo));
            }
            catch (Exception) { }
            return Json(product, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSettings()
        {
            Setting setting = new Setting();
            if (context.Settings.Count() == 0)
            {
                setting.SettingId = 1;
                setting.HasDescription = true;
                setting.HasWarranty = false;
                setting.HasDiscount = false;
                setting.HasWarehouseAvailability = true;
                setting.HasPhoto = true;
                context.Settings.Add(setting);
                context.SaveChanges();
            }
            return Json(context.Settings.First(), JsonRequestBehavior.AllowGet);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult ControlPanel()
        {
            Setting setting = new Setting();
            if (context.Settings.Count() == 0)
            {
                setting.SettingId = 1;
                setting.HasDescription = true;
                setting.HasWarranty = false;
                setting.HasDiscount = false;
                setting.HasWarehouseAvailability = true;
                setting.HasPhoto = true;
                context.Settings.Add(setting);
                context.SaveChanges();
            }
            ViewBag.UserName = AuthenticationManager.User.Identity.Name;
            ViewBag.IsAdmin = User.IsInRole("Admin");
            return View(context.Settings.First());
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public JsonResult ControlPanel(Setting setting)
        {
            context.Entry(setting).State = EntityState.Modified;
            context.SaveChanges();
            return Json(setting, JsonRequestBehavior.AllowGet);
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