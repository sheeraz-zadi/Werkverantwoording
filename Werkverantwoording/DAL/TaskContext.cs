using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Werkverantwoording.Models;

namespace Werkverantwoording.DAL
{
    public class TaskContext : DbContext
    {
        public TaskContext() : base("TaskContext"){
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Day> Day { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Assignment> Assignment { get; set; }
        public DbSet<Progress> Progress { get; set; }
    }
}