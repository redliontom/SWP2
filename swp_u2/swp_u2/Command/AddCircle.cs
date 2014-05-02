﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using SWP2;
using SWP2.Prototypes;

namespace SWP2.Command
{
    class AddCircle : ICommand
    {
        double posX;
        double posY;
        double w;

        Canvas scene;
        Composite.Composite comp;
        ModelShape shape;

        public AddCircle(double posX, double posY, double w, Canvas scene, Composite.Composite comp)
        {
            this.posX = posX;
            this.posY = posY;
            this.w = w;
 
            this.scene = scene;
            this.comp = comp;
        }

        public void Execute(ModelShape shape)
        {
            this.shape = shape.Clone() as ModelShape;
            this.shape.MyPath.Data = new EllipseGeometry(new Rect(posX, posY, w, w));
            this.shape.MyPath.Fill = Brushes.Red;
            this.shape.MyPath.Stroke = Brushes.Black;

            comp.Add(shape);
            scene.Children.Add(this.shape.MyPath);
        }
    }
}
