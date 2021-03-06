﻿using img_vector.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using Ookii.Dialogs;

namespace img_vector
{
    public partial class mainForm : Form
    {

        /// <summary>
        /// Whether or not an image has yet been loaded into the image display box.
        /// </summary>
        bool pictureLoaded => imageClassifications.Count > 0;

        /// <summary>
        /// List of all images loaded and their classifications during this session.
        /// </summary>
        List<ImageClassification> imageClassifications = new List<ImageClassification>();

        /// <summary>
        /// Index of the image classification currently being worked on.
        /// </summary>
        int currentImageClassificationIndex = 0;

        /// <summary>
        /// Image classification currently being worked on.
        /// </summary>
        ImageClassification currentImageClassification => imageClassifications.Count > 0 && currentImageClassificationIndex >= 0 ? imageClassifications[currentImageClassificationIndex] : null;

        /// <summary>
        /// Index of the vector currently being worked on.
        /// </summary>
        int currentVectorIndex = 0;

        /// <summary>
        /// The vector currently being worked on.
        /// </summary>
        Vector currentVector => currentImageClassification.vectors.Count > 0 && currentVectorIndex >= 0 ? currentImageClassification.vectors[currentVectorIndex] : null;

        /// <summary>
        /// Program settings.
        /// </summary>
        Settings settings = new Settings();

        /// <summary>
        /// Current zoom level, in percentage.
        /// </summary>
        int currentZoomLevel = 100;

        /// <summary>
        /// Percentage by which the zoom will increment/decrement when zooming.
        /// </summary>
        const int zoomStep = 25;

        /// <summary>
        /// Window used to display and change between loaded images.
        /// </summary>
        ImageListForm imageList;

        public mainForm()
        {
            InitializeComponent();
            imageList = new ImageListForm();
            imageList.VisibleChanged += ImageList_VisibleChanged;
            imageList.SelectedImageChanged += ImageList_SelectedImageChanged;
        }

        private void ImageList_VisibleChanged(object sender, EventArgs e)
        {
            // Handles the image list window being closed via the X button not updating the "View->Image List" check state.
            if(!imageList.Visible)
            {
                viewImageListToolStripMenuItem.Checked = false;
            }
        }

        private void ImageList_SelectedImageChanged(object sender, EventArgs e)
        {
            this.currentImageClassificationIndex = imageList.SelectedIndex; // Set the index of the current image classification to the selected image classification.
            currentVectorIndex = this.currentImageClassification.vectors.Count - 1; // Set the vector being worked on to the last vector created.
            currentZoomLevel = 100; // Reset the zoom level back to 100.
            zoomStatusLabel.Text = $"Zoom: {currentZoomLevel}%"; // Set the zoom status label to reflect this.

            if (currentImagePictureBox.Image != null)
            {
                currentImagePictureBox.Image.Dispose();
            }
            currentImagePictureBox.Size = currentImageClassification.imageSize; // Set the size of the picturebox to the size of the image to be displayed.

            using (Image i = currentImageClassification.WorkingImage())
            {
                currentImagePictureBox.Image = new Bitmap(i); // Set the image being displayed.
            }
            currentImagePictureBox.Refresh();
        }

        private void currentImagePictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            // When the picture box is clicked (and has an image loaded),
            // via the left mouse button: A new point will be recorded and displayed
            // via the right mouse button: The closest point (if one is within 5 pixels) will be removed and no longer displayed.

            if (pictureLoaded)
            {
                if (e.Button == MouseButtons.Left) // Left button : Add new point
                {
                    if (!CursorIsInAnyPoint(e.X, e.Y)) // Don't add a new point if we're already inside of one.
                    {
                        if (currentVector != null) // If a vector has been created
                        {
                            currentVector.points.Add(new Point((int)(e.X / (currentZoomLevel / 100.0f)), (int)(e.Y / (currentZoomLevel / 100.0f))));

                            UpdateImageListThumbnail();
                        }
                    }
                }
                else if(e.Button == MouseButtons.Right) // Right button : Delete closest point if a point is within a certain radius
                {
                    if (currentVector != null && currentVector.points.Count > 0) // If a vector has been created and has at least one point
                    {
                        int index = currentVector.points.FindIndex(point => CursorIsInPoint(new Point((int)(point.X * currentZoomLevel / 100.0f), (int)(point.Y * currentZoomLevel / 100.0f)), e.X, e.Y));
                        if (index > -1) // The cursor is actually in a point
                        {
                            currentVector.points.RemoveAt(index);

                            UpdateImageListThumbnail();
                        }
                    }
                }

                currentImagePictureBox.Refresh();
            }
        }

