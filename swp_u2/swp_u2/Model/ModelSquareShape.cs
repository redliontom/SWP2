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
using System.Windows.Media; //RectangleGeometry
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace swp_u2.Model
{
    class ModelSquareShape
    {
        public Path myPath { get; set; }

        public ModelSquareShape(double posX, double posY, double w)
        {
            myPath = new Path
            {
                Fill = Brushes.Yellow,
                Stroke = Brushes.Black,
                Data = new RectangleGeometry(new Rect(posX,posY,w,w)),
            };
        }
    }
}
