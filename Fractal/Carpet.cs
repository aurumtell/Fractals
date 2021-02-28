using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Fractal
{
    class Carpet : FractalImage
    {
        public static void DrawCarpet(int level, RectangleF carpet, Graphics graph)
        {
            //Проверяем, закончили ли мы построение.
            if (level == 0)
            {
                //Рисуем прямоугольник.
                graph.FillRectangle(Brushes.OrangeRed, carpet);
            }
            else
            {
                // Делим прямоугольник на 9 частей.
                var width = carpet.Width / 3f;
                var height = carpet.Height / 3f;
                // (x1, y1) - координаты левой верхней вершины прямоугольника.
                // От нее будем отсчитывать остальные вершины маленьких прямоугольников.
                var x1 = carpet.Left;
                var x2 = x1 + width;
                var x3 = x1 + 2f * width;
                var y1 = carpet.Top;
                var y2 = y1 + height;
                var y3 = y1 + 2f * height;
                DrawCarpet(level - 1, new RectangleF(x1, y1, width, height), graph); 
                DrawCarpet(level - 1, new RectangleF(x2, y1, width, height), graph); 
                DrawCarpet(level - 1, new RectangleF(x3, y1, width, height), graph); 
                DrawCarpet(level - 1, new RectangleF(x1, y2, width, height), graph); 
                DrawCarpet(level - 1, new RectangleF(x3, y2, width, height), graph); 
                DrawCarpet(level - 1, new RectangleF(x1, y3, width, height), graph); 
                DrawCarpet(level - 1, new RectangleF(x2, y3, width, height), graph); 
                DrawCarpet(level - 1, new RectangleF(x3, y3, width, height), graph); 
            }
        }
    }
}