        /// <summary>
        /// Updates the thumbnail of the current working image in the imagelistform.
        /// </summary>
        private void UpdateImageListThumbnail()
        {
            using (Bitmap newThumbnail = new Bitmap(currentImageClassification.imagePath)) // Work from the original image instead of the currently shown image in case there is a high zoom level (to save on memory usage)
            {
                Graphics g = Graphics.FromImage(newThumbnail); // Get a graphics object to draw with
                DrawCurrentImageVectors(g, 1); // Draw the vectors onto the image, with no scaling, since we're working from the original image.
                imageList.ModifyCurrentImageThumbnail(newThumbnail);
            }
        }

        private bool CursorIsInPoint(Point p, int cursor_x, int cursor_y)
        {
            if (settings.pointRepresentationType == PointRepresentationType.TopLeft)
            {
                if (cursor_x >= p.X && cursor_x <= p.X + settings.pointSize &&
                   cursor_y >= p.Y && cursor_y <= p.Y + settings.pointSize)
                {
                    return true;
                }
            }
            else if (settings.pointRepresentationType == PointRepresentationType.Centered)
            {
                if (cursor_x >= p.X - settings.pointSize / 2 && cursor_x <= p.X + settings.pointSize / 2 &&
                   cursor_y >= p.Y - settings.pointSize / 2 && cursor_y <= p.Y + settings.pointSize / 2)
                {
                    return true;
                }
            }

            return false;
        }

