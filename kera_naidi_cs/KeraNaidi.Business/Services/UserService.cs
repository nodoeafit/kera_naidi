using System;
using System.Text;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using KeraNaidi.Data.Entities;
using KeraNaidi.Data.Models;
using KeraNaidi.Interfaces;
using Microsoft.IdentityModel.Tokens;
using Microsoft.IdentityModel;
using System.IdentityModel.Tokens.Jwt;





namespace Quetzalcoatl.Business.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public UserService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        public async Task<TokenResponse> Login(LoginModel loginModel)
        {
            var user = await _userManager.FindByNameAsync(loginModel.UserName);
            if(user != null && await _userManager.CheckPasswordAsync(user, loginModel.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var authSignKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]));
                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddDays(10),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSignKey, SecurityAlgorithms.HmacSha256)
                );

                return new TokenResponse(){
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    Expiration = token.ValidTo,
                    UserName = user.UserName
                };
            }
            return new TokenResponse();
        }

        public async Task<bool> RegisterAdmin(RegisterModel registerModel)
        {
            var userExists = await _userManager.FindByNameAsync(registerModel.UserName);
            if(userExists != null)
            {
                return false;
            }
            
            ApplicationUser user = new ApplicationUser()
            {
                Email = registerModel.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = registerModel.UserName
            };

            var result = await _userManager.CreateAsync(user, registerModel.Password);
            if(!result.Succeeded)
            {
                return false;
            }

            if(!await _roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            }

            if(!await _roleManager.RoleExistsAsync(UserRoles.User))
            {
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));
            }

            if(await _roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await _userManager.AddToRoleAsync(user, UserRoles.Admin);
            }

            return true;
        }

        public async Task<bool> RegisterUser(RegisterModel registerModel)
        {
            var userExists = await _userManager.FindByNameAsync(registerModel.UserName);

            if(userExists != null)
            {
                return false;
            }

            ApplicationUser user = new ApplicationUser()
            {
                Email= registerModel.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = registerModel.UserName
            };

            var result = await _userManager.CreateAsync(user, registerModel.Password);
            if(!result.Succeeded)
            {
                return false;
            }
            return true;
        }

        public async Task SeedAdmin()
        {
            
            await RegisterAdmin(new RegisterModel() {
                Email = "dracvs@gmail.com",
                Password = "NissanGTR2020$",
                UserName = "Dracvs"
            });

            await RegisterAdmin(new RegisterModel()
            {
                Email = "lucilapg@yahoo.com",
                Password = "PowerDrive2022$",
                UserName = "Lucila"
            });
        }
    }
}
