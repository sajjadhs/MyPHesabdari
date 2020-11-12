using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyPHesabdari.Model
{
    public class MyDbContext : DbContext, IMyContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Cost> Costs { get; set; }
        public virtual DbSet<Expense> Expenses { get; set; }
        public virtual DbSet<CurrencyUnit> CurrencyUnits { get; set; }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CurrencyUnit>().HasData(
                new CurrencyUnit
                {
                    Id = 1,
                    Name = "TurkLira"
                }, new CurrencyUnit
                {
                    Id = 2,
                    Name = "Toman"
                }
            );
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
