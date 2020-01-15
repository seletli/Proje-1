using TubeRehber.Core.Map;
using TubeRehber.Model.Entities;


namespace TubeRehber.Map.EntityMaps
{
    public class CategoryMap:CoreMap<Category>
    {
        public CategoryMap()
        {
            ToTable("dbo.Categories");
            Property(cat => cat.CategoryName).IsRequired().HasMaxLength(20);

            HasMany(cat => cat.Channels)
                .WithRequired(channel => channel.Category)
                .HasForeignKey(channel => channel.CategoryID)
                .WillCascadeOnDelete(false);

            
        }
    }
}
