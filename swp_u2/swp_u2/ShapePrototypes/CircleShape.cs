using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swp_u2.ShapePrototypes
{
    class CircleShape
    {
        double r;

        public double radius { get { return r; } set { r = value; } }

        private object ShallowCopy()
        {
            return this.MemberwiseClone();
        }

        private object DeepCopy()
        {
            CircleShape cloned = this.MemberwiseClone() as CircleShape;
            return cloned;
        }

        public object Clone()
        {
            return DeepCopy();
        }
    }
}
