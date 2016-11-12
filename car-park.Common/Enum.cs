using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace car_park.Common
{
    public static class Enumaration
    {
        public enum Status {
            Active = 1,
            Deleted = 2,
            Passive = 4
        }

        public enum Engine {
            Petrol = 0,
            Diesel = 1
        }
    }
}
