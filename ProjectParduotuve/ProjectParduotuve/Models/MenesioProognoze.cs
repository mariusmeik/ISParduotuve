using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace ProjectParduotuve.Models
{
    public class MenesioProognoze
    {
        public MenesioProognoze() { }
        [DisplayName("Id")]
        public int id { get; set; }

        [DisplayName("metai")]
        public int metai { get; set; }
        [DisplayName("menuo")]
        public int menuo { get; set; }
        [DisplayName("reiksmingas")]
        public bool reiksmingas { get; set; }
      
    }
}