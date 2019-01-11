using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG_6.Models
{
    public static class Polyhedrons
    {
        public static Polyhedron Brick
        {
            get
            {
                return new Polyhedron(new List<Triangle>
                {
                    new Triangle(new Vector3(1, 1, -1), new Vector3(1, -1, -1), new Vector3(-1, -1, -1)),
                    new Triangle(new Vector3(-1, -1, -1), new Vector3(1, 1, -1), new Vector3(-1, 1, -1)),
                    new Triangle(new Vector3(1, 1, 1), new Vector3(1, 1, -1), new Vector3(-1, 1, -1)),
                    new Triangle(new Vector3(1, 1, 1), new Vector3(-1, 1, 1), new Vector3(-1, 1, -1)),
                    new Triangle(new Vector3(1, 1, -1), new Vector3(1, -1, -1), new Vector3(1, -1, 1)),
                    new Triangle(new Vector3(1, 1, -1), new Vector3(1, 1, 1), new Vector3(1, -1, 1)),
                    new Triangle(new Vector3(1, -1, 1), new Vector3(1, -1, -1), new Vector3(-1, -1, -1)),
                    new Triangle(new Vector3(1, -1, 1), new Vector3(-1, -1, 1), new Vector3(-1, -1, -1)),
                    new Triangle(new Vector3(-1, 1, -1), new Vector3(-1, -1, -1), new Vector3(-1, -1, 1)),
                    new Triangle(new Vector3(-1, 1, -1), new Vector3(-1, 1, 1), new Vector3(-1, -1, 1)),
                    new Triangle(new Vector3(1, 1, 1), new Vector3(1, -1, 1), new Vector3(-1, -1, 1)),
                    new Triangle(new Vector3(-1, -1, 1), new Vector3(1, 1, 1), new Vector3(-1, 1, 1))
                }, "Параллелепипед");
            }
        }
        public static Polyhedron Prisma
        {
            get
            {
                return new Polyhedron(new List<Triangle>
                {
                    new Triangle(new Vector3(0,1,1), new Vector3(0, -1, 1), new Vector3(0.75f,-1,-0.5f)),
                    new Triangle(new Vector3(0.75f,-1,-0.5f), new Vector3(0.75f, 1,-0.5f), new Vector3(0,1,1)),
                    new Triangle(new Vector3(0, 1, 1), new Vector3(0.75f, 1,-0.5f), new Vector3(-0.75f, 1,-0.5f)),
                    new Triangle(new Vector3(0, -1, 1), new Vector3(0.75f, -1,-0.5f), new Vector3(-0.75f, -1,-0.5f)),
                    new Triangle(new Vector3(0, 1, 1), new Vector3(-0.75f, 1,-0.5f), new Vector3(-0.75f, -1,-0.5f)),
                    new Triangle(new Vector3(0,1, 1), new Vector3(0, -1, 1), new Vector3(-0.75f, -1,-0.5f)),
                    new Triangle(new Vector3(-0.75f, 1,-0.5f), new Vector3(0.75f, 1,-0.5f), new Vector3(0.75f, -1,-0.5f)),
                    new Triangle(new Vector3(0.75f, -1,-0.5f), new Vector3(-0.75f, -1,-0.5f), new Vector3(-0.75f, 1,-0.5f))
                }, "Призма");
            }
        }
    }
}
