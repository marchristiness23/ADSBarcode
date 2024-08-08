using SHUNetMVC.Abstraction.Model.Dto;
using SHUNetMVC.Abstraction.Model.Entities;
using SHUNetMVC.Abstraction.Model.Response;
using SHUNetMVC.Abstraction.Model.View;
using SHUNetMVC.Abstraction.Services;
using SHUNetMVC.Infrastructure.Validators;
using SHUNetMVC.Web.Extensions;
using FluentValidation.Results;
using Microsoft.Owin.Security.Provider;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.ValueProviders;
using System.Web.Mvc;
using System.Web.Routing;

namespace SHUNetMVC.Web.Controllers
{
    // IRepository, Repository, IService, Service, Validator, Controller
    public class EmployeeController : BaseCrudController<EmployeeDto, EmployeeWithDepartement>
    {
        private IEmployeeService employeeService;
        public EmployeeController(IEmployeeService crudSvc, ILookupService lookupSvc) : base(crudSvc, lookupSvc)
        {
            employeeService = crudSvc;
        }

        protected override FormDefinition DefineForm(FormState formState)
        {
            var formDef = new FormDefinition
            {
                Title = "Employee",
                State = formState,
                FieldSections = new List<FieldSection>()
                {
                    GeneralField(),
                    AddressField(),
                    JobField(),
                    new FieldSection
                    {
                        SectionName = "Educations",
                        Fields =  new List<Field>
                        {
                            new Field
                            {
                                Id = nameof(EmployeeDto.Educations),
                                
                                FieldType = FieldType.Grid,
                                FormDefinition = new FormDefinition(EducationFormDefinition()),
                            },
                        }
                    }
                }
            };
            return formDef;
        }

        private FieldSection EducationFormDefinition()
        {
            return new FieldSection
            {
                SectionName = "",
                Fields = {

                        new Field(nameof(EmployeeEducationDto.Degree),FieldType.Text),
                        new Field(nameof(EmployeeEducationDto.School),FieldType.Text),
                        new Field(nameof(EmployeeEducationDto.FieldOfStudy),FieldType.Text),
                        new Field(nameof(EmployeeEducationDto.StartDate),FieldType.Date),
                        new Field(nameof(EmployeeEducationDto.EndDate),FieldType.Date),
                }
            };
        }
        private FieldSection GeneralField()
        {
            return new FieldSection
            {
                SectionName = "General",
                Fields = {
                        new Field {
                        Id = nameof(EmployeeDto.EmpId),
                        FieldType = FieldType.Hidden
                    },
                    new Field {
                        Id = nameof(EmployeeDto.EmpName),
                        Label = "Name",
                        FieldType = FieldType.Text,
                        IsRequired = true
                    },

                        new Field {
                        Id = nameof(EmployeeDto.Email),
                        Label = "Email",
                        FieldType = FieldType.Email
                    },
                        new Field {
                        Id = nameof(EmployeeDto.Phone),
                        Label = "Phone",
                        FieldType = FieldType.Phone
                    },
                    new Field {
                        Id = nameof(EmployeeDto.Birthdate),
                        Label = "Birth Date",
                        FieldType = FieldType.Date
                    },

                }
            };
        }
        private FieldSection JobField()
        {
            return new FieldSection
            {
                SectionName = "Job Information",
                Fields = {

                    new Field {
                        Id = nameof(EmployeeDto.DepartementId),
                        Label = "Departement",
                        FieldType = FieldType.Lookup,
                        LookUpController = "Departement",
                        LookUpOrderBy = "DepartementName"
                    },


                    new Field {
                        Id = nameof(EmployeeDto.EmpPosition),
                        Label = "Position",
                        FieldType = FieldType.Text
                    },

                    new Field {
                        Id = nameof(EmployeeDto.OrgUnitId),
                        Label = "Organization Unit",
                        FieldType = FieldType.Number
                    },

                    new Field {
                        Id = nameof(EmployeeDto.Score),
                        Label = "Score",
                        FieldType = FieldType.Number,


                    },
                    //new Field {
                    //    Id = nameof(EmployeeDto.ProjectIds),
                    //    Label = "Projects",
                    //    FieldType = FieldType.MultiCheckbox,
                    //    LookUpList = _lookupService.GetProjects()
                    //},
                    new Field {
                        Id = nameof(EmployeeDto.Role),
                        Label = "Role",
                        FieldType = FieldType.Radio,
                        LookUpList = new LookupList
                        {
                            Items = new List<LookupItem>
                            {
                                new LookupItem()
                                {
                                Text = "Manager" ,
                                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididun",
                                Value = "1"
                                },
                                new LookupItem()
                                {
                                Text = "Lead" ,
                                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit",
                                Value = "2"
                                },
                                new LookupItem()
                                {
                                Text = "Staff" ,
                                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                                Value = "3"
                                },
                                new LookupItem()
                                {
                                Text = "Junior" ,
                                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore",
                                Value = "4"
                                },
                            }
                        }
                    },


                    new Field {
                        Id = nameof(EmployeeDto.IsActive),
                        Label = "Active",
                        FieldType = FieldType.Switch
                    },
                }
            };
        }
        private FieldSection AddressField()
        {
            return new FieldSection
            {
                SectionName = "Address",
                Fields = {
                        new Field {
                        Id = nameof(EmployeeDto.City),
                        Label = "City",
                        FieldType = FieldType.Text

                    },

                    new Field {
                        Id = nameof(EmployeeDto.Address),
                        Label = "Address",
                        FieldType = FieldType.TextArea,
                        MaxLength = 500
                    }
                }
            };
        }

