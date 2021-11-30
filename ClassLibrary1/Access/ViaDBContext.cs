using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ClassLibrary1.Models;

namespace ClassLibrary1.Access
{
    public class ViaDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Adult> Adults { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = C:\Users\freum\source\repos\Assign1\ClassLibrary1\VIA.db");
        }
    }
}
