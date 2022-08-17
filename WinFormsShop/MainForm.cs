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
            CategoryAddForm dlg = new CategoryAddForm();
            if(dlg.ShowDialog()==DialogResult.OK)
            {
                CategoryEntity category = new CategoryEntity();
                category.Title = dlg.mTitle;
                category.Priority = dlg.mPriotiry;
                category.DateCreated = DateTime.Now;
                category.Image = "1.jpg";
                MyDataContext context = new MyDataContext();
                context.Categories.Add(category);
                context.SaveChanges();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            tvCategory.Nodes.Clear();
            MyDataContext dataContext = new MyDataContext();

            foreach(var c in dataContext.Categories
                .Where(x=>x.ParentId==null).ToList())
            {
                TreeNode node = new TreeNode(c.Title);
                node.Tag = c;
                node.Nodes.Add("");
                //node.Nodes.Add(c.Image);
                tvCategory.Nodes.Add(node);
            }
        }

        private void tvCategory_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //MessageBox.Show("Node click");
            var hitTest = e.Node.TreeView.HitTest(e.Location);
            if (hitTest.Location != TreeViewHitTestLocations.PlusMinus)
                return;
            if (!e.Node.IsExpanded)
                return;
            //MessageBox.Show("Node click "+ e.Node.Text);
            var item = e.Node.Tag as CategoryEntity;
            MessageBox.Show(item.Id.ToString());
        }
    }
}
