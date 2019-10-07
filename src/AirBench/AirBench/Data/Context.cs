using AirBench.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace AirBench.Data
{
    public class Context : DbContext, IContext
    {
        public DbSet<Bench> Benches { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<User> Users { get; set; }

        public Context()
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            var benchEntity = modelBuilder.Entity<Bench>();
            benchEntity.Property(b => b.Latitude).HasPrecision(9, 6);
            benchEntity.Property(b => b.Longitude).HasPrecision(9, 6);
        }
    }
}