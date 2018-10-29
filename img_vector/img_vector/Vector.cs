using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace img_vector
{
    class Vector
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
        public void DrawVector(Settings graphicsSettings, Graphics g)
        {
            Pen point_border_pen = new Pen(graphicsSettings.pointOuterColor); // Color of the border of a point
            Pen point_inner_pen = new Pen(graphicsSettings.pointInnerColor); // Color of the inside of a point

            Pen vector_line_pen = new Pen(graphicsSettings.lineColor); // Color of a line

            Brush inner_shade_brush = new SolidBrush(graphicsSettings.shadingColor); // Color of the shading inside of the area defined by the vector

            GraphicsPath path = new GraphicsPath();
            for (int i = 0; i < points.Count; i++)
            {
                Point p = points[i]; // Get the point

                int x = p.X; // Default to top left representation
                int y = p.Y;

                if (graphicsSettings.pointRepresentationType == PointRepresentationType.Centered) // Unless settings dictate the representation being centered around the click point
                {
                    x = p.X - graphicsSettings.pointSize / 2;
                    y = p.Y - graphicsSettings.pointSize / 2;
                }

                g.DrawRectangle(point_border_pen, x, y, graphicsSettings.pointSize, graphicsSettings.pointSize); // Draw the point representation

                if (i != 0)
                {
                    g.DrawLine(point_border_pen, p, points[i - 1]); // If this is a point besides the first one, draw a line representing the vector created
                    path.AddLine(points[i - 1], p); // Add the point to the graphics path so a vector area can be defined
                }
            }

            if (points.Count >= 3) // If a vector area can be defined
            {
                g.DrawLine(point_border_pen, points.Last(), points.First()); // Draw a line closing the vector
                path.CloseFigure(); // Close the vector in the graphics path

                g.FillPath(inner_shade_brush, path); // Shade the vector area
            }
        }

        public Vector()
        {
            points = new List<Point>();
        }
    }
}
