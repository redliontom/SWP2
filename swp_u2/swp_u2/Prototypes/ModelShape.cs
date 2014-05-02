using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Windows.Markup;
using System.IO;
using System.Xml;
using SWP2.Composite;

namespace SWP2.Prototypes
{
    public class ModelShape : IComposite, ICloneable
    {
        double posX;
        double posY;
        double w = 50;
        double h = 50;

        public bool isSelected = true;
        private System.Windows.Shapes.Path myPath = new System.Windows.Shapes.Path();

        bool isDragging = false;
        double mouseVerticalPosition;
        double mouseHorizontalPosition;

        public ModelShape()
        {
            myPath = new System.Windows.Shapes.Path
            {
                Fill = Brushes.Red,
                Stroke = Brushes.Black,
            };
        }

        public override void Draw(ModelShape shape, Canvas scene, double posX, double posY, double w, double h)
        {
            //shape.MyPath.Data = new RectangleGeometry(new Rect(posX, posY, w, h));
            //cene.Children.Add(shape.MyPath);
        }

        public override void Resize(double factor)
        {
            this.w *= factor;
            this.h *= factor;            

            ((Canvas)this.myPath.Parent).Children.Remove(this.myPath);
            this.MyPath.Data = new RectangleGeometry(new Rect(0, 0, 100, 100));
            ((Canvas)this.myPath.Parent).Children.Remove(this.myPath);
        }

        public enum type
        {
            Rectangle, Square, Ellipse, Circle, Triangle
        };

        public type Typ { get; set; }
        public System.Windows.Shapes.Path MyPath { get { return myPath; } set { myPath = value; } }
        public Point pos { get; set; }

        #region ICloneable Members

        private object ShallowCopy()
        {
            return this.MemberwiseClone();
        }

        private object DeepCopy()
        {
            var xaml = XamlWriter.Save(this);
            var xamlString = new StringReader(xaml);
            var xmlTextReader = new XmlTextReader(xamlString);
            var deepCopyObject = (ModelShape)XamlReader.Load(xmlTextReader);
            deepCopyObject.myPath.MouseDown += myPath_MouseDown;
            deepCopyObject.myPath.MouseMove += myPath_MouseMove;
            deepCopyObject.myPath.MouseUp += myPath_MouseUp;
            return deepCopyObject;
        }

        public object Clone()
        {
            return DeepCopy();
        }

        #endregion

        #region MouseEvents

        void myPath_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
            ((System.Windows.Shapes.Path)sender).ReleaseMouseCapture();
            mouseVerticalPosition = -1;
            mouseHorizontalPosition = -1;
        }

        private void myPath_MouseDown(object sender, MouseEventArgs e)
        {
            mouseVerticalPosition = e.GetPosition(((System.Windows.Shapes.Path)sender).Parent as Canvas).Y;
            mouseHorizontalPosition = e.GetPosition(((System.Windows.Shapes.Path)sender).Parent as Canvas).X;
            isDragging = true;
            ((System.Windows.Shapes.Path)sender).CaptureMouse();

        }

        private void myPath_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                // Calculate the current position of the object.
                double deltaV = e.GetPosition(((System.Windows.Shapes.Path)sender).Parent as Canvas).Y - mouseVerticalPosition;
                double deltaH = e.GetPosition(((System.Windows.Shapes.Path)sender).Parent as Canvas).X - mouseHorizontalPosition;
                double newTop = deltaV + posX;
                double newLeft = deltaH + posY;

                // Set new position of object.
                ((System.Windows.Shapes.Path)sender).SetValue(Canvas.TopProperty, newTop);
                ((System.Windows.Shapes.Path)sender).SetValue(Canvas.LeftProperty, newLeft);

                // Update position global variables.
                mouseVerticalPosition = e.GetPosition(((System.Windows.Shapes.Path)sender).Parent as Canvas).Y;
                mouseHorizontalPosition = e.GetPosition(((System.Windows.Shapes.Path)sender).Parent as Canvas).X;

                posX = newTop;
                posY = newLeft;
            }
        }

        #endregion
    }
}
