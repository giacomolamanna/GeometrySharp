namespace GeometrySharp
{
    public class Segment3D
    {
        public Segment3D(Point3D p1, Point3D p2)
        {
            StartPoint = p1;
            EndPoint = p2;
            Length = p1.DistanceTo(p2);
            if (Length == 0) IsPoint = true;
            else IsPoint = false;

            MidPoint = new Point3D(((p1.X + p2.X) / 2), ((p1.Y + p2.Y) / 2), ((p1.Z + p2.Z) / 2));
        }

        public Segment3D(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            StartPoint = new Point3D(x1, y1, z1);
            EndPoint = new Point3D(x2, y2, z2);
            Length = StartPoint.DistanceTo(EndPoint);
            if (Length == 0) IsPoint = true;
            else IsPoint = false;

            MidPoint = new Point3D(((StartPoint.X + EndPoint.X) / 2), ((StartPoint.Y + EndPoint.Y) / 2), ((StartPoint.Z + EndPoint.Z) / 2));
        }

        public Point3D StartPoint { get; private set; }
        public Point3D EndPoint { get; private set; }
        public Point3D MidPoint { get; private set; }
        public bool IsPoint { get; private set; }
        public double Length { get; private set; }

        /// <summary>
        /// Calculate if point p is inside segment
        /// </summary>
        /// <param name="p"></param>
        /// <returns>Returns true if point is inside</returns>
        public bool PointIsInside(Point3D p)
        {
            double length = StartPoint.DistanceTo(EndPoint);
            double l1 = p.DistanceTo(StartPoint);
            double l2 = p.DistanceTo(EndPoint);

            if (length == l1 + l2) return true;
            return false;
        }

        public static bool AreParallel(Segment3D seg1, Segment3D seg2)
        {
            return Vector3D.AreParallel(new Vector3D(seg1), new Vector3D(seg2));
        }

        public static bool ArePerpendicular(Segment3D seg1, Segment3D seg2)
        {
            return Vector3D.ArePerpendicular(new Vector3D(seg1), new Vector3D(seg2));
        }

        public void Translate(double x, double y, double z = 0)
        {
            StartPoint.Translate(x, y, z);
            EndPoint.Translate(x, y, z);
            Length = StartPoint.DistanceTo(EndPoint);
            if (Length == 0) IsPoint = true;
            else IsPoint = false;

            MidPoint = new Point3D(((StartPoint.X + EndPoint.X) / 2), ((StartPoint.Y + EndPoint.Y) / 2), ((StartPoint.Z + EndPoint.Z) / 2));
        }
    }
}