        protected override List<ColumnDefinition> DefineGrid()
        {
            return new List<ColumnDefinition>
            {
                new ColumnDefinition("Id", nameof(EmployeeWithDepartement.EmpId), ColumnType.Id),
                new ColumnDefinition("Name", nameof(EmployeeWithDepartement.EmpName), ColumnType.String),
                new ColumnDefinition("Position", nameof(EmployeeWithDepartement.EmpPosition), ColumnType.String),
                new ColumnDefinition("Departement", nameof(EmployeeWithDepartement.DepartementName), ColumnType.String,"d.DepartementName"),
                new ColumnDefinition("Birth Date", nameof(EmployeeWithDepartement.Birthdate), ColumnType.Date),
                new ColumnDefinition("Organization Id", nameof(EmployeeWithDepartement.OrgUnitId), ColumnType.Number),
                new ColumnDefinition("Score", nameof(EmployeeWithDepartement.Score), ColumnType.Number)
            };
        }


        public override async Task<ActionResult> Create([Bind(Exclude = "")] EmployeeDto model)
        {
            return await BaseCreate(model, new EmployeeValidator(FormState.Create, employeeService));
        }

        public override async Task<ActionResult> Edit([Bind(Exclude = "")] EmployeeDto model)
        {
            return await BaseUpdate(model, new EmployeeValidator(FormState.Edit, employeeService));
        }
        public ActionResult InitChildGrid(Field fieldChild)
        {
            // thead
            var lstColumnDef = new List<ColumnDefinition>();
            foreach (var field in fieldChild.FormDefinition.FieldSections.SelectMany(a => a.Fields))
            {
                var colType = ColumnType.String;
                if (field.FieldType == FieldType.Hidden)
                {
                    colType = ColumnType.Id;
                }
                else if (field.FieldType == FieldType.DateTime)
                {
                    colType = ColumnType.DateTime;
                }
                else if (field.FieldType == FieldType.Date)
                {
                    colType = ColumnType.Date;
                }
                lstColumnDef.Add(new ColumnDefinition(field.Label, field.Id, colType));
            }

            // tbody
            GridListModel result = new GridListModel
            {
                GridId = fieldChild.Id,
                ColumnDefinitions = lstColumnDef,
                IsForLookup = fieldChild.IsDisabled
            };

            result.FillRows(fieldChild.Value);
            return PartialView("Component/Form/Grid/_Field-Grid-List", result);
        }
        public ActionResult CreateChild(string fieldId, List<EmployeeEducationDto> modelList, EmployeeEducationDto model)
        {
         


         




            if (modelList == null)
            {
                modelList = new List<EmployeeEducationDto>();
            }
            modelList.Add(model);


            FieldSection formDef = EducationFormDefinition();

            var validator = new EmployeeEducationValidator();
            ValidationResult validationResult = validator.Validate(model);

            if (validationResult.IsValid == false)
            {
               
                foreach (var field in formDef.Fields)
                {
                    field.Value = model.GetType().GetProperty(field.Id).GetValue(model);

                    var errorField = validationResult.Errors.FirstOrDefault(o => o.PropertyName == field.Id);
                    if (errorField != null)
                    {
                        field.ErrorMessage = errorField.ErrorMessage;
                    }
                }

                var invalidForm = new FormDefinition
                {
                    Title = "Education",
                    FieldSection = formDef,

                };
                return PartialView("Component/Form/Grid/_Field-Grid-Form", invalidForm);
            }

            // thead
            var lstColumnDef = new List<ColumnDefinition>();
            foreach (var field in formDef.Fields)
            {
                var colType = ColumnType.String;
                if (field.FieldType == FieldType.Hidden)
                {
                    colType = ColumnType.Id;
                }
                else if (field.FieldType == FieldType.DateTime)
                {
                    colType = ColumnType.DateTime;
                }
                else if (field.FieldType == FieldType.Date)
                {
                    colType = ColumnType.Date;
                }
                lstColumnDef.Add(new ColumnDefinition(field.Label, field.Id, colType));
            }

            // tbody
            GridListModel result = new GridListModel
            {
                GridId = fieldId,
                ColumnDefinitions = lstColumnDef
            };
            result.FillRows(modelList);

            return PartialView("Component/Form/Grid/_Field-Grid-List", result);
        }

    }
}