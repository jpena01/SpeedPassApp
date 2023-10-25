using Microsoft.EntityFrameworkCore;
using SpeedPassApp.Models;
using System.ComponentModel.DataAnnotations;

namespace SpeedPassApp
{
    public class AppDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}