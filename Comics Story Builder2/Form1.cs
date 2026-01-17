using Microsoft.VisualBasic.Logging;
using System.Data.SQLite;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;

namespace Comics_Story_Builder2
{
    public partial class Form1 : Form
    {
        Graphics g;
        Bitmap canvas;
        Point loc = new Point();

        bool resize, moving;
        int page = 1;

        //Database
        String connectionString = "Data source = ComicManos2.db;Version=3";
        SQLiteConnection connection;

        //Images
        public static Image Asset_Donald1;
        public static Image Asset_Donald2;
        public static Image Asset_Scrooge1;
        public static Image Asset_Scrooge2;
        public static Image Asset_Text1;
        public static Image Asset_Text2;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            canvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(canvas);
            g.Clear(Color.White);
            pictureBox1.Image = canvas;



            Asset_Donald1 = Donald1.BackgroundImage;
            Asset_Donald2 = Donald2.BackgroundImage;
            Asset_Scrooge1 = Scrooge1.BackgroundImage;
            Asset_Scrooge2 = Scrooge2.BackgroundImage;
            Asset_Text1 = button5.BackgroundImage;
            Asset_Text2 = button6.BackgroundImage;


            //DEBUG
            if (Asset_Text2 == null)
                MessageBox.Show("TextBubble1_Image is NULL");
            //

        }



        //Assets

        private void Donald1_Click(object sender, EventArgs e)
        {
            PictureBox donald1 = new PictureBox();
            donald1.Size = Donald1.Size;
            donald1.BackgroundImage = Donald1.BackgroundImage;
            donald1.BackgroundImageLayout = Donald1.BackgroundImageLayout;
            donald1.Parent = pictureBox1;
            donald1.Location = new Point(0, 0);
            donald1.BackgroundImage.Tag = "Donald1";
            pictureBox1.Controls.Add(donald1);

            donald1.MouseDown += myAsset_MouseDown;
            donald1.MouseUp += myAsset_MouseUp;
            donald1.MouseMove += myPicture_MouseMove;
            donald1.MouseClick += myAsset_Click;

        }

        private void Donald2_Click_1(object sender, EventArgs e)
        {
            PictureBox donald2 = new PictureBox();
            donald2.Size = Donald2.Size;
            donald2.BackgroundImage = Donald2.BackgroundImage;
            donald2.BackgroundImageLayout = Donald2.BackgroundImageLayout;
            donald2.Parent = pictureBox1;
            donald2.Location = new Point(0, 0);
            donald2.BackgroundImage.Tag = "Donald2";

            pictureBox1.Controls.Add(donald2);

            donald2.MouseDown += myAsset_MouseDown;
            donald2.MouseUp += myAsset_MouseUp;
            donald2.MouseMove += myPicture_MouseMove;
            donald2.MouseClick += myAsset_Click;
        }

        private void Scrooge1_Click(object sender, EventArgs e)
        {
            PictureBox scrooge1 = new PictureBox();
            scrooge1.Size = Scrooge1.Size;
            scrooge1.BackgroundImage = Scrooge1.BackgroundImage;
            scrooge1.BackgroundImageLayout = Scrooge1.BackgroundImageLayout;
            scrooge1.Parent = pictureBox1;
            scrooge1.Location = new Point(0, 0);
            scrooge1.BackgroundImage.Tag = "Scrooge1";

            pictureBox1.Controls.Add(scrooge1);

            scrooge1.MouseDown += myAsset_MouseDown;
            scrooge1.MouseUp += myAsset_MouseUp;
            scrooge1.MouseMove += myPicture_MouseMove;
            scrooge1.MouseClick += myAsset_Click;
        }

