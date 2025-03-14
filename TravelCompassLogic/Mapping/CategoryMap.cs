using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelCompassData.Models;

namespace TravelCompassLogic.Mapping
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {

            builder.HasKey(x => x.CategoryId);
            builder.Property(x => x.CategoryName).HasMaxLength(500);
        }
    }
}
