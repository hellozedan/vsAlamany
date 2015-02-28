using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace almany.Controllers
{
    public class ArticleCarouselController : Controller
    {
        private Entities db = new Entities();

        // GET: ArticleCarousel
        public ActionResult Index()
        {
            return PartialView("ArticleCarousel", db.CursoleArticles.Where(s => s.statuss != null && s.statuss ==true));
        }
    }
}