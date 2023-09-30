using System;
using System.Collections.Generic;
using System.Linq;

namespace GeometrySharp
{
    public class Mesh2D
    {
        public Mesh2D()
        {

        }

        public Mesh2D(IList<Point2D> vertices, IList<TriangleIndices> triangleIndices)
        {
            Vertices = vertices.ToArray();
            Indices = triangleIndices.ToArray();
            Triangles = new Triangle2D[Indices.Length];
            for (int i = 0; i < Indices.Length; i++)
                Triangles[i] = new Triangle2D(Vertices[Indices[i].V1], Vertices[Indices[i].V2], Vertices[Indices[i].V3]);
        }

        public Mesh2D(IList<Triangle2D> trianglees)
        {
            Triangles = trianglees.ToArray();
            Vertices = Triangles.SelectMany(t => t.Vertices).Distinct().ToArray();

            Indices = new TriangleIndices[Triangles.Length];
            for (int i = 0; i < Triangles.Length; i++)
            {
                int v1 = Array.IndexOf(Vertices, Triangles[i].P1);
                int v2 = Array.IndexOf(Vertices, Triangles[i].P2);
                int v3 = Array.IndexOf(Vertices, Triangles[i].P3);
                Indices[i] = new TriangleIndices(v1, v2, v3);
            }
        }

        public Point2D[] Vertices { get; set; }
        public TriangleIndices[] Indices { get; set; }
        public Triangle2D[] Triangles { get; set; }

        public double GetArea()
        {
            double area = 0;
            foreach (var t in Triangles)
                area += t.Area;
            return area;
        }

        public class TriangleIndices
        {
            public TriangleIndices(int v1, int v2, int v3)
            {
                V1= v1;
                V2= v2;
                V3= v3;
            }

            public int V1 { get; set; }
            public int V2 { get; set; }
            public int V3 { get; set; }
        }
    }
}
