using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using almany;
using almany.Models;

namespace almany.Controllers
{
    public class AfterBeforeImagesController : Controller
    {
        private Entities db = new Entities();
        // GET: AfterBeforeImages
        public ActionResult Index()
        {
           
            return PartialView("AfterBeforeCarousel", db.AfterBeforeImages.Where(s => s.statuss != null && s.statuss == true).ToList());
        }

        

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
