using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zero.Model;

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

            //modelBuilder.Entity<Item>()
            //    .HasRequired(c => c.Categories)
            //    .Map(
            //        t => t.MapLeftKey("ItemId")
            //        .MapRightKey("CategoryId")
            //        .ToTable("CategoryItem")
            //    );
        }
    }
}
