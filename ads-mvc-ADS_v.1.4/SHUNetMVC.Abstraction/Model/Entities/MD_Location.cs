//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SHUNetMVC.Abstraction.Model.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class MD_Location
    {
        public int LocationId { get; set; }
        public string Regional { get; set; }
        public string Zona { get; set; }
        public string WilayahKerja { get; set; }
        public string LokasiAset { get; set; }
        public Nullable<double> Lon { get; set; }
        public Nullable<double> Lat { get; set; }
        public string NamaPlant { get; set; }
        public Nullable<bool> Ditemukan { get; set; }
        public string Sistem { get; set; }
    }
}
