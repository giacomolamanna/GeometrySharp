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
    
    public List<Point2D> Vertices
    {
        get
        {
            return new List<Point2D>() { P1, P2, P3 };
        }
    }
    
    public Triangle2D Clone()
    {
        return new Triangle2D(P1, P2, P3);
    }
    
    public Point2D GetCenter()
    {
        double centerX = (P1.X + P2.X + P3.X) / 3;
        double centerY = (P1.Y + P2.Y + P3.Y) / 3;
        return new Point2D(centerX, centerY);
    }
    
    public double GetArea()
    {
        return Math.Abs(0.5 * (P1.X * (P2.Y - P3.Y) + P2.X * (P3.Y - P1.Y) + P3.X * (P1.Y - P2.Y)));
    }
    
    public void Translate(double x, double y)
    {
        P1.Translate(x, y);
        P2.Translate(x, y);
        P3.Translate(x, y);
    }

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
