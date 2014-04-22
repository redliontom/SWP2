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
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Controls.Primitives;
using swp_u2.Command;
using swp_u2.Model;

namespace swp_u2.Command
{
    class AddSquare : Interface
    {
        double posX;
        double posY;
        double w;
        Canvas scene;
        bool isDragging = false;

        ModelShape shape;
        ModelSquareShape square;
        ModelThumb thumb;

        public AddSquare(double posX, double posY, double w, Canvas scene)
        {
            this.posX = posX;
            this.posY = posY;
            this.w = w;
            this.scene = scene;
        }

        public void Execute()
        {
            thumb = new ModelThumb(w, w);            
            thumb.cornerThumb.DragDelta += cornerThumb_DragDelta;
            scene.Children.Add(thumb.cornerThumb);

            shape = new ModelShape();
            square = new ModelSquareShape(posX, posY, w);

            shape.myPath = square.myPath;
            shape.pos = new Point(posX, posY);
            shape.Typ = ModelShape.type.Rectangle;
            shape.myPath.MouseDown += myPath_MouseDown;
            shape.myPath.MouseMove += myPath_MouseMove;
            shape.myPath.MouseUp += myPath_MouseUp;

            scene.Children.Add(shape.myPath);
        }

        void cornerThumb_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            //Move the Thumb to the mouse position during the drag operation 
            double yadjust = shape.myPath.Data.Bounds.Height + e.VerticalChange;
            double xadjust = shape.myPath.Data.Bounds.Width + e.HorizontalChange;

            if ((xadjust >= 0) && (yadjust >= 0))
            {
                square.myPath.Width = thumb.cornerThumb.Width = xadjust;
                square.myPath.Height = thumb.cornerThumb.Height = yadjust;
            }
        }

        void myPath_MouseUp(object sender, MouseButtonEventArgs e)
        {
           ((Path)sender).ReleaseMouseCapture();
            isDragging = false;
        }

        private void myPath_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ((Path)sender).CaptureMouse();
            isDragging = true;
        }

        private void myPath_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Canvas.SetLeft(((Path)sender), (e.GetPosition(scene).X - (((Path)sender).Data.Bounds.Width / 2)));
                Canvas.SetTop(((Path)sender), (e.GetPosition(scene).Y - (((Path)sender).Data.Bounds.Height / 2)));
            }
        }
    }
}
