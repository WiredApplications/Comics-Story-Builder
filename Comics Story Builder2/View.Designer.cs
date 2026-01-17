namespace Comics_Story_Builder2
{
    partial class View
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            prev = new Button();
            pbView = new PictureBox();
            next = new Button();
            Edit = new Button();
            ((System.ComponentModel.ISupportInitialize)pbView).BeginInit();
            SuspendLayout();
            // 
            // prev
            // 
            prev.Font = new Font("Segoe UI", 50F);
            prev.Location = new Point(113, 313);
            prev.Name = "prev";
            prev.Size = new Size(177, 194);
            prev.TabIndex = 0;
            prev.Text = "<";
            prev.UseVisualStyleBackColor = true;
            prev.Click += prev_Click;
            // 
            // pbView
            // 
            pbView.Location = new Point(368, 25);
            pbView.Name = "pbView";
            pbView.Size = new Size(589, 550);
            pbView.TabIndex = 1;
            pbView.TabStop = false;
            // 
            // next
            // 
            next.Font = new Font("Segoe UI", 50F);
            next.Location = new Point(113, 89);
            next.Name = "next";
            next.Size = new Size(177, 194);
            next.TabIndex = 2;
            next.Text = ">";
            next.UseVisualStyleBackColor = true;
            next.Click += next_Click;
            // 
            // Edit
            // 
            Edit.Font = new Font("Segoe UI", 15F);
            Edit.Location = new Point(1023, 40);
            Edit.Name = "Edit";
            Edit.Size = new Size(142, 57);
            Edit.TabIndex = 3;
            Edit.Text = "Edit";
            Edit.UseVisualStyleBackColor = true;
            Edit.Click += Edit_Click;
            // 
            // View
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1284, 603);
            Controls.Add(Edit);
            Controls.Add(next);
            Controls.Add(pbView);
            Controls.Add(prev);
            Name = "View";
            Text = "View";
            Load += View_Load;
            ((System.ComponentModel.ISupportInitialize)pbView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button prev;
        private PictureBox pbView;
        private Button next;
        private Button Edit;
    }
}