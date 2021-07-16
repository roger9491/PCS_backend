using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PCS.Models
{
    public class ResponseData
    {
        public int Code { get; set; } = 200;
        public string Token { get; set; }
        public string ErrorMessage { get; set; }
    }
}