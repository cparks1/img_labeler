namespace img_vector
{
    partial class ExportChoiceForm
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
            this.exportExampleTextbox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.exportFormatPNGMaskRadioButton = new System.Windows.Forms.RadioButton();
            this.exportFormatXMLRadioButton = new System.Windows.Forms.RadioButton();
            this.exportFormatJSONRadioButton = new System.Windows.Forms.RadioButton();
            this.exportButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // exportExampleTextbox
            // 
            this.exportExampleTextbox.Location = new System.Drawing.Point(13, 13);
            this.exportExampleTextbox.Multiline = true;
            this.exportExampleTextbox.Name = "exportExampleTextbox";
            this.exportExampleTextbox.ReadOnly = true;
            this.exportExampleTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.exportExampleTextbox.Size = new System.Drawing.Size(400, 369);
            this.exportExampleTextbox.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.exportFormatPNGMaskRadioButton);
            this.groupBox1.Controls.Add(this.exportFormatXMLRadioButton);
            this.groupBox1.Controls.Add(this.exportFormatJSONRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(13, 389);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(400, 101);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Export Format";
            // 
            // exportFormatPNGMaskRadioButton
            // 
            this.exportFormatPNGMaskRadioButton.AutoSize = true;
            this.exportFormatPNGMaskRadioButton.Location = new System.Drawing.Point(7, 68);
            this.exportFormatPNGMaskRadioButton.Name = "exportFormatPNGMaskRadioButton";
            this.exportFormatPNGMaskRadioButton.Size = new System.Drawing.Size(169, 17);
            this.exportFormatPNGMaskRadioButton.TabIndex = 2;
            this.exportFormatPNGMaskRadioButton.TabStop = true;
            this.exportFormatPNGMaskRadioButton.Text = "PNG Segmentation Mask Files";
            this.exportFormatPNGMaskRadioButton.UseVisualStyleBackColor = true;
            this.exportFormatPNGMaskRadioButton.CheckedChanged += new System.EventHandler(this.exportChoice_Changed);
            // 
            // exportFormatXMLRadioButton
            // 
            this.exportFormatXMLRadioButton.AutoSize = true;
            this.exportFormatXMLRadioButton.Location = new System.Drawing.Point(7, 44);
            this.exportFormatXMLRadioButton.Name = "exportFormatXMLRadioButton";
            this.exportFormatXMLRadioButton.Size = new System.Drawing.Size(47, 17);
            this.exportFormatXMLRadioButton.TabIndex = 1;
            this.exportFormatXMLRadioButton.TabStop = true;
            this.exportFormatXMLRadioButton.Text = "XML";
            this.exportFormatXMLRadioButton.UseVisualStyleBackColor = true;
            this.exportFormatXMLRadioButton.CheckedChanged += new System.EventHandler(this.exportChoice_Changed);
            // 
            // exportFormatJSONRadioButton
            // 
            this.exportFormatJSONRadioButton.AutoSize = true;
            this.exportFormatJSONRadioButton.Location = new System.Drawing.Point(7, 20);
            this.exportFormatJSONRadioButton.Name = "exportFormatJSONRadioButton";
            this.exportFormatJSONRadioButton.Size = new System.Drawing.Size(53, 17);
            this.exportFormatJSONRadioButton.TabIndex = 0;
            this.exportFormatJSONRadioButton.TabStop = true;
            this.exportFormatJSONRadioButton.Text = "JSON";
            this.exportFormatJSONRadioButton.UseVisualStyleBackColor = true;
            this.exportFormatJSONRadioButton.CheckedChanged += new System.EventHandler(this.exportChoice_Changed);
            // 
            // exportButton
            // 
            this.exportButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.exportButton.Location = new System.Drawing.Point(13, 496);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(90, 23);
            this.exportButton.TabIndex = 2;
            this.exportButton.Text = "Export";
            this.exportButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(323, 496);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(90, 23);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // ExportChoiceForm
            // 
            this.AcceptButton = this.exportButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(432, 616);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.exportExampleTextbox);
            this.Name = "ExportChoiceForm";
            this.Text = "Select Export Format";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox exportExampleTextbox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton exportFormatXMLRadioButton;
        private System.Windows.Forms.RadioButton exportFormatJSONRadioButton;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.RadioButton exportFormatPNGMaskRadioButton;
    }
}