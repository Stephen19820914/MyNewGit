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
        public ActionResult Add()
        {
            return PartialView();
        }

        public ActionResult Insert(WorksViewModel _WorksViewModel)
        {
            string ReturnMsg = "false";
            if (ModelState.IsValid)
            {
                var InputData = _Mapper.Map<WorksInputModel>(_WorksViewModel);
                ReturnMsg = _WorksServices.InsertCustomersService(InputData);
            }
            return Content(ReturnMsg);
        }
    }
}
