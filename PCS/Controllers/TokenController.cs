using PCS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;


namespace PCS.Controllers
{
    public class TokenController : ApiController
    {
        [AllowAnonymous]
        public string Get()
        {
            return "ok";
        }
        
        [AllowAnonymous]
        public string Post(AdminModel admin)
        {
         
        
             return JwtManager.GenerateToken(admin.Username);
           
            //return "ok";
            //throw new HttpResponseException(HttpStatusCode.Unauthorized);
        }

        /*
        public bool CheckUser(Admin admin)
        {
            // should check in the database
            return true;
        }*/
    }
}