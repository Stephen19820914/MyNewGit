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
        public ActionResult Delete(string CustomerID)
        {
            string ReturnMsg = "false";
            WorksInputModel _WorksInputModel = new WorksInputModel()
            {
                CustomerID = CustomerID
            };
            ReturnMsg = _WorksServices.DeleteCustomersListService(_WorksInputModel);
            return Content(ReturnMsg);
        }
    }
}
