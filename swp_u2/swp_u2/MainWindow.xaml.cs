using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
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
        GraphicsEditor ge = GraphicsEditor.GetInstance;

        Group group;
        Add add;

        bool dragging = false;
        Path tempElement;
        ModelShape.type tempType;
        Composite.Composite tempComp;

        double posX;
        double posY;

        public MainWindow()
        {
            InitializeComponent();

            group = new Group();

            ge.Scene = Scene;
            
            Path myPath = new System.Windows.Shapes.Path
            {
                Fill = Brushes.Red,
                Stroke = Brushes.Black,
            };
            ge.Root = new Composite.Composite();
        }

        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Rectangle_Click(object sender, RoutedEventArgs e)
        {
            ge.Mode = null;
            ge.Type = ModelShape.type.Rectangle;
        }

        private void Square_Click(object sender, RoutedEventArgs e)
        {
            ge.Mode = null;
            ge.Type = ModelShape.type.Square;
        }

        private void Ellipse_Click(object sender, RoutedEventArgs e)
        {
            ge.Mode = null;
            ge.Type = ModelShape.type.Ellipse;
        }

        private void Circle_Click(object sender, RoutedEventArgs e)
        {
            ge.Mode = null;
            ge.Type = ModelShape.type.Circle;
        }

        private void Triangle_Click(object sender, RoutedEventArgs e)
        {
            ge.Mode = null;
            ge.Type = ModelShape.type.Triangle;
        }

        private void Select_Click(object sender, RoutedEventArgs e)
        {
            ge.Type = null;
            ge.Mode = GraphicsEditor.mode.Select;
        }

        private void Deselect_Click(object sender, RoutedEventArgs e)
        {
            ge.Type = null;
            ge.Mode = GraphicsEditor.mode.Deselect;
        }

        private void Move_Click(object sender, RoutedEventArgs e)
        {
            ge.Type = null;
            ge.Mode = GraphicsEditor.mode.Move;
        }

        private void ResizeSmaller_Click(object sender, RoutedEventArgs e)
        {
            Resize resize = new Resize(0.8);
            resize.Execute(null);
        }

        private void Group_Click(object sender, RoutedEventArgs e)
        {
            group.Execute(null);
        }

        private void Typ1_Click(object sender, RoutedEventArgs e)
        {
            ge.Pen = GraphicsEditor.pen.Typ1;
        }

        private void Typ2_Click(object sender, RoutedEventArgs e)
        {
            ge.Pen = GraphicsEditor.pen.Typ2;
        }

        private void ResizeBigger_Click(object sender, RoutedEventArgs e)
        {
            Resize resize = new Resize(1.2);
            resize.Execute(null);
        }

        #region Mouse Events

        private void Scene_MouseDown(object sender, MouseButtonEventArgs e)
        {  
            posX = e.GetPosition(Scene).X;
            posY = e.GetPosition(Scene).Y;
            double h = slider_h.Value;
            double w = slider_w.Value;

            
            Path myPath = new System.Windows.Shapes.Path
            {
                Fill = Brushes.Red,
                Stroke = Brushes.Black,
            };
            ModelShape rectShape = new ModelShape();

            if (ge.Type != null)
            {
                add = new Add(posX, posY, h, w);
                add.Execute(rectShape);
            }
            else if (ge.Mode == GraphicsEditor.mode.Select)
            {
                Select select = new Select(posX, posY);
                select.Execute(null);
            }
            else if (ge.Mode == GraphicsEditor.mode.Deselect)
            {
                Deselect deselect = new Deselect(posX, posY);
                deselect.Execute(null);
            }
            else if (ge.Mode == GraphicsEditor.mode.Move)
            {                
                foreach (var element in ge.Root.childs)
                {                    
                    if (element.GetType().FullName == "SWP2.Composite.Composite")
                    {
                        tempElement = ((Composite.Composite)element).MyPath;
                        tempComp = (Composite.Composite)element;
                    }
                    else
                    {
                        tempElement = ((ModelShape)element).MyPath;
                        tempType = ((ModelShape)element).Typ;
                        tempComp = null;
                    }

                    if (posX > tempElement.Data.Bounds.TopLeft.X && posY > tempElement.Data.Bounds.TopLeft.Y &&
                    posX < tempElement.Data.Bounds.BottomRight.X && posY < tempElement.Data.Bounds.BottomRight.Y)
                    {
                        dragging = true;
                        tempElement.CaptureMouse();
                    }
                }
            }
        }

        private void Scene_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                // Calculate the current position of the object.
                double deltaV = e.GetPosition(Scene).Y - posY;
                double deltaH = e.GetPosition(Scene).X - posX;
                double newTop = deltaV + posY;
                double newLeft = deltaH + posX;

                // Set new position of object.
                tempElement.Data = new RectangleGeometry(new Rect(newLeft, newTop, tempElement.Data.Bounds.Width, tempElement.Data.Bounds.Height));

                if (tempType == ModelShape.type.Circle || tempType == ModelShape.type.Ellipse)
                    tempElement.Data = new EllipseGeometry(new Rect(newLeft, newTop, tempElement.Data.Bounds.Width, tempElement.Data.Bounds.Height));
                if (tempType == ModelShape.type.Rectangle || tempType == ModelShape.type.Square)
                    tempElement.Data = new RectangleGeometry(new Rect(newLeft, newTop, tempElement.Data.Bounds.Width, tempElement.Data.Bounds.Height));

                if (tempComp != null)
                {
                    foreach (ModelShape shape in tempComp.childs)
                    {
                        if (shape.Typ == ModelShape.type.Circle || shape.Typ == ModelShape.type.Ellipse)
                            shape.MyPath.Data = new EllipseGeometry(new Rect(shape.MyPath.Data.Bounds.Top + deltaH, shape.MyPath.Data.Bounds.Left + deltaV, shape.MyPath.Data.Bounds.Width, shape.MyPath.Data.Bounds.Height));
                        if (shape.Typ == ModelShape.type.Rectangle || shape.Typ == ModelShape.type.Square)
                            shape.MyPath.Data = new RectangleGeometry(new Rect(shape.MyPath.Data.Bounds.Top + deltaH, shape.MyPath.Data.Bounds.Left + deltaV, shape.MyPath.Data.Bounds.Width, shape.MyPath.Data.Bounds.Height));
                    }
                }

                // Update position global variables.
                posX = e.GetPosition(Scene).X;
                posY = e.GetPosition(Scene).Y;

                posX = newTop;
                posY = newLeft;
            }
        }

        private void Scene_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (ge.Mode == GraphicsEditor.mode.Move)
            {                
                tempElement.ReleaseMouseCapture();
                posX = -1;
                posY = -1;
            }

            dragging = false;
        }

        #endregion   
    }
}
