using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalFinanceManagement.Database.Entities;
using PersonalFinanceManagement.Models;

namespace PersonalFinanceManagement.Database.Configurations
{
    public class TransactionEntityTypeConfiguration : IEntityTypeConfiguration<TransactionEntity>
    {
        public void Configure(EntityTypeBuilder<TransactionEntity> builder)
        {
            builder.ToTable("transactions");
            builder.HasKey(t => t.Id);
            builder.Property(x=>x.Id).IsRequired();
            builder.Property(x => x.Beneficiaryname);
            builder.Property(x => x.Date).IsRequired();
            builder.Property(x => x.Direction).IsRequired().HasConversion<string>();
            builder.Property(x => x.Amount).IsRequired();
            builder.Property(x => x.Description);
            builder.Property(x => x.Currency).IsRequired();
            builder.Property(x => x.Mcc);
            builder.Property(x => x.Kind).IsRequired().HasConversion<string>();

        }
    }
}
