using SHUNetMVC.Abstraction.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHUNetMVC.Abstraction.Model.Dto
{
    public class EmployeeEducationDto : BaseDtoAutoMapper<EmployeeEducation>
    {
        public EmployeeEducationDto()
        {
        }

        public EmployeeEducationDto(EmployeeEducation entity) : base(entity)
        {
        }

        public int Id { get; set; }
        public int EmpId { get; set; }
        public string School { get; set; }
        public string Degree { get; set; }
        public string FieldOfStudy { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
