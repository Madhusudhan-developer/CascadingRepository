using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CascadingDropdownExample.Controllers
{
    public class MyController : Controller
    {
        MyDatabaseEntities databaseEntities = new MyDatabaseEntities();
        [HttpGet]
        public ActionResult Index()
        {
            List<State> states= databaseEntities.States.ToList();
            ViewBag.StateList = new SelectList(states, "Sid", "Sname");
            return View();
        }
        public JsonResult GetCities(int? Sid)
        {
            List<City> cities= databaseEntities.Cities.Where(city => city.Sid == Sid).ToList();
            return Json(new SelectList(cities,"Cid","Cname"));
        }

        public JsonResult GetLocations(int? Cid)
        {
           List<Location> locations= databaseEntities.Locations.Where(location => location.Cid == Cid).ToList();
            return Json(new SelectList(locations, "Lid", "Lname"));
        }

       
    }
}