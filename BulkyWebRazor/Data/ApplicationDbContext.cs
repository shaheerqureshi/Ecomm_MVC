﻿using BulkyWebRazor.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyWebRazor.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) :base(options)
        {
            
        }
        public DbSet<Category> CategoriesRazorTbl { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Comedy", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Sci Fi", DisplayOrder = 3 },
                new Category { Id = 4, Name = "History", DisplayOrder = 4 }

                );

        }

    }
}