using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Mission8_Group_1_12.Models
{
    public class listEntryContext : DbContext
    {
        public listEntryContext(DbContextOptions<listEntryContext> options) : base(options)
        {


        }

        public DbSet<listEntry> listEntry { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            // populates the Category database with the CategoryIDs along with their corresponding name options.

            mb.Entity<Category>().HasData(

                new Category { CategoryID = 1, CategoryName = "Home" },
                new Category { CategoryID = 2, CategoryName = "School" },
                new Category { CategoryID = 3, CategoryName = "Work" },
                new Category { CategoryID = 4, CategoryName = "Church" }

            );

            mb.Entity<listEntry>().HasData(
                new listEntry
                {
                    TaskID = 1,
                    Task = "Do homework",
                    DueDate = "2-22-2023",
                    Quadrant = 1,
                    CategoryID = 1,
                    Completed = false

                }

                );


        }
    }
}
