using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace almany.Controllers
{
    public class CrashPriceController : Controller
    {
        private Entities db = new Entities();
        // GET: CrashPrice
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase url_image_1,HttpPostedFileBase url_image_2,HttpPostedFileBase url_image_3,  [Bind(Include = "id,email,name,phone,messag,statuss,url_image_1,url_image_2,url_image_3")] CrashPrice crashPrice)
        {
             if (ModelState.IsValid)
            {
                if (url_image_1 != null && url_image_1.ContentLength > 0)
                {
                    var url_image_1_fileName = Path.GetFileName(url_image_1.FileName);
                    bool exists = Directory.Exists(Server.MapPath("~/Images/CrashPrice"));
                    if (!exists)
                        Directory.CreateDirectory(Server.MapPath("~/Images/CrashPrice"));
                    var url_image_1_path = Path.Combine(Server.MapPath("~/Images/CrashPrice"), url_image_1_fileName);
                    almany.Models.
                    url_image_1.SaveAs(url_image_1_path);
                    crashPrice.url_image_1 = "/Images/CrashPrice/" + url_image_1_fileName;
                }

                if (url_image_2 != null && url_image_2.ContentLength > 0)
                {
                    var url_image_2_fileName = Path.GetFileName(url_image_2.FileName);
                    bool exists = Directory.Exists(Server.MapPath("~/Images/CrashPrice"));
                    if (!exists)
                        Directory.CreateDirectory(Server.MapPath("~/Images/CrashPrice"));
                    var url_image_2_path = Path.Combine(Server.MapPath("~/Images/CrashPrice"), url_image_2_fileName);
                    url_image_2.SaveAs(url_image_2_path);
                    crashPrice.url_image_2 = "/Images/CrashPrice/" + url_image_2_fileName;
                }

                if (url_image_3 != null && url_image_3.ContentLength > 0)
                {
                    var url_image_3_fileName = Path.GetFileName(url_image_3.FileName);
                    bool exists = Directory.Exists(Server.MapPath("~/Images/CrashPrice"));
                    if (!exists)
                        Directory.CreateDirectory(Server.MapPath("~/Images/CrashPrice"));
                    var url_image_3_path = Path.Combine(Server.MapPath("~/Images/CrashPrice"), url_image_3_fileName);
                   
                    url_image_3.SaveAs(url_image_3_path);
                    crashPrice.url_image_3 = "/Images/CrashPrice/" + url_image_3_fileName;
                }

                crashPrice.statuss = false;
                crashPrice.created_date = DateTime.Now;
                if (crashPrice.messag == null)
                    crashPrice.messag = "";
                db.CrashPrices.Add(crashPrice);
                db.SaveChanges();
               return RedirectToAction("Index","Home");
            }
            return View(crashPrice);
        }
        
    }
}