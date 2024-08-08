using SHUNetMVC.Abstraction.Model.Dto;
using SHUNetMVC.Abstraction.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SHUNetMVC.Abstraction.Services
{
    public interface IWorkerService : ICrudService<WorkerDto, WorkerDto>
    {
        void Destroy(int employeeID);
    }
}
