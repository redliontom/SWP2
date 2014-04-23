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
    class AddLineThin : Interface
    {
        double posX1;
        double posY1;
        double posX2;
        double posY2;
        Canvas scene;
        bool isDragging = false;

        ModelLine line;
        ModelLineThin thinLine;

        public AddLineThin(double posX1, double posY1, double posX2, double posY2, Canvas scene)
        {
            this.posX1 = posX1;
            this.posY1 = posY1;
            this.posX2 = posX2;
            this.posY2 = posY2;
            this.scene = scene;
        }

        public void Execute()
        {
            line = new ModelLine();
            thinLine = new ModelLineThin(posX1, posY1, posX2, posY2);

            line.myLine = thinLine.myLine;
            line.Typ = ModelLine.type.Thin;
            //shape.pos = new Point(posX, posY);
            //line.myLine.MouseDown += myPath_MouseDown;
            //line.myLine.MouseMove += myPath_MouseMove;
            //line.myLine.MouseUp += myPath_MouseUp;

            scene.Children.Add(line.myLine);
        }

       /* void cornerThumb_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
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
        }*/
    }
}
