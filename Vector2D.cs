public class Vector2D
    {
        public Vector2D(Point2D p)
        {
            X = p.X;
            Y = p.Y;
            Length = Point2D.Zero.DistanceTo(p);
            if (Length == 0) IsPoint = true;
            else IsPoint = false;
        }

        public Vector2D(Point2D p1, Point2D p2)
        {
            X = p2.X - p1.X;
            Y = p2.Y - p1.Y;
            Length = p1.DistanceTo(p2);
            if (Length == 0) IsPoint = true;
            else IsPoint = false;
        }

        public Vector2D(double x1, double y1, double x2, double y2)
        {
            X = x2 - x1;
            Y = y2 - y1;
            Length = new Point2D(x1, y1).DistanceTo(new Point2D(x2, y2));
            if (Length == 0) IsPoint = true;
            else IsPoint = false;
        }

        public Vector2D(double x, double y)
        {
            X = x;
            Y = y;
            Length = Point2D.Zero.DistanceTo(new Point2D(x, y));
            if (Length == 0) IsPoint = true;
            else IsPoint = false;
        }

        private double x;
        private double y;

        public double X
        {
            get { return x; }
            set
            {
                x = value;
                Length = Point2D.Zero.DistanceTo(new Point2D(x, Y));
                if (Length == 0) IsPoint = true;
                else IsPoint = false;
            }
        }
        public double Y
        {
            get { return y; }
            set
            {
                y = value;
                Length = Point2D.Zero.DistanceTo(new Point2D(X, y));
                if (Length == 0) IsPoint = true;
                else IsPoint = false;
            }
        }

        public bool IsPoint { get; private set; }
        public double Length { get; private set; }

        public static Vector2D Zero = new Vector2D(0, 0);

        public static Vector2D Normalize(Vector2D vec)
        {
            return new Vector2D(vec.X / vec.Length, vec.Y / vec.Length);
        }

        public static double Dot(Vector2D v1, Vector2D v2)
        {
            return v1.X * v2.X + v1.Y * v2.Y;
        }

        public static double AngleBetweenVectors(Vector2D v1, Vector2D v2)
        {
            double dotProduct = Dot(v1, v2);
            double magnitudesProduct = v1.Length * v2.Length;
            return Math.Acos(dotProduct / magnitudesProduct);
        }

        public static Vector2D operator *(Vector2D vector, double value)
        {
            return new Vector2D(vector.X * value, vector.Y * value);
        }
    }
