namespace SHUNetMVC.Infrastructure.EntityFramework.Queries
{
    public abstract class BaseCrudQuery
    {
        public abstract  string SelectPagedQuery { get; }
        public abstract string CountQuery { get; }
        public abstract string LookupTextQuery { get; }
    }
}
