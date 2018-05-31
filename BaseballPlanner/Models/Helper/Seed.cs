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
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<User>>();

            foreach (var roleName in RoleNames.ROLES)
            {
                var roleExist = await RoleManager.RoleExistsAsync(roleName);

                if (!roleExist)
                    await RoleManager.CreateAsync(new IdentityRole(roleName));
            }

            // create default admin user for initial configuration
            var defaultAdmin = new User
            {
                UserName = configuration.GetSection("UserSettings")["Mail"],
                Email = configuration.GetSection("UserSettings")["Mail"]
            };

            string password = configuration.GetSection("UserSettings")["Password"];
            var user = await UserManager.FindByEmailAsync(configuration.GetSection("UserSettings")["Mail"]);
            if (user == null)
            {
                var createPowerUser = await UserManager.CreateAsync(defaultAdmin, password);
                if (createPowerUser.Succeeded)
                    await UserManager.AddToRoleAsync(defaultAdmin, RoleNames.ROLE_ADMIN);
            }
        }
    }
}
