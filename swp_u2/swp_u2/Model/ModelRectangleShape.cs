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
    class ModelRectangleShape
    {
        public Path myPath { get; set; }

        public ModelRectangleShape(double posX, double posY, double w, double h)
        {
            myPath = new Path
            {
                Fill = Brushes.Red,
                Stroke = Brushes.Black,
                Data = new RectangleGeometry(new Rect(posX,posY,w,h)),
            };
        }
    }
}
