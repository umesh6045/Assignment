using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIApp.Models;

namespace WebAPIApp.Controllers
{
    public class ValidateController : ApiController
    {
        // GET: api/Validate
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Validate/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Validate
        public UserInfo Post(UserInfo value)
        {
            if (!string.IsNullOrEmpty(value.PassCode))
            {
                value.LoggedIn = true;
                //Sp_ValidateOTP
                //Select statememet to get USer and we need to validate it with otp
                return value;
            }
            return value;
        }

        // PUT: api/Validate/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Validate/5
        public void Delete(int id)
        {
        }
    }
}
