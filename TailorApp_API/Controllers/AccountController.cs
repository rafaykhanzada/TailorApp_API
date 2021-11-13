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
        private readonly IUserRepository _userRepository;

        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpPost("signup")]
        [AllowAnonymous]
        public async Task<IActionResult> SignUpAsync([FromBody] SignUpModel model)
        {
            var result = await _userRepository.SignUpAsync(model);
            if (result.Succeeded)
            {
                return Ok(result);
            }
            return null;
        }
        [HttpPost("signin")]
        [AllowAnonymous]
        public async Task<IActionResult> SignInAsync([FromBody] SignInModel model)
        {
            var result = await _userRepository.SignInAsync(model);
            if (String.IsNullOrEmpty(result))
            {
                return Unauthorized();
            }
            return Ok(result);
        }

    }
}
