using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG_6
{
    public struct Flat
    {
        private float[] coeffs;
        public Flat(float A, float B, float C, float D)
        {
            coeffs = new float[] { A, B, C, D };
        }
        public float A { get { return coeffs[0]; } set { coeffs[0] = value; } }
        public float B { get { return coeffs[1]; } set { coeffs[1] = value; } }
        public float C { get { return coeffs[2]; } set { coeffs[2] = value; } }
        public float D { get { return coeffs[3]; } set { coeffs[3] = value; } }
        public bool IsParallelOrEqualTo(Flat flat)
        {
            if (A == 0)
            {
                if (B == 0)
                {
                    if (C == 0)
                        return false;
                    return flat.A == 0 && flat.B == 0;
                }
                if (C == 0)
                    return flat.A == 0 && flat.C == 0;
                if (flat.A != 0)
                    return false;
                return flat.B / B == flat.C / C;
            }
            if (B == 0)
            {
                if (C == 0)
                    return flat.B == 0 && flat.C == 0;
                if (flat.B != 0)
                    return false;
                return flat.A / A == flat.C / C;
            }
            if (C == 0)
            {
                if (flat.C != 0)
                    return false;
                return flat.A / A == flat.B / B;
            }
            float k = flat.A / A;
            return flat.B / B == k && flat.C / C == k;
        }
        public static float operator *(Flat flat, Vector3 vector)
        {
            return flat.A * vector.X + flat.B * vector.Y + flat.C * vector.Z + flat.D;
        }
        public static float operator *(Vector3 vector, Flat flat)
        {
            return flat.A * vector.X + flat.B * vector.Y + flat.C * vector.Z + flat.D;
        }
        public override string ToString()
        {
            return Math.Round(A, 1).ToString() + "x + " + Math.Round(B, 1).ToString() + "y + " +
                Math.Round(C, 1).ToString() + "z + " + Math.Round(D, 1).ToString() + " = 0";
        }
    }
}
