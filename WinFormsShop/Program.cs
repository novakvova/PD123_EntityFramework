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
                    CategoryEntity category = new CategoryEntity
                    {
                        Image = "laptop.jpg",
                        DateCreated = DateTime.Now,
                        Priority = 1,
                        Title = "Ноутбуки"
                    };
                    dataContext.Categories.Add(category);
                    dataContext.SaveChanges();
                    //MessageBox.Show("Тут категоірй немає");
                }
            }
        }
    }
}
