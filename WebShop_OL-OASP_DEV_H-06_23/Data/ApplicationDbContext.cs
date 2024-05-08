using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shared_OL_OASP_DEV_H_06_23.Interfaces;
using WebShop_OL_OASP_DEV_H_06_23.Models.Dbo.Common;
using WebShop_OL_OASP_DEV_H_06_23.Models.Dbo.CompanyModels;
using WebShop_OL_OASP_DEV_H_06_23.Models.Dbo.ProductModels;
using WebShop_OL_OASP_DEV_H_06_23.Models.Dbo.UserModel;


namespace WebShop_OL_OASP_DEV_H_06_23.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole,string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public ApplicationDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Address>().HasData(
                    new Address
                    {
                        Id = 1,
                        City = "Zagreb",
                        Created = DateTime.Now,
                        Country = "Hrvatska",
                        Street = "Maksimirska",
                        Number = "100",
                        Valid = true
                    }
            );



            modelBuilder.Entity<Company>().HasData(
                    new Company
                    {
                        Id = 1,
                        Created = DateTime.Now,
                        AddressId = 1,
                        FullName = "Tvrtka d.o.o.",
                        ShortName = "Tvrtka",
                        VAT = "71834573974",
                        Valid = true
                    }
                );


            base.OnModelCreating(modelBuilder);
        }


        public override int SaveChanges()
        {

            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is IBaseTableAtributes && (
                e.State == EntityState.Added || e.State == EntityState.Modified));


            foreach (var entityEntry in entries)
            {
                switch (entityEntry.State)
                {
                    case EntityState.Modified:
                        ((IBaseTableAtributes)entityEntry.Entity).Updated = DateTime.Now;
                        break;
                    case EntityState.Added:
                        ((IBaseTableAtributes)entityEntry.Entity).Valid = true;
                        ((IBaseTableAtributes)entityEntry.Entity).Created = DateTime.Now;
                        break;
                    default:
                        break;
                }

            }
            return base.SaveChanges();
        }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {

            var entries = ChangeTracker
            .Entries()
            .Where(e => e.Entity is IBaseTableAtributes && (
              e.State == EntityState.Added
              || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                switch (entityEntry.State)
                {
                    case EntityState.Deleted:
                        entityEntry.State = EntityState.Modified;
                        ((IBaseTableAtributes)entityEntry.Entity).Valid = false;
                        break;
                    case EntityState.Modified:
                        ((IBaseTableAtributes)entityEntry.Entity).Updated = DateTime.Now;
                        break;
                    case EntityState.Added:
                        ((IBaseTableAtributes)entityEntry.Entity).Valid = true;
                        ((IBaseTableAtributes)entityEntry.Entity).Created = DateTime.Now;
                        break;
                    default:
                        break;
                }

            }

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        #region Common
        public DbSet<Address> Addresss { get; set; }
        #endregion

        #region CompanyModels
        public DbSet<Company> Companys { get; set; }
        #endregion
        #region ProductModels
        public DbSet<ProductCategory> ProductCategorys { get; set; }
        public DbSet<ProductItem> ProductItems { get; set; }
        #endregion


    }
}
