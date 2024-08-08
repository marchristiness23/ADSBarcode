using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using SHUNetMVC.Abstraction.Model.Dto;
using SHUNetMVC.Abstraction.Model.Response;
using SHUNetMVC.Abstraction.Model.View;
using SHUNetMVC.Abstraction.Services;
using SHUNetMVC.Infrastructure.Services;
using SHUNetMVC.Infrastructure.Validators;

namespace SHUNetMVC.Web.Controllers
{
    public class WorkerController : BaseCrudController<WorkerDto, WorkerDto>
    {
        private IWorkerService _service;
        public WorkerController(IWorkerService crudSvc, ILookupService lookupSvc) : base(crudSvc, lookupSvc)
        {
            _service = crudSvc;
        }

        public override async Task<ActionResult> Create([Bind(Exclude = "")] WorkerDto model)
        {
            var A = await BaseCreate(model, new WorkerValidator(FormState.Create, _service));
            return A;
        }

       

        public override async Task<ActionResult> Edit([Bind(Exclude = "")] WorkerDto model)
        {
            return await BaseUpdate(model, new WorkerValidator(FormState.Edit, _service));
        }

        public ActionResult MyAction(string button)
        {
        return View("TestView");
        }

        protected override FormDefinition DefineForm(FormState formState)
        {
            return new FormDefinition
            {
                Title = "Worker",
                State = formState,
                FieldSections = new List<FieldSection>()
                {
                   new FieldSection
                    {
                        SectionName = "",
                        Fields = {
                                new Field {
                                Id = nameof(WorkerDto.EmployeeID),
                                FieldType = FieldType.Hidden
                            },
                            new Field {
                                Id = nameof(WorkerDto.FirstName),
                                Label = "First Name",
                                FieldType = FieldType.Text,
                                IsRequired = true
                            },
                             new Field {
                                Id = nameof(WorkerDto.LastName),
                                Label = "Last Name",
                                FieldType = FieldType.Text,
                                IsRequired = true
                            },
                             new Field {
                                Id = nameof(WorkerDto.BirthDate),
                                Label = "Birth Date",
                                FieldType = FieldType.Date,
                                IsRequired = true
                            },
                             new Field {
                                Id = nameof(WorkerDto.HireDate),
                                Label = "Hire Date",
                                FieldType = FieldType.Date,
                                IsRequired = true
                            },
                              new Field {
                                Id = nameof(WorkerDto.City),
                                Label = "City",
                                FieldType = FieldType.Text,
                                IsRequired = true
                            }

                        }
                    }
                }
            };
        }

        protected override List<ColumnDefinition> DefineGrid()
        {
            return new List<ColumnDefinition>
            {
                new ColumnDefinition("Id", nameof(WorkerDto.EmployeeID), ColumnType.Id),
                new ColumnDefinition("First Name", nameof(WorkerDto.FirstName), ColumnType.String),
                new ColumnDefinition("Last Name", nameof(WorkerDto.LastName), ColumnType.String),
                new ColumnDefinition("Birth Date", nameof(WorkerDto.BirthDate), ColumnType.Date),
                new ColumnDefinition("Hire Date", nameof(WorkerDto.HireDate), ColumnType.Date),
                new ColumnDefinition("City", nameof(WorkerDto.City), ColumnType.String),
            };
        }
    }
}
