using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel;

namespace ProjectParduotuve.Models
{
    public class Worker
    {
        public Worker() { }

        [DisplayName("Id")]
        public int id { get; set; }
        [DisplayName("vardas")]
        public string vardas { get; set; }
        [DisplayName("pavarde")]
        public string pavarde { get; set; }
        [DisplayName("el pastas")]
        public string elPastas { get; set; }
        [DisplayName("telefonas")]
        public string telefonas { get; set; }
        [DisplayName("dirba nuo:")]
        public DateTime dirbaNuo { get; set; }
        [DisplayName("dirba iki:")]
        public DateTime dirbaIki { get; set; }
        [DisplayName("pareigos")]
        public string pareigos { get; set; }
        [DisplayName("aktyvus")]
        public bool aktyvus { get; set; }
    }
}