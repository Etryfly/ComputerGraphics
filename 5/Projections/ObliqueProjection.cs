using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Projections
{
    class ObliqueProjection : Projection
    {
        private float Alpha, L;

        public ObliqueProjection(float Alpha, float L)
        {
            this.Alpha = Alpha;
            this.L = L;
        }

        public float getAlpha()
        {
            return Alpha;
        }

        public float getL()
        {
            return L;
        }
    }
}
