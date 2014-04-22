using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swp_u2.ShapePrototypes
{
    class RectangleShape : ICloneable
    {
        double h;
        double w;

        public double height { get { return h; } set { h = value; } }
        public double width { get { return w; } set { w = value; } }

        private object ShallowCopy()
        {
            return this.MemberwiseClone();
        }

        private object DeepCopy()
        {
            RectangleShape cloned = this.MemberwiseClone() as RectangleShape;
            return cloned;
        }

        public object Clone()
        {
            return DeepCopy();
        }
    }
}
