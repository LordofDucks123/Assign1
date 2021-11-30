using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Assign_2.Database 
{
    public class ProjectDB : DbContext
    {
        public DbSet<Adult> Courses { get; set; }
        public DbSet<Job> Programmes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // name of database
            optionsBuilder.UseSqlite(@"Data Source = C:\TRMO\.NET projects\DNPExamples\EFC\ViaExample\VIA.db");
        }
    }
}
