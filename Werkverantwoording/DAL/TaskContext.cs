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
        public DbSet<Day> Days { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Progress> Progresses { get; set; }
    }
}