using SHUNetMVC.Abstraction;
using SHUNetMVC.Abstraction.Model.Entities;
using SHUNetMVC.Abstraction.Model.Response;
using SHUNetMVC.Abstraction.Repositories;
using SHUNetMVC.Abstraction.Services;
using SHUNetMVC.Infrastructure.EntityFramework.Queries;
using SHUNetMVC.Infrastructure.EntityFramework.Repositories;
using SHUNetMVC.Infrastructure.Services;
using SHUNetMVC.Web.Providers; 
using System.Web;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using System.Runtime.Caching;

namespace SHUNetMVC.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterInstance(new MemoryCache("system"));
            container.RegisterType<DB_PHE_ADSEntities, DbContextMapper>();
            container.RegisterType<IConnectionProvider, ConnectionStringProvider>();
           
            container.RegisterFactory<HttpContextBase>((_) =>
            {
                return new HttpContextWrapper(HttpContext.Current);
            });
            container.RegisterType<IUserService, UserService>();



            container.RegisterType<IWorkerRepository, WorkerRepository>();
            container.RegisterType<IWorkerService, WorkerService>();

            container.RegisterType<IDepartementRepository, DepartementRepository>();
            container.RegisterType<IDepartementService, DepartementService>();

            container.RegisterType<IEmployeeRepository, EmployeeRepository>();
            container.RegisterType<IEmployeeService, EmployeeService>();

            container.RegisterType<ILookupRepository, LookupRepository>();
            container.RegisterType<ILookupService, LookupService>();

            container.RegisterType<IEmployeeKendoRepository, EmployeeKendoRepository>();
            container.RegisterType<IEmployeeKendoService, EmployeeKendoService>();

            container.RegisterType<ICrudEmployeeKendoRepository, CrudEmployeeKendoRepository>();
            container.RegisterType<ICrudEmployeeKendoService, EmployeeKendoCrudService>();

            container.RegisterType<ICommonRepository, CommonRepository>();
            container.RegisterType<ICommonService, CommonService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}