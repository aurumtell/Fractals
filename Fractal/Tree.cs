using System;
using System.Collections.Generic;
using System.Drawing;

namespace Fractal
{
    public class Tree : FractalImage
    {
        public static int i1;
        public static int size;
        public static List<Color> colorList = new List<Color>();
        public static int kz = 0;
        public static int k1 = 0;
        public static int k = 0;
        public static int i = 0;
        public static int x1;
        public static int y1;
        public const double angle45 = Math.PI / 4;
        public const double angle90 = Math.PI / 2;
        public const double angle30 = Math.PI / 6;

        public static void Check(double a, int recursNum)
        {
            if (a > recursNum)
            {
                a *= 0.7;
                kz++;
                Check(a, recursNum);
                Check(a, recursNum);
            }
        }

        public static void Draw(int w, int h, double a, double b, Graphics g, Pen pen, Color colorStart, Color colorEnd, int recursNum)
        {
            i1 = 0; kz = 0;
            Check(a, recursNum);
            size = kz + 1;
            i1 = recursNum;
            //Обозначаем минимальный и максимальный цвет.
            int rMax = colorStart.R;
            int gMax = colorStart.G;
            int bMax = colorStart.B;
            int rMin = colorEnd.R;
            int gMin = colorEnd.G;
            int bMin = colorEnd.B;
            colorList = null;
            //Заполняем промежуточные цвета.
            colorList = new List<Color>();
            for (int i = 0; i < size; i++)
            {
                var rAverage = rMin + (int)((rMax - rMin) * i / size);
                var gAverage = gMin + (int)((gMax - gMin) * i / size);
                var bAverage = bMin + (int)((bMax - bMin) * i / size);
                colorList.Add(Color.FromArgb(rAverage, gAverage, bAverage));
            }
            //Отрисовка фрактала.
            Draw1(w, h, a, b, g, pen, colorStart, colorEnd, recursNum);
        }

        public static void Draw1(int w, int h, double a, double b, Graphics g, Pen pen, Color colorStart, Color colorEnd, int recursNum)
        {
            if (a > recursNum)
            {
                a *= 0.7;
                DrawLine(w, h, a, b, g, pen, colorStart, colorEnd);
                //Поворот угла и отрисовка линии.
                w = (int)(Math.Round(w + (a * Math.Cos(b))));
                h = (int)(Math.Round(h - (a * Math.Sin(b))));
                Draw1(w, h, a, b + angle45, g, pen, colorStart, colorEnd, recursNum);
                Draw1(w, h, a, b - angle30, g, pen, colorStart, colorEnd, recursNum);
            }
        }

        private static void DrawLine(int x, int y, double a, double b, Graphics g, Pen pen, Color colorStart, Color colorEnd)
        {
            i++;
            pen.Color = colorList[i];
            g.DrawLine(pen, x, y, (float)Math.Round(x + a * Math.Cos(b)), (float)Math.Round(y - a * Math.Sin(b)));
        }
    }
}

