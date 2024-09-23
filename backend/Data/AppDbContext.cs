using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;
using Microsoft.EntityFrameworkCore;


namespace backend.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Report> Reports { get; set; }

        // We need that because in the program calss we initiated the DB context with options (currently DB name, in the future Connection string)
        public AppDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Init some basic data.

            // List<Report> reports = new List<Report>{
            //     new Report
            //  {
            //      Id = 1,
            //      Description = "First Report",
            //      Hours = 3.5

            //  },
            //  new Report
            //  {
            //      Id = 2,
            //      Description = "Second Report",
            //      Hours = 3
            //  }
            // };

            // modelBuilder.Entity<Report>().HasData(reports);
            ;

        }

    }
}