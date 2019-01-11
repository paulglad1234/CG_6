using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG_6
{
    public class Triangle
    {
        public Vector3[] Points { get; set; }
        public Triangle(Vector3 p1, Vector3 p2, Vector3 p3)
        {
            Points = new Vector3[3];
            Points[0] = p1;
            Points[1] = p2;
            Points[2] = p3;
        }
        public Flat Flat { get {
                float a = (Points[1].Y - Points[0].Y) * (Points[2].Z - Points[0].Z) - (Points[2].Y - Points[0].Y) * (Points[1].Z - Points[0].Z);
                float b = (Points[1].X - Points[0].X) * (Points[2].Z - Points[0].Z) - (Points[2].X - Points[0].X) * (Points[1].Z - Points[0].Z);
                float c = (Points[1].X - Points[0].X) * (Points[2].Y - Points[0].Y) - (Points[2].X - Points[0].X) * (Points[1].Y - Points[0].Y);
                float d = -Points[0].X * a - Points[0].Y * b - Points[0].Z * c;
                return new Flat(a, b, c, d);
            } }
        public PolyLine3D ToPolyLine3D()
        {
            return new PolyLine3D(Points.ToList(), true);
        }
    }
}
