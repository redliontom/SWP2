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
        ModelShape.type type = new ModelShape.type();
        swp_u2.Composite.Composite root = new swp_u2.Composite.Composite();

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
        }

        private void Square_Click(object sender, RoutedEventArgs e)
        {
            type = ModelShape.type.Square;
        }

        private void Ellipse_Click(object sender, RoutedEventArgs e)
        {
            type = ModelShape.type.Ellipse;
        }

        private void Circle_Click(object sender, RoutedEventArgs e)
        {
            type = ModelShape.type.Circle;
        }

        private void Triangle_Click(object sender, RoutedEventArgs e)
        {
            //type = ModelShape.type.Triangle;
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
            }
        }
    }
}
