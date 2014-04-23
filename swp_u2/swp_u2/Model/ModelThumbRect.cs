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
using System.Windows.Controls.Primitives;

namespace swp_u2.Model
{
    class ModelThumbRect
    {
        public Thumb myPath { get; set; }

        public ModelThumbRect(double posX, double posY, double w, double h)
        {
            myPath = new Thumb
            {
                Cursor = Cursors.SizeNWSE,
                Opacity = 1,
                Height = w,
                Width = w,
                Background = Brushes.Violet,
                BorderBrush = Brushes.Transparent,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(w + 5, h + 5, w + 5 - w, h + 5 - h),
            };
            myPath.SetValue(Canvas.LeftProperty, posX-w);
            myPath.SetValue(Canvas.TopProperty, posY-h);
        }
    }
}
