using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectParduotuve.Models
{
    public class BusenaEnum
    {
        public int id { get; set; }
        public string busena { get; set; }

        public BusenaEnum(int id)
        {
            this.id = id;

        }
    }
}