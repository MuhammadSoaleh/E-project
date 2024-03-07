using dm.Constants;
using Microsoft.AspNetCore.Identity;

namespace dm.Data
{
    public class DbSeeder
    {
        public static async Task SeedDefaultData(IServiceProvider service)
        {
            var usrMngr = service.GetService<UserManager<IdentityUser>>();
            var roleMngr = service.GetService<RoleManager<IdentityRole>>();

            await roleMngr.CreateAsync(new IdentityRole(Roles.User.ToString()));
            await roleMngr.CreateAsync(new IdentityRole(Roles.Admin.ToString()));

            var admin = new IdentityUser
            {
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                EmailConfirmed = true,
            };

            var isUserExist = await usrMngr.FindByEmailAsync(admin.Email);
            if (isUserExist is null)
            {
                await usrMngr.CreateAsync(admin, "Admin@123");
                await usrMngr.AddToRoleAsync(admin, Roles.Admin.ToString());
            }
        }
    }
}
