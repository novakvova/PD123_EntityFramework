using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsShop.Data;
using WinFormsShop.Data.Entities;
using WinFormsShop.Helpers;

namespace WinFormsShop
{
    public partial class CategoryForm : Form
    {
        public CategoryForm()
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
                Bitmap bmp = new Bitmap(dlg.mImage);
                String dir = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "images");
                string fileSaveName = System.IO.Path.GetRandomFileName() + ".jpg";
                category.Image = fileSaveName;
                for (int i = 1; i < 6; i++)
                {
                    var bmpSave = ImageWorker.CompressImage(bmp, i * 32, i * 32);
                    string imageSave = System.IO.Path.Combine(dir, $"{i * 32}_" + fileSaveName);
                    bmpSave.Save(imageSave, ImageFormat.Jpeg);
                }
                //category.Image = "1.jpg";
                MyDataContext context = new MyDataContext();
                context.Categories.Add(category);
                context.SaveChanges();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            tvCategory.Nodes.Clear();
            MyDataContext dataContext = new MyDataContext();

            //ImageList myImageList = new ImageList();
            //myImageList.Images.Add("1", Image.FromFile("images\\1.jpg"));
            //tvCategory.ImageList = myImageList;
            tvCategory.ImageList = new ImageList();
            
            foreach (var c in dataContext.Categories
                .Where(x=>x.ParentId==null).ToList())
            {
                TreeNode node = new TreeNode(c.Title);
                tvCategory.ImageList.Images.Add(c.Id.ToString(), Image.FromFile($"images\\32_{c.Image}"));
                //node.ImageIndex = 0;
                node.ImageKey = c.Id.ToString();
                node.SelectedImageKey= c.Id.ToString();
                //tvCategory.ImageList
                //node.ima
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
            MyDataContext dataContext = new MyDataContext();
            var list = dataContext.Categories.Where(x => x.ParentId == item.Id).ToList();
            e.Node.Nodes.Clear();
            if(list.Count>0)
            {
                foreach (var c in list)
                {
                    TreeNode node = new TreeNode(c.Title);
                    tvCategory.ImageList.Images.Add(c.Id.ToString(), Image.FromFile($"images\\32_{c.Image}"));
                    //node.ImageIndex = 0;
                    node.ImageKey = c.Id.ToString();
                    node.SelectedImageKey = c.Id.ToString();
                    //tvCategory.ImageList
                    //node.ima
                    node.Tag = c;
                    e.Node.Nodes.Add(node);
                }
            }
            //MessageBox.Show(item.Id.ToString());
        }
    }
}
