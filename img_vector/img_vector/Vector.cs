using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace img_vector
{
    public class Vector
    {
        /// <summary>
        /// All points that make up this vector.
        /// </summary>
        public List<Point> points;

        /// <summary>
        /// Classification of this vector.
        /// </summary>
        public string classification;

        /// <summary>
        /// Draws this vector onto an area given by the graphics object passed to the method.
        /// </summary>
        /// <param name="graphicsSettings">Settings dictated by the user.</param>
        /// <param name="g">Graphics object to draw with.</param>
        public void DrawVector(Settings graphicsSettings, Graphics g, float scaleFactor = 1.0f)
        {
            Pen point_border_pen = new Pen(graphicsSettings.pointOuterColor); // Color of the border of a point
            Pen point_inner_pen = new Pen(graphicsSettings.pointInnerColor); // Color of the inside of a point
            Pen vector_line_pen = new Pen(graphicsSettings.lineColor); // Color of a line
            Brush inner_shade_brush = new SolidBrush(graphicsSettings.shadingColor); // Color of the shading inside of the area defined by the vector

            GraphicsPath path = new GraphicsPath(); // GraphicsPath object used to shade the inside of a vector

            List<Point> scaledPoints = points.Select(point => new Point((int)(point.X * scaleFactor), (int)(point.Y * scaleFactor))).ToList(); // If a zoom level is being applied to the picture the points are being drawn over, the scale factor must be considered.
            for (int i = 0; i < scaledPoints.Count; i++) // Loop that draws each point representation, and the line between the two. Also adds the line to the graphics path.
            {
                Point p = scaledPoints[i]; // Get the point

                int x = p.X; // Default to top left representation
                int y = p.Y;

                if (graphicsSettings.pointRepresentationType == PointRepresentationType.Centered) // Unless settings dictate the representation being centered around the click point
                {
                    x = p.X - graphicsSettings.pointSize / 2;
                    y = p.Y - graphicsSettings.pointSize / 2;
                }

                g.DrawRectangle(point_border_pen, x, y, graphicsSettings.pointSize, graphicsSettings.pointSize); // Draw the point representation border
                // TODO: Add drawing the point inner portion

                if (i != 0)
                {
                    g.DrawLine(vector_line_pen, p, scaledPoints[i - 1]); // If this is a point after the first one, draw a line between the two representing the vector being created
                    path.AddLine(scaledPoints[i - 1], p); // Add the line to the graphics path so a vector area can be defined
                }
            }

            if (points.Count >= 3) // If a vector area can be defined
            {
                g.DrawLine(vector_line_pen, scaledPoints.Last(), scaledPoints.First()); // Draw a line closing the vector
                path.CloseFigure(); // Close the vector in the graphics path

                g.FillPath(inner_shade_brush, path); // Shade the vector area
            }
        }

        public void DrawPNGMask(Graphics g)
        {
            Brush inner_shade_brush = new SolidBrush(Color.White);
            GraphicsPath path = new GraphicsPath();

            if (points.Count > 1)
            {
                for (int i = 1; i < points.Count; i++)
                {
                    path.AddLine(points[i - 1], points[i]);
                }
            }

            path.CloseFigure();

            g.Clear(Color.Black); // Clear the image with the background being black.
            g.FillPath(inner_shade_brush, path);
        }

        public Vector()
        {
            points = new List<Point>();
        }

        public Vector(string vectorClassification) : this()
        {
            this.classification = vectorClassification;
        }
    }
}
