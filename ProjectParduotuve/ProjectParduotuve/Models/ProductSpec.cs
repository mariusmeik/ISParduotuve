using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel;

namespace ProjectParduotuve.Models
{
    public class ProductSpec
    {
        [DisplayName("Id")]
        public int id { get; set; }
        [DisplayName("Vardas")]
        public string name { get; set; }
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