using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel;

namespace ProjectParduotuve.Models
{
    public class Card
    {
        [DisplayName("Id")]
        public int id { get; set; }
        [DisplayName("busena")]
        public string name { get; set; }
        [DisplayName("busena")]
        public string surname { get; set; }
        [DisplayName("busena")]
        public string email { get; set; }
        [DisplayName("busena")]
        public string phone { get; set; }
        [DisplayName("Work From")]
        public DateTime validityFrom { get; set; }
        [DisplayName("Work To")]
        public DateTime validityTo { get; set; }
        [DisplayName("Active")]
        public bool active { get; set; }
    }
}