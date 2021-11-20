using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TailorApp_API.Models
{
    public class Auth
    {
        public String UserID { get; set; }
        public int CustomerId { get; set; }
        public String Name { get; set; }
        public String Email { get; set; }
        public IList<string> Roles { get; set; }
        public String JWT { get; set; }
    }
}
