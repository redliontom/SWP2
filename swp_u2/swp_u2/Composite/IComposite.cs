using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using SWP2.Prototypes;

namespace SWP2.Composite
{
    public abstract class IComposite
    {
        public bool isSelected;

        public abstract void Draw(ModelShape shape, Canvas scene, double posX, double posY, double w, double h);
        public abstract void Resize(double factor);
    }
}
