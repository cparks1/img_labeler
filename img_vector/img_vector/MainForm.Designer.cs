namespace img_vector
{
    partial class mainForm
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
            this.mainFormMenuStrip = new System.Windows.Forms.MenuStrip();
            this.mainFormMenuStrip_FileItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.directoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.currentImagePictureBox = new System.Windows.Forms.PictureBox();
            this.openSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetPointsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeLastPointToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainFormMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.currentImagePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // mainFormMenuStrip
            // 
            this.mainFormMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainFormMenuStrip_FileItem,
            this.editToolStripMenuItem});
            this.mainFormMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainFormMenuStrip.Name = "mainFormMenuStrip";
            this.mainFormMenuStrip.Size = new System.Drawing.Size(800, 24);
            this.mainFormMenuStrip.TabIndex = 0;
            this.mainFormMenuStrip.Text = "menuStrip1";
            // 
            // mainFormMenuStrip_FileItem
            // 
            this.mainFormMenuStrip_FileItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.mainFormMenuStrip_FileItem.Name = "mainFormMenuStrip_FileItem";
            this.mainFormMenuStrip_FileItem.Size = new System.Drawing.Size(37, 20);
            this.mainFormMenuStrip_FileItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imageToolStripMenuItem,
            this.directoryToolStripMenuItem,
            this.openSettingsToolStripMenuItem});
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // imageToolStripMenuItem
            // 
            this.imageToolStripMenuItem.Name = "imageToolStripMenuItem";
            this.imageToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.imageToolStripMenuItem.Text = "Image";
            this.imageToolStripMenuItem.Click += new System.EventHandler(this.imageToolStripMenuItem_Click);
            // 
            // directoryToolStripMenuItem
            // 
            this.directoryToolStripMenuItem.Name = "directoryToolStripMenuItem";
            this.directoryToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.directoryToolStripMenuItem.Text = "Directory";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveSettingsToolStripMenuItem});
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // saveSettingsToolStripMenuItem
            // 
            this.saveSettingsToolStripMenuItem.Name = "saveSettingsToolStripMenuItem";
            this.saveSettingsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveSettingsToolStripMenuItem.Text = "Settings";
            this.saveSettingsToolStripMenuItem.Click += new System.EventHandler(this.saveSettingsToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // currentImagePictureBox
            // 
            this.currentImagePictureBox.Location = new System.Drawing.Point(0, 27);
            this.currentImagePictureBox.Name = "currentImagePictureBox";
            this.currentImagePictureBox.Size = new System.Drawing.Size(800, 423);
            this.currentImagePictureBox.TabIndex = 1;
            this.currentImagePictureBox.TabStop = false;
            this.currentImagePictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.currentImagePictureBox_Paint);
            this.currentImagePictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.currentImagePictureBox_MouseClick);
            // 
            // openSettingsToolStripMenuItem
            // 
            this.openSettingsToolStripMenuItem.Name = "openSettingsToolStripMenuItem";
            this.openSettingsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openSettingsToolStripMenuItem.Text = "Settings";
            this.openSettingsToolStripMenuItem.Click += new System.EventHandler(this.openSettingsToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetPointsToolStripMenuItem,
            this.removeLastPointToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // resetPointsToolStripMenuItem
            // 
            this.resetPointsToolStripMenuItem.Name = "resetPointsToolStripMenuItem";
            this.resetPointsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.resetPointsToolStripMenuItem.Text = "Reset points";
            this.resetPointsToolStripMenuItem.Click += new System.EventHandler(this.resetPointsToolStripMenuItem_Click);
            // 
            // removeLastPointToolStripMenuItem
            // 
            this.removeLastPointToolStripMenuItem.Name = "removeLastPointToolStripMenuItem";
            this.removeLastPointToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.removeLastPointToolStripMenuItem.Text = "Remove last point";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.currentImagePictureBox);
            this.Controls.Add(this.mainFormMenuStrip);
            this.MainMenuStrip = this.mainFormMenuStrip;
            this.Name = "mainForm";
            this.Text = "Image Vector";
            this.mainFormMenuStrip.ResumeLayout(false);
            this.mainFormMenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.currentImagePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainFormMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem mainFormMenuStrip_FileItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem directoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.PictureBox currentImagePictureBox;
        private System.Windows.Forms.ToolStripMenuItem saveSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetPointsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeLastPointToolStripMenuItem;
    }
}

