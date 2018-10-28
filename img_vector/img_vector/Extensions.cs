using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace img_vector
{
    static class Extensions
    {
        public static double DistanceTo(this Point point, Point point2)
        {
            return Math.Sqrt
            (
                (point2.X - point.X) * (point2.X - point.X) + // (X_2 - X_1)^2 +
                (point2.Y - point.Y) * (point2.Y - point.Y)   // (Y_2 - Y_1)^2
            );
        }

        public static double DistanceTo(this Point point, int x, int y)
        {
            return point.DistanceTo(new Point(x, y));
        }
    }
}
