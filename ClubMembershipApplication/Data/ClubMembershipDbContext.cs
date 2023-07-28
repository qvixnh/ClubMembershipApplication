using ClubMembershipApplication.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembershipApplication.Data
{
    public class ClubMembershipDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //connection string: establish the path to our sqlitle db file 
            optionsBuilder.UseSqlite($"Data Source={AppDomain.CurrentDomain.BaseDirectory}ClubMembershipDb.db");
            base.OnConfiguring(optionsBuilder);
        }
        //create a table database structure for relevant model classes
        public DbSet<User> Users { get; set; }
        //-use DbSet generic type to (contain a reference to the user table )
        //EF uses "Users" to add users to "database tables" and retrieves data  from "database table"
        //---create a migration
    }
}
