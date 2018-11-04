using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace img_vector.Forms
{
    public partial class ImageListForm : Form
    {
        readonly Size thumbnailBoxSize = new Size(150, 75);
        readonly Size thumbnailLabelSize = new Size(150, 13);

        ImageList loadedImageList = new ImageList();

        public event EventHandler SelectedImageChanged;
        bool suppressSelectedImageChanged = false;

        public int SelectedIndex { get { return imageListView.Items.IndexOf(imageListView.SelectedItems[0]); } set { imageListView.Items[value].Selected = true; } }

        /// <summary>
        /// Y Position for the next element set representing an image thumbnail.
        /// </summary>
        int newControl_Y_Position = 13;

        /// <summary>
        /// X position for the next new picture box element representing an image thumbnail.
        /// </summary>
        int newThumbnail_X_Position = 13;

        /// <summary>
        /// X position for the next new label representing the filepath of the corresponding thumbnail.
        /// </summary>
        int newLabel_X_Position = 170;

        /// <summary>
        /// Amount of Y position increase from the Y position of the label's corresponding thumbnail.
        /// </summary>
        const int label_Y_Position_Relative_To_Thumbnail = 34;

        /// <summary>
        /// Amount of Y position increase from the Y position of the last label to the next picture box.
        /// </summary>
        const int nextPicture_Y_Position_Relative_To_Last_Label = 48;

        public ImageListForm()
        {
            InitializeComponent();

            loadedImageList.ImageSize = thumbnailBoxSize;
            imageListView.LargeImageList = loadedImageList;
            imageListView.SmallImageList = loadedImageList;
        }

        public void AddNewImage(Image image, string filepath)
        {
            suppressSelectedImageChanged = true;
            loadedImageList.Images.Add(image);
            int newImageIndex = loadedImageList.Images.Count - 1;
            imageListView.Items.Add(new ListViewItem { ImageIndex = newImageIndex, Text = filepath });
            imageListView.Items[imageListView.Items.Count - 1].Selected = true;
            suppressSelectedImageChanged = false;

            /// PictureBox setup
            /*
            PictureBox pb = new PictureBox();
            pb.Location = new Point(newThumbnail_X_Position, newControl_Y_Position);
            pb.Size = thumbnailBoxSize; // Set the size of the picturebox to be thumbnail sized.
            pb.SizeMode = PictureBoxSizeMode.StretchImage; // Resizes the image to fit the picturebox as a thumbnail instead of the full image.
            pb.Image = image; // Set the image being shown inside of the picturebox.

            newControl_Y_Position += label_Y_Position_Relative_To_Thumbnail; // Increment the y position for the label.

            /// Label setup
            Label label = new Label();
            label.Location = new Point(newLabel_X_Position, newControl_Y_Position);
            label.AutoSize = false; // Disable autosizing of the label from making the label too long for long filepaths
            label.Size = thumbnailLabelSize; // Set the size of the label
            label.AutoEllipsis = true; // If the text in the label is too long, it will shorten it and append "..."
            label.Text = filepath; // Set the text to be the path of the file.

            newControl_Y_Position += nextPicture_Y_Position_Relative_To_Last_Label;

            // Add the picturebox and label to the controls
            Controls.Add(pb);
            Controls.Add(label);*/
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            // Do not ever override a close caused by windows shutting down.
            if (e.CloseReason == CloseReason.WindowsShutDown)
            {
                return;
            }
            else if(e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide(); // Opt to hide the image list window instead of closing it.
            }
        }

        private void imageListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            EventHandler eventHandler = SelectedImageChanged;
            if (eventHandler != null && !suppressSelectedImageChanged && imageListView.SelectedIndices.Count > 0)
            {
                eventHandler(this, e);
            }
        }
    }
}
