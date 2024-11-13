using EndPoint.Models.DomainModels.PlanAggregates;
using Microsoft.EntityFrameworkCore;
using System;

namespace EndPoint.Models
{
    public class PlanDbContext:DbContext
    {

        public PlanDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Plan>? Plan { get; set; }

    }
}
