using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG_6
{
    public class PolyLine3D
    {
        private List<Vector3> line = new List<Vector3>();
        public List<Vector3> Line { get { return new List<Vector3>(line); } }
        public PolyLine3D(List<Vector3> l, bool closed = false)
        //_______________________________| является ли замкнутой
        {
            line.AddRange(l);
            if (closed)
                line.Add(l[0]);
        }

    }
}
