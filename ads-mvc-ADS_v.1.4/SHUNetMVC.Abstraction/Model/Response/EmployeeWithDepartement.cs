using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHUNetMVC.Abstraction.Model.Response
{
    public class EmployeeWithDepartement
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpPosition { get; set; }
        public string DepartementName { get; set; }
        public DateTime? Birthdate { get; set; }
        public int? OrgUnitId { get; set; }
        public double? Score { get; set; }
    }
}
