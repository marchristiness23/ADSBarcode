using SHUNetMVC.Abstraction.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHUNetMVC.Abstraction.Repositories
{
    public interface ICommonRepository
    {
        Task<List<Departement>> GetDataDepartement();
    }
}
