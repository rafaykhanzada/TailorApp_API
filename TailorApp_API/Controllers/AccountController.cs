using DataAccessLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TailorApp_API.DataContext;
using TailorApp_API.Models;
using TailorApp_API.Repository;

namespace TailorApp_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;

        public AccountController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        [HttpPost("signup")]
        [AllowAnonymous]
        public async Task<IdentityResult> SignUp([FromBody] SignUpModel model)
        {
            var user = new User()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Address = model.Address,
                Country = model.Country,
                Email = model.Email,
                UserName = model.Email
            };
            var result = await _userManager.CreateAsync(user,model.Password);
            if (result.Succeeded)
            {
                return result;
            }
            return null;
        }
        
    }
}
