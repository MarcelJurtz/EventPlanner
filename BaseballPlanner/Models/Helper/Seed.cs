using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Planner.Models.Helper
{
    public static class Seed
    {
        public static async Task CreateRoles(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            //adding custom roles
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();

            foreach (var roleName in RoleNames.ROLES)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);

                if (!roleExist)
                    await roleManager.CreateAsync(new IdentityRole(roleName));
            }

            // create default admin user for initial configuration
            var defaultAdmin = new User
            {
                UserName = configuration.GetSection("UserSettings")["Mail"],
                Email = configuration.GetSection("UserSettings")["Mail"],
                Verified = true
            };

            string password = configuration.GetSection("UserSettings")["Password"];
            var user = await userManager.FindByEmailAsync(configuration.GetSection("UserSettings")["Mail"]);
            if (user == null)
            {
                var createPowerUser = await userManager.CreateAsync(defaultAdmin, password);
                if (createPowerUser.Succeeded)
                    await userManager.AddToRolesAsync(defaultAdmin, RoleNames.ROLES);
            }
        }
    }
}
