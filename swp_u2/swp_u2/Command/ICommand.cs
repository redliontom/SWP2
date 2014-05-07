using System;

using SWP2.Prototypes;

namespace SWP2.Command
{
    interface ICommand
    {
        void Execute(ModelShape shape);
    }
}
