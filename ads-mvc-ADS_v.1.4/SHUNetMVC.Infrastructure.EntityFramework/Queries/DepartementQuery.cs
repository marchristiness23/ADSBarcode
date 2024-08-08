namespace SHUNetMVC.Infrastructure.EntityFramework.Queries
{
    public class DepartementQuery : BaseCrudQuery
    {
        public override string SelectPagedQuery => @"
            select  d.DepartementId,
                d.DepartementName
            from dbo.Departement d";

        public override string CountQuery => @"
            select count(1) from dbo.Departement d";

        public override string LookupTextQuery => @"
            select d.DepartementName 
            from dbo.Departement d
            where d.DepartementId = {0}";



    }
}
