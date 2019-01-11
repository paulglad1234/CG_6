using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG_6.Models
{
    public class Polyhedron : IModel
    {
        public List<Triangle> Triangles { get; set; }
        private string name = null;
        public Polyhedron(List<Triangle> triangles)
        {
            Triangles = triangles;
        }
        public Polyhedron(List<Triangle> triangles, string name)
        : this(triangles) {
            this.name = name;
        }
        public List<PolyLine3D> GetLines()
        {
            List<PolyLine3D> lines = new List<PolyLine3D>();
            foreach (Triangle triangle in Triangles)
                lines.Add(triangle.ToPolyLine3D());
            return lines;
        }
        private void Sort(List<Vector3> verteces, Flat flat)
        {
            Vector3 center = GetCenter(verteces);
            Vector3 xAxis = GetXAxis(verteces, center);
            Vector3 yAxis = GetYAxis(xAxis, flat);
            Sort(verteces, center, xAxis, yAxis);
            int current;
            do
            {
                current = verteces.Count;
                RemoveExtraPoints(verteces, center);
            } while (verteces.Count != current);
        }
        private void RemoveExtraPoints(List<Vector3> verteces, Vector3 center)
        {
            int from = GetIndexOfMaxPoint(verteces, center);
            int to = from + verteces.Count;
            for (int i = from; i < to; i++)
            {
                int j = i % verteces.Count;
                int k = (i + 1) % verteces.Count;
                int l = (i + 2) % verteces.Count;
                Vector3 current = new Vector3(verteces[j].X - center.X, verteces[j].Y - center.Y, verteces[j].Z - center.Z);
                Vector3 next = new Vector3(verteces[k].X - center.X, verteces[k].Y - center.Y, verteces[k].Z - center.Z);
                Vector3 next_next = new Vector3(verteces[l].X - center.X, verteces[l].Y - center.Y, verteces[l].Z - center.Z);
                Vector3 intersection = Vector3.Zero();
                float t0 = (next.X * next_next.Y - next.X * current.Y - next.Y * next_next.X + next.Y * current.X);
                float t;
                if (t0 != 0)
                    t = (current.X * next.Y - next.X * current.Y) / t0;
                else
                {
                    t0 = (next.X * next_next.Z - next.X * current.Z - next.Z * next_next.X + next.Z * current.X);
                    if (t0 != 0)
                        t = (current.X * next.Z - next.X * current.Z) / t0;
                    else
                    {
                        t0 = (next.Z * next_next.Y - next.Z * current.Y - next.Y * next_next.Z + next.Y * current.Z);
                        t = (current.Z * next.Y - next.Z * current.Y) / t0;
                    }
                }
                intersection.X = next.X == 0 ? 0 : ((next_next.X - current.X) * t + current.X);
                intersection.Y = next.Y == 0 ? 0 : ((next_next.Y - current.Y) * t + current.Y);
                intersection.Z = next.Z == 0 ? 0 : ((next_next.Z - current.Z) * t + current.Z);
                if (next.Modul <= intersection.Modul)
                {
                    verteces.RemoveAt(k);
                    i++;
                }
            }
        }
        private int GetIndexOfMaxPoint(List<Vector3> v, Vector3 center)
        {
            if (v.Count > 0)
            {
                Vector3 current = new Vector3(v[0].X - center.X, v[0].Y - center.Y, v[0].Z - center.Z);
                float max = current.Modul;
                int maxIndex = 0;
                for (int i = 1; i < v.Count; i++)
                {
                    current = new Vector3(v[i].X - center.X, v[i].Y - center.Y, v[i].Z - center.Z);
                    float current_Modul = current.Modul;
                    if (current_Modul > max)
                    {
                        max = current_Modul;
                        maxIndex = i;
                    }
                }
                return maxIndex;
            }
            return -1;
        }
        private Vector3 GetCenter(List<Vector3> verteces)
        {
            Vector3 center = Vector3.Zero();
            foreach (Vector3 v in verteces)
            {
                center.X += v.X; center.Y += v.Y; center.Z += v.Z;
            }
            center.X /= verteces.Count; center.Y /= verteces.Count; center.Z /= verteces.Count;
            return center;
        }
        private Vector3 GetXAxis(List<Vector3> verteces, Vector3 center)
        {
            Vector3 xAxis = Vector3.Zero();
            foreach (Vector3 v in verteces)
            {
                Vector3 vector = new Vector3(v.X - center.X, v.Y - center.Y, v.Z - center.Z);
                if (vector.Modul > xAxis.Modul)
                    xAxis = vector;
            }
            return xAxis;
        }
        private Vector3 GetYAxis(Vector3 xAxis, Flat flat)
        {
            Vector3 yAxis = Vector3.Zero();
            if (flat.A != 0 || flat.B != 0)
            { yAxis.X = xAxis.X; yAxis.Y = xAxis.Y; yAxis.Z = 1; }
            else if (flat.B != 0 || flat.C != 0)
            { yAxis.X = 1; yAxis.Y = xAxis.Y; yAxis.Z = xAxis.Z; }
            else { yAxis.X = xAxis.X; yAxis.Y = 1; yAxis.Z = xAxis.Z; }
            return yAxis;
        }
        private void Sort(List<Vector3> verteces, Vector3 center, Vector3 xAxis, Vector3 yAxis)
        {
            List<double> angles = GetAngles(verteces, center, xAxis, yAxis);
            int N = angles.Count;
            for (int i = 0; i < N - 1; i++)
            {
                int imin = i;
                for (int j = i + 1; j < N; j++)
                    if (angles[j] < angles[imin]) imin = j;
                if (i != imin)
                {
                    double tmp = angles[imin];
                    angles[imin] = angles[i];
                    angles[i] = tmp;
                    Vector3 t = new Vector3(verteces[imin].X, verteces[imin].Y, verteces[imin].Z);
                    verteces[imin] = verteces[i];
                    verteces[i] = t;
                }
            }
        }
        private List<double> GetAngles(List<Vector3> verteces, Vector3 center, Vector3 xAxis, Vector3 yAxis)
        {
            List<double> angles = new List<double>();
            for (int i = 0; i < verteces.Count; i++)
            {
                Vector3 current = new Vector3(verteces[i].X - center.X, verteces[i].Y - center.Y, verteces[i].Z - center.Z);
                double x = current * xAxis / xAxis.Modul;
                double y = current * yAxis / yAxis.Modul;
                double angle = Math.PI / 2;
                if (x == 0)
                {
                    if (y < 0)
                        angle = -angle;
                }
                else angle = Math.Atan(y / x);
                if (x > 0)
                    angles.Add(angle);
                else angles.Add(angle + Math.PI);
            }
            return angles;
        }
        public List<PolyLine3D> Half(Flat crossing, bool first)
        {
            List<PolyLine3D> lines = new List<PolyLine3D> { Section(crossing) };
            foreach (Triangle tr in Triangles)
            {
                int pos0 = Math.Sign(tr.Points[0] * crossing);
                int pos1 = Math.Sign(tr.Points[1] * crossing);
                int pos2 = Math.Sign(tr.Points[2] * crossing);
                if ((pos0 == pos1 && pos1 == pos2) || 
                    (pos0 == pos1 && pos2 == 0) ||
                    (pos0 == pos2 && pos1 == 0))
                {
                    if (first)
                    {
                        if (pos0 <= 0)
                        {
                            lines.Add(tr.ToPolyLine3D());
                        }
                    }
                    else
                    {
                        if (pos0 >= 0)
                        {
                            lines.Add(tr.ToPolyLine3D());
                        }
                    }
                }
                else if (pos2 == pos1 && pos0 == 0)
                {
                    if (first)
                    {
                        if (pos2 <= 0)
                        {
                            lines.Add(tr.ToPolyLine3D());
                        }
                    }
                    else
                    {
                        if (pos2 >= 0)
                        {
                            lines.Add(tr.ToPolyLine3D());
                        }
                    }
                }
                else
                {
                    List<Vector3> v3s = new List<Vector3>();
                    if (pos0 == pos1)
                    {
                        //найти точки пересечения
                        Vector3 p = new Vector3(tr.Points[2].X - tr.Points[0].X, tr.Points[2].Y - tr.Points[0].Y, tr.Points[2].Z - tr.Points[0].Z);
                        float t = -(crossing * tr.Points[0]) / (crossing * p - crossing.D);
                        Vector3 toadd1 = new Vector3(p.X * t + tr.Points[0].X, p.Y * t + tr.Points[0].Y, p.Z * t + tr.Points[0].Z);
                        p = new Vector3(tr.Points[2].X - tr.Points[1].X, tr.Points[2].Y - tr.Points[1].Y, tr.Points[2].Z - tr.Points[1].Z);
                        t = -(crossing * tr.Points[1]) / (crossing * p - crossing.D);
                        Vector3 toadd2 = new Vector3(p.X * t + tr.Points[1].X, p.Y * t + tr.Points[1].Y, p.Z * t + tr.Points[1].Z);
                        if (first)
                        {
                            if (pos2 <= 0)
                            {
                                v3s.Add(tr.Points[2]);
                                v3s.Add(toadd1);
                                v3s.Add(toadd2);
                            }
                            else {
                                v3s.Add(toadd1);
                                v3s.Add(toadd2);
                                v3s.Add(tr.Points[0]);
                                v3s.Add(tr.Points[1]);
                            }
                        }
                        else {
                            if (pos2 < 0)
                            {
                                v3s.Add(toadd1);
                                v3s.Add(toadd2);
                                v3s.Add(tr.Points[0]);
                                v3s.Add(tr.Points[1]);
                            }
                            else {
                                v3s.Add(tr.Points[2]);
                                v3s.Add(toadd1);
                                v3s.Add(toadd2);
                            }
                        }
                    }
                    else if (pos1 == pos2)
                    {
                        //найти точки пересечения
                        Vector3 p = new Vector3(tr.Points[0].X - tr.Points[1].X, tr.Points[0].Y - tr.Points[1].Y, tr.Points[0].Z - tr.Points[1].Z);
                        float t = -(crossing * tr.Points[1]) / (crossing * p - crossing.D);
                        Vector3 toadd1 = new Vector3(p.X * t + tr.Points[1].X, p.Y * t + tr.Points[1].Y, p.Z * t + tr.Points[1].Z);
                        p = new Vector3(tr.Points[0].X - tr.Points[2].X, tr.Points[0].Y - tr.Points[2].Y, tr.Points[0].Z - tr.Points[2].Z);
                        t = -(crossing * tr.Points[2]) / (crossing * p - crossing.D);
                        Vector3 toadd2 = new Vector3(p.X * t + tr.Points[2].X, p.Y * t + tr.Points[2].Y, p.Z * t + tr.Points[2].Z);
                        if (first)
                        {
                            if (pos0 <= 0)
                            {
                                v3s.Add(tr.Points[0]);
                                v3s.Add(toadd1);
                                v3s.Add(toadd2);
                            }
                            else
                            {
                                v3s.Add(toadd1);
                                v3s.Add(toadd2);
                                v3s.Add(tr.Points[1]);
                                v3s.Add(tr.Points[2]);
                            }
                        }
                        else
                        {
                            if (pos0 < 0)
                            {
                                v3s.Add(toadd1);
                                v3s.Add(toadd2);
                                v3s.Add(tr.Points[2]);
                                v3s.Add(tr.Points[1]);
                            }
                            else
                            {
                                v3s.Add(tr.Points[0]);
                                v3s.Add(toadd1);
                                v3s.Add(toadd2);
                            }
                        }
                    }
                    else if (pos2 == pos0)
                    {
                        //найти точки пересечения
                        Vector3 p = new Vector3(tr.Points[1].X - tr.Points[0].X, tr.Points[1].Y - tr.Points[0].Y, tr.Points[1].Z - tr.Points[0].Z);
                        float t = -(crossing * tr.Points[0]) / (crossing * p - crossing.D);
                        Vector3 toadd1 = new Vector3(p.X * t + tr.Points[0].X, p.Y * t + tr.Points[0].Y, p.Z * t + tr.Points[0].Z);
                        p = new Vector3(tr.Points[1].X - tr.Points[2].X, tr.Points[1].Y - tr.Points[2].Y, tr.Points[1].Z - tr.Points[2].Z);
                        t = -(crossing * tr.Points[2]) / (crossing * p - crossing.D);
                        Vector3 toadd2 = new Vector3(p.X * t + tr.Points[2].X, p.Y * t + tr.Points[2].Y, p.Z * t + tr.Points[2].Z);
                        if (first)
                        {
                            if (pos1 <= 0)
                            {
                                v3s.Add(tr.Points[1]);
                                v3s.Add(toadd1);
                                v3s.Add(toadd2);
                            }
                            else
                            {
                                v3s.Add(toadd1);
                                v3s.Add(toadd2);
                                v3s.Add(tr.Points[0]);
                                v3s.Add(tr.Points[2]);
                            }
                        }
                        else
                        {
                            if (pos1 < 0)
                            {
                                v3s.Add(toadd1);
                                v3s.Add(toadd2);
                                v3s.Add(tr.Points[0]);
                                v3s.Add(tr.Points[2]);
                            }
                            else
                            {
                                v3s.Add(tr.Points[1]);
                                v3s.Add(toadd1);
                                v3s.Add(toadd2);
                            }
                        }
                    }
                    else if (pos0 == 0)
                    {
                        Vector3 p = new Vector3(tr.Points[2].X - tr.Points[1].X, tr.Points[2].Y - tr.Points[1].Y, tr.Points[2].Z - tr.Points[1].Z);
                        float t = -(crossing * tr.Points[1]) / (crossing * p - crossing.D);
                        Vector3 toadd = new Vector3(p.X * t + tr.Points[1].X, p.Y * t + tr.Points[1].Y, p.Z * t + tr.Points[1].Z);
                        v3s.Add(tr.Points[0]);
                        v3s.Add(toadd);
                        if (first)
                        {
                            if (pos1 < 0)
                            {
                                v3s.Add(tr.Points[1]);
                            }
                            else
                            {
                                v3s.Add(tr.Points[2]);
                            }
                        }
                        else
                        {
                            if (pos1 < 0)
                            {
                                v3s.Add(tr.Points[2]);
                            }
                            else
                            {
                                v3s.Add(tr.Points[1]);
                            }
                        }
                    }
                    else if (pos1 == 0)
                    {
                        Vector3 p = new Vector3(tr.Points[2].X - tr.Points[0].X, tr.Points[2].Y - tr.Points[0].Y, tr.Points[2].Z - tr.Points[0].Z);
                        float t = -(crossing * tr.Points[0]) / (crossing * p - crossing.D);
                        Vector3 toadd = new Vector3(p.X * t + tr.Points[0].X, p.Y * t + tr.Points[0].Y, p.Z * t + tr.Points[0].Z);
                        v3s.Add(tr.Points[1]);
                        v3s.Add(toadd);
                        if (first)
                        {
                            if (pos0 < 0)
                            {
                                v3s.Add(tr.Points[0]);
                            }
                            else
                            {
                                v3s.Add(tr.Points[2]);
                            }
                        }
                        else
                        {
                            if (pos0 < 0)
                            {
                                v3s.Add(tr.Points[2]);
                            }
                            else
                            {
                                v3s.Add(tr.Points[0]);
                            }
                        }
                    }
                    else {
                        Vector3 p = new Vector3(tr.Points[0].X - tr.Points[1].X, tr.Points[0].Y - tr.Points[1].Y, tr.Points[0].Z - tr.Points[1].Z);
                        float t = -(crossing * tr.Points[1]) / (crossing * p - crossing.D);
                        Vector3 toadd = new Vector3(p.X * t + tr.Points[1].X, p.Y * t + tr.Points[1].Y, p.Z * t + tr.Points[1].Z);
                        v3s.Add(tr.Points[2]);
                        v3s.Add(toadd);
                        if (first)
                        {
                            if (pos1 < 0)
                            {
                                v3s.Add(tr.Points[1]);
                            }
                            else
                            {
                                v3s.Add(tr.Points[0]);
                            }
                        }
                        else
                        {
                            if (pos1 < 0)
                            {
                                v3s.Add(tr.Points[0]);
                            }
                            else
                            {
                                v3s.Add(tr.Points[1]);
                            }
                        }
                    }
                    Sort(v3s, crossing);
                    if (v3s.Count > 0)
                        lines.Add(new PolyLine3D(v3s, true));
                }
            }

            return lines;
        }
        public PolyLine3D Section(Flat crossing)
        {
            List<Vector3> points = new List<Vector3>();
            foreach (Triangle tr in Triangles)
            {
                int pos0 = Math.Sign(tr.Points[0] * crossing);
                int pos1 = Math.Sign(tr.Points[1] * crossing);
                int pos2 = Math.Sign(tr.Points[2] * crossing);
                if (pos0 != pos1)
                {
                    Vector3 p = new Vector3(tr.Points[1].X - tr.Points[0].X, tr.Points[1].Y - tr.Points[0].Y, tr.Points[1].Z - tr.Points[0].Z);
                    float t = -(crossing * tr.Points[0]) / (crossing * p - crossing.D);
                    Vector3 toadd = new Vector3(p.X * t + tr.Points[0].X, p.Y * t + tr.Points[0].Y, p.Z * t + tr.Points[0].Z);
                    bool add = true;
                    foreach (Vector3 point in points)
                    {
                        if (toadd.X == point.X && toadd.Y == point.Y && toadd.Z == point.Z)
                        {
                            add = false;
                            break;
                        }
                    }
                    if(add)
                    points.Add(toadd);
                }
                if (pos1 != pos2)
                {
                    Vector3 p = new Vector3(tr.Points[2].X - tr.Points[1].X, tr.Points[2].Y - tr.Points[1].Y, tr.Points[2].Z - tr.Points[1].Z);
                    float t = -(crossing * tr.Points[1]) / (crossing * p - crossing.D);
                    Vector3 toadd = new Vector3(p.X * t + tr.Points[1].X, p.Y * t + tr.Points[1].Y, p.Z * t + tr.Points[1].Z);
                    bool add = true;
                    foreach (Vector3 point in points)
                    {
                        if (toadd.X == point.X && toadd.Y == point.Y && toadd.Z == point.Z)
                        {
                            add = false;
                            break;
                        }
                    }
                    if (add)
                        points.Add(toadd);
                }
                if (pos0 != pos2)
                {
                    Vector3 p = new Vector3(tr.Points[2].X - tr.Points[0].X, tr.Points[2].Y - tr.Points[0].Y, tr.Points[2].Z - tr.Points[0].Z);
                    float t = -(crossing * tr.Points[0]) / (crossing * p - crossing.D);
                    Vector3 toadd = new Vector3(p.X * t + tr.Points[0].X, p.Y * t + tr.Points[0].Y, p.Z * t + tr.Points[0].Z);
                    bool add = true;
                    foreach (Vector3 point in points)
                    {
                        if (toadd.X == point.X && toadd.Y == point.Y && toadd.Z == point.Z)
                        {
                            add = false;
                            break;
                        }
                    }
                    if (add)
                        points.Add(toadd);
                }
            }
            Sort(points, crossing);
            if (points.Count > 0)
                return new PolyLine3D(points, true);
            return null;
        }
        public override string ToString()
        {
            if (name == null)
                return base.ToString();
            return name;
        }
    }
}
