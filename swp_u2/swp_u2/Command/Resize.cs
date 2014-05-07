using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

using SWP2.Prototypes;

namespace SWP2.Command
{
    class Resize : ICommand
    {
        GraphicsEditor ge = GraphicsEditor.GetInstance;
        double _factor;

        public Resize(double factor)
        {
            _factor = factor;
        }

        public void Execute(ModelShape shape)
        {
            foreach (AbstractShape element in ge.Root.childs)
            {
                if (element.isSelected)
                {
                    if (element.GetType().FullName == "SWP2.Composite.Composite")
                    {
                        Composite.Composite tempElement = element as Composite.Composite;
                        tempElement.Resize(_factor);
                    }
                    else
                    {
                        ModelShape tempElement = element as ModelShape;
                        tempElement.Resize(_factor);
                    }                    
                }
            }
        }
    }
}
