using EF_PD123.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text;

namespace EF_DP123
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            AppEFContext context = new AppEFContext();
            //var car = context.Cars.SingleOrDefault(x => x.Id == 2);
            //if(car!=null)
            //{
            //    //car.Name = "Бичок";
            //    //context.SaveChanges(); 
            //    context.Cars.Remove(car);
            //    context.SaveChanges();
            //}

            //Car car = new Car()
            //{
            //    Name = "Жигуль звичаний",
            //    Mark="Жигуль",
            //    Model="2107"
            //};
            //context.Cars.Add(car);
            //context.SaveChanges();

            //City city = new City()
            //{
            //    Name="Люблін",
            //    CountryId=1
            //};
            //context.Cities.Add(city);
            //context.SaveChanges();


            var list = context.Cities.
                Include(x=>x.Country).ToList();
            foreach (var item in list)
            {
                Console.WriteLine($"{item.Id}\t{item.Name}\t {item.Country.Name}");
            }

        }
    }
}

