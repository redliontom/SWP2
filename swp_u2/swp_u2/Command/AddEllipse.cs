using System;
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
    class AddEllipse : ICommand
    {
        double posX;
        double posY;
        double w;
        double h;

        Canvas scene;
        Composite.Composite comp;
        ModelShape shape;

        public AddEllipse(double posX, double posY, double w, double h, Canvas scene, Composite.Composite comp)
        {
            this.posX = posX;
            this.posY = posY;
            this.w = w;
            this.h = h;

            this.scene = scene;
            this.comp = comp;
        }

        public void Execute(ModelShape shape)
        {
            this.shape = shape.Clone() as ModelShape;
            this.shape.MyPath.Data = new EllipseGeometry(new Rect(posX, posY, w, h));
            this.shape.MyPath.Fill = Brushes.Red;
            this.shape.MyPath.Stroke = Brushes.Black;

            comp.Add(shape);
            scene.Children.Add(this.shape.MyPath);
        }
    }
}
