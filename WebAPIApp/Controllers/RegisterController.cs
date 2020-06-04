using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web.Http;
using WebAPIApp.Models;

namespace WebAPIApp.Controllers
{
    public class RegisterController : ApiController
    {
        // GET: api/Register
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Register/5
        public string Get(int id)
        {
            return "value";
        }
        [Route("api/Register/PostRegister")]
        [HttpPost]
        public async Task<UserInfo> PostRegister(UserInfo signUpModel)
        {

            string emailMsg = string.Empty;
            string emailSubject = string.Empty;

            Random random = new Random();
            String number = random.Next(0, 999999).ToString("D6");
            emailMsg = "Dear " + signUpModel.Email + ", <br /><br /> '" + number + "' is the password to Register <br /><br /> Thanks & Regards, <br /> umesh";
            emailSubject = " Registration OTP";

            try
            {

                await this.SendEmailAsync(signUpModel.Email, emailMsg, emailSubject);
            }
            catch (Exception ex)
            {

            }
            signUpModel.ShowPassCode = true;
            return signUpModel;

        }
        // POST: api/Register
        public async Task<UserInfo> Post(UserInfo signUpModel)
        {
            string emailMsg = string.Empty;
            string emailSubject = string.Empty;

            Random random = new Random();
            String number = random.Next(0, 999999).ToString("D6");
            emailMsg = "Dear " + signUpModel.Email + ", <br /><br /> '" + number + "' is the password to Login <br /><br /> Thanks & Regards, <br /> umesh";
            emailSubject = "Login OTP";
            signUpModel.ShowPassCode = true;

            // CryptoEngine.Encrypt(signUpModel.Password)
            //DB connection and checking Email once Email is not avaialble in DB we can isert record into DB
            //Usp_CreateUser stored procedure.
            //
            //Insert into dbo.UserInfo (USerEmail,Password,Passcode) values (singupmodel.  etc)
            // Sending Email.  
            //DataTable datatable = AppConverters.CreateDataTable(userModel);
            //SqlCommand cmd = new SqlCommand("[Dic].[Usp_CreateUser]");
            //cmd.Parameters.AddWithValue("@UTT_UserAttribute", datatable).SqlDbType = SqlDbType.Structured;
            //cmd.Parameters.AddWithValue("@UserId", 0).Direction = ParameterDirection.Output;
            //ExecuteInsertStoredProc(cmd);try      
            try
            {

                await this.SendEmailAsync(signUpModel.Email, emailMsg, emailSubject);
            }
            catch (Exception ex)
            {

            }

            return signUpModel;
        }

        // PUT: api/Register/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Register/5
        public void Delete(int id)
        {
        }
        public async Task<bool> SendEmailAsync(string email, string msg, string subject = "")
        {
            // Initialization.  
            bool isSend = false;

            try
            {
                // Initialization.  
                var body = msg;
                var message = new MailMessage();

                // Settings.  
                message.To.Add(new MailAddress(email));
                message.From = new MailAddress("umesh.6045@gmail.com");
                message.Subject = !string.IsNullOrEmpty(subject) ? subject : "";
                message.Body = body;
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    // Settings.  
                    smtp.UseDefaultCredentials = false;
                    var credential = new NetworkCredential
                    {
                        UserName = "umesh.6045@gmail.com",
                        Password = "j@nAkr!shnaven1ume$h"
                    };

                    // Settings.  
                    smtp.Credentials = credential;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;

                    // Sending  
                    await smtp.SendMailAsync(message);

                    // Settings.  
                    isSend = true;
                }
            }
            catch (Exception ex)
            {
                // Info  
                throw ex;
            }

            // info.  
            return isSend;
        }

    }
}
