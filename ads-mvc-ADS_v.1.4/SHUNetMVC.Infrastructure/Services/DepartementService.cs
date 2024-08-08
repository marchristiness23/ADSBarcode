using SHUNetMVC.Abstraction.Model.Dto;
using SHUNetMVC.Abstraction.Repositories;
using SHUNetMVC.Abstraction.Services; 

namespace SHUNetMVC.Infrastructure.Services
{
    public class DepartementService : BaseCrudService<DepartementDto, DepartementDto>, IDepartementService
    {
        private readonly IDepartementRepository _repo;
        public DepartementService(IDepartementRepository repo) : base(repo)
        {
            _repo = repo;
        }
    }
}
