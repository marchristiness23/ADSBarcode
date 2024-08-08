using SHUNetMVC.Abstraction.Model.Dto;
using SHUNetMVC.Abstraction.Model.Entities;
using AutoMapper;

namespace SHUNetMVC.Web
{
    public class AutoMapperConfig
    {
        public static void RegisterGlobalMapping()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<Employee, EmployeeDto>().ReverseMap();
                cfg.CreateMap<Departement, DepartementDto>().ReverseMap();
                cfg.CreateMap<EmployeeEducation, EmployeeEducationDto>().ReverseMap();
                cfg.CreateMap<Worker, WorkerDto>().ReverseMap();
                cfg.CreateMap<MD_Aset, MD_AsetDto>().ReverseMap();
            });
        }
    }
}
