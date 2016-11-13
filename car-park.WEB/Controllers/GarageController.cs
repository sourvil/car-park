using AutoMapper;
using car_park.Common;
using car_park.DTO;
using car_park.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace car_park.Controllers
{
    public class GarageController : BaseController
    {
        // GET: Garage
        public ActionResult Index()
        {
            var result = GetWebApiResult("api/garage", new List<GarageDTO>());
            if (result.Count > 0)
            {
                List<GarageVM> garageVM = mapper.Map<List<GarageVM>>(result);
                return View(garageVM);
            }                
            else
                return View();
        }

        public ActionResult Details(int? ID)
        {
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var result = GetWebApiResult("api/garage/" + ID, new GarageDTO());
            if (result != null)
            {
                GarageVM garageVM = mapper.Map<GarageVM>(result);
                return View(garageVM);

            }                
            else
                return View();

        }

        public ActionResult Edit(int? ID) {

            GarageVM garageVM = new GarageVM();

            if (ID.HasValue)
            {
                var result = GetWebApiResult("api/garage/" + ID, new GarageDTO());
                if (result != null)
                    garageVM = mapper.Map<GarageVM>(result);
            }
            return View(garageVM);
        }

        [HttpPost]
        public ActionResult Edit(GarageVM garageVM)
        {
            if (ModelState.IsValid)
            {
                HttpClient hc = GetHttpClient();

                HttpResponseMessage Response = null;

                GarageDTO garageDTO = mapper.Map<GarageDTO>(garageVM);

                if (garageDTO.ID <= 0)
                    Response = hc.PostAsJsonAsync<GarageDTO>("api/garage", garageDTO).Result;
                else
                    Response = hc.PutAsJsonAsync<GarageDTO>("api/garage", garageDTO).Result;

                if (Response.IsSuccessStatusCode)
                {
                    var Result = Response.Content.ReadAsAsync<ApiResult>().Result;
                    if (ValidateResult(Result))
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            return View(garageVM);
        }

        public ActionResult Delete(int? ID)
        {
            if (!ID.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var result = GetWebApiResult("api/garage/" + ID, new GarageDTO());


            if (result == null)
                return HttpNotFound();
            else
            {
                GarageVM garageVM = mapper.Map<GarageVM>(result);
                return View(garageVM);
            }
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult Delete(int ID)
        {
            HttpClient hc = GetHttpClient();

            var Result = hc.DeleteAsync("api/garage/" + ID).Result;

            if (Result.IsSuccessStatusCode)
            {
                var Response = Result.Content.ReadAsAsync<ApiResult>().Result;
                if (ValidateResult(Response))
                {
                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
        }
    }
}