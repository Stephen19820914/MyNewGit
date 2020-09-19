using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using WebApplication1.Interface;
using WebApplication1.Repository;
using WebApplication1.Repository.Interface;
using WebApplication1.Service.Model;

namespace WebApplication1.Service
{
    public class WorksServices: IWorksServices
    {
        private readonly IWorksRepository _worksRepository;
        public WorksServices(string _ConnectionString)
        {
            _worksRepository = new WorksRepository(_ConnectionString);
        }

        public List<WorksOutputModel> SelectCustomersListService(int pageCnt, int pageRows)
        {
            var OutputData = _worksRepository.SelectCustomersList();
            if (OutputData != null)
            {
                if (OutputData.Count > 0 && string.IsNullOrEmpty(OutputData[0].ErrorMsg))
                {
                    //沒有錯誤訊息
                    return OutputData.Select(x => new WorksOutputModel
                    {
                        CustomerID = x.CustomerID,
                        CompanyName = x.CompanyName,
                        ContactName = x.ContactName,
                        ContactTitle = x.ContactTitle,
                        Address = x.Address
                    }).Skip((pageCnt - 1) * pageRows).Take(pageRows).ToList();
                }
                else
                {
                    //有錯誤訊息
                    return OutputData.Select(x => new WorksOutputModel
                    {
                        ErrorMsg = x.ErrorMsg
                    }).ToList();
                }
            }
            else
            {
                //有問題
                return new List<WorksOutputModel>();
            }
        }
    }
}