using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PS.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("MyCategories");
            builder.HasKey(c => c.CategoryKey);
            builder.Property(p => p.Name)
                .HasMaxLength(50)
                .IsRequired()
                .HasColumnName("CategoryName")
                .HasDefaultValue("Cat");

            //builder.HasMany(c => c.Products)
            //    .WithOne(p => p.Category)
            //    .HasForeignKey(p => p.CategoryRef)
            //    .OnDelete(DeleteBehavior.ClientSetNull);

        }
    }
}