        private void Scrooge2_Click(object sender, EventArgs e)
        {
            PictureBox scrooge2 = new PictureBox();
            scrooge2.Size = Scrooge2.Size;
            scrooge2.BackgroundImage = Scrooge2.BackgroundImage;
            scrooge2.BackgroundImageLayout = Scrooge2.BackgroundImageLayout;
            scrooge2.Parent = pictureBox1;
            scrooge2.Location = new Point(0, 0);
            scrooge2.BackgroundImage.Tag = "Scrooge2";
            pictureBox1.Controls.Add(scrooge2);

            scrooge2.MouseDown += myAsset_MouseDown;
            scrooge2.MouseUp += myAsset_MouseUp;
            scrooge2.MouseMove += myPicture_MouseMove;
            scrooge2.MouseClick += myAsset_Click;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            PictureBox text1 = new PictureBox();
            text1.Size = button5.Size;
            text1.BackgroundImage = button5.BackgroundImage;
            text1.BackgroundImageLayout = button5.BackgroundImageLayout;
            text1.Location = new Point(0, 0);
            text1.BackgroundImage.Tag = "textbubble1";
            text1.Parent = pictureBox1;

            TextBox txtBox = new TextBox();
            txtBox.Size = new Size(140, 50);
            txtBox.Multiline = true;
            txtBox.Location = new Point(0, 0);
            txtBox.Parent = text1;

            pictureBox1.Controls.Add(text1);

            text1.MouseDown += myAsset_MouseDown;
            text1.MouseUp += myAsset_MouseUp;
            text1.MouseMove += myPicture_MouseMove;
            text1.MouseClick += myAsset_Click;

            txtBox.MouseDown += myAsset_MouseDown;
            txtBox.MouseUp += myAsset_MouseUp;
            txtBox.MouseMove += myTextBox_MouseMove;
            txtBox.MouseClick += myText_Click;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            PictureBox text2 = new PictureBox();
            text2.Size = button5.Size;
            text2.BackgroundImage = button6.BackgroundImage;
            text2.BackgroundImageLayout = button6.BackgroundImageLayout;
            text2.Location = new Point(0, 0);
            text2.BackgroundImage.Tag = "textbubble2";
            text2.Parent = pictureBox1;

            TextBox txtBox = new TextBox();
            txtBox.Size = new Size(140, 50);
            txtBox.Multiline = true;
            txtBox.Location = new Point(0, 0);
            txtBox.Parent = text2;

            pictureBox1.Controls.Add(text2);

            text2.MouseDown += myAsset_MouseDown;
            text2.MouseUp += myAsset_MouseUp;
            text2.MouseMove += myPicture_MouseMove;
            text2.MouseClick += myAsset_Click;


            txtBox.MouseDown += myAsset_MouseDown;
            txtBox.MouseUp += myAsset_MouseUp;
            txtBox.MouseMove += myTextBox_MouseMove;
            txtBox.MouseClick += myText_Click;
        }




        //Move - Change Size
        private void myPicture_MouseMove(object sender, MouseEventArgs e)
        {
            PictureBox temp = (PictureBox)sender;


            if (e.Location.X >= temp.Width - 20 && e.Location.Y >= temp.Height - 20)
            {
                temp.Cursor = Cursors.SizeNWSE;
                if (resize)
                {
                    temp.Size = new System.Drawing.Size(e.X, e.Y);
                }
                moving = false;

            }
            else
            {
                temp.Cursor = Cursors.Default;

            }

            if (moving)
            {
                ((PictureBox)sender).Location =
                new Point(((PictureBox)sender).Location.X + e.X - loc.X,
                ((PictureBox)sender).Location.Y + e.Y - loc.Y);
            }



        }
        private void myTextBox_MouseMove(object sender, MouseEventArgs e)
        {
            TextBox temp2 = (TextBox)sender;


            if (e.Location.X >= temp2.Width - 20 && e.Location.Y >= temp2.Height - 20)
            {
                temp2.Cursor = Cursors.SizeNWSE;
                if (resize)
                {
                    temp2.Size = new System.Drawing.Size(e.X, e.Y);

                }
                moving = false;
            }
            else
            {
                temp2.Cursor = Cursors.Default;
            }

            if (moving)
            {
                ((TextBox)sender).Location =
                new Point(((TextBox)sender).Location.X + e.X - loc.X,
                ((TextBox)sender).Location.Y + e.Y - loc.Y);

            }
        }
        private void myAsset_MouseDown(object sender, MouseEventArgs e)
        {
            resize = true;
            moving = true;
            loc = e.Location;
        }
        private void myAsset_MouseUp(object sender, MouseEventArgs e)
        {
            resize = false;
            moving = false;
        }
        private void myText_Click(object sender, EventArgs e)
        {
            TextBox temp = (TextBox)sender;
            if (temp.BorderStyle == BorderStyle.None)
            {
                temp.BorderStyle = BorderStyle.Fixed3D;
            }
            else
            {
                temp.BorderStyle = BorderStyle.None;
            }
        }
        private void myAsset_Click(object sender, EventArgs e)
        {
            PictureBox temp = (PictureBox)sender;
            if (Delete.Text == "Deleting")
            {
                temp.Parent.Controls.Remove(temp);
                temp.Dispose();

            }
        }




        //Controls


        //Clear Page
        private void NewPage_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            pictureBox1.Invalidate();

