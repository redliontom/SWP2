using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

using SWP2;
using SWP2.Prototypes;

namespace SWP2.Command
{
    class Add : ICommand
    {
        GraphicsEditor ge = GraphicsEditor.GetInstance;
        ModelShape shape;

        double _posX;
        double _posY;
        double _w;
        double _h;

        public Add(double posX, double posY, double w, double h)
        {
            _posX = posX;
            _posY = posY;
            _w = w;
            _h = h;
        }

        public void Execute(ModelShape shape)
        {
            this.shape = shape.Clone() as ModelShape;

            if (ge.Type != null)
            {
                switch (ge.Type)
                {
                    case ModelShape.type.Rectangle:
                        this.shape.MyPath.Data = new RectangleGeometry(new Rect(_posX, _posY, _w, _h));                        
                        break;
                    case ModelShape.type.Square:
                        this.shape.MyPath.Data = new RectangleGeometry(new Rect(_posX, _posY, _w, _w));
                        break;
                    case ModelShape.type.Ellipse:
                        this.shape.MyPath.Data = new EllipseGeometry(new Rect(_posX, _posY, _w, _h));
                        break;
                    case ModelShape.type.Circle:
                        this.shape.MyPath.Data = new EllipseGeometry(new Rect(_posX, _posY, _w, _w));
                        break;
                    case ModelShape.type.Triangle:
                        this.shape.MyPath.Data = Geometry.Parse("M 0 " + _w + " L 0 0 L " + _w + " " + _w + " Z");
                        break;
                }
            }

            if (ge.Pen == GraphicsEditor.pen.Typ1)
            {
                this.shape.MyPath.Fill = Brushes.Red;
                this.shape.MyPath.Stroke = Brushes.Black;
            }
            else
            {
                this.shape.MyPath.Fill = Brushes.Blue;
                this.shape.MyPath.Stroke = Brushes.Black;
                this.shape.MyPath.StrokeThickness = 4;
            }


            this.shape.Typ = (ModelShape.type)ge.Type;

            ge.Root.Add(this.shape);
            ge.Scene.Children.Add(this.shape.MyPath);
        }
    }
}
