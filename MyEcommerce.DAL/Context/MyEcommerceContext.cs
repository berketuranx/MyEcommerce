
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyEcommerce.DAL.Seed;
using MyEcommerce.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyEcommerce.DAL.Context
{
    public class MyEcommerceContext : IdentityDbContext<AppUser>
    {

        public MyEcommerceContext(DbContextOptions<MyEcommerceContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>().HasData(ProductSeed.products);
            builder.Entity<Category>().HasData(CategorySeed.categories);


            base.OnModelCreating(builder);
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=DESKTOP-3Q5USRG\\MSSQLSERVER01;Database=MyEcommerceDB;Trusted_Connection=True;");
        //}


    }
}
