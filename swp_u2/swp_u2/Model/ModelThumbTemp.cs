using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
    class ModelThumbTemp : Thumb
    {
        public ModelThumbTemp()
        {
            DragDelta += new DragDeltaEventHandler(this.ModelThumb_DragDelta);
        }

        private void ModelThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            Control designerItem = this.DataContext as Control;

            if (designerItem != null)
            {
                double left = Canvas.GetLeft(designerItem);
                double top = Canvas.GetTop(designerItem);

                Canvas.SetLeft(designerItem, left + e.HorizontalChange);
                Canvas.SetTop(designerItem, top + e.VerticalChange);
            }
        }

        /*public Thumb cornerThumb{ get; set; }

        public ModelThumb(double w, double h)
        {
            cornerThumb = new Thumb
            {
                Cursor = Cursors.SizeNWSE,
                Height = h,
                Width = w,
                Opacity = 0.4,
                Background = new SolidColorBrush(Colors.MediumBlue),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(w - 5, h -5, w - 5 + w, h - 5 + h),
            };
        }*/
    }
}
