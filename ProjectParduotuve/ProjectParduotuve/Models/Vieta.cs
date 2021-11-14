using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace ProjectParduotuve.Models
{
    public class Vieta
    {
        public Vieta() { }

        [DisplayName("Id")]
        public int id { get; set; }
        [DisplayName("pavadinimas")]
        public string pavadinimas { get; set; }
        [DisplayName("adresas")]
        public string adresas { get; set; }
        [DisplayName("paskirtis")]
        public string paskirtis { get; set; }

    }
}