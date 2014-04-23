using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Resources;
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
using System.Windows.Media.Composition;
using System.Windows;
using System.Windows.Controls;
using System.Reflection;
using System.Data;
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
        double mouseVerticalPosition;
        double mouseHorizontalPosition;

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
            /*ModelThumbRect thumbrect = new ModelThumbRect(posX, posY, w, w);
            thumb = new ModelThumb();
            thumbrect.myPath.DragDelta += cornerThumb_DragDelta;
            scene.Children.Add(thumbrect.myPath);
            thumb.myPath = thumbrect.myPath;*/


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

        void tmb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            //Thumb anhand des sender-Parameters bestimmen
            Canvas.SetLeft(shape.myPath, Canvas.GetLeft(shape.myPath) + e.HorizontalChange);
            Canvas.SetTop(shape.myPath, Canvas.GetTop(shape.myPath) + e.VerticalChange);
            Canvas.SetLeft(sender as Thumb, Canvas.GetLeft(sender as Thumb) + e.HorizontalChange);
            Canvas.SetTop(sender as Thumb, Canvas.GetTop(sender as Thumb) + e.VerticalChange);
        }

        void tmb_DragCompleted(object sender, DragCompletedEventArgs e)
        {
            if ((sender as Thumb).Tag == null)
            {
                (sender as Thumb).Tag = "Completed";//Wert zuweisen, damit wir erkennen können, ob der Thumb schonmal gezigen wurde
                //CreateThumb();//neuen Thumb erzeugen
            }
        }

        void cornerThumb_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            double yadjust = w + e.VerticalChange;
            double xadjust = w + e.HorizontalChange;
            if ((xadjust >= 0) && (yadjust >= 0))
            {
                square.myPath.Width = w = yadjust;
                square.myPath.Height = w = xadjust;
            }
            //Move the Thumb to the mouse position during the drag operation 
            /*double yadjust = w + e.VerticalChange;
            double xadjust = w + e.HorizontalChange;

            if ((xadjust >= 0) && (yadjust >= 0))
            {
                square.myPath.Width = thumb.myPath.Width = xadjust;
                square.myPath.Height = thumb.myPath.Height = yadjust;
            }*/
        }

        void myPath_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
           ((Path)sender).ReleaseMouseCapture(); 
            mouseVerticalPosition = -1;
            mouseHorizontalPosition = -1;
        }

        private void myPath_MouseDown(object sender, MouseEventArgs e)
        {
            var test = shape.myPath.Data.Bounds;
            mouseVerticalPosition = e.GetPosition(scene).Y;
            mouseHorizontalPosition = e.GetPosition(scene).X;
            isDragging = true;
            ((Path)sender).CaptureMouse();

        }

        private void myPath_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                if (Math.Abs(posX + w - e.GetPosition(scene).X) < 25 &&
                    Math.Abs(posY + w - e.GetPosition(scene).Y) < 25)
                {
                    var x = Math.Abs(e.GetPosition(scene).X - mouseHorizontalPosition);
                    var y = Math.Abs(e.GetPosition(scene).Y - mouseVerticalPosition);

                    var width = Math.Abs(w - x);
                    var height = Math.Abs(w - y);

                    shape.myPath.Width = w += width;
                    shape.myPath.Height = w += height;
                }
                else
                {
                    // Calculate the current position of the object.
                    double deltaV = e.GetPosition(scene).Y - mouseVerticalPosition;
                    double deltaH = e.GetPosition(scene).X - mouseHorizontalPosition;
                    double newTop = deltaV + posX;
                    double newLeft = deltaH + posY;

                    // Set new position of object.
                    ((Path)sender).SetValue(Canvas.TopProperty, newTop);
                    ((Path)sender).SetValue(Canvas.LeftProperty, newLeft);

                    // Update position global variables.
                    mouseVerticalPosition = e.GetPosition(scene).Y;
                    mouseHorizontalPosition = e.GetPosition(scene).X;

                    posX = newTop;
                    posY = newLeft;
                }
            }
        }
    }
}
