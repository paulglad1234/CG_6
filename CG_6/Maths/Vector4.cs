using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG_6
{
    public struct Vector4
    {
        private float[] v;
        public Vector4(float[] a)
        {
            v = new float[4];
            for (int i = 0; i < 4; i++)
                v[i] = a[i];
        }
        public Vector4(float x, float y, float z, float w = 0)
        {
            v = new float[] { x, y, z, w };
        }
        public Vector4(Vector3 vector, float w = 0)
            : this (vector.X, vector.Y, vector.Z, w)
        { }
        public static Vector4 Zero()
        {
            return new Vector4(0, 0, 0, 0);
        }
        public float X { get { return v[0]; } set { v[0] = value; } }
        public float Y { get { return v[1]; } set { v[1] = value; } }
        public float Z { get { return v[2]; } set { v[2] = value; } }
        public float W { get { return v[3]; } set { v[3] = value; } }
        public float this[int i]
        {
            get { return v[i]; }
            set { v[i] = value; }
        }
        //нормализация
        public Vector4 Normalized
        {
            get
            {
                return (Math.Abs(W) < 1e-15) ? this : new Vector4(X / W, Y / W, Z / W, 1);
            }
        }
    }
}
