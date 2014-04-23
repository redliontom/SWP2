using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Shapes;
using System.Windows.Media; //RectangleGeometry
using System.Windows.Media.Imaging;

namespace swp_u2.Model
{
    class ModelLineThin
    {
        public Line myLine { get; set; }

        public ModelLineThin(double posX1, double posY1, double posX2, double posY2)
        {
            myLine = new Line
            {
                Stroke = Brushes.Blue,
                StrokeThickness = 2,
                X1 = posX1,
                Y1 = posY1,
                X2 = posX2,
                Y2 = posY2
            };
        }
    }
}
