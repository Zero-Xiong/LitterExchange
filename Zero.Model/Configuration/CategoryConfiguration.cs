using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zero.Model.Configuration
{
    public class CategoryConfiguration : EntityTypeConfiguration<Category>
    {
        public CategoryConfiguration()
        {
            ToTable("Category");
            HasKey(c => c.Id);
            Property(c => c.Name).IsRequired().HasMaxLength(50);
            Property(c => c.Sequence).IsRequired();
            Property(c => c.Description).IsOptional();
            Property(c => c.DateCreated).IsRequired();
            Property(c => c.IsEnabled).IsRequired();

            HasMany(i => i.Items).WithOptional();
        }
    }
}
