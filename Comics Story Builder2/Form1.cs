
using System.Data.SQLite;


namespace Comics_Story_Builder2
{
    public partial class Form1 : Form
    {
        Graphics g;
        Bitmap canvas;
        

        bool resize, moving;
        int page = 1;

        //Database
        String connectionString = "Data source = ComicM2.db;Version=3";


        //Images
        public static Image Asset_Donald1;
        public static Image Asset_Donald2;
        public static Image Asset_Scrooge1;
        public static Image Asset_Scrooge2;
        public static Image Asset_Text1;
        public static Image Asset_Text2;
        private Dictionary<string, Image> assetLibrary;
        public string currentcomidID;
        Size originalSize;
        Point originalMouse;

        public Form1()
        {
            InitializeComponent();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            canvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(canvas);
            g.Clear(Color.White);
            pictureBox1.Image = canvas;

            label3.Text = "Page: " + page;
            string currentcomidID;
            Asset_Donald1 = Donald1.BackgroundImage;
            Asset_Donald2 = Donald2.BackgroundImage;
            Asset_Scrooge1 = Scrooge1.BackgroundImage;
            Asset_Scrooge2 = Scrooge2.BackgroundImage;
            Asset_Text1 = button5.BackgroundImage;
            Asset_Text2 = button6.BackgroundImage;
            textBox1.PlaceholderText = "Enter Comic Name";
            assetLibrary = new Dictionary<string, Image>
          {
              { "Donald1", Asset_Donald1 },
              { "Donald2", Asset_Donald2 },
              { "Scrooge1", Asset_Scrooge1 },
              { "Scrooge2", Asset_Scrooge2 },
              { "textbubble1", Asset_Text1 },
              { "textbubble2", Asset_Text2 }
};


            /*DEBUG
            if (Asset_Text2 == null)
                MessageBox.Show("TextBubble1_Image is NULL");
            */

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
            PictureBox pb = (PictureBox)sender;

            if (resize)
            {
                int newW = Math.Max(20, originalSize.Width + e.X - originalMouse.X);
                int newH = Math.Max(20, originalSize.Height + e.Y - originalMouse.Y);
                pb.Size = new Size(newW, newH);
               
            }
            else if (moving)
            {
                pb.Left += e.X - originalMouse.X;
                pb.Top += e.Y - originalMouse.Y;
            }
        }
        private void myTextBox_MouseMove(object sender, MouseEventArgs e)
        {
            TextBox tb = (TextBox)sender;

            if (resize)
            {
                int newW = Math.Max(40, originalSize.Width + e.X - originalMouse.X);
                int newH = Math.Max(20, originalSize.Height + e.Y - originalMouse.Y);
                tb.Size = new Size(newW, newH);
                
            }
            else if (moving)
            {
                tb.Left += e.X - originalMouse.X;
                tb.Top += e.Y - originalMouse.Y;
            }
        }

        private void myAsset_MouseDown(object sender, MouseEventArgs e)
        {
            Control c = (Control)sender;

            originalSize = c.Size;
            originalMouse = e.Location;

            resize = e.Location.X >= c.Width - 15 && e.Location.Y >= c.Height - 15;
            moving = !resize;
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
                Delete.Text = "Delete";
                temp.Parent.Controls.Remove(temp);
                temp.Dispose();

            }
        }




        //Controls



        private void NewPage_Click(object sender, EventArgs e)
        {

            page++;

            label3.Text = "Page: " + page;
            if (button1.Text == "Editing" && ComicPageExists(currentcomidID, page))
            {

                LoadComicPage(currentcomidID, page);
            }
            else
            {
                g.Clear(Color.White);
                pictureBox1.Invalidate();
                pictureBox1.Controls.Clear();
            }


        }


