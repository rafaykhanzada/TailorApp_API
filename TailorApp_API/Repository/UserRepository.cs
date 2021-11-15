using DataAccessLayer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TailorApp_API.DataContext;
using TailorApp_API.Helpers;
using TailorApp_API.Models;

namespace TailorApp_API.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public UserRepository(ApplicationDbContext context, UserManager<User> userManager,SignInManager<User> signInManager,RoleManager<IdentityRole> roleManager,IConfiguration configuration) : base(context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }
        public async Task<IdentityResult> SignUpAsync([FromBody] SignUpModel model)
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
            var userExist = await _userManager.FindByEmailAsync(user.Email);
            if (userExist==null)
            {
                await _userManager.CreateAsync(user, model.Password);
                await CreateRoleAsync();
                await _userManager.GetRolesAsync(user);
            }
            return new IdentityResult();
        }
        public async Task<String> SignInAsync(SignInModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
            if (!result.Succeeded)
            {
                return null;
            }
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,model.Email),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };
            var authSigninKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JWT:Secret"]));
            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddDays(1),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256Signature));
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<IdentityResult> CreateRoleAsync()
        {
            if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            if (!await _roleManager.RoleExistsAsync(UserRoles.User))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));
            return new IdentityResult();
        }
        public async Task<IdentityResult> AddRoleAsync(User user,String role)
        {
           var result = await _userManager.AddToRoleAsync(user, role);
            return result;
        }
        public async Task<User> FindByIdAsync(String Id)
        {
            var result = await _userManager.FindByIdAsync(Id);
            return result;
        }
    }
}
