using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIApp.Models
{
    public class UserInfo
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string PassCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Promotions { get; set; }
        public string PhoneNumber { get; set; }
        public bool ShowPassCode { get; set; }
        public bool LoggedIn { get; set; }
        public string FullName { get { return FirstName + " " + LastName; } set { } }
    }
}