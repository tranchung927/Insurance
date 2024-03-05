using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting;
using InsuranceCore.Builder;
using InsuranceCore.Data.Permission;
using InsuranceCore.Data;

namespace InsuranceCore.DataContext
{
    /// <summary>
    /// Class used to initialize Database if the database is empty (test data).
    /// </summary>
    public static class DbInitializer
    {
        private const string UserRole = "User";
        private const string RedactorRole = "Redactor";
        private const string AdminRole = "Admin";

        private static async Task GenerateDefaultRoles(RoleManager<Role> roleManager, InsuranceDbContext context)
        {
            var userRole = await new RoleBuilder(roleManager)
                .WithName(UserRole)
                .WithCanReadAllOnAllResourcesExceptAccount()
                .WithCanCreateOwn(PermissionTarget.Comment)
                .WithCanUpdateOwn(PermissionTarget.Comment)
                .WithCanCreateOwn(PermissionTarget.Like)
                .WithCanUpdateOwn(PermissionTarget.Like)
                .WithCanDeleteOwn(PermissionTarget.Comment)
                .WithCanDeleteOwn(PermissionTarget.Like)
                .WithCanReadOwn(PermissionTarget.Account)
                .WithCanDeleteOwn(PermissionTarget.Account)
                .WithCanUpdateOwn(PermissionTarget.Account)
                .Build();

            await new RoleBuilder(roleManager)
                .WithName(RedactorRole)
                .WithCanCreateAll(PermissionTarget.Category)
                .WithCanCreateAll(PermissionTarget.Tag)
                .WithCanCreateOwn(PermissionTarget.Post)
                .WithCanUpdateOwn(PermissionTarget.Post)
                .WithCanDeleteOwn(PermissionTarget.Post)
                .Build();

            await new RoleBuilder(roleManager)
                .WithName(AdminRole)
                .WithCanReadAllOnAllResourcesExceptAccount()
                .WithCanCreateAllOnAllResources()
                .WithCanUpdateAllOnAllResources()
                .WithCanDeleteAllOnAllResources()
                .WithCanReadAll(PermissionTarget.Account)
                .Build();

            await context.DefaultRoles.AddAsync(new DefaultRoles() { Role = userRole });
            await context.SaveChangesAsync();
        }

        private static async Task GenerateDefaultUsers(UserManager<User> userManager)
        {
            var users = new List<(User, string)>()
            {
                (new UserBuilder()
                .WithFirstName("Tran")
                .WithLastName("Chung")
                .WithEmail("chungtv@gmail.com")
                .WithUsername("chungtv")
                .Build(), "123456Aa@"),
                (new UserBuilder()
                .WithEmail("admin@gmail.com")
                .WithUsername("admin")
                .WithDescription("I'm admin")
                .Build(), "adminAa@")
            };
            foreach (var user in users)
            {
                await userManager.CreateAsync(user.Item1, user.Item2);
                var emailConfirmationToken = await userManager.GenerateEmailConfirmationTokenAsync(user.Item1);
                await userManager.ConfirmEmailAsync(user.Item1, emailConfirmationToken);
            }
        }

        private static void AssignRolesToDefaultUsers(InsuranceDbContext context)
        {
            context.UserRoles.AddRange(
                new UserRoleBuilder(context).WithUser("chungtv").WithRole(UserRole).Build(),
                new UserRoleBuilder(context).WithUser("admin").WithRole(UserRole).Build(),
                new UserRoleBuilder(context).WithUser("chungtv").WithRole(RedactorRole).Build(),
                new UserRoleBuilder(context).WithUser("admin").WithRole(AdminRole).Build()
            );
            context.SaveChanges();
        }

        /// <summary>
        /// Fill the database with <see cref="InsuranceDbContext"/> (Entity Framework).
        /// The methods will fill the database only if no <see cref="Role"/> exists
        /// (No existing roles means that the database is still empty / not used).
        /// </summary>
        /// <param name="context"></param>
        /// <param name="roleManager"></param>
        /// <param name="userManager"></param>
        public static async Task SeedWithDefaultValues(InsuranceDbContext context, RoleManager<Role> roleManager,
            UserManager<User> userManager)
        {
            if (!context.Roles.Any())
            {
                await GenerateDefaultRoles(roleManager, context);
                await GenerateDefaultUsers(userManager);
                AssignRolesToDefaultUsers(context);
            }
        }
    }
}
