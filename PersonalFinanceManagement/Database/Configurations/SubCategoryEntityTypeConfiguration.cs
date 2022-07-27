using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalFinanceManagement.Database.Entities;

namespace PersonalFinanceManagement.Database.Configurations
{
    public class SubCategoryEntityTypeConfiguration : IEntityTypeConfiguration<SubCategoryEntity>
    {
        public void Configure(EntityTypeBuilder<SubCategoryEntity> builder)
        {
            builder.ToTable("subcategories");
            builder.HasKey(t => t.Code);

            builder.Property(x => x.Code).IsRequired();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.ParentCode).IsRequired();


        }
    }
}
