using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace ProjectParduotuve.Models
{
    public class ProognozuojamaPreke
    {
        public ProognozuojamaPreke() { }
        [DisplayName("Id")]
        public int id { get; set; }

        [DisplayName("ReikalingasKiekis")]
        public double reikalingasKiekis { get; set; }
        [DisplayName("pirkimoProognoze")]
        public double pirkimoProognoze { get; set; }

    }
}