//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectParduotuve.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Prognazuojama_preke
    {
        public int id_Prognazuojama_preke { get; set; }
        public double Uzsakymo_kiekis { get; set; }
        public double Reikalingas_kiekis { get; set; }
        public double Pirkimo_prognoze { get; set; }
        public int fk_id_Menesio_prognoze { get; set; }
        public int fk_id_Produkto_specifikacija { get; set; }
    
        public virtual Menesio_prognoze Menesio_prognoze { get; set; }
        public virtual Produkto_specifikacija Produkto_specifikacija { get; set; }
    }
}