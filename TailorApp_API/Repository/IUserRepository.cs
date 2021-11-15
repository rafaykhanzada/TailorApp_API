using DataAccessLayer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TailorApp_API.Models;

namespace TailorApp_API.Repository
{
    public interface IUserRepository: IRepositoryBase<User>
    {
        public Task<IdentityResult> SignUpAsync(SignUpModel model);
        public Task<String> SignInAsync(SignInModel model);
        public Task<IdentityResult> CreateRoleAsync();
        public Task<IdentityResult> AddRoleAsync(User user, String role);
        public Task<User> FindByIdAsync(String Id);

    }
}
