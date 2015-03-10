using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

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

        [HttpPost]
        public ActionResult Index(string name, string phone, string selDate, int selTime)
        {
            DateTime selectedDate = Convert.ToDateTime(selDate);
            Check check = new Check();
            check.datee = selectedDate;
            check.name = name;
            check.phone = phone;
            check.timee = selTime;
            if (db.Checks.Where(s=>s.datee==check.datee&&s.timee==check.timee).FirstOrDefault()==null)
            {
                db.Checks.Add(check);
                db.SaveChanges();

                return PartialView("Sucess",name);

            }
            return RedirectToAction("Index","Check");
        }

        [HttpGet]
        public string GetAvailableTimesInDates(string date)
        {
            var serializer = new JavaScriptSerializer();
            DateTime selectedDate= Convert.ToDateTime(date);
            bool[] Available = new bool[12];
            var temp = db.Checks.Where(s => s.datee != null && s.datee == selectedDate).Select(s => s.timee).ToList();
            for(int i=0;i<12;i++)
            {
                if (temp.Contains(i))
                { Available[i] = true; }
                else { Available[i] = false;  }
            }
            return serializer.Serialize(Available);
             ;
        }
    }
}