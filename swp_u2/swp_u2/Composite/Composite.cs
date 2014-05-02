using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using SWP2.Prototypes;

namespace SWP2.Composite
{
    class Composite : IComposite
    {
        private List<ModelShape> childs { get; set; }

        public Composite()
        {
            childs = new List<ModelShape>();
        }

        public void Add(ModelShape component)
        {
            childs.Add(component);
        }

        public void Remove(ModelShape component)
        {
            childs.Remove(component);
        }

        public override void Draw(ModelShape shape, Canvas scene, double posX, double posY, double w, double h)
        {

        }

        public override void Resize(double factor)
        {
            foreach (ModelShape child in childs){
               if (child.isSelected)
                child.Resize(factor);
            }
        }
    }
}
