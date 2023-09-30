namespace GeometrySharp
{
    public class Vector3D
    {
        public Vector3D(Point3D p1, Point3D p2)
        {
            X = p2.X - p1.X;
            Y = p2.Y - p1.Y;
            Z = p2.Z - p1.Z;
            Length = p1.DistanceTo(p2);
            if (Length == 0) IsPoint = true;
            else IsPoint = false;
        }

        public Vector3D(Segment3D seg)
        {
            X = seg.EndPoint.X - seg.StartPoint.X;
            Y = seg.EndPoint.Y - seg.StartPoint.Y;
            Z = seg.EndPoint.Z - seg.StartPoint.Z;
            Length = seg.StartPoint.DistanceTo(seg.EndPoint);
            if (Length == 0) IsPoint = true;
            else IsPoint = false;
        }

        public Vector3D(Point3D p)
        {
            X = p.X;
            Y = p.Y;
            Z = p.Z;
            Length = Point3D.Zero.DistanceTo(p);
            if (Length == 0) IsPoint = true;
            else IsPoint = false;
        }

        public Vector3D(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            X = x2 - x1;
            Y = y2 - y1;
            Z = z2 - z1;
            Length = new Point3D(x1, y1, z1).DistanceTo(new Point3D(x2, y2, z2));
            if (Length == 0) IsPoint = true;
            else IsPoint = false;
        }

        public Vector3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
            Length = Point3D.Zero.DistanceTo(new Point3D(x, y, z));
            if (Length == 0) IsPoint = true;
            else IsPoint = false;
        }

        private double x;
        private double y;
        private double z;

        public double X
        {
            get { return x; }
            set
            {
                x = value;
                Length = Point3D.Zero.DistanceTo(new Point3D(x, Y, Z));
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
                Length = Point3D.Zero.DistanceTo(new Point3D(X, y, Z));
                if (Length == 0) IsPoint = true;
                else IsPoint = false;
            }
        }
        public double Z
        {
            get { return z; }
            set
            {
                z = value;
                Length = Point3D.Zero.DistanceTo(new Point3D(X, Y, z));
                if (Length == 0) IsPoint = true;
                else IsPoint = false;
            }
        }
        public bool IsPoint { get; private set; }
        public double Length { get; private set; }

        public static Vector3D Zero = new Vector3D(0, 0, 0);

        public void Normalize()
        {
            X = X / Length;
            Y = Y / Length;
            Z = Z / Length;
        }

        public static Vector3D Normalize(Vector3D vec)
        {
            return new Vector3D(vec.X / vec.Length, vec.Y / vec.Length, vec.Z / vec.Length);
        }

        public static Vector3D CrossProduct(Vector3D vector1, Vector3D vector2)
        {
            return new Vector3D(vector1.Y * vector2.Z - vector1.Z * vector2.Y,
                vector1.Z * vector2.X - vector1.X * vector2.Z,
                vector1.X * vector2.Y - vector1.Y * vector2.X);
        }

        public static double DotProduct(Vector3D v1, Vector3D v2)
        {
            //v1 • v2 = |v1| * |v2| * cos(θ)
            return v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z;
        }

        public static bool AreParallel(Vector3D v1, Vector3D v2)
        {
            if (v1.X / v2.X == v1.Y / v2.Y && v1.X / v2.X == v1.Z / v2.Z)
                return true;
            return false;
        }

        public static bool ArePerpendicular(Vector3D v1, Vector3D v2)
        {
            if ((v1.X * v2.X) + (v1.Y * v2.Y) + (v1.Z * v2.Z) == 0)
                return true;
            return false;
        }

        public static Vector3D operator *(Vector3D vector, double value)
        {
            return new Vector3D(vector.X * value, vector.Y * value, vector.Z * value);
        }

        public static Vector3D operator -(Vector3D p1, Vector3D p2)
        {
            return new Vector3D(p1.X - p2.X, p1.Y - p2.Y, p1.Z - p2.Z);
        }

        public static Vector3D operator +(Vector3D p1, Vector3D p2)
        {
            return new Vector3D(p1.X + p2.X, p1.Y + p2.Y, p1.Z + p2.Z);
        }
    }
}
