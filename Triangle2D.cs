public class Triangle2D
{
    public Triangle2D(Point2D p1, Point2D p2, Point2D p3)
    {
        P1 = p1;
        P2 = p2;
        P3 = p3;
    }

    public Point2D P1 { get; set; }
    public Point2D P2 { get; set; }
    public Point2D P3 { get; set; }

    public bool IsPointInsideTriangle(Point2D p)
    {
        double d1 = Sign(p, P1, P2);
        double d2 = Sign(p, P2, P3);
        double d3 = Sign(p, P3, P1);

        bool hasNeg = (d1 < 0) || (d2 < 0) || (d3 < 0);
        bool hasPos = (d1 > 0) || (d2 > 0) || (d3 > 0);

        return !(hasNeg && hasPos);
    }

    private double Sign(Point2D p1, Point2D p2, Point2D p3)
    {
        return (p1.X - p3.X) * (p2.Y - p3.Y) - (p2.X - p3.X) * (p1.Y - p3.Y);
    }
}
