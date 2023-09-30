namespace GeometrySharp
{
    public class Segment2D
    {
        public Segment2D(Point2D p1, Point2D p2)
        {
            StartPoint = p1;
            EndPoint = p2;
            Length = StartPoint.DistanceTo(EndPoint);
            if (Length == 0) IsPoint = true;
            else IsPoint = false;

            MidPoint = new Point2D(((StartPoint.X + EndPoint.X) / 2), ((StartPoint.Y + EndPoint.Y) / 2));

            double dx = EndPoint.X - StartPoint.X;
            double dy = EndPoint.Y - StartPoint.Y;
            Normal = Vector2D.Normalize(new Vector2D(new Point2D(-dy, dx), new Point2D(dy, -dx)));
        }

        public Point2D StartPoint { get; private set; }
        public Point2D EndPoint { get; private set; }
        public Point2D MidPoint { get; private set; }
        public bool IsPoint { get; private set; }
        public double Length { get; private set; }

        /// <summary>
        /// Vettore normale al segmento (normalizzato)
        /// </summary>
        public Vector2D Normal { get; private set; }

        /// <summary>
        /// Calculate if point p is inside segment
        /// </summary>
        /// <param name="p"></param>
        /// <returns>Returns true if point is inside</returns>
        public bool PointIsInside(Point2D p)
        {
            double length = StartPoint.DistanceTo(EndPoint);
            double l1 = p.DistanceTo(StartPoint);
            double l2 = p.DistanceTo(EndPoint);

            if (length == l1 + l2) return true;
            return false;
        }

        
        public static bool Intersection(Segment2D seg1, Segment2D seg2, out Point2D intersection)
        {
            intersection = null;

            Point2D p1 = seg1.StartPoint;
            Point2D p2 = seg1.EndPoint;
            Point2D p3 = seg2.StartPoint;
            Point2D p4 = seg2.EndPoint;

            double dx12 = p2.X - p1.X;
            double dy12 = p2.Y - p1.Y;
            double dx34 = p4.X - p3.X;
            double dy34 = p4.Y - p3.Y;

            double denominator = (dy12 * dx34 - dx12 * dy34);

            double t1 = ((p1.X - p3.X) * dy34 + (p3.Y - p1.Y) * dx34) / denominator;

            //Segmenti paralleli
            if (double.IsInfinity(t1))
                return false;

            double t2 = ((p3.X - p1.X) * dy12 + (p1.Y - p3.Y) * dx12) / -denominator;

            intersection = new Point2D(p1.X + dx12 * t1, p1.Y + dy12 * t1);

            return ((t1 >= 0) && (t1 <= 1) && (t2 >= 0) && (t2 <= 1));
        }

        public static bool AreParallel(Segment2D seg1, Segment2D seg2)
        {
            return Vector2D.AreParallel(new Vector2D(seg1), new Vector2D(seg2));
        }

        public void Translate(double x, double y, double z = 0)
        {
            StartPoint.Translate(x, y, z);
            EndPoint.Translate(x, y, z);
            Length = StartPoint.DistanceTo(EndPoint);
            if (Length == 0) IsPoint = true;
            else IsPoint = false;

            MidPoint = new Point2D(((StartPoint.X + EndPoint.X) / 2), ((StartPoint.Y + EndPoint.Y) / 2));

            double dx = EndPoint.X - StartPoint.X;
            double dy = EndPoint.Y - StartPoint.Y;
            Normal = Vector2D.Normalize(new Vector2D(new Point2D(-dy, dx), new Point2D(dy, -dx)));
        }
    }
}
