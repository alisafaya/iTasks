using System;
using System.Collections.Generic;
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
        public string Name { get; set; }
        public string Description { get; set; }
        public iTaskPriority Priority { get; set; }
        public bool Complete { get; set; }
        public iTaskType Type { get; set; }
        public virtual ApplicationUser User { get; set; }
    }

}