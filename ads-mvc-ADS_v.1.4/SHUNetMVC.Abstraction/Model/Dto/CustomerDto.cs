using SHUNetMVC.Abstraction.Extensions;
using SHUNetMVC.Abstraction.Model.Entities;

namespace SHUNetMVC.Abstraction.Model.Dto
{
    public class CustomerDto : BaseDtoAutoMapper<Customer>
    {
        public string CustomerID { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }

        public CustomerDto()
        {

        }

        public CustomerDto(Customer entity) : base(entity)
        {
        }
    }
}
