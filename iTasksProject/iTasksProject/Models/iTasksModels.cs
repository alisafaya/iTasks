using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

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
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public iTaskPriority Priority { get; set; }
        public bool Complete { get; set; }
        public iTaskType Type { get; set; }
        public virtual ApplicationUser User { get; set; }
    }

    public class AdminViewModel
    {
        public virtual List<ApplicationUser> Users { get; set; }
        public virtual List<ContactMessageModel> Messages { get; set; }
    }

    public class iTaskViewModel
    {
        public iTask task { get; set; }
        public List<iTask> tasks { get; set; }
    }

    public class ContactMessageModel
    {
        public int Id { get; set; }

        public string userName { get; set; }

        [Required]
        [EmailAddress]
        public string userEmail { get; set; }

        public string subject { get; set; }

        public string message { get; set; }

    }
}