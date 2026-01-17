using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Comics_Story_Builder2
{
    public partial class View : Form
    {
        int currentPage = 1;
        string connectionString = "Data source = ComicManos2.db;Version=3";

        Bitmap reader;
        public View()
        {
            InitializeComponent();
        }

        private void View_Load(object sender, EventArgs e)
        {
                LoadPage(currentPage);   
        }


        private void LoadPage(int pageNumber)
        {
            reader = new Bitmap(pbView.Width, pbView.Height);
            Graphics g = Graphics.FromImage(reader);
            g.Clear(Color.White);
            pbView.Image = reader;




            pbView.Controls.Clear();
            Dictionary<long, PictureBox> imageMap = new Dictionary<long, PictureBox>();

            SQLiteConnection conn = new SQLiteConnection(connectionString);
            conn.Open();

            SQLiteCommand pCmd = new SQLiteCommand(
                "SELECT PageId FROM Pages WHERE PageNumber=@n", conn);
            pCmd.Parameters.AddWithValue("@n", pageNumber);

            object res = pCmd.ExecuteScalar();
            if (res == null) return;

            long pageId = (long)res;

            SQLiteCommand cmd = new SQLiteCommand(
                "SELECT * FROM Elements WHERE PageId=@p ORDER BY ZOrder", conn);
            cmd.Parameters.AddWithValue("@p", pageId);

            SQLiteDataReader r = cmd.ExecuteReader();

            while (r.Read())
            {
                string type = r["ElementType"].ToString();
                int x = Convert.ToInt32(r["X"]);
                int y = Convert.ToInt32(r["Y"]);
                int w = Convert.ToInt32(r["Width"]);
                int h = Convert.ToInt32(r["Height"]);

                if (type == "Image")
                {
                    PictureBox pb = new PictureBox();
                    pb.Location = new Point(x, y);
                    pb.Size = new Size(w, h);
                    pb.BackgroundImageLayout = ImageLayout.Stretch;
                    pb.BackgroundImage = LoadAsset(r["AssetName"].ToString());


                    //DEBUG
                    //  if (pb.BackgroundImage == null)
                    //  {
                    //      MessageBox.Show("Image NOT FOUND: " + r["AssetName"].ToString());
                    //  }
                    // pb.BackColor = Color.Blue;

                    ////

                    pbView.Controls.Add(pb);
                    imageMap.Add(Convert.ToInt64(r["Id"]), pb);
                }
                else if (type == "Text")
                {
                    TextBox tb = new TextBox();
                    tb.Multiline = true;
                    tb.ReadOnly = true;
                    tb.BorderStyle = BorderStyle.None;
                    tb.Size = new Size(w, h);
                    tb.Text = r["TextContent"].ToString();

                    long parentId = Convert.ToInt64(r["ParentId"]);
                    imageMap[parentId].Controls.Add(tb);
                    tb.Location = new Point(x, y);
                }
            }

            conn.Close();
        }


        private Image LoadAsset(string name)
        {
            switch (name)
            {
                case "Donald1": return Form1.Asset_Donald1;
                case "Donald2": return Form1.Asset_Donald2;
                case "Scrooge1": return Form1.Asset_Scrooge1;
                case "Scrooge2": return Form1.Asset_Scrooge2;
                case "textbubble1": return Form1.Asset_Text1;
                case "textbubble2": return Form1.Asset_Text2;
                default:
                    MessageBox.Show($"Unknown asset: {name}");
                    return null;
            }
        }



        private void prev_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadPage(currentPage);
            }
        }

        private void next_Click(object sender, EventArgs e)
        {
            currentPage++;
            LoadPage(currentPage);
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            if (Edit.Text == "Edit")
            {
                Edit.Text = "Editing";
            }
            else
            {
                Edit.Text = "Edit";
            }
        }
    }
}
