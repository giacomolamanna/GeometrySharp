using System.Collections.Generic;
using System.Linq;

namespace GeometrySharp
{
    public static class Mesh2DIntersection
    {
        public static double Tolerance = 1e-06;

        /// <summary>
        /// Intersection between two Mesh2D
        /// </summary>
        /// <param name="mesh1"></param>
        /// <param name="mesh2"></param>
        /// <param name="intersection"></param>
        /// <returns></returns>
        public static bool Intersection(Mesh2D mesh1, Mesh2D mesh2, out Mesh2D intersection)
        {
            intersection = null;

            List<Triangle2D> triangles = new List<Triangle2D>();

            foreach (var t1 in mesh1.Triangles)
            {
                foreach (var t2 in mesh2.Triangles)
                {
                    List<Point2D> list = IntersectionBetweenTriangles2D(t1, t2);
                    if (list.Count > 2)
                        triangles.AddRange(InternalConvexPolygonTriangulation(list));
                }
            }

            intersection = new Mesh2D(triangles);

            if (intersection == null)
                return false;
            if (intersection.Vertices.Length < 3)
            {
                intersection = null;
                return false;
            }
            if (intersection.GetArea() < Tolerance)
            {
                intersection = null;
                return false;
            }

            return true;
        }



        /// <summary>
        /// Lista di point2D che descrivono il contorno di un poligono convesso, 
        /// con massimo 6 vertici, ordinati in senso orario o antiorario
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        private static List<Triangle2D> InternalConvexPolygonTriangulation(List<Point2D> points)
        {
            List<Triangle2D> triangles = new List<Triangle2D>();
            if (points.Count >= 3)
            {
                triangles.Add(new Triangle2D(points[0], points[1], points[2]));
                if (points.Count > 3)
                    triangles.Add(new Triangle2D(points[0], points[2], points[3]));
                if (points.Count > 4)
                    triangles.Add(new Triangle2D(points[0], points[3], points[4]));
                if (points.Count > 5)
                    triangles.Add(new Triangle2D(points[0], points[4], points[5]));
            }

            return triangles;
        }



        private static List<Point2D> IntersectionBetweenTriangles2D(Triangle2D t1, Triangle2D t2)
        {
            List<Point2D> points = new List<Point2D>();

            if (t1.ContainsTriangle(t2)) return t2.Vertices;
            if (t2.ContainsTriangle(t1)) return t1.Vertices;

            //punti contenuti all'interno
            points.AddRange(t1.ContainedPoints(t2));
            points.AddRange(t2.ContainedPoints(t1));

            //punti in comune
            points.AddRange(t1.SharedPoints(t2));

            //intersezione tra segmenti
            points.AddRange(t1.IntersectionPoints(t2));

            points = points.Distinct().ToList();

            List<Point2D> intersectionPoints = ClockWiseSort.OrderPointsClockwise(points.Where(p => p != null).ToList());
            if (intersectionPoints.Count > 2)
                return intersectionPoints;
            return new List<Point2D>();
        }

    }
}

