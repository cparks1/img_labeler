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
        public static readonly Size thumbnailBoxSize = new Size(150, 75);
        readonly Size thumbnailLabelSize = new Size(150, 13);

        ImageList loadedImageList = new ImageList();

        public event EventHandler SelectedImageChanged;
        bool suppressSelectedImageChanged = false;

        public int SelectedIndex { get { return imageListView.Items.IndexOf(imageListView.SelectedItems[0]); } set { imageListView.Items[value].Selected = true; } }


        int desiredSelectionIndex = -1;

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
            suppressSelectedImageChanged = true; // Prevent any selection change events from being raised while loading new images

            loadedImageList.Images.Add(new Bitmap(image, thumbnailBoxSize)); // Add the new image to the image list
            int newImageIndex = loadedImageList.Images.Count - 1; // Get the index of the image loaded into the image list.
            imageListView.Items.Add(new ListViewItem { ImageIndex = newImageIndex, Text = filepath }); // Add the new item to the listview control

            if (this.Visible) // Only update the selection if this control is visible.
            {
                imageListView.Items[imageListView.Items.Count - 1].Selected = true; // Set this item as selected, since it is the latest item added.
            }
            else
            {
                desiredSelectionIndex = imageListView.Items.Count - 1;
            }

            suppressSelectedImageChanged = false; // Image load finished, re-allow selection change events.
        }

        /// <summary>
        /// Updates the thumbnail of the image currently being worked on.
        /// </summary>
        /// <param name="newThumbnail">New thumbnail to show.</param>
        public void ModifyCurrentImageThumbnail(Image newThumbnail)
        {
            if (SelectedIndex > -1)
            {
                loadedImageList.Images[SelectedIndex].Dispose();
                loadedImageList.Images[SelectedIndex] = new Bitmap(newThumbnail, thumbnailBoxSize);
            }
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

        private void ImageListForm_Shown(object sender, EventArgs e)
        {
            if(desiredSelectionIndex >= 0)
            {
                imageListView.Items[desiredSelectionIndex].Selected = true;
                desiredSelectionIndex = -1;
            }
        }
    }
}
