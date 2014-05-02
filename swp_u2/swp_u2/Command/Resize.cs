using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWP2.Prototypes;

namespace SWP2.Command
{
    class Resize : ICommand
    {
        Composite.Composite comp;

        public Resize(Composite.Composite comp)
        {
            this.comp = comp;
        }

        public void Execute(ModelShape shape)
        {
            comp.Resize(0.5);
        }
    }
}
