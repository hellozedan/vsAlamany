using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace almany.Controllers
{
    public class GalleryController : Controller
    {
        private Entities db = new Entities();

        // GET: Gallery
        public ActionResult Index()
        {
            return View(db.GalleryImages.Where(s=>s.statuss!=null&&s.statuss==true).ToList());
        }
    }
}