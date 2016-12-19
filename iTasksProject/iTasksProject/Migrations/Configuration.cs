namespace iTasksProject.Migrations
{
    using Controllers;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<iTasksProject.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(iTasksProject.Models.ApplicationDbContext context)
        {
            var rolestore = new RoleStore<IdentityRole>(context);
            var rolemanager = new RoleManager<IdentityRole>(rolestore);
            if (rolemanager.RoleExists("admin") == false)
            {
                rolemanager.Create(new IdentityRole("admin"));
            }
            var userstore = new UserStore<ApplicationUser>(context);
            var usermanager = new UserManager<ApplicationUser>(userstore);

            var user = new ApplicationUser { UserName = "Ali Safaya", Email = "ali@mail.com" };

            var result = new AccountController().Register(
                new Models.RegisterOrLoginViewModel {
                    RegisterViewModel = new RegisterViewModel {
                        UserName = "Ali Safaya", Email = "ali@mail.com" , Password ="Admin12345" ,ConfirmPassword = "Admin12345" } });


            if (user != null)
            {
                if (!usermanager.IsInRole(user.Id, "admin"))
                {
                    usermanager.AddToRole(user.Id, "admin");
                }
            }

        }
    }
}
