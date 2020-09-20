using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Service;
using WebApplication1.Service.Model;

namespace WebApplication1.Controllers
{
    public partial class WorksController
    {
        public ActionResult Edit(string CustomerID)
        {
            WorksInputModel _WorksInputModel = new WorksInputModel()
            {
                CustomerID = CustomerID
            };
            var Output = _WorksServices.EditCustomersListService(_WorksInputModel);
            var OutputData = _Mapper.Map<List<WorksViewModel>>(Output);
            return PartialView(OutputData);
        }

        public ActionResult Update(WorksViewModel _WorksViewModel)
        {
            string ReturnMsg = "false";
            if (ModelState.IsValid)
            {
                var InputData = _Mapper.Map<WorksInputModel>(_WorksViewModel);
                ReturnMsg = _WorksServices.UpdateCustomersService(InputData);
            }
            return Content(ReturnMsg);
        }
    }
}
