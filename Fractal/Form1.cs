using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Fractal
{
    public partial class Form1 : Form
    {
        public const double angle45 = Math.PI / 4;
        public const double angle90 = Math.PI / 2;
        public const double angle30 = Math.PI / 6;

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            colorDialog1.FullOpen = true;
            colorDialog1.Color = button4.BackColor;
            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            Color sColor = colorDialog1.Color;
            button4.BackColor = colorDialog1.Color;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            colorDialog1.FullOpen = true;
            colorDialog1.Color = button3.BackColor;
            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            Color sColor = colorDialog1.Color;
            button3.BackColor = colorDialog1.Color;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Tree.i = 0;
            Tree.x1 = pictureBox1.Width;
            Tree.y1 = pictureBox1.Height;
            Pen pen = new Pen(Color.Black, (int)numericUpDown2.Value);
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            SolidBrush fon = new SolidBrush(pictureBox1.BackColor);
            if (checkBox3.Checked)
                Tree.Draw((int)(pictureBox1.Width / 2), (int)(pictureBox1.Height), ((pictureBox1.Width / 2) + (pictureBox1.Height)) / 4, angle90, g, pen, button3.BackColor, button4.BackColor, 11 - (int)numericUpDown3.Value);
             if (checkBox1.Checked)
            {
                //Создаем Bitmap для прямоугольника.
                Bitmap fractal = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                //Создаем новый объект Graphics из указанного Bitmap.
                Graphics graph = Graphics.FromImage(fractal);
                RectangleF carpet = new RectangleF(0, 0, pictureBox1.Width, pictureBox1.Height);
                Carpet.DrawCarpet((int)numericUpDown3.Value, carpet, graph);
                pictureBox1.Image = fractal;
            }
             if (checkBox2.Checked)
            {
                //Создаем Bitmap для треугольника.
                Bitmap fractal = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                // cоздаем новый объект Graphics из указанного Bitmap.
                Graphics graph = Graphics.FromImage(fractal);
                //Вершины треугольника.
                PointF topPoint = new PointF(pictureBox1.Width / 2f, 0);
                PointF leftPoint = new PointF(0, pictureBox1.Height);
                PointF rightPoint = new PointF(pictureBox1.Width, pictureBox1.Height);
                //Вызываем функцию отрисовки.
                Triangle.DrawTriangle((int)numericUpDown3.Value, topPoint, leftPoint, rightPoint, graph);
                //Отображаем получившийся фрактал.
                pictureBox1.Image = fractal;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
