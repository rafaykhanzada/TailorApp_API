using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TailorApp_API.Repository
{
    public interface IUserRepository
    {
        public Task<IActionResult> GetAllUser();
    }
}
