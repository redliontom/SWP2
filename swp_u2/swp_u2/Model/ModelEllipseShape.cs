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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace swp_u2.Model
{
    class ModelEllipseShape
    {
        public Path myPath { get; set; }
 
        public ModelEllipseShape(double posX, double posY, double radX, double radY)
        {
            myPath = new Path
            {
                Fill = Brushes.Blue,
                Stroke = Brushes.Black,
                Data = new EllipseGeometry(new Rect(posX, posY, radX, radY)),
            };
        }
    }
}
