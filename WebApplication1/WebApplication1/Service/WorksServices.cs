using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using WebApplication1.Interface;
using WebApplication1.Repository;
using WebApplication1.Repository.Interface;
using WebApplication1.Repository.Model;
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

        public string InsertCustomersService(WorksInputModel _WorksInputModel)
        {
            WorksPara _WorksPara = new WorksPara()
            {
                CustomerID= _WorksInputModel.CustomerID,
                CompanyName= _WorksInputModel.CompanyName,
                ContactName = _WorksInputModel.ContactName,
                ContactTitle= _WorksInputModel.ContactTitle,
                Address= _WorksInputModel.Address,
                City= _WorksInputModel.City,
                Region= _WorksInputModel.Region,
                PostalCode= _WorksInputModel.PostalCode,
                Country= _WorksInputModel.Country,
                Phone= _WorksInputModel.Phone,
                Fax= _WorksInputModel.Fax
            };
            return _worksRepository.InsertCustomers(_WorksPara);
        }

        public List<WorksOutputModel> EditCustomersListService(WorksInputModel _WorksInputModel)
        {
            WorksPara _WorksPara = new WorksPara()
            {
                CustomerID = _WorksInputModel.CustomerID
            };
            var OutputData = _worksRepository.EditCustomersList(_WorksPara);
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
                        Address = x.Address,
                        City = x.City,
                        Region = x.Region,
                        PostalCode = x.PostalCode,
                        Country = x.Country,
                        Phone = x.Phone,
                        Fax = x.Fax
                    }).ToList();
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

        public string UpdateCustomersService(WorksInputModel _WorksInputModel)
        {
            WorksPara _WorksPara = new WorksPara()
            {
                CustomerID = _WorksInputModel.CustomerID,
                CompanyName = _WorksInputModel.CompanyName,
                ContactName = _WorksInputModel.ContactName,
                ContactTitle = _WorksInputModel.ContactTitle,
                Address = _WorksInputModel.Address,
                City = _WorksInputModel.City,
                Region = _WorksInputModel.Region,
                PostalCode = _WorksInputModel.PostalCode,
                Country = _WorksInputModel.Country,
                Phone = _WorksInputModel.Phone,
                Fax = _WorksInputModel.Fax
            };
            return _worksRepository.UpdateCustomers(_WorksPara);
        }
    }
}