using DataAccessLayer;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TailorApp_API.Models;

namespace TailorApp_API.Factory
{
    public class AuthModelFactory
    {
        private readonly UserManager<User> _userManager;

        public AuthModelFactory(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public static Auth GetAuthModel(User model)
        {
            Auth auth = new Auth();
            if (model!=null)
            {
               
                auth.CustomerId = model.CustomerId;
                auth.Email = model.Email;
                auth.UserID = model.Id;
                auth.Name = model.FirstName + " " + model.LastName;
                return auth;
            }
            return auth;
        }
    }
}
