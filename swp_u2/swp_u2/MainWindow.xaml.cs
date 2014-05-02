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
using SWP2.Prototypes;
using SWP2.Command;
using SWP2.Composite;

namespace SWP2
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ModelShape.type? type = ModelShape.type.Square;
        Composite.Composite root = new Composite.Composite();
        ModelShape rectShape = new ModelShape();        

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
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
            type = ModelShape.type.Triangle;
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
                    AddRectangle addRect = new AddRectangle(posX, PosY, w, h, Scene, root);
                    addRect.Execute(rectShape);
                    break;
                case ModelShape.type.Square:
                    AddSquare addSquare = new AddSquare(posX, PosY, w, Scene, root);
                    addSquare.Execute(rectShape);
                    break;
                case ModelShape.type.Ellipse:
                    AddEllipse addEllipse = new AddEllipse(posX, PosY, w, h, Scene, root);
                    addEllipse.Execute(rectShape);
                    break;
                case ModelShape.type.Circle:
                    AddCircle addCircle = new AddCircle(posX, PosY, w, Scene, root);
                    addCircle.Execute(rectShape);
                    break;
                case ModelShape.type.Triangle:
                    AddTriangle addTriangle = new AddTriangle(posX, PosY, w, Scene, root);
                    addTriangle.Execute(rectShape);
                    break;
            }            
        }

        private void Move_Click(object sender, RoutedEventArgs e)
        {
            type = null;
        }

        private void Resize_Click(object sender, RoutedEventArgs e)
        {
            Resize resize = new Resize(root);
            resize.Execute(rectShape);
        }

        /*public bool HasHeight
        {
            get
            {
                if (type == ModelShape.type.Ellipse || type == ModelShape.type.Rectangle || type == ModelShape.type.Triangle)
                    return true;
                else
                    return false;
            }
        }*/
    }
}
