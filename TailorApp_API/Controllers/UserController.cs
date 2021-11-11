using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TailorApp_API.Helpers;
using TailorApp_API.Repository;

namespace TailorApp_API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public ResponseHelper GetAllUsers()
        {
            var data = _userRepository.GetAll();
            return new ResponseHelper(1,data, new ErrorDef());
        }
    }
}
