using SHUNetMVC.Abstraction.Model.Dto;
using SHUNetMVC.Abstraction.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHUNetMVC.Abstraction.Model.Dto
{
    public class TerritoryDto : BaseDtoAutoMapper<Territory>
    {
        [Required]
        public string TerritoryID { get; set; }
        public string TerritoryDescription { get; set; }
        public int RegionID { get; set; }

        public virtual Region Region { get; set; }

        public TerritoryDto()
        {

        }

        public TerritoryDto(Territory entity) : base(entity)
        {
        }
    }
}
