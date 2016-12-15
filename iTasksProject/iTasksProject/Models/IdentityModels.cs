using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace iTasksProject.Models
{
    public enum iTaskPriority
    {
        VeryImportant,
        Important,
        Scheduled,
        Reminder
    }

    public enum iTaskType
    {
        Daily,
        Weekly,
        Goal
    }

    public class iTask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public iTaskPriority Priority { get; set; }
        public bool Complete { get; set; }
        public iTaskType Type { get; set; }
        public virtual ApplicationUser User { get; set; }
    }

    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public byte[] ProfilePhoto { get; set; }
        public byte[] CoverPhoto { get; set; }
        public virtual ICollection<iTask> Tasks { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}