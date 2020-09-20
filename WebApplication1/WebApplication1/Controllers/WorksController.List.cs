using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Service;

namespace WebApplication1.Controllers
{
    public partial class WorksController
    {
        public ActionResult List(int pageCnt = 1, int pageRows = 10)
        {
            var DataList = _WorksServices.SelectCustomersListService(pageCnt, pageRows);
            var Output = _Mapper.Map<List<WorksViewModel>>(DataList);
            return View("CustomersList", Output);
        }
    }
}
