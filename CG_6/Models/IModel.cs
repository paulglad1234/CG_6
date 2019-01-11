using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG_6
{
    interface IModel
    {
        List<PolyLine3D> GetLines();
    }
}
