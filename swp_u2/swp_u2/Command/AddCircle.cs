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
    class AddCircle : Interface
    {
        double posR;

        ModelEllipseShape ellipse;

        public AddCircle(double posR)
        {
            this.posR = posR;
        }

        public void Execute()
        {
            ModelShape shape = new ModelShape();
            ellipse = new ModelEllipseShape(posR, posR, 0, 0);
            shape.myPath = ellipse.myPath;
            shape.pos = new Point(posR, posR);
            shape.Typ = ModelShape.type.Circle;
        }
    }
}