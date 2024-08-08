using SHUNetMVC.Abstraction.Extensions;
using SHUNetMVC.Abstraction.Model.Entities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SHUNetMVC.Abstraction.Model.Dto
{
    public class WorkerDto : BaseDtoAutoMapper<Worker>
    {
        [Required]
        [DisplayName("EmployeeID")]
        public int EmployeeID { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Title")]
        public string Title { get; set; }
        [Required]
        [DisplayName("Title Of Courtesy")]
        public string TitleOfCourtesy { get; set; }
        [DisplayName("Birth Date")]
        [UIHint("DateTime")]
        public Nullable<System.DateTime> BirthDate { get; set; }
        [DisplayName("Hire Date")]
        [UIHint("DateTime")]
        public Nullable<System.DateTime> HireDate { get; set; }
        [DisplayName("Address")]
        public string Address { get; set; }
        [DisplayName("City")]
        public string City { get; set; }
        [DisplayName("Region")]
        public string Region { get; set; }
        [DisplayName("Postal Code")]
        public string PostalCode { get; set; }
        [DisplayName("Country")]
        public string Country { get; set; }
        [DisplayName("Home Phone")]
        public string HomePhone { get; set; }
        [DisplayName("Extension")]
        public string Extension { get; set; }
        [DisplayName("Notes")]
        public string Notes { get; set; }
        [DisplayName("EmployeeStatus")]
        public string EmployeeStatus { get; set; }
        public WorkerDto()
        {

        }

        public WorkerDto(Worker entity) : base(entity)
        {
        }
    }

    public class WorkerDtoPopUp : BaseDtoAutoMapper<Worker>
    {
        [Editable(false)]
        [DisplayName("EmployeeID")]
        public int EmployeeID { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Title")]
        public string Title { get; set; }
        [Required]
        [DisplayName("Title Of Courtesy")]
        public string TitleOfCourtesy { get; set; }
        [DisplayName("Birth Date")]
        [UIHint("Date")]
        public Nullable<System.DateTime> BirthDate { get; set; }
        [DisplayName("Hire Date")]
        [UIHint("Date")]
        public Nullable<System.DateTime> HireDate { get; set; }
        public string Notes { get; set; }
        [DisplayName("EmployeeStatus")]
        public string EmployeeStatus { get; set; }
        public WorkerDtoPopUp()
        {

        }

        public WorkerDtoPopUp(Worker entity) : base(entity)
        {
        }
    }
}
