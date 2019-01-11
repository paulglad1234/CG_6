using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG_6
{
    public class Camera
    {
        public Matrix4 View { get; set; } //матрица обзора
        public Matrix4 Projection { get; set; } //матрица проекции(перспективы)
        public Camera()
        {
            View = Matrix4.One();//единичная матрица
            Projection = Matrix4.One();
        }
        public Vector3 Convert(Vector3 v)
        {
            Vector4 a = new Vector4(v, 1);
            Vector4 b = Projection * View * a;
            return new Vector3(b.Normalized);//нормализация вектора b
        }
    }
}
