using System;

namespace GeometrySharp
{
    public class Plane
    {
        public Plane() { }

        public Plane(Vector3D normal, double d) 
        { 
            Normal = normal; 
            D = d;
            a = Normal.X;
            b = Normal.Y;
            c = Normal.Z;
        }

        public Plane(Point3D p1, Point3D p2, Point3D p3)
        {
            Vector3D vecP1P2 = (p2 - p1).AsVector;
            Vector3D vecP1P3 = (p3 - p1).AsVector;
            Vector3D normalVec = Vector3D.CrossProduct(vecP1P2, vecP1P3);
            Vector3D normal = Vector3D.Normalize(normalVec);
            double d = - Vector3D.DotProduct(normal, p1.AsVector);
            Normal = normal;
            D = d;
            a = Normal.X;
            b = Normal.Y;
            c = Normal.Z;
        }

        /// <summary>
        /// Vettore normale al piano
        /// </summary>
        public Vector3D Normal { get; set; }

        /// <summary>
        /// Distanza del piano lungo la relativa normale dall'origine.
        /// </summary>
        public double D { get; set; }

        /// <summary>
        /// Coefficiente dell'equazione del pinao ax + by + cz + d = 0
        /// </summary>
        public double a { get; private set; }

        /// <summary>
        /// Coefficiente dell'equazione del pinao ax + by + cz + d = 0
        /// </summary>
        public double b { get; private set; }

        /// <summary>
        /// Coefficiente dell'equazione del pinao ax + by + cz + d = 0
        /// </summary>
        public double c { get; private set; }


        /// <summary>
        /// Distanza di un punto dal piano
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public double DistanceTo(Point3D p)
        {
            return Math.Abs(a * p.X + b * p.Y + c * p.Z + D) / Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2) + Math.Pow(c, 2));
        }
    }
}
