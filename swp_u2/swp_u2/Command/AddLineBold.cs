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
    class AddLineBold : Interface
    {
        double posX1;
        double posY1;
        double posX2;
        double posY2;
        Canvas scene;
        bool isDragging = false;

        ModelLine line;
        ModelLineBold boldLine;

        Point p;

        public AddLineBold(double posX1, double posY1, double posX2, double posY2, Canvas scene)
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
            boldLine = new ModelLineBold(posX1, posY1, posX2, posY2);

            line.myLine = boldLine.myLine;
            line.Typ = ModelLine.type.Bold;
            line.myLine.MouseDown += myLine_MouseDown;
            line.myLine.MouseMove += myLine_MouseMove;
            line.myLine.MouseUp += myLine_MouseUp;

            scene.Children.Add(line.myLine);
        }

        /*void cornerThumb_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            //Move the Thumb to the mouse position during the drag operation 
            double yadjust = line.myLine.Data.Bounds.Height + e.VerticalChange;
            double xadjust = line.myLine.Data.Bounds.Width + e.HorizontalChange;

            if ((xadjust >= 0) && (yadjust >= 0))
            {
                line.myLine.Width = thumb.cornerThumb.Width = xadjust;
                line.myLine.Height = thumb.cornerThumb.Height = yadjust;
            }
        }*/

        void myLine_MouseUp(object sender, MouseButtonEventArgs e)
        {
            isDragging = false;
        }

        private void myLine_MouseDown(object sender, MouseButtonEventArgs e)
        {
            p = e.GetPosition(scene);
            isDragging = true;
        }

        private void myLine_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging && e.LeftButton == MouseButtonState.Pressed)
            {
                Point newPos = e.GetPosition(scene);
                line.myLine.X1 += newPos.X - p.X;
                line.myLine.X2 += newPos.X - p.X;
                line.myLine.Y1 += newPos.Y - p.Y;
                line.myLine.Y2 += newPos.Y - p.Y;
            }
        }
    }
}
