using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using SHUNetMVC.Abstraction.Model.Dto;
using SHUNetMVC.Abstraction.Model.View;
using SHUNetMVC.Abstraction.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ASPNetMVC.Web.Controllers
{
    public class GridController : Controller
    {
        private readonly IWorkerService _service;
        public GridController(IWorkerService service)
        {
            _service = service;
        }
        // GET: Grid
        public ActionResult Index()
        {
            var define = DefineForm(FormState.Create);
            return PartialView("Index", define);
        }

        protected FormDefinition DefineForm(FormState formState)
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
                                FieldType = FieldType.Number
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
                            },
                              new Field {
                                Id = nameof(WorkerDto.EmployeeStatus),
                                Label = "EmployeeStatus",
                                FieldType = FieldType.Text,
                                IsRequired = true
                            }

                        }
                    }
                }
            };
        }

        public ActionResult EditingCustom_Read([DataSourceRequest] DataSourceRequest request)
        {
            var model = new CrudPage
            {
                Id = "Worker",
                Title = "Worker Record",
                SubTitle = "This is the list of Workers",
                GridParam = new GridParam
                {
                    GridId = this.GetType().Name + "_grid",
                    FilterList = new FilterList
                    {
                        OrderBy = "EmployeeID desc",
                        Page = 1,
                        Size = 1000
                    }
                }
            };
            var datas = Task.Run(() => _service.GetPaged(model.GridParam)).Result;
            return Json(datas.Items.ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditingCustom_Update([DataSourceRequest] DataSourceRequest request,
            [Bind(Prefix = "models")] IEnumerable<WorkerDto> workers)
        {
            if (workers != null && ModelState.IsValid)
            {
                foreach (var worker in workers)
                {
                    _service.Update(worker);
                }
            }

            return Json(workers.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditingCustom_Create([DataSourceRequest] DataSourceRequest request,
            [Bind(Prefix = "models")] IEnumerable<WorkerDto> workers)
        {
            var results = new List<WorkerDto>();

            if (workers != null && ModelState.IsValid)
            {
                foreach (var worker in workers)
                {
                    _service.Create(worker);

                    results.Add(worker);
                }
            }

            return Json(results.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditingCustom_Destroy([DataSourceRequest] DataSourceRequest request,
            [Bind(Prefix = "models")] IEnumerable<WorkerDto> workers)
        {
            foreach (var worker in workers)
            {
                _service.Destroy(worker.EmployeeID);
            }

            return Json(workers.ToDataSourceResult(request, ModelState));
        }
    }
}