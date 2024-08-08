using SHUNetMVC.Abstraction.Extensions;
using SHUNetMVC.Abstraction.Model.Entities;

namespace SHUNetMVC.Abstraction.Model.Dto
{
    public class DepartementDto : BaseDtoAutoMapper<Departement>
    {
        public int DepartementId { get; set; }
        public string DepartementName { get; set; }

        public DepartementDto()
        {

        }

        public DepartementDto(Departement entity) : base(entity)
        {
        }
    }
}
