using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;
using static System.Formats.Asn1.AsnWriter;

namespace pochinki
{
    public class Triangle
    {
        public Point2D P1 { get; private set; }
        public Point2D P2 { get; private set; }
        public Point2D P3 { get; private set; }

        public Triangle(Point2D p1, Point2D p2, Point2D p3)
        {
            P1 = p1;
            P2 = p2;
            P3 = p3;
        }
        public void AddX(int x)
        {
            P1.AddX(x);
            P2.AddX(x);
            P3.AddX(x);
        }
        public void AddY(int y)
        {
            P1.AddY(y);
            P2.AddY(y);
            P3.AddY(y);
        }
        public void DrowLine(Point2D p1, Point2D p2)
        {
            Line line = new Line();
            line.Stroke = Brushes.Red;
            line.StrokeThickness = 3;

            line.X1 = p1.X;
            line.Y1 = p1.Y;
            line.X2 = p2.X;
            line.Y2 = p2.Y;

            //Scene.Children.Add(line);
        }
    }
}