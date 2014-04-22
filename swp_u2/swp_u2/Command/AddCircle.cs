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
using swp_u2;

namespace swp_u2.Command
{
    class AddCircle : Interface
    {
        double posX;
        double posY;
        double posR;
        Canvas scene;

        ModelCircleShape circle;

        public AddCircle(double posX, double posY, double posR, Canvas scene)
        {
            this.posX = posX;
            this.posY = posY;
            this.posR = posR;
            this.scene = scene;
        }

        public void Execute()
        {
            ModelShape shape = new ModelShape();
            circle = new ModelCircleShape(posX, posY, posR);
            shape.myPath = circle.myPath;
            shape.pos = new Point(posX, posY);
            shape.Typ = ModelShape.type.Circle;            
        }
    }
}
