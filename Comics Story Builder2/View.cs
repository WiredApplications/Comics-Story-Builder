using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Comics_Story_Builder2
{
    
    public partial class View : Form
        
    {
        private string[] pages;
        private int currentIndex = 0;
        public View(string path)
        {
            InitializeComponent();
            pages = Directory.GetFiles(path, "*.png")
                    .OrderBy(f => f)
                    .ToArray();

            if (pages.Length > 0)
                LoadImage(pages[0]);
        }

        private void View_Load(object sender, EventArgs e)
        {
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.BackColor = Color.White;
        }
        private void LoadImage(string path)
        {
            if (pictureBox1.Image != null)
                pictureBox1.Image.Dispose();

            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                pictureBox1.Image = Image.FromStream(fs);
            }
        }
    }
}
