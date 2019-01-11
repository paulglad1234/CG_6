using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG_6
{
    public struct Vector3
    {
        private float[] v;
        public Vector3(float[] a)
        {
            v = new float[3];
            for (int i = 0; i < 3; i++)
                v[i] = a[i];
        }
        public Vector3(float x, float y, float z)
        {
            v = new float[] { x, y, z };
        }
        public Vector3(Vector4 vector)
            : this(vector.X, vector.Y, vector.Z)
        { }
        public static Vector3 Zero()
        {
            return new Vector3(0, 0, 0);
        }
        public float X { get { return v[0]; } set { v[0] = value; } }
        public float Y { get { return v[1]; } set { v[1] = value; } }
        public float Z { get { return v[2]; } set { v[2] = value; } }
        public float Modul { get { return (float)Math.Sqrt(X * X + Y * Y + Z * Z); } }
        public float this[int i]
        { get { return v[i]; } set { v[i] = value; } }
        public static float operator *(Vector3 v1, Vector3 v2)
        {
            return v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z;
        }
        public override string ToString()
        {
            return "( " + X.ToString() + ", " + Y.ToString() + ", " + Z.ToString() + " )";
        }
    }
}
