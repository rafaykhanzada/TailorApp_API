using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TailorApp_API.Repository
{
    public class UserRepository : IUserRepository
    {
        public Task<IActionResult> GetAllUser()
        {
            throw new NotImplementedException();
        }
    }
}
