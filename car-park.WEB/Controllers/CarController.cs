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
    public class CarController : BaseController
    {
        // GET: Car
        public ActionResult Index()
        {
            var result = GetWebApiResult("api/car", new List<CarDTO>());
            if (result.Count > 0)
            {
                List<CarVM> carVM = mapper.Map<List<CarVM>>(result);
                return View(carVM);
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
            var result = GetWebApiResult("api/car/" + ID, new CarDTO());
            if (result != null)
            {
                CarVM carVM = mapper.Map<CarVM>(result);
                return View(carVM);
            }            
            else
                return View();

        }

        public ActionResult Edit(int? ID)
        {
            CarVM carVM = new CarVM();

            if (ID.HasValue)
            {
                var result = GetWebApiResult("api/car/" + ID, new CarDTO());
                if (result != null)
                {
                    carVM = mapper.Map<CarVM>(result);
                    carVM.ColorList = GetWebApiResult("api/color", new List<ColorDTO>());
                    carVM.BrandList = GetWebApiResult("api/brand", new List<BrandDTO>());
                    //carVM.ModelList = GetWebApiResult("api/model", new List<ModelDTO>());
                    carVM.ModelList = GetWebApiResult("api/model/getbybrandid/" + carVM.BrandList.FirstOrDefault().ID, new List<ModelDTO>());
                    carVM.GarageList = GetWebApiResult("api/garage", new List<GarageDTO>());
                    return View(carVM);
                }
            }

            carVM.ColorList = GetWebApiResult("api/color", new List<ColorDTO>());
            carVM.BrandList = GetWebApiResult("api/brand", new List<BrandDTO>());
            //carVM.ModelList = GetWebApiResult("api/model", new List<ModelDTO>());
            carVM.ModelList = GetWebApiResult("api/model/getbybrandid/" + carVM.BrandList.FirstOrDefault().ID, new List<ModelDTO>());
            carVM.GarageList = GetWebApiResult("api/garage", new List<GarageDTO>());
            return View(carVM);
        }

        [HttpPost]
        public ActionResult Edit(CarVM carVM)
        {
            if (ModelState.IsValid)
            {
                HttpClient hc = GetHttpClient();

                HttpResponseMessage Response = null;

                CarDTO carDTO = mapper.Map<CarDTO>(carVM);

                if (carDTO.ID <= 0)
                    Response = hc.PostAsJsonAsync<CarDTO>("api/car", carDTO).Result;
                else
                    Response = hc.PutAsJsonAsync<CarDTO>("api/car", carDTO).Result;

                if (Response.IsSuccessStatusCode)
                {
                    var Result = Response.Content.ReadAsAsync<ApiResult>().Result;
                    if (ValidateResult(Result))
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            carVM.ColorList = GetWebApiResult("api/color", new List<ColorDTO>());
            carVM.BrandList = GetWebApiResult("api/brand", new List<BrandDTO>());
            //carVM.ModelList = GetWebApiResult("api/model", new List<ModelDTO>());
            carVM.ModelList = GetWebApiResult("api/model/getbybrandid/" + carVM.BrandList.FirstOrDefault().ID, new List<ModelDTO>());
            carVM.GarageList = GetWebApiResult("api/garage", new List<GarageDTO>());
            return View(carVM);
        }
        public ActionResult Delete(int? ID)
        {
            if (!ID.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var result = GetWebApiResult("api/car/" + ID, new CarDTO());

            if (result == null)
                return HttpNotFound();
            else
            {
                CarVM carVM = mapper.Map<CarVM>(result);
                return View(carVM);
            }
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult Delete(int ID)
        {
            HttpClient hc = GetHttpClient();

            var Result = hc.DeleteAsync("api/car/" + ID).Result;

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

        public ActionResult Models(int id)
        {
            var result = GetWebApiResult("api/model/getbybrandid/" + id, new List<ModelDTO>());

            return Json(
                result.Select(x => new { value = x.ID, text = x.Name }),
                JsonRequestBehavior.AllowGet
            );
        }
    }
}