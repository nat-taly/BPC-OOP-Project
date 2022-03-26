using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppDatabase.Models;

namespace WebAppDatabase.Data
{
    public class ApplicationContext : DbContext
    {
        
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().HasOne<ItemsType>(g => g.ItemsType).WithMany(s => s.Items).HasForeignKey(s => s.TypeID);
            modelBuilder.Entity<Item>().HasOne<Unit>(g => g.Unit).WithMany(s => s.Items).HasForeignKey(s => s.UnitID);
        }

        public DbSet<Unit> Units { get; set; }
        public DbSet<ItemsType> ItemsTypes { get; set; }
        public DbSet<Item> Items { get; set; }
    }
}
