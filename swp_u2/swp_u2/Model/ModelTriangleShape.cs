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
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
namespace swp_u2.Model
{
    class ModelTriangleShape
    {
        public Path myPath { get; set; }

        public ModelTriangleShape(double posX, double posY, double w)
        {
            myPath = new Path
            {
                Fill = Brushes.Yellow,
                Stroke = Brushes.Black,
                Data = Geometry.Parse("M 0 "+w+" L 0 0 L "+w+" "+w+" Z"),
            };
        }
    }
}
