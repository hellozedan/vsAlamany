using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace almany.Controllers
{
    public class ContactUsController : Controller
    {
        private Entities db = new Entities();

        // GET: ContactUs
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index([Bind(Include = "id,email,name,phone,messag,statuss")] ContactU contactU)
        {
            if (ModelState.IsValid)
            {
                contactU.statuss = false;
                contactU.created_date = DateTime.Now;
                db.ContactUs.Add(contactU);
                db.SaveChanges();
               return RedirectToAction("Index","Home");
            }
            return View(contactU);
        }

    }
}