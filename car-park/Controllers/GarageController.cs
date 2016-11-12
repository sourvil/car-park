using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace car_park.Controllers
{
    public class GarageController : Controller
    {
        // GET: Garage
        public ActionResult Index()
        {
            return View();
        }
    }
}