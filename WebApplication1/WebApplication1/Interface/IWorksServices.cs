using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Service.Model;

namespace WebApplication1.Interface
{
    public interface IWorksServices
    {
        List<WorksOutputModel> SelectCustomersListService(int pageCnt, int pageRows);
    }
}