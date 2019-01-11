using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG_6
{
    public struct Matrix4
    {
        private float[,] matrix;
        public Matrix4(float[,] matr)
        {
            matrix = new float[4, 4];
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    matrix[i, j] = matr[i, j];
        }
        public static Matrix4 Zero()
        {
            return new Matrix4(new float[,]
            {
                {0, 0, 0, 0},
                {0, 0, 0, 0},
                {0, 0, 0, 0},
                {0, 0, 0, 0}
            });
        }
        public static Matrix4 One()
        {
            return new Matrix4(new float[,]
            {
                {1, 0, 0, 0},
                {0, 1, 0, 0},
                {0, 0, 1, 0},
                {0, 0, 0, 1}
            });
        }
        public float this[int i, int j]
        {
            get { return matrix[i, j]; }
            set { matrix[i, j] = value; }
        }
        public static Vector4 operator *(Matrix4 m, Vector4 v)
        {
            Vector4 r = Vector4.Zero();
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    r[i] += m[i, j] * v[j];
            return r;
        }
        public static Matrix4 operator *(Matrix4 m1, Matrix4 m2)
        {
            Matrix4 r = Zero();
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    for (int k = 0; k < 4; k++)
                        r[i, j] += m1[i, k] * m2[k, j];
            return r;
        }
        public static Matrix4 Rotate(int n, float a)
        {
            //если n = 0, то вращаем вокруг Ox
            Matrix4 m = One();
            int a1 = (n + 1) % 3;
            int a2 = (n + 2) % 3;
            m[a1, a1] = (float)Math.Cos(a);
            m[a1, a2] = (float)-Math.Sin(a);
            m[a2, a1] = (float)Math.Sin(a);
            m[a2, a2] = (float)Math.Cos(a);
            return m;
        }
    }
}
