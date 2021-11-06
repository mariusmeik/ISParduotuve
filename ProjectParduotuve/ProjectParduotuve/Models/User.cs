using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel;


namespace ProjectParduotuve.Models
{
    public class User
    {
        public User() { }

        [DisplayName("Name")]
        public string name { get; set; }

        [DisplayName("Password")]
        public string password { get; set; }

        [DisplayName("Rights")]
        public string right { get; set; }
    }
}