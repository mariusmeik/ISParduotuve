using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace ProjectParduotuve.Models
{
    public class UzsakomosPrekes
    {
        public UzsakomosPrekes() { }

        [DisplayName("Id")]
        public int id { get; set; }
        [DisplayName("kiekis")]
        public double kiekis { get; set; }
        [DisplayName("Patvirtintas")]
        public bool Patvirtintas { get; set; }
        [DisplayName("pakeistas")]
        public bool pakeistas { get; set; }
        [DisplayName("kaina")]
        public double kaina { get; set; }
        [DisplayName("Nuolaida")]
        public double Nuolaida { get; set; }

    }
}