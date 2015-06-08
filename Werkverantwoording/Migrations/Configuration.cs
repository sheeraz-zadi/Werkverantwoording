namespace Werkverantwoording.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Threading.Tasks;
    using Werkverantwoording.Migrations;
    using Werkverantwoording.Models;


    internal sealed class Configuration : DbMigrationsConfiguration<Werkverantwoording.DAL.TaskContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Werkverantwoording.DAL.TaskContext";
        }

        protected override void Seed(Werkverantwoording.DAL.TaskContext context)
        {
            var assignments = new List<Assignment>

           {
                  new Assignment { Description = "Programmeren"},
                  new Assignment { Description = "Overleg met de opdrachtgever"},
                  new Assignment { Description = "Testen"},
                  new Assignment { Description = "Oplevering"},
                  new Assignment { Description = "Technisch ontwerp maken"},
                  new Assignment { Description = "Documentatie schrijven"},
                  new Assignment { Description = "Database ontwerpen"},
                  new Assignment { Description = "Bedrijfsuitje"},
                  new Assignment { Description = "Ziek"},
                  new Assignment { Description = "Vrije dag"}

           };
            assignments.ForEach(s => context.Assignments.AddOrUpdate(i => i.Description, s));            
            context.SaveChanges();          
            
         
        }
    }
}
