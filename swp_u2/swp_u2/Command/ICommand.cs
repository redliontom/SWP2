using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWP2.Prototypes;

namespace SWP2.Command
{
    interface ICommand
    {
        void Execute(ModelShape shape);
    }
}
