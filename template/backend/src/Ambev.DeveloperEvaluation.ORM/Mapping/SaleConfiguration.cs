using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable("Sales");

            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

            builder.Property(u => u.Number).IsRequired().HasMaxLength(10);
            builder.Property(u => u.TotalAmount).IsRequired();

            builder.Property(u => u.CustomerId).HasColumnType("uuid").IsRequired();
            builder.Property(u => u.BranchId).HasColumnType("uuid").IsRequired();

            builder.Property(u => u.CustomerName).IsRequired().HasMaxLength(100);
            builder.Property(u => u.BranchName).IsRequired().HasMaxLength(100);

            builder.HasMany(s => s.Products)
                   .WithOne()
                   .HasForeignKey(x => x.SaleId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(u => u.SaleStatus)
                .HasConversion<string>()
                .HasMaxLength(20);
        }
    }
}
