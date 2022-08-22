using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsShop.Data.Entities;

namespace WinFormsShop.Data
{
    public class MyDataContext : DbContext
    {
        public MyDataContext()
        {
            //Якщо міграцій немає, автоматично їх запускаємо (БД створиться автоматично)
            this.Database.Migrate();
        }

        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<ProductImageEntity> ProductImages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Integrated Security=True;Initial Catalog=pd123Shop;");
        }
        //Fluent API
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ProductImageEntity>(x => 
                x.ToTable("tblProductImages")
            );
        }
    }
}
