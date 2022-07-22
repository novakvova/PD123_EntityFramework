using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_PD123.Data
{
    public class AppEFContext : DbContext
    {
        public AppEFContext()
        {
            //this.Database.EnsureCreated(); //Якщо БД немає, то вона створиться
            this.Database.Migrate();
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Integrated Security=True;Initial Catalog=pd123db22;");
        }
    }
}
