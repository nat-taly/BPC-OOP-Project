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
            base.OnModelCreating(modelBuilder);
 
            modelBuilder.Entity<Item>().HasOne<ItemType>(g => g.ItemType).WithMany(s => s.Items).HasForeignKey(s => s.TypeID);
            modelBuilder.Entity<Item>().HasOne<Unit>(g => g.Unit).WithMany(s => s.Items).HasForeignKey(s => s.UnitID);
            
            modelBuilder.Entity<Item>().HasIndex(m => m.ItemName).IsUnique();
        } 

        public DbSet<Unit> Unit { get; set; }
        public DbSet<ItemType> ItemType { get; set; }
        public DbSet<Item> Item { get; set; }
    }
}
