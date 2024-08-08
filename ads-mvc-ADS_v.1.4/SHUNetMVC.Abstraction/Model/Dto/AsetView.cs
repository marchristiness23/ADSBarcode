using SHUNetMVC.Abstraction.Extensions;
using SHUNetMVC.Abstraction.Model.Entities;
using System.Collections.Generic;

namespace SHUNetMVC.Abstraction.Model.Dto
{
    public class AsetView
    {
        public List<MD_Aset> assets { get; set; }
        public MD_Aset newAset { get; set; }
    }
}