        private bool CursorIsInAnyPoint(int X, int Y)
        {
            if (pictureLoaded) // An image has been loaded for classification
            {
                foreach (Vector v in currentImageClassification.vectors) // TODO: Optimize this O(n^2) loop, if possible.
                {
                    foreach (Point p in v.points)
                    {
                        Point scaledPoint = new Point((int)(p.X * currentZoomLevel / 100.0f), (int)(p.Y * currentZoomLevel / 100.0f)); // Handle the zoom level
                        if (CursorIsInPoint(scaledPoint, X, Y))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private void currentImagePictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if(CursorIsInAnyPoint(e.X, e.Y))  // If the mouse is on (within) a point, change the cursor to a hand with a pointing finger.
            {
                Cursor.Current = Cursors.Hand;
            }
            else // Default the cursor back to a normal arrow otherwise.
            {
                Cursor.Current = Cursors.Arrow;
            }

            mousePositionStatusLabel.Text = $"({(int)(e.X / (currentZoomLevel / 100.0f))}, {(int)(e.Y / (currentZoomLevel / 100.0f))})"; // Ex: (1235, 1904)
        }

        /// <summary>
        /// Draws all the vectors for the current image, using the given graphics object and scaling factor.
        /// </summary>
        /// <param name="g">Graphics object to draw with.</param>
        /// <param name="scaleFactor">Optional parameter that defaults to the current zoom level divided by 100 (to get a percent scale) if not specified, or if set to -1.</param>
        private void DrawCurrentImageVectors(Graphics g, float scaleFactor = -1)
        {
            if(scaleFactor == -1)
            {
                scaleFactor = currentZoomLevel / 100.0f;
            }

            if(pictureLoaded)
            {
                foreach(Vector v in currentImageClassification.vectors)
                {
                    v.DrawVector(settings, g, scaleFactor);
                }
            }
        }

        private void currentImagePictureBox_Paint(object sender, PaintEventArgs e)
        {
            DrawCurrentImageVectors(e.Graphics);
        }

        /// <summary>
        /// Event called upon user selecting File->Open->Image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void imageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.Filter = "Bitmaps|*.bmp|" + // Filter for all types of image files, with an option to select a file with an extension not included.
                                    "PNG files|*.png|" +
                                    "JPEG files|*.jpg|" +
                                    "GIF files|*.gif|" +
                                    "TIFF files|*.tif|" +
                                    "Image files|*.bmp;*.jpg;*.gif;*.png;*.tif|" +
                                    "All files|*.*";

                if(fileDialog.ShowDialog() == DialogResult.OK) // The user has selected a file to open and clicked OK
                {
                    try
                    {
                        LoadImage(fileDialog.FileName, displayNewImage: true);
                    }
                    catch (Exception error) // If the user chose a file that isn't an image file, or somehow selected a file that doesn't exist, we'll catch the error and display it to the user.
                    {
                        MessageBox.Show("Error", error.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// Loads a new image into the picture box.
        /// </summary>
        /// <param name="newImage">New image to be displayed via the picture box.</param>
        private void LoadImage(string filePath, bool displayNewImage)
        {
            this.imageClassifications.Add(new ImageClassification(filePath)); // Add a new image classification object to the list.
            this.currentImageClassificationIndex = this.imageClassifications.Count - 1; // Set the current image classification index to the new classification object.
            this.currentVectorIndex = 0; // Reset the current vector.

            using (Image newImage = Image.FromFile(filePath))
            {
                imageList.AddNewImage(newImage, filePath); // Add a new image to the image list.

                if (displayNewImage)
                {
                    this.currentZoomLevel = 100; // Reset the zoom level.
                    zoomStatusLabel.Text = $"Zoom: {currentZoomLevel}%"; // Reset the zoom status label.

                    if (this.currentImagePictureBox.Image != null) // Get rid of the old picture being shown.
                    {
                        this.currentImagePictureBox.Image.Dispose();
                    }

                    using (Image i = this.currentImageClassification.WorkingImage())
                    {
                        this.currentImagePictureBox.Image = new Bitmap(i); // Show the new image
                    }

                    this.currentImagePictureBox.Size = this.currentImageClassification.imageSize; // Set the size of the picture box so that it can display the entire image.

                    this.Activate();
                }
            }
        }

        private void saveSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
                if(saveDialog.ShowDialog() == DialogResult.OK)
                {
                    settings.saveToXMLFile(saveDialog.FileName);
                }
            }
        }

        private void openSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openDialog = new OpenFileDialog())
            {
                openDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
                if(openDialog.ShowDialog() == DialogResult.OK)
                {
                    this.settings = Settings.fromFilepath(openDialog.FileName);
                    currentImagePictureBox.Refresh();
                }
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SettingsForm settingsForm = new SettingsForm(this.settings))
            {
                if(settingsForm.ShowDialog() == DialogResult.OK)
                {
                    this.settings = settingsForm.Settings;
                    currentImagePictureBox.Refresh();
                }
            }
        }

        private void resetPointsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Clear all added points.
            if(imageClassifications.Count > 0)
            {
                if(currentImageClassification.vectors.Count > 0)
                {
                    if(MessageBox.Show("Are you sure you wish to delete all classified vectors for this image?", "Please confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        currentImageClassification.vectors.Clear();
                        this.currentVectorIndex = 0;
                        this.currentImagePictureBox.Refresh();
                    }
                }
            }
        }

        private void mainForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void mainForm_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            for(int i=0; i<files.Length; i++)
            {
                string file = files[i];

                switch (Path.GetExtension(file).ToLower())
                {
                    case ".xml":
                        this.settings = Settings.fromFilepath(file);
                        break;
                    case ".jpg":
                    case ".jpeg":
                    case ".png":
                    case ".bmp":
                    case ".gif":
                    case ".tif":
                        LoadImage(file, displayNewImage: i == files.Length - 1);
                        break;
                }
            }
        }

        /// <summary>
        /// Event called upon user clicking File -> Open -> Directory
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void directoryToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Adds a new vector. Prompts the user for this vector's classification in doing so.
        /// </summary>
        private void AddNewVector()
        {
            if (pictureLoaded) // An image has been loaded for classification
            {
                if (currentVector != null && currentVector.points.Count <= 0)  // User tried to create a new vector when the current one is blank.
                {
                    MessageBox.Show("Your current vector is blank. You must add some points before creating a new vector.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (ClassificationQueryForm classificationQuery = new ClassificationQueryForm())
                {
                    if (currentVector != null) // If a vector has already been created
                    {
                        classificationQuery.Classification = currentVector.classification; // Default the classification being presented to be the last classification entered.
                    }
                    classificationQuery.Activate(); // Activate the classification query form so the user can just type and press enter instead of having to click the query form first

                    if (classificationQuery.ShowDialog() == DialogResult.OK) // If the user clicked "OK"
                    {
                        currentImageClassification.vectors.Add(new Vector(classificationQuery.Classification)); // Then add the new vector, with the classification the user entered.
                        currentVectorIndex = currentImageClassification.vectors.Count - 1; // Set the current vector to be the new vector.
                    }
                }
            }
            else // User tried to create a new vector when an image hasn't even been loaded yet.
            {
                MessageBox.Show("You must load an image before creating a vector.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Activate(); // Bring focus back to this form.
        }

        private void newVectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewVector();
        }

        private void mainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Control && e.KeyCode == Keys.N) // New vector
            {
                AddNewVector();
            }
            else if(e.Control && e.KeyCode == Keys.Add) // Zoom in
            {
                ZoomImageShown(increment: true);
            }
            else if(e.Control && e.KeyCode == Keys.Subtract) // Zoom out
            {
                ZoomImageShown(increment: false);
            }
        }

        private void saveVectorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureLoaded)
            {
                using (ExportChoiceForm exportForm = new ExportChoiceForm(typeof(List<ImageClassification>), imageClassifications))
                {
                    if (exportForm.ShowDialog() == DialogResult.OK)
                    {
                        switch (exportForm.DataFormat)
                        {
                            case ExportChoiceForm.ExportFormat.JSON:
                            case ExportChoiceForm.ExportFormat.XML:
                                using (SaveFileDialog saveDialog = new SaveFileDialog())
                                {
                                    saveDialog.Filter = $"{exportForm.DataFormat.ToString()} Files | *.{exportForm.DataFormat.ToString()}";
                                    if (saveDialog.ShowDialog() == DialogResult.OK)
                                    {
                                        File.WriteAllText(saveDialog.FileName, exportForm.Text_Export_Data);
                                    }
                                }
                                break;
                            case ExportChoiceForm.ExportFormat.PNG_Segmentation_Mask:
                                using (VistaFolderBrowserDialog dirBrowser = new VistaFolderBrowserDialog())
                                {
                                    dirBrowser.Description = "Select a folder to save the PNG masks to.";
                                    if (dirBrowser.ShowDialog() == DialogResult.OK)
                                    {
                                        Image[] masks = currentImageClassification.PNG_Masks();
                                        for (int i = 0; i < masks.Length; i++)
                                        {
                                            masks[i].Save(Path.Combine(dirBrowser.SelectedPath, Path.GetFileNameWithoutExtension(currentImageClassification.imagePath) + '_' + i.ToString() + ".png"), System.Drawing.Imaging.ImageFormat.Png);
                                            masks[i].Dispose();
                                        }
                                    }
                                }
                                break;
                        }
                    }
                }
            }
        }

