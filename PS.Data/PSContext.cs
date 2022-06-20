using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PS.Domain;
using PS.Data.Configurations;
using System.Linq;

namespace PS.Data
{
    public class PSContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Chemical> Chemicals { get; set; }
        public DbSet<Biological> Biologicals { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Facture> Factures { get; set; }
        public DbSet<Client> Clients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source =(localdb)\MSSQLLOCALDB;
Initial Catalog =ProductStoreDb; integrated security = true")
                .UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chemical>().ToTable("Chemicals");
            modelBuilder.Entity<Biological>().ToTable("Biological");

            modelBuilder.Entity<Chemical>().OwnsOne(p => p._Address,
                myaddres => {
                    myaddres.Property(a => a.City).HasMaxLength(50).IsRequired().HasColumnName("MyCity");
                    myaddres.Property(a => a.StreetAddress).HasMaxLength(50).IsRequired().HasColumnName("MyStreet");


                });

            //modelBuilder.Entity<Facture>()
            //    .HasKey(f => new { f.ProductFk, f.ClientFk, f.DateAchat });
            //modelBuilder.Entity<Facture>().HasOne(f => f.Client).WithMany(c => c.Factures)
            //    .HasForeignKey(f => f.ClientFk);
            //modelBuilder.Entity<Facture>().HasOne(f => f.Product).WithMany(p => p.Factures)
            //    .HasForeignKey(f => f.ProductFk);

            modelBuilder.Entity<Product>().HasMany(p => p.Clients)
                .WithMany(c => c.Products)
                .UsingEntity<Facture>(
                    j => j.HasOne(f => f.Client).WithMany(c => c.Factures)
                    .HasForeignKey(f => f.ClientFk),
                    j => j.HasOne(f => f.Product).WithMany(p => p.Factures)
                    .HasForeignKey(f => f.ProductFk),
                    j=>j.HasKey(f=>new { f.ClientFk,f.ProductFk,f.DateAchat})
                );


            var query = modelBuilder.Model
                .GetEntityTypes()
                .SelectMany(e => e.GetProperties())
                .Where(p => p.ClrType == typeof(string) &&
                p.Name.StartsWith("Name"));

            foreach (var item in query)
            {
                item.SetColumnName("MyName");
            }

            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.Entity<Provider>().Ignore(p => p.ConfirmPassword);        
        }

        //public PSContext()
        //{
        //    Database.EnsureCreated();
        //}

    }
}