        //Save
        private void Save_Click(object sender, EventArgs e)
        {
            string comicId;
            if (button1.Text == "Edit")
            {
                comicId = textBox1.Text.Trim();
            }
            else
            {
                comicId = currentcomidID;
            }

            if (string.IsNullOrEmpty(comicId))
            {
                MessageBox.Show("Please enter a comic name");
                return;
            }

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();


                new SQLiteCommand(@"
        CREATE TABLE IF NOT EXISTS Comics (
            ComicId TEXT PRIMARY KEY
        );", connection).ExecuteNonQuery();

                new SQLiteCommand(@"
        CREATE TABLE IF NOT EXISTS Pages (
            PageId INTEGER PRIMARY KEY AUTOINCREMENT,
            ComicId TEXT,
            PageNumber INTEGER,
            UNIQUE (ComicId, PageNumber)
        );", connection).ExecuteNonQuery();

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
            ParentId INTEGER
        );", connection).ExecuteNonQuery();



                SQLiteCommand insertComic = new SQLiteCommand(
                    "INSERT OR IGNORE INTO Comics (ComicId) VALUES (@cid)",
                    connection);
                insertComic.Parameters.AddWithValue("@cid", comicId);
                insertComic.ExecuteNonQuery();



                SQLiteCommand checkPage = new SQLiteCommand(
                    "SELECT PageId FROM Pages WHERE ComicId = @cid AND PageNumber = @p",
                    connection);
                checkPage.Parameters.AddWithValue("@cid", comicId);
                checkPage.Parameters.AddWithValue("@p", page);

                object result = checkPage.ExecuteScalar();

                long pageId;

                if (result == null)
                {

                    SQLiteCommand insertPage = new SQLiteCommand(
                        "INSERT INTO Pages (ComicId, PageNumber) VALUES (@cid, @p)",
                        connection);
                    insertPage.Parameters.AddWithValue("@cid", comicId);
                    insertPage.Parameters.AddWithValue("@p", page);
                    insertPage.ExecuteNonQuery();

                    pageId = connection.LastInsertRowId;
                }
                else
                {
                    // Page exists → REUSE
                    pageId = (long)result;

                    // Clear old elements
                    SQLiteCommand deleteElements = new SQLiteCommand(
                        "DELETE FROM Elements WHERE PageId = @pid",
                        connection);
                    deleteElements.Parameters.AddWithValue("@pid", pageId);
                    deleteElements.ExecuteNonQuery();
                }



                int z = 0;

                foreach (Control c in pictureBox1.Controls)
                {
                    if (c is PictureBox pb && pb.BackgroundImage?.Tag != null)
                    {
                        SQLiteCommand imgCmd = new SQLiteCommand(@"
                INSERT INTO Elements
                (PageId, ElementType, AssetName, X, Y, Width, Height, ZOrder)
                VALUES (@pid, 'Image', @a, @x, @y, @w, @h, @z)", connection);

                        imgCmd.Parameters.AddWithValue("@pid", pageId);
                        imgCmd.Parameters.AddWithValue("@a", pb.BackgroundImage.Tag.ToString());
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
            }

            MessageBox.Show($"Saved page {page} of comic \"{comicId}\"");
            g.Clear(Color.White);
            pictureBox1.Invalidate();
            page = 1;
            label3.Text = "Page: " + page;
            pictureBox1.Controls.Clear();
            button1.Text = "Edit";
            textBox1.PlaceholderText = "Enter Comic Name";
        }



        //View
        private void View_Click(object sender, EventArgs e)
        {
            string selectedC = ShowComicPicker(GetAllComicIds());
            if (selectedC != null)
            {
                if (IsExportable(selectedC))
                {
                    using (FolderBrowserDialog dialog = new FolderBrowserDialog())
                    {
                        dialog.Description = "Select export folder";

                        if (dialog.ShowDialog() == DialogResult.OK)
                        {
                            ExportComicFromDatabase(selectedC, dialog.SelectedPath);
                            View viewForm = new View(dialog.SelectedPath);
                            viewForm.ShowDialog();

                        }
                    }
                }else
                {
                    MessageBox.Show("This comic is missing pages!");
                }
            }

           
        }
        private bool IsExportable(string comicId)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                SQLiteCommand c = new SQLiteCommand(@" 
                SELECT
              CASE
                WHEN MIN(PageNumber) = 1
                AND MAX(PageNumber) - MIN(PageNumber) + 1 = COUNT(DISTINCT PageNumber)
                THEN 1
                ELSE 0
                   END
                FROM Pages
                WHERE ComicId = @cid;

                    
                    ", connection);
                c.Parameters.AddWithValue("@cid", comicId);
                object result = c.ExecuteScalar();
                if (result == DBNull.Value || result == null)
                    return false;
                return Convert.ToInt32(result) ==1;
            }
        }


        //Clear
        private void ClearDatabase_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "This will delete every comic.\nAre you sure?",
                "Delete All Comics",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();


                new SQLiteCommand("DELETE FROM Elements;", connection).ExecuteNonQuery();
                new SQLiteCommand("DELETE FROM Pages;", connection).ExecuteNonQuery();
                new SQLiteCommand("DELETE FROM Comics;", connection).ExecuteNonQuery();


                new SQLiteCommand(
                    "DELETE FROM sqlite_sequence WHERE name IN ('Pages','Elements');",
                    connection).ExecuteNonQuery();
            }

            //reset app
            page = 1;
            currentcomidID = null;

            pictureBox1.Controls.Clear();
            g.Clear(Color.White);
            pictureBox1.Invalidate();

            label3.Text = "Page: 1";
            button1.Text = "Edit"; // exit editing mode
            Delete.Text = "Delete";

            MessageBox.Show("All comics deleted.\nDatabase reset.");
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


        private void LoadComicPage(string comicId, int pageNumber)
        {
            pictureBox1.Controls.Clear();

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();


                SQLiteCommand pageCmd = new SQLiteCommand(
                    "SELECT PageId FROM Pages WHERE ComicId = @cid AND PageNumber = @p",
                    connection);

                pageCmd.Parameters.AddWithValue("@cid", comicId);
                pageCmd.Parameters.AddWithValue("@p", pageNumber);

                object pageResult = pageCmd.ExecuteScalar();
                if (pageResult == null)
                {
                    MessageBox.Show("Page not found");
                    return;
                }

                long pageId = (long)pageResult;

                SQLiteCommand elemCmd = new SQLiteCommand(
                    "SELECT * FROM Elements WHERE PageId = @pid ORDER BY ZOrder",
                    connection);

                elemCmd.Parameters.AddWithValue("@pid", pageId);

                SQLiteDataReader reader = elemCmd.ExecuteReader();


                Dictionary<long, Control> elementMap = new Dictionary<long, Control>();

                while (reader.Read())
                {
                    long elementId = (long)reader["Id"];
                    string type = reader["ElementType"].ToString();

                    int x = Convert.ToInt32(reader["X"]);
                    int y = Convert.ToInt32(reader["Y"]);
                    int w = Convert.ToInt32(reader["Width"]);
                    int h = Convert.ToInt32(reader["Height"]);
                    int z = Convert.ToInt32(reader["ZOrder"]);

                    if (type == "Image")
                    {
                        PictureBox pb = new PictureBox
                        {
                            Left = x,
                            Top = y,
                            Width = w,
                            Height = h,
                            SizeMode = PictureBoxSizeMode.StretchImage,
                            BackColor = Color.Transparent
                        };

                        string asset = reader["AssetName"].ToString();

                        if (assetLibrary.TryGetValue(asset, out Image img))
                        {
                            pb.BackgroundImage = img;
                            pb.BackgroundImage.Tag = asset;
                            pb.BackgroundImageLayout = ImageLayout.Stretch;
                            pb.MouseDown += myAsset_MouseDown;
                            pb.MouseUp += myAsset_MouseUp;
                            pb.MouseMove += myPicture_MouseMove;
                            pb.MouseClick += myAsset_Click;
                        }
                        else
                        {
                            MessageBox.Show($"Asset not found: {asset}");
                        }


                        pictureBox1.Controls.Add(pb);
                        pb.BringToFront();

                        elementMap[elementId] = pb;
                    }
                    else if (type == "Text")
                    {
                        TextBox tb = new TextBox
                        {
                            Left = x,
                            Top = y,
                            Width = w,
                            Height = h,
                            Text = reader["TextContent"].ToString(),
                            Multiline = true,
                            BorderStyle = BorderStyle.None
                        };
                        tb.MouseDown += myAsset_MouseDown;
                        tb.MouseUp += myAsset_MouseUp;
                        tb.MouseMove += myTextBox_MouseMove;
                        tb.MouseClick += myText_Click;

                        long parentId = Convert.ToInt64(reader["ParentId"]);

                        if (elementMap.ContainsKey(parentId))
                        {
                            elementMap[parentId].Controls.Add(tb);
                        }
                        else
                        {
                            pictureBox1.Controls.Add(tb);
                        }

                        tb.BringToFront();
                        elementMap[elementId] = tb;
                    }
                }
            }
            currentcomidID = comicId;
            textBox1.PlaceholderText = "Currently Editing: " + currentcomidID;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> comics = GetAllComicIds();
            if (comics.Count > 0)
            {
                string selected = ShowComicPicker(comics);
                if (selected != null)
                {
                    LoadComicPage(selected, page);
                    button1.Text = "Editing";
                }
            }
            else
            {
                MessageBox.Show("There are no saved comics");
            }
        }
        public static string ShowComicPicker(List<string> comicIds)
        {
            Form form = new Form();
            ListBox listBox = new ListBox();
            Button btnOk = new Button();
            Button btnCancel = new Button();

            form.Text = "Select Comic";
            form.StartPosition = FormStartPosition.CenterScreen;
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.ClientSize = new Size(300, 300);
            form.MinimizeBox = false;
            form.MaximizeBox = false;

            listBox.SetBounds(10, 10, 270, 210);
            listBox.DataSource = comicIds;

            btnOk.Text = "Open";
            btnCancel.Text = "Cancel";
            btnOk.SetBounds(120, 230, 75, 45);
            btnCancel.SetBounds(205, 230, 75, 45);

            btnOk.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.Cancel;

            form.AcceptButton = btnOk;
            form.CancelButton = btnCancel;

            form.Controls.AddRange(new Control[] { listBox, btnOk, btnCancel });

            if (form.ShowDialog() == DialogResult.OK && listBox.SelectedItem != null)
                return listBox.SelectedItem.ToString();

            return null;
        }
        private List<string> GetAllComicIds()
        {
            List<string> comics = new List<string>();

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                SQLiteCommand cmd = new SQLiteCommand(
                    "SELECT ComicId FROM Comics ORDER BY ComicId",
                    connection);

                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        comics.Add(reader.GetString(0));
                    }
                }
            }

            return comics;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (page > 1)
            {
                page--;
                label3.Text = "Page: " + page;
                if (button1.Text == "Editing" && ComicPageExists(currentcomidID, page))
                {

                    LoadComicPage(currentcomidID, page);
                }
                else
                {
                    g.Clear(Color.White);
                    pictureBox1.Invalidate();

                    pictureBox1.Controls.Clear();
                }

            }
            else
            {
                MessageBox.Show("This is the first Page!");
            }
        }
        private bool ComicPageExists(string comicId, int pageNumber)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                SQLiteCommand cmd = new SQLiteCommand(
                    "SELECT 1 FROM Pages WHERE ComicId = @cid AND PageNumber = @p LIMIT 1",
                    connection);

                cmd.Parameters.AddWithValue("@cid", comicId);
                cmd.Parameters.AddWithValue("@p", pageNumber);

                return cmd.ExecuteScalar() != null;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            
                button3.Text = "Resizing";
                resize = true;
            
              
        }
        private void ExportComicFromDatabase(string comicId, string folderPath)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                SQLiteCommand pagesCmd = new SQLiteCommand(
                    "SELECT PageId, PageNumber FROM Pages WHERE ComicId = @cid ORDER BY PageNumber",
                    connection);

                pagesCmd.Parameters.AddWithValue("@cid", comicId);

                using (SQLiteDataReader pagesReader = pagesCmd.ExecuteReader())
                {
                    while (pagesReader.Read())
                    {
                        long pageId = pagesReader.GetInt64(0);
                        int pageNumber = pagesReader.GetInt32(1);

                        Bitmap pageImage = RenderPageFromDatabase(pageId);

                        string fileName = Path.Combine(
                            folderPath,
                            $"{comicId}_page_{pageNumber:D2}.png");
                        if (File.Exists(fileName))
                        {
                            File.Delete(fileName);
                        }

                        pageImage.Save(fileName, System.Drawing.Imaging.ImageFormat.Png);
                        pageImage.Save(fileName, System.Drawing.Imaging.ImageFormat.Png);
                        pageImage.Dispose();
                    }
                }
            }
        }
        private Bitmap RenderPageFromDatabase(long pageId)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);

                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    SQLiteCommand cmd = new SQLiteCommand(
                        "SELECT * FROM Elements WHERE PageId = @pid ORDER BY ZOrder",
                        connection);

                    cmd.Parameters.AddWithValue("@pid", pageId);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        Dictionary<long, Rectangle> imageBounds = new();
                       
                        while (reader.Read())
                        {
                            long id = (long)reader["Id"];
                            string type = reader["ElementType"].ToString();

                            int x = Convert.ToInt32(reader["X"]);
                            int y = Convert.ToInt32(reader["Y"]);
                            int w = Convert.ToInt32(reader["Width"]);
                            int h = Convert.ToInt32(reader["Height"]);
                            

                           
                            if (type == "Image")
                            {

                                
                                
                                 string assetName = reader["AssetName"].ToString();

                                  if (assetLibrary.TryGetValue(assetName, out Image img))
                                  {
                                      Rectangle imgRect = new Rectangle(x, y, w, h);

                                      using Image imgClone = (Image)img.Clone();
                                      g.DrawImage(imgClone, imgRect);


                                      imageBounds[id] = imgRect;
                                  } 

                            }
                            else if (type == "Text")
                            {



                                
                                    string text = reader["TextContent"].ToString();
                                    long parentId = Convert.ToInt64(reader["ParentId"]);

                                    Rectangle textBounds;
                                if (imageBounds.TryGetValue(parentId, out Rectangle parent))
                                {
                                    textBounds = new Rectangle(parent.X + x, parent.Y + y, w, h);
                                    
                                }
                                else
                                    textBounds = new Rectangle(x, y, w, h);

                                    using Font font = new Font("Arial", 12);
                                    Brush brush = Brushes.Black;
                                    using StringFormat sf = new StringFormat
                                    {
                                        Alignment = StringAlignment.Near,
                                        LineAlignment = StringAlignment.Near
                                    };
                                
                                g.DrawString(text, font, brush, textBounds, sf);
                                
                            }

                        }
                    }
                }
            }

            return bmp;
        }

    }
}
