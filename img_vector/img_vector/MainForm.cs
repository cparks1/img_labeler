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
        List<Point> vectorPoints = new List<Point>();

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
                    vectorPoints.Add(new Point(e.X, e.Y));
                    currentImagePictureBox.Refresh();
                }
                else if(e.Button == MouseButtons.Right) // Right button : Delete closest point if a point is within a certain radius
                {

                }
            }
        }

        private bool CursorIsInPoint(int X, int Y)
        {
            foreach(Point p in vectorPoints)
            {
                if (settings.pointRepresentationType == PointRepresentationType.TopLeft)
                {
                    if (X >= p.X && X <= p.X + settings.pointSize &&
                       Y >= p.Y && Y <= p.Y + settings.pointSize)
                    {
                        return true;
                    }
                }
                else if(settings.pointRepresentationType == PointRepresentationType.Centered)
                {
                    if(X >= p.X - settings.pointSize/2 && X <= p.X + settings.pointSize/2 && 
                       Y >= p.Y - settings.pointSize/2 && Y <= p.Y + settings.pointSize/2)
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
            if(CursorIsInPoint(e.X, e.Y))
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
                Pen point_border_pen = new Pen(settings.pointOuterColor); // Color of the border of a point
                Pen point_inner_pen = new Pen(settings.pointInnerColor); // Color of the inside of a point

                Pen vector_line_pen = new Pen(settings.lineColor); // Color of a line

                Brush inner_shade_brush = new SolidBrush(settings.shadingColor); // Color of the shading inside of the area defined by the vector

                GraphicsPath path = new GraphicsPath();
                for(int i=0; i<vectorPoints.Count; i++)
                {
                    Point p = vectorPoints[i]; // Get the point

                    int x = p.X; // Default to top left representation
                    int y = p.Y;

                    if(settings.pointRepresentationType == PointRepresentationType.Centered) // Unless settings dictate the representation being centered around the click point
                    {
                        x = p.X - settings.pointSize / 2;
                        y = p.Y - settings.pointSize / 2;
                    }

                    e.Graphics.DrawRectangle(point_border_pen, x, y, settings.pointSize, settings.pointSize); // Draw the point representation

                    if (i!=0)
                    {
                        e.Graphics.DrawLine(point_border_pen, p, vectorPoints[i - 1]); // If this is a point besides the first one, draw a line representing the vector created
                        path.AddLine(vectorPoints[i - 1], p); // Add the point to the graphics path so a vector area can be defined
                    }
                }

                if(vectorPoints.Count >= 3) // If a vector area can be defined
                {
                    e.Graphics.DrawLine(point_border_pen, vectorPoints.Last(), vectorPoints.First()); // Draw a line closing the vector
                    path.CloseFigure(); // Close the vector in the graphics path

                    e.Graphics.FillPath(inner_shade_brush, path); // Shade the vector area
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
            this.vectorPoints.Clear(); // Clear all points added, if any.

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
            this.vectorPoints.Clear(); // Clear all added points.
            this.currentImagePictureBox.Refresh();
        }
    }
}
