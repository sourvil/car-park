using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace car_park.Controllers
{
    public class CarController : BaseController
    {
        // GET: Car
        public ActionResult Index()
        {
            return View();
        }
    }
}