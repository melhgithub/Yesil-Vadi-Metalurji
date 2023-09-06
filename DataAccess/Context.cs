
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Context : DbContext
    {
        //public Context(DbContextOptions<Context> options) : base(options)
        //{
        //}

        //public Context()
        //{
        //}
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    if (modelBuilder == null)
        //        throw new ArgumentNullException("modelBuilder");

        //    foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        //    {
        //        entityType.SetTableName(entityType.DisplayName());
        //        entityType.GetForeignKeys()
        //            .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade)
        //            .ToList()
        //            .ForEach(fk => fk.DeleteBehavior = DeleteBehavior.Restrict);
        //    }

        //    base.OnModelCreating(modelBuilder);
        //}


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=176.53.40.162\\MSSQLSERVER2016;Database=YesilVadiMetalurjiDB;user=admindb;password=8M1fr79^t");
        }




        public DbSet<Suggestion> Suggestions { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<Footer> Footers { get; set; }
        public DbSet<Urunler> Urunlers { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<HomePage> HomePages { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<OfferDetail> OfferDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Production> Productions { get; set; }


    }
}
