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
        Settings settings;

        public mainForm()
        {
            InitializeComponent();
        }

        private void currentImagePictureBox_MouseClick(object sender, MouseEventArgs e)
        {
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
            if (pictureLoaded)
            {
                Pen point_border_pen = new Pen(Color.Black);
                Pen point_inner_pen = new Pen(Color.Red);
                Brush inner_shade_brush = new SolidBrush(Color.Purple);

                GraphicsPath path = new GraphicsPath();
                for(int i=0; i<vectors.Count; i++)
                {
                    Point p = vectors[i];
                    e.Graphics.DrawRectangle(point_border_pen, new Rectangle(p.X, p.Y, 2, 2));

                    if(i!=0)
                    {
                        e.Graphics.DrawLine(point_border_pen, p, vectors[i - 1]);
                        path.AddLine(p, vectors[i - 1]);
                    }
                }

                if(vectors.Count >= 3)
                {
                    e.Graphics.DrawLine(point_border_pen, vectors.Last(), vectors.First());
                    path.AddLine(vectors.Last(), vectors.First());

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

        private void LoadImage(Image newImage)
        {
            this.currentImage = newImage;
            this.currentImagePictureBox.Image = this.currentImage;

            this.currentImagePictureBox.Width = newImage.Width;
            this.currentImagePictureBox.Height = newImage.Height;

            this.pictureLoaded = true;
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

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
