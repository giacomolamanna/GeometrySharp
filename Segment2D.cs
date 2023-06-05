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

        public static Point2D Intersection(Segment2D s1, Segment2D s2)
        {
            double m1 = (s1.EndPoint.Y - s1.StartPoint.Y) / (s1.EndPoint.X - s1.StartPoint.X);
            double m2 = (s2.EndPoint.Y - s2.StartPoint.Y) / (s2.EndPoint.X - s2.StartPoint.X);
            double y = (1 / (m2 - m1)) * (-m1 * s2.StartPoint.Y + m1 * m2 * s2.StartPoint.X - m1 * m2 * s1.StartPoint.X + m2 * s1.StartPoint.Y);
            double x = (1 / m2) * (y - s2.StartPoint.Y + m2 * s2.StartPoint.X);
            return new Point2D(x, y);
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
