using AutoMapper;
using car_park.Common;
using car_park.WEB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace car_park.Controllers
{
    public class BaseController : Controller
    {
        public IMapper mapper { get; set; }
        public BaseController()
        {
            if (mapper == null)
            {
                // AutoMapper
                var config = new MapperConfiguration(cfg => cfg.AddProfile(new AutoMapperConfig()));
                mapper = config.CreateMapper();
            }
        }
        protected T GetWebApiResult<T>(string apiPath, T t)
        {
            HttpClient hc = GetHttpClient();

            var Result = hc.GetAsync(apiPath).Result;

            if (Result.IsSuccessStatusCode)
            {
                return Result.Content.ReadAsAsync<ApiResult<T>>().Result.Data;
            }
            return t;
        }

        protected HttpClient GetHttpClient()
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri(Common.ConfigValue.apiUrl);
            return hc;
        }

        public bool ValidateResult(IApiResult result)
        {
            if (result.Message != null)
            {
                TempData["Message"] = result.Message;
                TempData["MessageType"] = "alert-info";
            }

            if (result.StatusCode != (int)HttpStatusCode.OK)
            {
                TempData["MessageType"] = "alert-danger";
                return false;
            }
            return true;
        }
    }
}