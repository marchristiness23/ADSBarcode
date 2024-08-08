using SHUNetMVC.Abstraction.Extensions;
using SHUNetMVC.Abstraction.Model.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SHUNetMVC.Abstraction.Model.Dto
{
    public class EmployeeDto : BaseDtoAutoMapper<Employee>
    {
        #region DB Field
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpPosition { get; set; }
        public Nullable<int> DepartementId { get; set; }
        
        public Nullable<System.DateTime> Birthdate { get; set; }
        public Nullable<int> OrgUnitId { get; set; }
        public Nullable<decimal> Score { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public int Role { get; set; }

        public List<EmployeeEducationDto> Educations { get; set; }

        #endregion


        #region Additional Field
        public string DepartementName { get; set; }
        public List<int> ProjectIds { get; set; }

        
        #endregion

        public EmployeeDto()
        {
         
        }

        public EmployeeDto(Employee entity) : base(entity)
        {
        }

    }
}
