﻿using Microsoft.EntityFrameworkCore;
using SpeedPassApp.Models;

namespace SpeedPassApp
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Order> Orders { get; set; }

    }
}