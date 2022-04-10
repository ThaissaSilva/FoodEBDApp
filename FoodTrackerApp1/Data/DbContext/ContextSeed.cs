namespace FoodTrackerApp.Data.DbContext
{
    public static class ContextSeed
    {
        public static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            //Seed Roles    
            await roleManager.CreateAsync(new IdentityRole("Administrator"));
            await roleManager.CreateAsync(new IdentityRole("BasicUser"));

        }

        public static async Task SeedAdminAsync(UserManager<User> userManager)
        {
            //Seed Default User
            var defaultUser = new User
            {
                UserName = "admin@gmail.com",
                NormalizedUserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                EmailConfirmed = false,
                PhoneNumberConfirmed = false
            };

            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);

                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "Aa123**");
                    await userManager.AddToRoleAsync(defaultUser, "Administrator");
                    await userManager.AddToRoleAsync(defaultUser, "BasicUser");

                }
            }
        }
    }
}