        private void viewImageListToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if(viewImageListToolStripMenuItem.Checked) // Show the image list window if not already shown.
            {
                imageList.Show();
            }
            else // Hide the image list window if not already shown.
            {
                imageList.Hide();
            }
        }

        /// <summary>
        /// Event called upon the main form's size changing.
        /// Resizes the main panel to take up the entire space of the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainForm_Resize(object sender, EventArgs e)
        {
            mainPanel.Width = this.Width - 18;
            mainPanel.Height = this.Height - 85;
        }

        /// <summary>
        /// Zooms the image in the picturebox by a given amount.
        /// </summary>
        /// <param name="increment">Whether to increment or decrement the current zoom level.</param>
        private void ZoomImageShown(bool increment)
        {
            if (pictureLoaded)
            {
                currentZoomLevel = increment ? currentZoomLevel + zoomStep : currentZoomLevel <= zoomStep ? currentZoomLevel : currentZoomLevel - zoomStep; // Zoom in as much as you want, but prevent the zoom level from going to 0 or lower than 0 because it will throw exceptions.

                float zoomScaleFactor = currentZoomLevel / 100.0f;

                currentImagePictureBox.Image.Dispose();

                using (Image i = currentImageClassification.WorkingImage())
                {
                    currentImagePictureBox.Image = new Bitmap(i, new Size((int)(currentImageClassification.imageSize.Width * zoomScaleFactor), (int)(currentImageClassification.imageSize.Height * zoomScaleFactor)));
                }
                currentImagePictureBox.Size = currentImagePictureBox.Image.Size;

                zoomStatusLabel.Text = $"Zoom: {currentZoomLevel.ToString()}%";
            }
        }

        private void viewZoomPlusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ZoomImageShown(increment: true);
        }

        private void viewZoomMinusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ZoomImageShown(increment: false);
        }
    }
}
