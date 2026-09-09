using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace pochinki
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Triangle tr;
        Quadrilateral qd;
        Random rnd = new Random();
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
            DrawLine(tr.P3 , tr.P1);
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