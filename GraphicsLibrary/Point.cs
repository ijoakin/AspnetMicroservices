using System;
using System.Collections.Generic;
using System.Text;

namespace GraphicsLibrary
{
    public class Point
    {
        public int X { get; set; } = 0;
        public int Y { get; set; } = 0;
        public Point(){}
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        public static Point operator + (Point p1, Point p2)
        {
            return new Point(p1.X + p2.X, p1.Y + p2.Y);
        }
        public static Point operator - (Point p1, Point p2)
        {
            return new Point(p2.X - p1.X, p2.Y - p1.Y);
        }
        public static Point operator ++ (Point p1)
        {
            return new Point(p1.X++, p1.Y++);
        }
        public static Point operator -- (Point p1)
        {
            return new Point(p1.X--, p1.Y--);
        }

        public static Point operator * (Point p1, int value)
        {
            return new Point(p1.X*value, p1.Y*value);
        }
        public static int operator * (Point p1, Point p2)
        {
            return p1.X * p2.X + p1.Y * p2.Y;
        }

        public override string ToString()
        {
            return $"X:{X}, Y:{Y}";
        }

    }
}
