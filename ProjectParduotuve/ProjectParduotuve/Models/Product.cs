using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel;

namespace ProjectParduotuve.Models
{
    public class Product
    {
        public Product() { }
        [DisplayName("pagaminimoData")]
        public DateTime pagaminimoData { get; set; }
        [DisplayName("pardavimoData")]
        public DateTime pardavimoData { get; set; }
        [DisplayName("galiojimoData")]
        public DateTime galiojimoData { get; set; }
        [DisplayName("kiekis")]
        public double kiekis { get; set; }
        [DisplayName("busena")]
        public string busena { get; set; }

    }
}