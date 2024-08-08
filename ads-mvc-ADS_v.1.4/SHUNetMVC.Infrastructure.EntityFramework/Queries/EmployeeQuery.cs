namespace SHUNetMVC.Infrastructure.EntityFramework.Queries
{
    public class EmployeeQuery : BaseCrudQuery
    {
        public override string SelectPagedQuery => @"
            select  e.EmpId,
                    e.EmpName,
                    e.EmpPosition,
                    d.DepartementName,
                    e.Birthdate,
                    e.OrgUnitId,
                    e.Score
            from dbo.Employee e
            left join dbo.Departement d on e.DepartementId = d.DepartementId";

        public override string CountQuery => @"
            select count(1) from dbo.Employee e
            left join dbo.Departement d on e.DepartementId = d.DepartementId";

        public override string LookupTextQuery => @"select e.EmpName from dbo.Employee e";
    }
}
