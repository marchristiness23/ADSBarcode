using SHUNetMVC.Abstraction.Model.Dto;
using SHUNetMVC.Abstraction.Repositories;
using SHUNetMVC.Abstraction.Services; 

namespace SHUNetMVC.Infrastructure.Services
{
    public class EmployeeKendoCrudService : BaseCrudService<EmployeeDto, EmployeeDto>, ICrudEmployeeKendoService
    {
        private readonly ICrudEmployeeKendoRepository _repo;
        public EmployeeKendoCrudService(ICrudEmployeeKendoRepository repo) : base(repo)
        {
            _repo = repo;
        }
    }
}
