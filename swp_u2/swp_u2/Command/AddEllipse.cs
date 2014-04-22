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
using swp_u2.Command;
using swp_u2.Model;

namespace swp_u2.Command
{
    class AddEllipse : Interface
    {
        double posX;
        double posY;
        double h;
        double w;
        Canvas scene;

        ModelEllipseShape ellipse;

        public AddEllipse(double posX, double posY, double h, double w, Canvas scene)
        {
            this.posX = posX;
            this.posY = posY;
            this.h = h;
            this.w = w;
            this.scene = scene;
        }

        public void Execute()
        {
            ModelShape shape = new ModelShape();
            ellipse = new ModelEllipseShape(posX, posY, h, w);
            shape.myPath = ellipse.myPath;
            shape.pos = new Point(posX, posY);
            shape.Typ = ModelShape.type.Ellipse;
            scene.Children.Add(shape.myPath);
        }
    }
}
