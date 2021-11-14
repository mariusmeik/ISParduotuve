using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel;

namespace ProjectParduotuve.Models
{
    public class ProductSpec
    {
        [DisplayName("Name")]
        public int name { get; set; }
        [DisplayName("Weight")]
        public double weight { get; set; }
        [DisplayName("Price")]
        public double price { get; set; }
        [DisplayName("Discount ")]
        public double discount { get; set; }
        [DisplayName("Count")]
        public double count { get; set; }
    }
}