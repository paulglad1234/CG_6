using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CG_6.Models;

namespace CG_6
{
    public partial class For_Lab6 : Form
    {
        private Scene scene;
        private Camera camera;
        private int current_index;
        private Flat crossing_flat;
        public For_Lab6()
        {
            InitializeComponent();
            scene = new Scene();
            camera = new Camera();
            MouseWheel += new MouseEventHandler(For_Lab6_MouseWheel);
            modelsCB.Items.AddRange(new object[]
            {
                Polyhedrons.Prisma,
                Polyhedrons.Brick
            });
            scene.Models.Add((Polyhedron)modelsCB.Items[0]);
            current_index = modelsCB.SelectedIndex = 0;
            crossing_flat = new Flat((float)aNumeric.Value, (float)bNumeric.Value,
                (float)cNumeric.Value, (float)dNumeric.Value);
        }
        private Point last = new Point();
        private void For_Lab6_Paint(object sender, PaintEventArgs e)
        {
            Bitmap bmp = scene.DrawAll(camera,
                new ScreenConverter(new Size(Width, Height),
                new RectangleF(-1, 1, 2, 2)), crossing_flat, standardViewRB.Checked, firstHalfViewRB.Checked,
                secondHalfViewRB.Checked, sectionViewRB.Checked);
            e.Graphics.DrawImage(bmp, 0, 0);
            bmp.Dispose();
        }

        private void For_Lab6_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button.HasFlag(MouseButtons.Left))
            {
                last = e.Location;
            }
        }

        private void For_Lab6_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button.HasFlag(MouseButtons.Left))
            {
                last = new Point();
            }
        }

        private void For_Lab6_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button.HasFlag(MouseButtons.Left) && !last.IsEmpty)
            {
                float dx = (e.X - last.X) * (float)Math.PI / 180;
                float dy = (e.Y - last.Y) * (float)Math.PI / 180;
                camera.View = Matrix4.Rotate(0, dy) * Matrix4.Rotate(1, dx) * camera.View;
                Invalidate();
                last = e.Location;
            }
        }
        private void For_Lab6_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                camera.View *= new Matrix4(new float[,] { { 2, 0, 0, 0 }, { 0, 2, 0, 0 }, { 0, 0, 2, 0 }, { 0, 0, 0, 1 } });
            }
            else
            {
                camera.View *= new Matrix4(new float[,] { { 0.5f, 0, 0, 0 }, { 0, 0.5f, 0, 0 }, { 0, 0, 0.5f, 0 }, { 0, 0, 0, 1 } });
            }
            Invalidate();
        }

        private void modelsCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            scene.Models.Remove((Polyhedron)modelsCB.Items[current_index]);
            scene.Models.Add((Polyhedron)modelsCB.SelectedItem);
            current_index = modelsCB.SelectedIndex;
            Invalidate();
        }

        private void aNumeric_ValueChanged(object sender, EventArgs e)
        {
            crossing_flat.A = (float)aNumeric.Value;
            Invalidate();
        }

        private void bNumeric_ValueChanged(object sender, EventArgs e)
        {
            crossing_flat.B = (float)bNumeric.Value;
            Invalidate();
        }

        private void cNumeric_ValueChanged(object sender, EventArgs e)
        {
            crossing_flat.C = (float)cNumeric.Value;
            Invalidate();
        }

        private void dNumeric_ValueChanged(object sender, EventArgs e)
        {
            crossing_flat.D = (float)dNumeric.Value;
            Invalidate();
        }

        private void standardViewRB_CheckedChanged(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void firstHalfViewRB_CheckedChanged(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void secondHalfViewRB_CheckedChanged(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void sectionViewRB_CheckedChanged(object sender, EventArgs e)
        {
            Invalidate();
        }
    }
}
