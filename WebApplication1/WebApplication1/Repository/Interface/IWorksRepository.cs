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
    }
}