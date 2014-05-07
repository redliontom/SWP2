using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Markup;
using System.Xml;

using SWP2.Composite;

namespace SWP2.Prototypes
{
    public class ModelShape : AbstractShape, ICloneable
    {        
        public bool isSelected = false;
        public Path myPath = new Path();

        GraphicsEditor ge = GraphicsEditor.GetInstance;        

        public enum type
        {
            Rectangle, Square, Ellipse, Circle, Triangle
        };

        public type Typ { get; set; }
        public Path MyPath { get { return myPath; } set { myPath = value; base.myPath = value; } }

        public override void Add(AbstractShape component)
        {
            throw new NotImplementedException();            
        }

        public override void Remove(AbstractShape component)
        {
            throw new NotImplementedException();
        }

        public override void Resize(double factor)
        {           
            double h = this.MyPath.Data.Bounds.Height * factor;
            double w = this.MyPath.Data.Bounds.Width * factor;

            if (this.Typ == ModelShape.type.Circle || this.Typ == ModelShape.type.Ellipse)
                this.MyPath.Data = new EllipseGeometry(new Rect(this.MyPath.Data.Bounds.Top, this.myPath.Data.Bounds.Left, h, w));
            if (this.Typ == ModelShape.type.Rectangle || this.Typ == ModelShape.type.Square)
                this.MyPath.Data = new RectangleGeometry(new Rect(this.MyPath.Data.Bounds.Top, this.myPath.Data.Bounds.Left, h, w));
            
        }

        #region ICloneable Members

        private object ShallowCopy()
        {
            return this.MemberwiseClone();
        }

        private object DeepCopy()
        {
            var xaml = XamlWriter.Save(this);
            var xamlString = new System.IO.StringReader(xaml);
            var xmlTextReader = new XmlTextReader(xamlString);
            var deepCopyObject = (ModelShape)XamlReader.Load(xmlTextReader);
            deepCopyObject.MyPath.Data = new RectangleGeometry(new Rect(0, 0, 50, 50));
            return deepCopyObject;
        }

        public object Clone()
        {
            return DeepCopy();
        }

        #endregion
    }
}
