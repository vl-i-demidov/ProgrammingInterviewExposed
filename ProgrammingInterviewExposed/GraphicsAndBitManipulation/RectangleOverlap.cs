using System;
using System.Collections.Generic;
using System.Text;

namespace ProgrammingInterviewExposed.GraphicsAndBitManipulation
{
    /*
        PROBLEM You are given two rectangles, each defined by an upper-left (UL)
        corner and a lower-right (LR) corner. Both rectangles’ edges will always be parallel
        to the x or y axis, as shown in Figure 14-2. Write a function that determines
        whether the two rectangles overlap. For convenience, you may use the following
        classes:
        class Point {
            public int x;
            public int y;
            public Point( int x, int y ){
                this.x = x;
                this.y = y;
            }
        }
        class Rect {
            public Point ul;
            public Point lr;
            public Rect( Point ul, Point lr ){
                this.ul = ul;
                this.lr = lr;
            }
        }
        The function should take two Rect objects and return true if they overlap, and
        false if they don’t.
     */

    class RectangleOverlap
    {
        public static bool Overlap(Rect a, Rect b)
        {
            return a.lr.x >= b.ul.x && a.ul.x <= b.lr.x
                 && a.lr.y <= b.ul.y && a.ul.y >= b.lr.y;
        }

    }

    class Point
    {
        public int x;
        public int y;
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    class Rect
    {
        public Point ul;
        public Point lr;
        public Rect(Point ul, Point lr)
        {
            this.ul = ul;
            this.lr = lr;
        }
    }
}
