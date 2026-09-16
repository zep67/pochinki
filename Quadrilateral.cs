using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pochinki
{
    public class Quadrilateral
    {
        public Point2D P4 { get; private set; }
        public Point2D P5 { get; private set; }
        public Point2D P6 { get; private set; }
        public Point2D P7 { get; private set; }

        public Quadrilateral(Point2D p4, Point2D p5, Point2D p6, Point2D p7)
        {
            P4= p4;
            P5 = p5;
            P6 = p6;
            P7 = p7;
        }
        public void AddX(int x)
        {
            P4.AddX(x);
            P5.AddX(x);
            P6.AddX(x);
            P7.AddX(x);
        }
        public void AddY(int y)
        {
            P4.AddY(y);
            P5.AddY(y);
            P6.AddY(y);
            P7.AddY(y);
        }
        public void MoveTo(int newX, int newY)
        {
            int dx = newX - P4.X;
            int dy = newY - P4.Y;
            AddX(dx);
            AddY(dy);
        }
    }
}
