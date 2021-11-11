using DataAccessLayer.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
   public class User : HasId
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public int Usertype { get; set; }

    }
}
