using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.UserId).IsRequired();
            builder.Property(s => s.Number).IsRequired().HasMaxLength(50);
            builder.Property(s => s.CreateDate).IsRequired();
            builder.Property(s => s.BranchName).HasMaxLength(100);
            builder.Property(s => s.TotalAmount).HasColumnType("decimal(18,2)");
            builder.Property(s => s.BranchName).HasMaxLength(100);

            builder.HasMany(s => s.Items)
                .WithOne(si => si.Cart)
                .HasForeignKey(si => si.CartId);

            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(si => si.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
