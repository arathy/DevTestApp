using System;
using DevTestApp.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DevTestApp.DAL
{

    public class DevTestContext : DbContext
    {
        public DbSet<RealTimeVotes> RealTimeVotes { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}