using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Projections
{
    class CentralProjection : Projection
    {
        public CentralProjection(float Z = 10)
        {
            this.Z = Z;
        }
        float Z;

        public float getZ()
        {
            return Z;
        }
    }
}
