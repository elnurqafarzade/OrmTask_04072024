using Microsoft.EntityFrameworkCore;
using OrmTask_04072024.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrmTask_04072024.DAL
{
    public class DataContext : DbContext
    {

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Books> Books { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-D89M4VG9\\SQLEXPRESS;Database=_ORM_Database;Trusted_Connection=True;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}


