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
    
    public partial class Menesio_prognoze
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Menesio_prognoze()
        {
            this.Prognazuojama_preke = new HashSet<Prognazuojama_preke>();
        }
    
        public int id_Menesio_prognoze { get; set; }
        public int Metai { get; set; }
        public int Menuo { get; set; }
        public int Diena { get; set; }
        public int Laikas { get; set; }
        public Nullable<bool> Reiksmingas { get; set; }
        public Nullable<int> fk_id_Vieta { get; set; }
    
        public virtual Vieta Vieta { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Prognazuojama_preke> Prognazuojama_preke { get; set; }
    }
}
