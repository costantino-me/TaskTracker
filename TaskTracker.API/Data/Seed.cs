using System.Collections.Generic;
using System.Linq;
using TaskTracker.API.Models;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace TaskTracker.API.Data
{
    public class Seed
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly DataContext _context;
        private readonly IMainRepository _repo;
        public Seed(UserManager<User> userManager, RoleManager<Role> roleManager, DataContext context, IMainRepository repo)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
            _repo = repo;
        }

        public void SeedUsers()
        {
            if (!_userManager.Users.Any())
            {
                var userData = System.IO.File.ReadAllText("Data/UserSeedData.json");
                var users = JsonConvert.DeserializeObject<List<User>>(userData);
                
                var roles = new List<Role>
                {
                    new Role{Name = "Member"},
                    new Role{Name = "Admin"}
                };

                foreach (var role in roles)
                {
                    _roleManager.CreateAsync(role).Wait();
                }

                foreach (var user in users)
                {
                    _userManager.CreateAsync(user, "password").Wait();
                    _userManager.AddToRoleAsync(user, "Member").Wait();
                }

                var adminUser = new User
                {
                    UserName = "Admin"
                };

                IdentityResult result = _userManager.CreateAsync(adminUser, "55OFq0xZKBI4sSf*8B89").Result;

                if (result.Succeeded)
                {
                    var admin = _userManager.FindByNameAsync("Admin").Result;
                    _userManager.AddToRolesAsync(admin, new[] {"Admin"}).Wait();
                }
            }
        }
    }
}