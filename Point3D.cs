    public class Point3D
    {
        public Point3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public double X { get; set; }

        public double Y { get; set; }

        public double Z { get; set; }

        public Point2D P2D { get { return new Point2D(X, Y); } }

        public Vector3D AsVector { get { return new Vector3D(X, Y, Z); } }

        public static Point3D Zero = new Point3D(0, 0, 0);

        public static Point3D operator +(Point3D p1, Point3D p2)
        {
            return new Point3D(p1.X + p2.X, p1.Y + p2.Y, p1.Z + p2.Z);
        }

        public static Point3D operator -(Point3D p1, Point3D p2)
        {
            return new Point3D(p1.X - p2.X, p1.Y - p2.Y, p1.Z - p2.Z);
        }

        public static Point3D operator +(Point3D p, Vector2D v2d)
        {
            return new Point3D(p.X + v2d.X, p.Y + v2d.Y, p.Z);
        }

        public double DistanceTo(Point3D p)
        {
            return Math.Sqrt(Math.Pow(p.X - X, 2) + Math.Pow(p.Y - Y, 2) + Math.Pow(p.Z - Z, 2));
        }

        public bool Equals(Point3D p)
        {
            if (Math.Abs(Math.Abs(p.X) - Math.Abs(X)) == 0 &&
                Math.Abs(Math.Abs(p.Y) - Math.Abs(Y)) == 0 &&
                Math.Abs(Math.Abs(p.Z) - Math.Abs(Z)) == 0)
                return true;
            else 
                return false;
        }

        public Point3D MidPoint(Point3D p)
        {
            return new Point3D(((X + p.X) / 2), ((Y + p.Y) / 2), ((Z + p.Z) / 2));
        }

        public void Translate(double x, double y, double z = 0)
        {
            X += x;
            Y += y;
            Z += z;
        }

        public Point3D Clone()
        {
            return new Point3D(X, Y, Z);
        }

    }
