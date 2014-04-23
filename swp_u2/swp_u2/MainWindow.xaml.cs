using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using swp_u2.Command;
using swp_u2.Model;

namespace swp_u2
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ModelShape.type? type = null;
        ModelLine.type? lineType = null;
        swp_u2.Composite.Composite root = new swp_u2.Composite.Composite();

        Point currentPoint = new Point();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Rectangle_Click(object sender, RoutedEventArgs e)
        {
            type = ModelShape.type.Rectangle;
            lineType = null;
        }

        private void Square_Click(object sender, RoutedEventArgs e)
        {
            type = ModelShape.type.Square;
            lineType = null;
        }

        private void Ellipse_Click(object sender, RoutedEventArgs e)
        {
            type = ModelShape.type.Ellipse;
            lineType = null;
        }

        private void Circle_Click(object sender, RoutedEventArgs e)
        {
            type = ModelShape.type.Circle;
            lineType = null;
        }

        private void Triangle_Click(object sender, RoutedEventArgs e)
        {
            type = ModelShape.type.Triangle;
            lineType = null;
        }

        private void Scene_MouseDown(object sender, MouseButtonEventArgs e)
        {      
            double posX = e.GetPosition(Scene).X;
            double PosY = e.GetPosition(Scene).Y;
            double h = slider_h.Value;
            double w = slider_w.Value;

            switch (type)
            {
                case ModelShape.type.Rectangle:
                    AddRectangle addRect = new AddRectangle(posX, PosY, w, h, Scene);
                    addRect.Execute();
                    break;
                case ModelShape.type.Square:
                    AddSquare addSquare = new AddSquare(posX, PosY, w, Scene);
                    addSquare.Execute();
                    break;
                case ModelShape.type.Ellipse:
                    AddEllipse addEllipse = new AddEllipse(posX, PosY, w, h, Scene);
                    addEllipse.Execute();
                    break;
                case ModelShape.type.Circle:
                    AddCircle addCircle = new AddCircle(posX, PosY, w, Scene);
                    addCircle.Execute();
                    break;
                case ModelShape.type.Triangle:
                    AddTriangle addTriangle = new AddTriangle(posX, PosY, w, Scene);
                    addTriangle.Execute();
                    break;
                default:
                    if (e.ButtonState == MouseButtonState.Pressed)
                        currentPoint = e.GetPosition(Scene);
                    break;
            }

            
        }

        private void Scene_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                switch (lineType)
                {
                    case ModelLine.type.Thin:
                        AddLineThin addThin = new AddLineThin(currentPoint.X, currentPoint.Y, e.GetPosition(Scene).X, e.GetPosition(Scene).Y, Scene);
                        currentPoint = e.GetPosition(Scene);
                        addThin.Execute();
                        break;
                    case ModelLine.type.Bold:
                        AddLineBold addBold = new AddLineBold(currentPoint.X, currentPoint.Y, e.GetPosition(Scene).X, e.GetPosition(Scene).Y, Scene);
                        currentPoint = e.GetPosition(Scene);
                        addBold.Execute();
                        break;
                }
            }
        }

        private void Pen1_Click(object sender, RoutedEventArgs e)
        {
            lineType = ModelLine.type.Thin;
            type = null;
        }

        private void Pen2_Click(object sender, RoutedEventArgs e)
        {
            lineType = ModelLine.type.Bold;
            type = null;
        }

        private void Move_Click(object sender, RoutedEventArgs e)
        {
            lineType = null;
            type = null;
        }
    }
}
