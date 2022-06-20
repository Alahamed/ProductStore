using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PS.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .HasMany(p => p.Providers)
                .WithMany(p => p.Products)
                .UsingEntity(j => j.ToTable("Providings"));

            //builder.HasDiscriminator<int>("IsBilogical")
            //    .HasValue<Product>(0)
            //    .HasValue<Chemical>(2)
            //    .HasValue<Biological>(1);                

            builder
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryRef)
                //.OnDelete(DeleteBehavior.Cascade);//activer la supression en cascade
                .OnDelete(DeleteBehavior.ClientSetNull);//desactiver la supression en cascade 
        }
    }
}
