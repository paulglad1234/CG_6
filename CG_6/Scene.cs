using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using CG_6.Models;

namespace CG_6
{
    class Scene
    {
        public List<Polyhedron> Models { get; private set; }
        public Scene()
        {
            Models = new List<Polyhedron>();
        }
        public Bitmap DrawAll(Camera cam, ScreenConverter scr, Flat crossing, bool standard, bool firstHalf,
            bool secondHalf, bool section)
        {
            Bitmap bmp = new Bitmap(scr.Size.Width, scr.Size.Height);
            Graphics g = Graphics.FromImage(bmp);
            List<PolyLine3D> lines = new List<PolyLine3D>();
            foreach (Polyhedron m in Models)
            {
                if (standard)
                    foreach (PolyLine3D pl in m.GetLines())
                    {
                        var p = new PolyLine3D(pl.Line.ConvertAll(a => cam.Convert(a)));
                        lines.Add(p);
                    }
                if (firstHalf)
                {
                    foreach (PolyLine3D pl in m.Half(crossing, true))
                    {
                        var p = new PolyLine3D(pl.Line.ConvertAll(a => cam.Convert(a)));
                        lines.Add(p);
                    }
                }
                if (secondHalf)
                {
                    foreach (PolyLine3D pl in m.Half(crossing, false))
                    {
                        var p = new PolyLine3D(pl.Line.ConvertAll(a => cam.Convert(a)));
                        lines.Add(p);
                    }
                }
                if (section)
                {
                    var pl = m.Section(crossing);

                    if (pl != null)
                    {
                        var p = new PolyLine3D(pl.Line.ConvertAll(a => cam.Convert(a)));
                        lines.Add(p);
                    }
                }
            }
            lines.Sort(new Comparison<PolyLine3D>((a, b) => { return (int)(a.Line.Average(x => x.Z) - b.Line.Average(x => x.Z)); }));
            foreach (PolyLine3D pl in lines)
            {
                var p = pl.Line.ConvertAll(a => scr.Convert(new Vector3(a.X, a.Y, 0))).ToArray();
                g.DrawLines(Pens.Black, p);
            }
            lines.Clear();
            g.Dispose();
            return bmp;
        }
    }
}
