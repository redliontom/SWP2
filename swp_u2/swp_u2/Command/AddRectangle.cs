﻿using System;
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
using swp_u2.Command;
using swp_u2.Model;

namespace swp_u2.Command
{
    class AddRectangle : Interface
    {
        double posX;
        double posY;
        double w;
        double h;
        Canvas scene;
        bool isDragging = false;
        double mouseVerticalPosition;
        double mouseHorizontalPosition;

        ModelShape shape;
        ModelRectangleShape rectangle;
        ModelThumbTemp thumb;

        public AddRectangle(double posX, double posY, double w, double h, Canvas scene)
        {
            this.posX = posX;
            this.posY = posY;
            this.w = w;
            this.h = h;
            this.scene = scene;
        }

        public void Execute()
        {
            shape = new ModelShape();
            rectangle = new ModelRectangleShape(posX, posY, w, h);
            shape.myPath = rectangle.myPath;
            shape.pos = new Point(posX, posY);
            shape.Typ = ModelShape.type.Rectangle;
            shape.myPath.MouseDown += myPath_MouseDown;
            shape.myPath.MouseMove += myPath_MouseMove;
            shape.myPath.MouseUp += myPath_MouseUp;
            scene.Children.Add(shape.myPath);
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

            mouseVerticalPosition = e.GetPosition(scene).Y;
            mouseHorizontalPosition = e.GetPosition(scene).X;
            isDragging = true;
            ((Path)sender).CaptureMouse();

        }

        private void myPath_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
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
