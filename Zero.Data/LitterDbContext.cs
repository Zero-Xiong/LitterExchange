using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zero.Model;
using Zero.Model.Configuration;

namespace Zero.Data
{
    public class LitterDbContext : DbContext
    {
        public LitterDbContext() : base("DbConnect")
        {
            Database.SetInitializer<LitterDbContext>(null);
        }

        public DbSet<Category> Categorys { get; set; }

        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new ItemConfiguration());

            modelBuilder.Configurations.Add(new CategoryConfiguration());
        }
    }
}
