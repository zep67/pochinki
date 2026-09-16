using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace pochinki
{
    public partial class MainWindow : Window
    {
        Triangle tr;
        Quadrilateral qd;
        Random rnd = new Random();

        private Point2D dragStartPoint;   
        private object draggedFigure;     
        private Point2D figureStartPos;   

        public MainWindow()
        {
            InitializeComponent();

            Point2D p1 = new Point2D(rnd.Next(0, (int)Scene.Width), rnd.Next(0, (int)Scene.Height));
            Point2D p2 = new Point2D(rnd.Next(0, (int)Scene.Width), rnd.Next(0, (int)Scene.Height));
            Point2D p3 = new Point2D(rnd.Next(0, (int)Scene.Width), rnd.Next(0, (int)Scene.Height));
            Point2D p4 = new Point2D(rnd.Next(50, (int)Scene.Width - 50), rnd.Next(50, (int)Scene.Height - 50));

            int width = rnd.Next(30, 150);
            int height = rnd.Next(30, 150);

            Point2D p5 = new Point2D(p4.X + width, p4.Y);
            Point2D p6 = new Point2D(p4.X + width, p4.Y + height);
            Point2D p7 = new Point2D(p4.X, p4.Y + height);

            tr = new Triangle(p1, p2, p3);
            qd = new Quadrilateral(p4, p5, p6, p7);

            DrawQuadrilateral(qd);
            DrawTriangle(tr);

            Scene.MouseLeftButtonDown += Scene_MouseLeftButtonDown;
            Scene.MouseMove += Scene_MouseMove;
            Scene.MouseLeftButtonUp += Scene_MouseLeftButtonUp;
        }

        private void Scene_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point mouse = e.GetPosition(Scene);

            if (IsPointInQuadrilateral(qd, mouse))
            {
                draggedFigure = qd;
                figureStartPos = new Point2D(qd.P4.X, qd.P4.Y);
            }
            else if (IsPointInTriangle(tr, mouse))
            {
                draggedFigure = tr;
                figureStartPos = new Point2D(tr.P1.X, tr.P1.Y);
            }
            else
            {
                draggedFigure = null;
                return;
            }

            dragStartPoint = new Point2D((int)mouse.X, (int)mouse.Y);
            Scene.CaptureMouse(); 
        }

        private void Scene_MouseMove(object sender, MouseEventArgs e)
        {
            if (draggedFigure == null) return;

            Point mouse = e.GetPosition(Scene);

            int dx = (int)mouse.X - dragStartPoint.X;
            int dy = (int)mouse.Y - dragStartPoint.Y;

            if (draggedFigure is Quadrilateral q)
            {
                q.MoveTo(figureStartPos.X + dx, figureStartPos.Y + dy);
            }
            else if (draggedFigure is Triangle t)
            {
                t.MoveTo(figureStartPos.X + dx, figureStartPos.Y + dy);
            }

            ClearScene();
            DrawQuadrilateral(qd);
            DrawTriangle(tr);
        }

        private void Scene_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            draggedFigure = null;
            Scene.ReleaseMouseCapture();
        }

        private bool IsPointInTriangle(Triangle t, Point p)
        {
            Point2D a = t.P1, b = t.P2, c = t.P3;

            double d1 = Sign(p, a, b);
            double d2 = Sign(p, b, c);
            double d3 = Sign(p, c, a);

            bool hasNeg = (d1 < 0) || (d2 < 0) || (d3 < 0);
            bool hasPos = (d1 > 0) || (d2 > 0) || (d3 > 0);

            return !(hasNeg && hasPos);
        }

        private double Sign(Point p1, Point2D p2, Point2D p3)
        {
            return (p1.X - p3.X) * (p2.Y - p3.Y) - (p2.X - p3.X) * (p1.Y - p3.Y);
        }

        private bool IsPointInQuadrilateral(Quadrilateral q, Point p)
        {
            return IsPointInTriangle(new Triangle(q.P4, q.P5, q.P6), p)
                || IsPointInTriangle(new Triangle(q.P4, q.P6, q.P7), p);
        }

        public void DrawQuadrilateral(Quadrilateral qd)
        {
            DrawLine(qd.P4, qd.P5);
            DrawLine(qd.P5, qd.P6);
            DrawLine(qd.P6, qd.P7);
            DrawLine(qd.P7, qd.P4);
        }

        public void DrawTriangle(Triangle tr)
        {
            DrawLine(tr.P1, tr.P2);
            DrawLine(tr.P2, tr.P3);
            DrawLine(tr.P3, tr.P1);
        }

        public void ClearScene()
        {
            Scene.Children.Clear();
        }

        public void DrawLine(Point2D p1, Point2D p2)
        {
            Line line = new Line();
            line.Stroke = Brushes.Red;
            line.StrokeThickness = 3;

            line.X1 = p1.X;
            line.Y1 = p1.Y;
            line.X2 = p2.X;
            line.Y2 = p2.Y;

            Scene.Children.Add(line);
        }
    }
}