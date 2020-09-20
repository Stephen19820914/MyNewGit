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
                    command.CommandText = @"    SELECT [CustomerID]
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

        public string InsertCustomers(WorksPara _WorksPara)
        {
            string _ErrorMsg = "";
            int ExecuteResult = 0;
            using (SqlConnection nowConnection = new SqlConnection(ConnectionString))//使用連接字串初始SqlConnection物件連接資料庫
            {
                nowConnection.Open();//開啟連線
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = @"INSERT INTO [Customers]
                                            (
                                               [CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address],
                                               [City], [Region], [PostalCode], [Country], [Phone],
                                               [Fax]
                                            )
                                            VALUES
                                            (
                                               @CustomerID, @CompanyName, @ContactName, @ContactTitle, @Address,
                                               @City, @Region, @PostalCode, @Country, @Phone,
                                               @Fax
                                            )";
                    command.Connection = nowConnection;//資料庫連接
                    command.Parameters.AddWithValue("@CustomerID", _WorksPara.CustomerID);
                    command.Parameters.AddWithValue("@CompanyName", _WorksPara.CompanyName);
                    command.Parameters.AddWithValue("@ContactName", _WorksPara.ContactName);
                    command.Parameters.AddWithValue("@ContactTitle", _WorksPara.ContactTitle);
                    command.Parameters.AddWithValue("@Address", _WorksPara.Address);
                    command.Parameters.AddWithValue("@City", _WorksPara.City);
                    command.Parameters.AddWithValue("@Region", _WorksPara.Region);
                    command.Parameters.AddWithValue("@PostalCode", _WorksPara.PostalCode);
                    command.Parameters.AddWithValue("@Country", _WorksPara.Country);
                    command.Parameters.AddWithValue("@Phone", _WorksPara.Phone);
                    command.Parameters.AddWithValue("@Fax", _WorksPara.Fax);
                    try
                    {
                        ExecuteResult = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        _ErrorMsg = ex.Message;
                    }
                }
            }
            if (String.IsNullOrEmpty(_ErrorMsg))
            {
                //沒有錯誤訊息
                if (ExecuteResult > 0)
                {
                    return true.ToString().ToLower();
                }
                else
                {
                    return false.ToString().ToLower();
                }
            }
            else
            {
                //有錯誤訊息
                return _ErrorMsg;
            }
        }

        public List<Works> EditCustomersList(WorksPara _WorksPara)
        {
            DataTable dt = new DataTable();
            string _ErrorMsg = "";
            using (SqlConnection nowConnection = new SqlConnection(ConnectionString))//使用連接字串初始SqlConnection物件連接資料庫
            {
                nowConnection.Open();//開啟連線
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = @"    SELECT [CustomerID]
                                                ,[CompanyName]
                                                ,[ContactName]
                                                ,[ContactTitle]
                                                ,[Address]
                                                ,[City]
                                                ,[Region]
                                                ,[PostalCode]
                                                ,[Country]
                                                ,[Phone]
                                                ,[Fax]
                                                FROM [Customers]
                                                WHERE [CustomerID] = @CustomerID";
                    command.Connection = nowConnection;//資料庫連接
                    command.Parameters.AddWithValue("@CustomerID", _WorksPara.CustomerID);
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
                Address = m.Field<string>("Address"),
                City = m.Field<string>("City"),
                Region = m.Field<string>("Region"),
                PostalCode = m.Field<string>("PostalCode"),
                Country = m.Field<string>("Country"),
                Phone = m.Field<string>("Phone"),
                Fax = m.Field<string>("Fax")
            }).ToList() : new List<Works>()
            {
                new Works()
                {
                    ErrorMsg = _ErrorMsg
                }
            };
        }

        public string UpdateCustomers(WorksPara _WorksPara)
        {
            string _ErrorMsg = "";
            int ExecuteResult = 0;
            using (SqlConnection nowConnection = new SqlConnection(ConnectionString))//使用連接字串初始SqlConnection物件連接資料庫
            {
                nowConnection.Open();//開啟連線
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = @"UPDATE [Customers]
                                            SET
                                                [CompanyName] = @CompanyName, 
                                                [ContactName] = @ContactName, 
                                                [ContactTitle] = @ContactTitle, 
                                                [Address] = @Address,
                                                [City] = @City, 
                                                [Region] = @Region, 
                                                [PostalCode] = @PostalCode, 
                                                [Country] = @Country, 
                                                [Phone] = @Phone,
                                                [Fax] = @Fax
                                            WHERE [CustomerID] = @CustomerID";
                    command.Connection = nowConnection;//資料庫連接
                    command.Parameters.AddWithValue("@CustomerID", _WorksPara.CustomerID);
                    command.Parameters.AddWithValue("@CompanyName", _WorksPara.CompanyName);
                    command.Parameters.AddWithValue("@ContactName", _WorksPara.ContactName);
                    command.Parameters.AddWithValue("@ContactTitle", _WorksPara.ContactTitle);
                    command.Parameters.AddWithValue("@Address", _WorksPara.Address);
                    command.Parameters.AddWithValue("@City", _WorksPara.City);
                    command.Parameters.AddWithValue("@Region", _WorksPara.Region);
                    command.Parameters.AddWithValue("@PostalCode", _WorksPara.PostalCode);
                    command.Parameters.AddWithValue("@Country", _WorksPara.Country);
                    command.Parameters.AddWithValue("@Phone", _WorksPara.Phone);
                    command.Parameters.AddWithValue("@Fax", _WorksPara.Fax);
                    try
                    {
                        ExecuteResult = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        _ErrorMsg = ex.Message;
                    }
                }
            }
            if (String.IsNullOrEmpty(_ErrorMsg))
            {
                //沒有錯誤訊息
                if (ExecuteResult > 0)
                {
                    return true.ToString().ToLower();
                }
                else
                {
                    return false.ToString().ToLower();
                }
            }
            else
            {
                //有錯誤訊息
                return _ErrorMsg;
            }
        }

        public string DeteleCustomers(WorksPara _WorksPara)
        {
            string _ErrorMsg = "";
            int ExecuteResult = 0;
            using (SqlConnection nowConnection = new SqlConnection(ConnectionString))//使用連接字串初始SqlConnection物件連接資料庫
            {
                nowConnection.Open();//開啟連線
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = @"DELETE FROM [Customers]
                                            WHERE [CustomerID] = @CustomerID";
                    command.Connection = nowConnection;//資料庫連接
                    command.Parameters.AddWithValue("@CustomerID", _WorksPara.CustomerID);
                    try
                    {
                        ExecuteResult = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        _ErrorMsg = ex.Message;
                    }
                }
            }
            if (String.IsNullOrEmpty(_ErrorMsg))
            {
                //沒有錯誤訊息
                if (ExecuteResult > 0)
                {
                    return true.ToString().ToLower();
                }
                else
                {
                    return false.ToString().ToLower();
                }
            }
            else
            {
                //有錯誤訊息
                return _ErrorMsg;
            }
        }
    }
}