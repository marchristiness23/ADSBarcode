using SHUNetMVC.Abstraction.Model.View;

namespace SHUNetMVC.Abstraction.Services
{
    public interface ILookupService
    {
        LookupList GetDepartements();
        LookupList GetProjects();
    }
}
