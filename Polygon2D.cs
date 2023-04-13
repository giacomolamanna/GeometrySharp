public class Polygon
{
    public Polygon(List<Point2D> points)
    {
        if (!points.Any()) return;
        SetCenter(points);                
        ComputeBoundingRectangle();
        IsRectangle = CheckIfIsRectangle();
    }

    public List<Point2D> Points { get; set; }
    public Point2D Center { get; private set; }
    public bool IsRectangle { get; private set; }
    public Point2D BoxMin { get; private set; }
    public Point2D BoxMax { get; private set; }

    private bool CheckIfIsRectangle()
    {
        foreach (var p in Points)
        {
            bool inX = p.X > BoxMin.X && p.X < BoxMax.X;
            bool inY = p.Y > BoxMin.Y && p.Y < BoxMax.Y;
            if (inX && inY)
                return false;
        }
        return true;
    }

    /// <summary> 
    /// Area di un poligono secondo la formula di Shoelace https://en.wikipedia.org/wiki/Shoelace_formula
    /// </summary>
    public double GetArea()
    {
        double sum = 0;
        for (int i = 0; i < Points.Count; i++)
        {
            if (i == Points.Count - 1) 
                sum += (Points[0].X - Points[i].X) * (Points[0].Y + Points[i].Y);
            else 
                sum += (Points[i + 1].X - Points[i].X) * (Points[i + 1].Y + Points[i].Y);
        }
        //la somma sarà negativa se i vertici sono in senso antiorario
        return Math.Abs(sum * 0.5);
    }

   private void SetCenter(List<Point2D> points)
   {
       double xCentroide = 0;
       double yCentroide = 0;
       foreach (Point2D p in points)
       {
           xCentroide += p.X;
           yCentroide += p.Y;
       }
       xCentroide /= points.Count;
       yCentroide /= points.Count;
       Center = new Point2D(xCentroide, yCentroide);
   }

    public void ComputeBoundingRectangle()
    {
        BoxMax = Points[0];
        BoxMin = Points[0];
        foreach (var p in Points)
        {
            BoxMin = Min(BoxMin, p);
            BoxMax = Max(BoxMax, p);
        }
    }

   static Point2D Min(Point2D p1, Point2D p2)
   {
       return new Point2D(Math.Min(p1.X, p2.X), Math.Min(p1.Y, p2.Y));
   }
   static Point2D Max(Point2D p1, Point2D p2)
   {
       return new Point2D(Math.Max(p1.X, p2.X), Math.Max(p1.Y, p2.Y));
   }


}
