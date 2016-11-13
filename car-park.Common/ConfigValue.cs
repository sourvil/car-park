using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace car_park.Common
{
    public static class ConfigValue
    {
        private static string _apiUrl = ReadConfigValue("ApiUrl");

        public static string apiUrl { get { return _apiUrl; } }

        private static string ReadConfigValue(string key)
        {
            try
            {
                return System.Configuration.ConfigurationSettings.AppSettings[key].ToString();
            }
            catch (Exception)
            {
                return "";
            }
        }
    }
}
