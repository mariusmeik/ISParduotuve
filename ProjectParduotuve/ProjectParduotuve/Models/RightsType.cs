﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectParduotuve.Models
{
    public class RightsType
    {
        public int id { get; set; }
        public string name { get; set; }

        public RightsType(int id) {
            this.id = id;

        }
    }
}