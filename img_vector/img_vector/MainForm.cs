using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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
        /// List of all current vectors.
        /// </summary>
        List<Point> vectors = new List<Point>();

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
                    vectors.Add(new Point(e.X, e.Y));
                    currentImagePictureBox.Refresh();
                }
                else if(e.Button == MouseButtons.Right) // Right button : Delete closest point if a point is within a certain radius
                {

                }
            }
        }

        private void currentImagePictureBox_Paint(object sender, PaintEventArgs e)
        {
            // This function paints all the vector points, lines, and vector area shading.

            if (pictureLoaded)
            {
                Pen point_border_pen = new Pen(settings.pointOuterColor); // Color of the border of a point
                Pen point_inner_pen = new Pen(settings.pointInnerColor); // Color of the inside of a point

                Pen vector_line_pen = new Pen(settings.lineColor); // Color of a line

                Brush inner_shade_brush = new SolidBrush(settings.shadingColor); // Color of the shading inside of the area defined by the vector

                GraphicsPath path = new GraphicsPath();
                for(int i=0; i<vectors.Count; i++)
                {
                    Point p = vectors[i];
                    e.Graphics.DrawRectangle(point_border_pen, new Rectangle(p.X, p.Y, 2, 2));

                    if(i!=0)
                    {
                        e.Graphics.DrawLine(point_border_pen, p, vectors[i - 1]);
                        path.AddLine(vectors[i - 1], p);
                    }
                }

                if(vectors.Count >= 3)
                {
                    e.Graphics.DrawLine(point_border_pen, vectors.Last(), vectors.First());
                    path.CloseFigure();

                    e.Graphics.FillPath(inner_shade_brush, path);
                }
            }
        }

        private void imageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
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
            this.vectors.Clear(); // Clear all points added, if any.

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
            this.vectors.Clear(); // Clear all added points.
            this.currentImagePictureBox.Refresh();
        }
    }
}
