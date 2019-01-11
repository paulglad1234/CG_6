using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG_6.Models
{
    public class Line3D : IModel
    {
        Vector3 p1, p2;
        public Line3D(Vector3 a, Vector3 b)
        {
            p1 = a; p2 = b;
        }
        public List<PolyLine3D> GetLines()
        {
            return new List<PolyLine3D>()
            {
                new PolyLine3D( new List<Vector3>()
                {
                    p1, p2
                })
            };
        }
    }
}
