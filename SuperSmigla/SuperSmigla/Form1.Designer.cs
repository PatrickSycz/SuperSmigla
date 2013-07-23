namespace SuperSmigla
{
    partial class superSmiglaForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(superSmiglaForm));
            this.stepsButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.loadMapMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.loadBarbersMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.stepsText = new System.Windows.Forms.TextBox();
            this.stepsCounterText = new System.Windows.Forms.TextBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.StartButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // stepsButton
            // 
            this.stepsButton.Font = new System.Drawing.Font("Courier New", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stepsButton.Location = new System.Drawing.Point(16, 33);
            this.stepsButton.Margin = new System.Windows.Forms.Padding(4);
            this.stepsButton.Name = "stepsButton";
            this.stepsButton.Size = new System.Drawing.Size(204, 38);
            this.stepsButton.TabIndex = 0;
            this.stepsButton.Text = "Move Smigla!";
            this.stepsButton.UseVisualStyleBackColor = true;
            this.stepsButton.Click += new System.EventHandler(this.stepsButton_Click);
            this.stepsButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.stepsButton_MouseDown);
            this.stepsButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.stepsButton_MouseUp);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Menu;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadMapMenu,
            this.loadBarbersMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1045, 29);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // loadMapMenu
            // 
            this.loadMapMenu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadMapMenu.Name = "loadMapMenu";
            this.loadMapMenu.Size = new System.Drawing.Size(91, 25);
            this.loadMapMenu.Text = "Load Map";
            this.loadMapMenu.Click += new System.EventHandler(this.loadMapMenu_Click);
            // 
            // loadBarbersMenu
            // 
            this.loadBarbersMenu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadBarbersMenu.Name = "loadBarbersMenu";
            this.loadBarbersMenu.Size = new System.Drawing.Size(113, 25);
            this.loadBarbersMenu.Text = "Load Barbers";
            this.loadBarbersMenu.Click += new System.EventHandler(this.loadBarbersMenu_Click);
            // 
            // stepsText
            // 
            this.stepsText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.stepsText.Font = new System.Drawing.Font("Courier New", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stepsText.Location = new System.Drawing.Point(228, 33);
            this.stepsText.Margin = new System.Windows.Forms.Padding(4);
            this.stepsText.Name = "stepsText";
            this.stepsText.ReadOnly = true;
            this.stepsText.Size = new System.Drawing.Size(131, 31);
            this.stepsText.TabIndex = 2;
            this.stepsText.Text = "Steps:";
            // 
            // stepsCounterText
            // 
            this.stepsCounterText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.stepsCounterText.Font = new System.Drawing.Font("Courier New", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stepsCounterText.Location = new System.Drawing.Point(326, 34);
            this.stepsCounterText.Margin = new System.Windows.Forms.Padding(4);
            this.stepsCounterText.Name = "stepsCounterText";
            this.stepsCounterText.ReadOnly = true;
            this.stepsCounterText.Size = new System.Drawing.Size(77, 31);
            this.stepsCounterText.TabIndex = 3;
            this.stepsCounterText.Text = "0";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Smigla.jpg");
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Desktop;
            this.pictureBox1.Location = new System.Drawing.Point(22, 80);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1000, 600);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // StartButton
            // 
            this.StartButton.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartButton.Location = new System.Drawing.Point(901, 33);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(121, 38);
            this.StartButton.TabIndex = 5;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // superSmiglaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1045, 692);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.stepsCounterText);
            this.Controls.Add(this.stepsText);
            this.Controls.Add(this.stepsButton);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(848, 582);
            this.Name = "superSmiglaForm";
            this.ShowIcon = false;
            this.Text = "Super Smigla!";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button stepsButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem loadMapMenu;
        private System.Windows.Forms.TextBox stepsText;
        private System.Windows.Forms.TextBox stepsCounterText;
        private System.Windows.Forms.ToolStripMenuItem loadBarbersMenu;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button StartButton;
    }
}

