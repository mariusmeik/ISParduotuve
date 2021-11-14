using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace ProjectParduotuve.Models
{
    public class DarbuotojoMenesioAtaskaita
    {
        [DisplayName("Id")]
        public int id { get; set; }
        [DisplayName("Metai")]
        public string metai { get; set; }
        [DisplayName("Menuo")]
        public string menuo { get; set; }
        [DisplayName("Dirba nuo h")]
        public string dirbaNuoH { get; set; }
        [DisplayName("Dirba iki h")]
        public string dirbaIkiH { get; set; }
        [DisplayName("Darbo dienos")]
        public DateTime darboDienos { get; set; }
        [DisplayName("Atlyginimas")]
        public DateTime atlyginimas { get; set; }
        [DisplayName("Pelnas")]
        public bool pelnas { get; set; }
        [DisplayName("Pareigos")]
        public bool pareigos { get; set; }
    }
}