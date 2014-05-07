using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

using SWP2.Prototypes;

namespace SWP2.Command
{
    class Select : ICommand
    {
        GraphicsEditor ge = GraphicsEditor.GetInstance;

        double _posX;
        double _posY;

        public Select(double posX, double posY)
        {
            _posX = posX;
            _posY = posY;
        }

        public void Execute(ModelShape shape)
        {
            Path tempElement;
            foreach (var element in ge.Root.childs)
            {
                if (element.GetType().FullName == "SWP2.Composite.Composite")
                {
                    tempElement = ((Composite.Composite)element).myPath;
                }
                else
                {
                    tempElement = element.myPath;
                }

                if (_posX > tempElement.Data.Bounds.TopLeft.X && _posY > tempElement.Data.Bounds.TopLeft.Y &&
                    _posX < tempElement.Data.Bounds.BottomRight.X && _posY < tempElement.Data.Bounds.BottomRight.Y)
                {
                    element.isSelected = true;
                    tempElement.Stroke = Brushes.Yellow;
                }
            }
        }
    }
}
