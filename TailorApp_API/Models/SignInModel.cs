using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TailorApp_API.Models
{
    public class SignInModel
    {
        [Required(ErrorMessage = "Email is Required"), EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }
        public bool Remember { get; set; }
    }
}
