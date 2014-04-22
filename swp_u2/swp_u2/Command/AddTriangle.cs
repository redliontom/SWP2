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
    class AddTriangle : Interface
    {
        double posX;
        double posY;
        double posW;
        Canvas scene;

        ModelTriangleShape triangle;

        public AddTriangle(double posX, double posY, double posW, Canvas scene)
        {
            this.posX = posX;
            this.posY = posY;
            this.posW = posW;
            this.scene = scene;
        }

        public void Execute()
        {
            ModelShape shape = new ModelShape();
            triangle = new ModelTriangleShape(posX, posY, posW);
            shape.myPath = triangle.myPath;
            shape.pos = new Point(posX, posY);
            shape.Typ = ModelShape.type.Triangle;
            scene.Children.Add(shape.myPath);
        }
    }
}
