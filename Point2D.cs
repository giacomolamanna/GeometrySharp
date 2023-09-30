using System;

namespace GeometrySharp
{
    public class Point2D
    {
        public Point2D(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get; set; }
        public double Y { get; set; }

        public static Point2D Zero = new Point2D(0, 0);

        public double DistanceTo(Point2D p) => Math.Sqrt(Math.Pow(p.X - X, 2) + Math.Pow(p.Y - Y, 2));

        public Point2D MidPoint(Point2D p)
        {
            return new Point2D(((X + p.X) / 2), ((Y + p.Y) / 2));
        }

        public void Translate(double x, double y, double z = 0)
        {
            X += x;
            Y += y;
        }

        public static Point2D operator +(Point2D p1, Point2D p2)
        {
            return new Point2D(p1.X + p2.X, p1.Y + p2.Y);
        }

        public static Point2D operator -(Point2D p1, Point2D p2)
        {
            return new Point2D(p1.X - p2.X, p1.Y - p2.Y);
        }

    }
}
