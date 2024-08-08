using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHUNetMVC.Abstraction.Model.Request
{
    public class EmployeeFilter : PagedFilter
    {
        public string EmpName { get; set; }
        public string DepartementName { get; set; }
    }
}
