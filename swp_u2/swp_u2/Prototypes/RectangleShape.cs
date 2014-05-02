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
    public class RectangleShape : ModelShape, ICloneable
    {
        double posX;
        double posY;

        bool isSelected;
        private System.Windows.Shapes.Path myPath = new System.Windows.Shapes.Path();

        bool isDragging = false;
        double mouseVerticalPosition;
        double mouseHorizontalPosition;

        #region ModelShape Members

        public type Typ { get; set; }
        public System.Windows.Shapes.Path MyPath { get { return myPath; } set { myPath = value; } }
        public Point pos { get; set; }

        public RectangleShape(double posX, double posY, double width, double height)
        {
            myPath = new System.Windows.Shapes.Path
            {
                Fill = Brushes.Red,
                Stroke = Brushes.Black,
                Data = new RectangleGeometry(new Rect(posX, posY, width, height)),
            };
        }

        #endregion

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
            return deepCopyObject;
        }

        public object Clone()
        {
            return DeepCopy();
        }

        #endregion


    }
}
