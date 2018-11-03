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
            this.newVectorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.directoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveVectorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetPointsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewImageListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewZoomPlusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewZoomMinusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.currentImagePictureBox = new System.Windows.Forms.PictureBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.mousePositionStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.zoomStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.mainFormMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.currentImagePictureBox)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainFormMenuStrip
            // 
            this.mainFormMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainFormMenuStrip_FileItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.mainFormMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainFormMenuStrip.Name = "mainFormMenuStrip";
            this.mainFormMenuStrip.Size = new System.Drawing.Size(802, 24);
            this.mainFormMenuStrip.TabIndex = 0;
            this.mainFormMenuStrip.Text = "menuStrip1";
            // 
            // mainFormMenuStrip_FileItem
            // 
            this.mainFormMenuStrip_FileItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newVectorToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.mainFormMenuStrip_FileItem.Name = "mainFormMenuStrip_FileItem";
            this.mainFormMenuStrip_FileItem.Size = new System.Drawing.Size(37, 20);
            this.mainFormMenuStrip_FileItem.Text = "File";
            // 
            // newVectorToolStripMenuItem
            // 
            this.newVectorToolStripMenuItem.Name = "newVectorToolStripMenuItem";
            this.newVectorToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.newVectorToolStripMenuItem.Text = "New Vector (Ctrl + N)";
            this.newVectorToolStripMenuItem.Click += new System.EventHandler(this.newVectorToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imageToolStripMenuItem,
            this.directoryToolStripMenuItem,
            this.openSettingsToolStripMenuItem});
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // imageToolStripMenuItem
            // 
            this.imageToolStripMenuItem.Name = "imageToolStripMenuItem";
            this.imageToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.imageToolStripMenuItem.Text = "Image";
            this.imageToolStripMenuItem.Click += new System.EventHandler(this.imageToolStripMenuItem_Click);
            // 
            // directoryToolStripMenuItem
            // 
            this.directoryToolStripMenuItem.Name = "directoryToolStripMenuItem";
            this.directoryToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.directoryToolStripMenuItem.Text = "Directory";
            // 
            // openSettingsToolStripMenuItem
            // 
            this.openSettingsToolStripMenuItem.Name = "openSettingsToolStripMenuItem";
            this.openSettingsToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.openSettingsToolStripMenuItem.Text = "Settings";
            this.openSettingsToolStripMenuItem.Click += new System.EventHandler(this.openSettingsToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveSettingsToolStripMenuItem,
            this.saveVectorsToolStripMenuItem});
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // saveSettingsToolStripMenuItem
            // 
            this.saveSettingsToolStripMenuItem.Name = "saveSettingsToolStripMenuItem";
            this.saveSettingsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveSettingsToolStripMenuItem.Text = "Settings";
            this.saveSettingsToolStripMenuItem.Click += new System.EventHandler(this.saveSettingsToolStripMenuItem_Click);
            // 
            // saveVectorsToolStripMenuItem
            // 
            this.saveVectorsToolStripMenuItem.Name = "saveVectorsToolStripMenuItem";
            this.saveVectorsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveVectorsToolStripMenuItem.Text = "Classification Data";
            this.saveVectorsToolStripMenuItem.Click += new System.EventHandler(this.saveVectorsToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetPointsToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // resetPointsToolStripMenuItem
            // 
            this.resetPointsToolStripMenuItem.Name = "resetPointsToolStripMenuItem";
            this.resetPointsToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.resetPointsToolStripMenuItem.Text = "Reset points";
            this.resetPointsToolStripMenuItem.Click += new System.EventHandler(this.resetPointsToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewImageListToolStripMenuItem,
            this.viewZoomPlusToolStripMenuItem,
            this.viewZoomMinusToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // viewImageListToolStripMenuItem
            // 
            this.viewImageListToolStripMenuItem.CheckOnClick = true;
            this.viewImageListToolStripMenuItem.Name = "viewImageListToolStripMenuItem";
            this.viewImageListToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.viewImageListToolStripMenuItem.Text = "Image List";
            this.viewImageListToolStripMenuItem.CheckedChanged += new System.EventHandler(this.viewImageListToolStripMenuItem_CheckedChanged);
            // 
            // viewZoomPlusToolStripMenuItem
            // 
            this.viewZoomPlusToolStripMenuItem.Name = "viewZoomPlusToolStripMenuItem";
            this.viewZoomPlusToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.viewZoomPlusToolStripMenuItem.Text = "Zoom (+)";
            this.viewZoomPlusToolStripMenuItem.Click += new System.EventHandler(this.viewZoomPlusToolStripMenuItem_Click);
            // 
            // viewZoomMinusToolStripMenuItem
            // 
            this.viewZoomMinusToolStripMenuItem.Name = "viewZoomMinusToolStripMenuItem";
            this.viewZoomMinusToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.viewZoomMinusToolStripMenuItem.Text = "Zoom (-)";
            this.viewZoomMinusToolStripMenuItem.Click += new System.EventHandler(this.viewZoomMinusToolStripMenuItem_Click);
            // 
            // currentImagePictureBox
            // 
            this.currentImagePictureBox.Location = new System.Drawing.Point(0, 0);
            this.currentImagePictureBox.Name = "currentImagePictureBox";
            this.currentImagePictureBox.Size = new System.Drawing.Size(800, 423);
            this.currentImagePictureBox.TabIndex = 1;
            this.currentImagePictureBox.TabStop = false;
            this.currentImagePictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.currentImagePictureBox_Paint);
            this.currentImagePictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.currentImagePictureBox_MouseClick);
            this.currentImagePictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.currentImagePictureBox_MouseMove);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mousePositionStatusLabel,
            this.zoomStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 447);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(802, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusStrip1";
            // 
            // mousePositionStatusLabel
            // 
            this.mousePositionStatusLabel.Name = "mousePositionStatusLabel";
            this.mousePositionStatusLabel.Size = new System.Drawing.Size(33, 17);
            this.mousePositionStatusLabel.Text = "(0, 0)";
            // 
            // zoomStatusLabel
            // 
            this.zoomStatusLabel.Name = "zoomStatusLabel";
            this.zoomStatusLabel.Size = new System.Drawing.Size(73, 17);
            this.zoomStatusLabel.Text = "Zoom: 100%";
            // 
            // mainPanel
            // 
            this.mainPanel.AutoScroll = true;
            this.mainPanel.Controls.Add(this.currentImagePictureBox);
            this.mainPanel.Location = new System.Drawing.Point(1, 24);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(800, 423);
            this.mainPanel.TabIndex = 3;
            // 
            // mainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(802, 469);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.mainFormMenuStrip);
            this.KeyPreview = true;
            this.MainMenuStrip = this.mainFormMenuStrip;
            this.Name = "mainForm";
            this.Text = "Image Vector";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.mainForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.mainForm_DragEnter);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mainForm_KeyDown);
            this.Resize += new System.EventHandler(this.mainForm_Resize);
            this.mainFormMenuStrip.ResumeLayout(false);
            this.mainFormMenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.currentImagePictureBox)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.mainPanel.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripMenuItem newVectorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveVectorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewImageListToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel zoomStatusLabel;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.ToolStripMenuItem viewZoomPlusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewZoomMinusToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel mousePositionStatusLabel;
    }
}

