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

        }

        public DbSet<CategoryEntity> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Integrated Security=True;Initial Catalog=pd123Shop;");
        }
    }
}
