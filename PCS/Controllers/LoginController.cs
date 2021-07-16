using PCS.Models;
using PCS.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PCS.Controllers
{   [EnableCors(origins:"*",headers:"*",methods:"*")]
    [AllowAnonymous]
    public class LoginController : ApiController
    {
        PCSEntities db = new PCSEntities();

        public IHttpActionResult PostLogin(AdminModel admin)
        {
            var DataItem = from data in db.Admin
                           where data.Username == admin.Username && data.Password == admin.Password
                           select data;

            foreach(var Data in DataItem)
            {
                if(Data != null)
                {
                    ResponseData data = new Models.ResponseData()
                    {
                        Token = JwtManager.GenerateToken(admin.Username)
                    };
                    return Ok(data);
                }
            }
            return Ok(new Models.ResponseData { Code = 401 ,ErrorMessage = "帳號密碼錯誤"});
        }
    }
}
