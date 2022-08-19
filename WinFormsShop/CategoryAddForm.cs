using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using Image = System.Drawing.Image;

namespace WinFormsShop
{
    public partial class CategoryAddForm : Form
    {
        public string mTitle
        {
            get
            {
                return txtTitle.Text;
            }
        }
        public int mPriotiry
        {
            get
            {
                return int.Parse(nudPiority.Value.ToString());
            }
        }
        public string mImage { get; set; }
        public CategoryAddForm()
        {
            InitializeComponent();
        }

        private void pbImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if(ofd.ShowDialog() == DialogResult.OK)
            {
                mImage=ofd.FileName;
                pbImage.Image=Image.FromFile(ofd.FileName);
                //MessageBox.Show("Open file", ofd.FileName);
            }
        }
    }
}
