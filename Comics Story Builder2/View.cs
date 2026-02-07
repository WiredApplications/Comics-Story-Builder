

namespace Comics_Story_Builder2
{
    public partial class View : Form
    {
        private string baseFolder;
        private string comicId;
        private int currentPage = 1;

        public View(string folderPath)
        {
            InitializeComponent();

            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;

            baseFolder = folderPath;

            string firstPage = Directory
                .GetFiles(baseFolder, "*_page_*.png")
                .FirstOrDefault();

            if (firstPage == null)
            {
                MessageBox.Show("No comic pages found.");
                Close();
                return;
            }

            string fileName = Path.GetFileNameWithoutExtension(firstPage);
            comicId = fileName.Substring(0, fileName.IndexOf("_page_"));

            LoadPage(currentPage);
        }

        private void View_Load(object sender, EventArgs e)
        {
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }

       
        private void LoadPage(int pageNumber)
        {
            string filePath = GetPagePath(pageNumber);

            if (!File.Exists(filePath))
                return;

            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
            }

            using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                pictureBox1.Image = Image.FromStream(fs);
            }

            currentPage = pageNumber;
        }

        private string GetPagePath(int pageNumber)
        {
            return Path.Combine(
                baseFolder,
                $"{comicId}_page_{pageNumber:D2}.png");
        }

        
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            int nextPage = currentPage + 1;

            if (File.Exists(GetPagePath(nextPage)))
            {
                LoadPage(nextPage);
            }
        }

      
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            int prevPage = currentPage - 1;

            if (prevPage >= 1 && File.Exists(GetPagePath(prevPage)))
            {
                LoadPage(prevPage);
            }
        }
    }
}
