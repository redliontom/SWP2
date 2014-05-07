using System;
using System.Windows.Shapes;

namespace SWP2.Prototypes
{
    public abstract class AbstractShape
    {
        public bool isSelected;
        public Path myPath;

        public abstract void Add(AbstractShape component);
        public abstract void Remove(AbstractShape component);
        public abstract void Resize(double factor);
    }
}
