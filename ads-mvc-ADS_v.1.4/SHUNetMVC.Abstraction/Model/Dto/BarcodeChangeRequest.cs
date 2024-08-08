using SHUNetMVC.Abstraction.Extensions;
using SHUNetMVC.Abstraction.Model.Entities;
using System.Collections.Generic;
using System.ComponentModel;

namespace SHUNetMVC.Abstraction.Model.Dto
{
    public class BarcodeChangeRequest
    {
        public string Aset_No { get; set; }
        [DefaultValue("BETON")]
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
