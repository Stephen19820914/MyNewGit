using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Interface;
using WebApplication1.Models;
using WebApplication1.Service;
using WebApplication1.Service.Model;

namespace WebApplication1.Controllers
{
    public partial class WorksController : Controller
    {
        private IWorksServices _WorksServices;
        private IMapper _Mapper;

        public WorksController()
        {
            this._WorksServices = new WorksServices(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["NorthwindConnectionString"].ToString()); ;
            _Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<WorksOutputModel, WorksViewModel>()));
        }
    }
}
