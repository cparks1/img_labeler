namespace img_vector.Forms
{
    partial class ImageListForm
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
            this.imageListView = new System.Windows.Forms.ListView();
            this.filePathColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // imageListView
            // 
            this.imageListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.filePathColumn});
            this.imageListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.imageListView.Location = new System.Drawing.Point(0, 0);
            this.imageListView.MultiSelect = false;
            this.imageListView.Name = "imageListView";
            this.imageListView.Size = new System.Drawing.Size(333, 450);
            this.imageListView.TabIndex = 0;
            this.imageListView.UseCompatibleStateImageBehavior = false;
            this.imageListView.View = System.Windows.Forms.View.Details;
            this.imageListView.SelectedIndexChanged += new System.EventHandler(this.imageListView_SelectedIndexChanged);
            // 
            // filePathColumn
            // 
            this.filePathColumn.Text = "Loaded Images";
            this.filePathColumn.Width = 333;
            // 
            // ImageListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(333, 450);
            this.Controls.Add(this.imageListView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "ImageListForm";
            this.Text = "Images";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ColumnHeader filePathColumn;
        private System.Windows.Forms.ListView imageListView;
    }
}