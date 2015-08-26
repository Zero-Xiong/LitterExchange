using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zero.Model.Configuration
{
    public class ItemConfiguration : EntityTypeConfiguration<Item>
    {
        public ItemConfiguration()
        {
            HasKey(c => c.Id);
            ToTable("Item");

            HasMany(i => i.Categories).WithMany(i => i.Items).Map(t => t.MapLeftKey("ItemId").MapRightKey("CategoryId").ToTable("CategoryItem"));
        }
    }
}
