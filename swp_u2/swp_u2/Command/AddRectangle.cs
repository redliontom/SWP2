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
    class AddRectangle : Interface
    {
        double posX;
        double posY;
        double w;
        double h;
        Canvas scene;

        ModelRectangleShape rectangle;
        ModelThumb thumb;

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
            ModelShape shape = new ModelShape();
            rectangle = new ModelRectangleShape(posX, posY, w, h);
            shape.myPath = rectangle.myPath;
            shape.pos = new Point(posX, posY);
            shape.Typ = ModelShape.type.Rectangle;
            scene.Children.Add(shape.myPath);
        }
    }
}
