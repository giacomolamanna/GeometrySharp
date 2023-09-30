using System;
using System.Collections.Generic;

namespace GeometrySharp
{
    public class Triangle2D
    {
        #region Constructors

        public Triangle2D(Point2D p1, Point2D p2, Point2D p3)
        {
            P1 = p1;
            P2 = p2;
            P3 = p3;

            Side1 = new Segment2D(P1, P2);
            Side2 = new Segment2D(P2, P3);
            Side3 = new Segment2D(P3, P1);
        }

        #endregion

        #region Properties

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


        public Segment2D Side1 { get; private set; }
        public Segment2D Side2 { get; private set; }
        public Segment2D Side3 { get; private set; }

        public List<Segment2D> Sides
        {
            get
            {
                return new List<Segment2D>() { Side1, Side2, Side3 };
            }
        }

        public static double Tolerance { get; set; } = 0.001;

        public double Area { get { return GetArea(this); } }
        public double Perimeter { get { return GetPerimeter(this); } }
        public double AngleP1 { get { return GetAngleInPoint(P1, P2, P3); } }
        public double AngleP2 { get { return GetAngleInPoint(P2, P1, P3); } }
        public double AngleP3 { get { return GetAngleInPoint(P3, P2, P1); } }

        #endregion


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

        public static double GetArea(Triangle2D t)
        {
            return Math.Abs(0.5 * (t.P1.X * (t.P2.Y - t.P3.Y) + t.P2.X * (t.P3.Y - t.P1.Y) + t.P3.X * (t.P1.Y - t.P2.Y)));
        }

        public static double GetPerimeter(Triangle2D t)
        {
            return t.Side1.Length + t.Side2.Length + t.Side3.Length;
        }

        /// <summary>
        /// Calcolo angolo interno triangolo (Teorema Carnot)
        /// </summary>
        public static double GetAngleInPoint(Point2D p1, Point2D p2, Point2D p3)
        {
            double l1 = p2.DistanceTo(p3);
            double l2 = p1.DistanceTo(p3);
            double l3 = p1.DistanceTo(p2);
            return Math.Acos(((l2 * l2) + (l3 * l3) - (l1 * l1)) / (2 * l2 * l3));
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

        /// <summary>
        /// Restituisce true se il triangolo in input è contenuto interamente nel triangolo
        /// </summary>
        /// <returns></returns>
        public bool ContainsTriangle(Triangle2D t)
        {
            return IsPointInsideTriangle(t.P1) && IsPointInsideTriangle(t.P2) && IsPointInsideTriangle(t.P3);
        }

        /// <summary>
        /// Restituisce una lista di punti che contiene i punti del triangolo t che sono all'interno del triangolo oggetto
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public List<Point2D> ContainedPoints(Triangle2D t)
        {
            List<Point2D> points = new List<Point2D>();
            if (IsPointInsideTriangle(t.P1))
                points.Add(t.P1);
            if (IsPointInsideTriangle(t.P2))
                points.Add(t.P2);
            if (IsPointInsideTriangle(t.P3))
                points.Add(t.P3);
            return points; ;

        }

        /// <summary>
        /// Restituisce i punti in comune con il triangolo t
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public List<Point2D> SharedPoints(Triangle2D t)
        {
            List<Point2D> points = new List<Point2D>();

            foreach (var v in Vertices)
                foreach (var vt in t.Vertices)
                    if (v.DistanceTo(vt) < Tolerance)
                        points.Add(vt);

            return points;
        }

        /// <summary>
        /// Restituisce una lista che contiene i punti di intersezione tra i lati dei triangoli
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public List<Point2D> IntersectionPoints(Triangle2D t)
        {
            List<Point2D> points = new List<Point2D>();
            foreach (var seg in Sides)
                foreach (var segT in t.Sides)
                {
                    if(Segment2D.Intersection(seg, segT, out Point2D intersection))
                        points.Add(intersection);
                }
            return points;
        }


    }
}

