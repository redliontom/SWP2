using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swp_u2.ShapePrototypes
{
    class SquareShape
    {
        double w;

        public double width { get { return w; } set { w = value; } }

        private object ShallowCopy()
        {
            return this.MemberwiseClone();
        }

        private object DeepCopy()
        {
            SquareShape cloned = this.MemberwiseClone() as SquareShape;
            return cloned;
        }

        public object Clone()
        {
            return DeepCopy();
        }
    }
}