            pictureBox1.Controls.Clear();

        }


        //Save
        private void Save_Click(object sender, EventArgs e)
        {
            connection = new SQLiteConnection(connectionString);
            connection.Open();

            new SQLiteCommand(@"
             CREATE TABLE IF NOT EXISTS Pages (
             PageId INTEGER PRIMARY KEY AUTOINCREMENT,
             PageNumber INTEGER UNIQUE);",
              connection).ExecuteNonQuery(); //Table1: Pages

            new SQLiteCommand(@"
             CREATE TABLE IF NOT EXISTS Elements (
             Id INTEGER PRIMARY KEY AUTOINCREMENT,
             PageId INTEGER,
              ElementType TEXT,
              AssetName TEXT,
             X INTEGER,
             Y INTEGER,
             Width INTEGER,
              Height INTEGER,
             TextContent TEXT,
              ZOrder INTEGER,
              ParentId INTEGER);",
              connection).ExecuteNonQuery(); // Table2: Elements

            new SQLiteCommand(
                "INSERT INTO Pages (PageNumber) VALUES (@p)",
                connection
            )
            { Parameters = { new SQLiteParameter("@p", page) } }
            .ExecuteNonQuery();

            long pageId = connection.LastInsertRowId;
            int z = 0;

            foreach (Control c in pictureBox1.Controls)
            {
                if (c is PictureBox pb && pb.BackgroundImage?.Tag != null)
                {
                    string asset = pb.BackgroundImage.Tag.ToString();

                    SQLiteCommand imgCmd = new SQLiteCommand(@"
                     INSERT INTO Elements
                     (PageId, ElementType, AssetName, X, Y, Width, Height, ZOrder)
                     VALUES (@pid, 'Image', @a, @x, @y, @w, @h, @z)", connection);

                    imgCmd.Parameters.AddWithValue("@pid", pageId);
                    imgCmd.Parameters.AddWithValue("@a", asset);
                    imgCmd.Parameters.AddWithValue("@x", pb.Left);
                    imgCmd.Parameters.AddWithValue("@y", pb.Top);
                    imgCmd.Parameters.AddWithValue("@w", pb.Width);
                    imgCmd.Parameters.AddWithValue("@h", pb.Height);
                    imgCmd.Parameters.AddWithValue("@z", z++);
                    imgCmd.ExecuteNonQuery();

                    long parentId = connection.LastInsertRowId;

                    foreach (Control child in pb.Controls)
                    {
                        if (child is TextBox tb)
                        {
                            SQLiteCommand txtCmd = new SQLiteCommand(@"
                             INSERT INTO Elements
                             (PageId, ElementType, X, Y, Width, Height, TextContent, ZOrder, ParentId)
                             VALUES (@pid, 'Text', @x, @y, @w, @h, @t, @z, @parent)", connection);

                            txtCmd.Parameters.AddWithValue("@pid", pageId);
                            txtCmd.Parameters.AddWithValue("@x", tb.Left);
                            txtCmd.Parameters.AddWithValue("@y", tb.Top);
                            txtCmd.Parameters.AddWithValue("@w", tb.Width);
                            txtCmd.Parameters.AddWithValue("@h", tb.Height);
                            txtCmd.Parameters.AddWithValue("@t", tb.Text);
                            txtCmd.Parameters.AddWithValue("@z", z++);
                            txtCmd.Parameters.AddWithValue("@parent", parentId);
                            txtCmd.ExecuteNonQuery();
                        }
                    }
                }
            }

            connection.Close();
            MessageBox.Show("Saved page " + page);
            page++;
        }



        //View
        private void View_Click(object sender, EventArgs e)
        {
            View reader = new View();
            reader.Show();
        }



        //Clear
        private void ClearDatabase_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
              "This will delete the entire comic.\nAre you sure?",
              "New Comic",
              MessageBoxButtons.YesNo,
              MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;

            connection = new SQLiteConnection(connectionString);
            connection.Open();

            string deleteElements = "DELETE FROM Elements;";
            string deletePages = "DELETE FROM Pages;";
            string resetIds = "DELETE FROM sqlite_sequence WHERE name='Pages' OR name='Elements';";

            new SQLiteCommand(deleteElements, connection).ExecuteNonQuery();
            new SQLiteCommand(deletePages, connection).ExecuteNonQuery();
            new SQLiteCommand(resetIds, connection).ExecuteNonQuery();

            connection.Close();

            // Reset editor state
            page = 1;
            pictureBox1.Controls.Clear();
            g.Clear(Color.White);
            pictureBox1.Invalidate();

            MessageBox.Show("Database cleared.\nYou can start a new comic.");
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (Delete.Text == "Delete")
            {
                Delete.Text = "Deleting";
            }
            else
            {
                Delete.Text = "Delete";
            }
        }
    }
}
