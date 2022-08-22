using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsShop.Data;
using WinFormsShop.Data.Entities;

namespace WinFormsShop
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            SeedData();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CategoryForm());
        }
        static void SeedData()
        {
            using (MyDataContext dataContext = new MyDataContext())
            {
                if(!dataContext.Categories.Any())
                {
                    CategoryEntity laptop = new CategoryEntity
                    {
                        Image = "laptop.jpg",
                        DateCreated = DateTime.Now,
                        Priority = 1,
                        Title = "Ноутбуки"
                    };
                    dataContext.Categories.Add(laptop);
                    dataContext.SaveChanges();

                    CategoryEntity game = new CategoryEntity
                    {
                        Image = "game.png",
                        DateCreated = DateTime.Now,
                        Priority = 2,
                        ParentId=laptop.Id,
                        Title = "Ігрові"
                    };
                    dataContext.Categories.Add(game);
                    dataContext.SaveChanges();

                    CategoryEntity ofice = new CategoryEntity
                    {
                        Image = "office.jpg",
                        DateCreated = DateTime.Now,
                        Priority = 3,
                        ParentId = laptop.Id,
                        Title = "Офісні"
                    };
                    dataContext.Categories.Add(ofice);
                    dataContext.SaveChanges();
                    //MessageBox.Show("Тут категоірй немає");
                }
            }
        }
    }
}
