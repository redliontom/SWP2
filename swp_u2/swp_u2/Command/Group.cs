using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Collections.Generic;

using SWP2;
using SWP2.Composite;
using SWP2.Prototypes;

namespace SWP2.Command
{
    class Group : ICommand
    {
        GraphicsEditor ge = GraphicsEditor.GetInstance;

        public void Execute(ModelShape shape){
            List<AbstractShape> tempList = new List<AbstractShape>();
            Composite.Composite group = new Composite.Composite();
            double PosX1 = 9999;
            double PosY1 = 9999;
            double PosX2 = 0;
            double PosY2 = 0; 

            foreach(AbstractShape element in ge.Root.childs){
                if (element.isSelected){
                    group.Add(element);
                    tempList.Add(element);
                    element.isSelected = false;

                    PosX1 = Math.Min(element.myPath.Data.Bounds.X, PosX1);
                    PosY1 = Math.Min(element.myPath.Data.Bounds.Y, PosY1);

                    PosX2 = Math.Max(element.myPath.Data.Bounds.BottomRight.X, PosX2);
                    PosY2 = Math.Max(element.myPath.Data.Bounds.BottomRight.Y, PosY2);

                    element.myPath.Stroke = Brushes.Black;
                }
            }

            foreach (AbstractShape element in tempList)
            {
                ge.Root.Remove(element);
            }

            group.MyPath.Data = new RectangleGeometry(new Rect(PosX1, PosY1, PosX2, PosY2));
            group.MyPath.Fill = Brushes.Transparent;
            group.MyPath.Stroke = Brushes.AliceBlue;
            
            DoubleCollection dashes = new DoubleCollection();
            dashes.Add(2);
            dashes.Add(2);
            group.MyPath.StrokeDashArray = dashes;
            group.MyPath.StrokeDashCap = PenLineCap.Round;
            group.MyPath.StrokeThickness = 5;
            ge.Scene.Children.Add(group.MyPath);
            ge.Root.Add(group);
        }
    }
}
