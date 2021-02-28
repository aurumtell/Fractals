using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Fractal
{
    class Triangle : FractalImage
    {
        public static void DrawTriangle(int level, PointF top, PointF left, PointF right, Graphics graph)
        {
            //Проверяем, закончили ли мы построение.
            if (level == 0)
            {
                PointF[] points = new PointF[3]
                {
                    top, right, left
                };
                //Рисуем фиолетовый треугольник.
                graph.FillPolygon(Brushes.BlueViolet, points);
            }
            else
            {
                //Вычисляем среднюю точку.
                var leftMid = MidPoint(top, left); 
                var rightMid = MidPoint(top, right); 
                var topMid = MidPoint(left, right); 
                //Рекурсивно вызываем функцию для каждого и 3 треугольников.
                DrawTriangle(level - 1, top, leftMid, rightMid, graph);
                DrawTriangle(level - 1, leftMid, left, topMid, graph);
                DrawTriangle(level - 1, rightMid, topMid, right, graph);
            }
        }

        private static PointF MidPoint(PointF p1, PointF p2) => new PointF((p1.X + p2.X) / 2f, (p1.Y + p2.Y) / 2f);
    }
}
