using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsShop.Data;
using WinFormsShop.Data.Entities;

namespace WinFormsShop
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            CategoryEntity category = new CategoryEntity();
            category.Title = "Ноутбуки";
            category.Priority = 1;
            category.DateCreated = DateTime.Now;
            category.Image = "1.jpg";
            MyDataContext context = new MyDataContext();
            context.Categories.Add(category);
            context.SaveChanges();
        }
    }
}
