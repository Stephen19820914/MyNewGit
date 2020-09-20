using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class WorksViewModel
    {
        [Required(ErrorMessage ="客戶ID未填！")]
        public string CustomerID { get; set; }
        [Required(ErrorMessage = "公司名稱未填！")]
        public string CompanyName { get; set; }
        [Required(ErrorMessage = "聯絡人未填！")]
        public string ContactName { get; set; }
        [Required(ErrorMessage = "聯絡人職稱未填！")]
        public string ContactTitle { get; set; }
        [Required(ErrorMessage = "地址未填！")]
        public string Address { get; set; }
        [Required(ErrorMessage = "城市未填！")]
        public string City { get; set; }
        [Required(ErrorMessage = "地區未填！")]
        public string Region { get; set; }
        [Required(ErrorMessage = "郵遞區號未填！")]
        public string PostalCode { get; set; }
        [Required(ErrorMessage = "國家未填！")]
        public string Country { get; set; }
        [Required(ErrorMessage = "電話未填！")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "傳真未填！")]
        public string Fax { get; set; }
        public int pageCnt { get; set; }
        public int pageRows { get; set; }
        public int DataRows { get; set; }

        public string ErrorMsg { get; set; }
    }
}