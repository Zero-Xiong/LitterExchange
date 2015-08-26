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

            HasOptional(c => c.Items).WithMany().Map(t => t.MapKey("CategoryId").ToTable("CategoryItem"));
        }
    }
}
