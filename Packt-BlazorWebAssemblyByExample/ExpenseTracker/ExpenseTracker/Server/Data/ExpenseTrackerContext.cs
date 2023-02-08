﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ExpenseTracker.Shared;

namespace ExpenseTracker.Server.Data
{
    public class ExpenseTrackerContext : DbContext
    {
        public ExpenseTrackerContext (DbContextOptions<ExpenseTrackerContext> options)
            : base(options)
        {
        }

        public DbSet<ExpenseTracker.Shared.ExpenseType> ExpenseType { get; set; } = default!;

        public DbSet<ExpenseTracker.Shared.Expense> Expense { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExpenseType>().HasData(
                new ExpenseType { Type = "Airfare", Id = 1 },
                new ExpenseType { Type = "Lodging", Id = 2 },
                new ExpenseType { Type = "Meal", Id = 3 },
                new ExpenseType { Type = "Other", Id = 4 }
            );
        }
    }
}
