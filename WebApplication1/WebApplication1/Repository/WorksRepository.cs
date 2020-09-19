using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication1.Repository.Interface;
using WebApplication1.Repository.Model;

namespace WebApplication1.Repository
{
    public class WorksRepository: IWorksRepository
    {
        private readonly string ConnectionString;
        public WorksRepository(string _ConnectionString)
        {
            this.ConnectionString = _ConnectionString;
        }

        public List<Works> SelectCustomersList()
        {
            DataTable dt = new DataTable();
            string _ErrorMsg = "";
            using (SqlConnection nowConnection = new SqlConnection(ConnectionString))//使用連接字串初始SqlConnection物件連接資料庫
            {
                nowConnection.Open();//開啟連線
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = @"    SELECT TOP 100 [CustomerID]
                                                ,[CompanyName]
                                                ,[ContactName]
                                                ,[ContactTitle]
                                                ,[Address]
                                                FROM [Customers]";
                    command.Connection = nowConnection;//資料庫連接
                    try
                    {
                        SqlDataReader dr = command.ExecuteReader();//執行並回傳DataReader
                        dt.Load(dr);
                    }
                    catch (Exception ex)
                    {
                        _ErrorMsg = ex.Message;
                    }
                }
            }
            return dt != null && dt.Rows.Count > 0 ? dt.AsEnumerable().Select(m => new Works()
            {
                CustomerID = m.Field<string>("CustomerID"),
                CompanyName = m.Field<string>("CompanyName"),
                ContactName = m.Field<string>("ContactName"),
                ContactTitle = m.Field<string>("ContactTitle"),
                Address = m.Field<string>("Address")
            }).ToList() : new List<Works>()
            {
                new Works()
                {
                    ErrorMsg = _ErrorMsg
                }
            };
        }
    }
}