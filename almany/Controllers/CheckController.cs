using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace almany.Controllers
{
    public class CheckController : Controller
    {
        private Entities db = new Entities();

        // GET: Check
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public bool[] GetAvailableTimesInDates(string date)
        {
            DateTime selectedDate= Convert.ToDateTime(date);
            bool[] Available = new bool[12];
            var temp = db.Checks.Where(s => s.datee != null && s.datee == selectedDate).Select(s => s.timee).ToList();
            for(int i=0;i<12;i++)
            {
                if (temp.Contains(i))
                { Available[i] = true; }
                else { Available[i] = false;  }
            }
            return Available;
        }
    }
}