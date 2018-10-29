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

namespace img_vector
{
    public partial class mainForm : Form
    {

        /// <summary>
        /// Whether or not an image has yet been loaded into the image display box.
        /// </summary>
        bool pictureLoaded = false;

        /// <summary>
        /// List of all vectors created for this image.
        /// </summary>
        List<Vector> vectors = new List<Vector>();

        /// <summary>
        /// Index of the vector currently being worked on.
        /// </summary>
        int currentVectorIndex = 0;

        /// <summary>
        /// Current image being vectored.
        /// </summary>
        Image currentImage;

        /// <summary>
        /// Program settings.
        /// </summary>
        Settings settings = new Settings();

        public mainForm()
        {
            InitializeComponent();
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
                        vectors[currentVectorIndex].points.Add(new Point(e.X, e.Y));
                    }
                }
                else if(e.Button == MouseButtons.Right) // Right button : Delete closest point if a point is within a certain radius
                {
                    int index = vectors[currentVectorIndex].points.FindIndex(point => CursorIsInPoint(point, e.X, e.Y));
                    if (index > -1) // The cursor is actually in a point
                    {
                        vectors[currentVectorIndex].points.RemoveAt(index);
                    }
                }

                currentImagePictureBox.Refresh();
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
            foreach(Vector v in vectors) // TODO: Optimize this O(n^2) loop
            {
                foreach(Point p in v.points)
                {
                    if (CursorIsInPoint(p, X, Y))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void currentImagePictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            // If the mouse is on (within) a point, change the cursor to a finger.
            if(CursorIsInAnyPoint(e.X, e.Y))
            {
                Cursor.Current = Cursors.Hand;
            }
            else
            {
                Cursor.Current = Cursors.Arrow;
            }
        }

        private void currentImagePictureBox_Paint(object sender, PaintEventArgs e)
        {
            // This function paints all the vector points, lines, and vector area shading.

            if (pictureLoaded)
            {
                foreach(Vector v in vectors)
                {
                    v.DrawVector(settings, e.Graphics);
                }
            }
        }

        private void imageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.Filter = "Bitmaps|*.bmp|" +
                                    "PNG files|*.png|" +
                                    "JPEG files|*.jpg|" +
                                    "GIF files|*.gif|" +
                                    "TIFF files|*.tif|" +
                                    "Image files|*.bmp;*.jpg;*.gif;*.png;*.tif|" +
                                    "All files|*.*";

                if(fileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        LoadImage(new Bitmap(fileDialog.OpenFile()));
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Error", error.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// Loads a new image into the picture box.
        /// </summary>
        /// <param name="newImage">New image to be displayed via the picture box.
        /// </param>
        private void LoadImage(Image newImage)
        {
            this.vectors.Clear();
            this.vectors.Add(new Vector()); // Add a blank vector at index 0.
            this.currentVectorIndex = 0;

            this.currentImage = newImage; // Set the current image known as being displayed
            this.currentImagePictureBox.Image = this.currentImage; // Show the new image

            this.currentImagePictureBox.Width = newImage.Width; // Set the size of the picture box.
            this.currentImagePictureBox.Height = newImage.Height;

            this.pictureLoaded = true; // Set a variable indicating a picture has been loaded.
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
            this.vectors.Clear();
            this.vectors.Add(new Vector());
            this.currentVectorIndex = 0;

            this.currentImagePictureBox.Refresh();
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
            string file = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
            switch(Path.GetExtension(file).ToLower())
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
                    LoadImage(new Bitmap(file));
                    break;
            }
        }
    }
}
