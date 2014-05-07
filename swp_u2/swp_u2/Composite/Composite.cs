using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

using SWP2.Prototypes;

namespace SWP2.Composite
{
    class Composite : AbstractShape
    {
        public List<AbstractShape> childs { get; set; }

        GraphicsEditor ge = GraphicsEditor.GetInstance;

        public bool isSelected = false;
        public Path myPath = new Path();

        public Composite()
        {
            this.childs = new List<AbstractShape>();
        }

        public override void Add(AbstractShape component)
        {
            childs.Add(component);
        }

        public override void Remove(AbstractShape component)
        {
            childs.Remove(component);
        }

        public override void Resize(double factor)
        {
            double h = this.MyPath.Data.Bounds.Height * factor;
            double w = this.MyPath.Data.Bounds.Width * factor;
            this.MyPath.Data = new RectangleGeometry(new Rect(this.MyPath.Data.Bounds.Top, this.MyPath.Data.Bounds.Left, h, w));

            foreach (ModelShape child in childs){
                h = child.MyPath.Data.Bounds.Height * factor;
                w = child.MyPath.Data.Bounds.Width * factor;

                if (child.Typ == ModelShape.type.Circle || child.Typ == ModelShape.type.Ellipse)
                    child.MyPath.Data = new EllipseGeometry(new Rect(child.MyPath.Data.Bounds.Top, child.myPath.Data.Bounds.Left, h, w));
                if (child.Typ == ModelShape.type.Rectangle || child.Typ == ModelShape.type.Square)
                    child.MyPath.Data = new RectangleGeometry(new Rect(child.MyPath.Data.Bounds.Top, child.myPath.Data.Bounds.Left, h, w));
            }
        }

        public enum type
        {
            Rectangle, Square, Ellipse, Circle, Triangle
        };

        public type Typ { get; set; }
        public Path MyPath { get { return myPath; } set { myPath = value; base.myPath = value; } }
    }
}
