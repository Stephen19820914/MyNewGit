using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Repository.Model;

namespace WebApplication1.Repository.Interface
{
    public interface IWorksRepository
    {
        List<Works> SelectCustomersList();

        string InsertCustomers(WorksPara _WorksPara);

        List<Works> EditCustomersList(WorksPara _WorksPara);

        string UpdateCustomers(WorksPara _WorksPara);

        string DeteleCustomers(WorksPara _WorksPara);
    }
}