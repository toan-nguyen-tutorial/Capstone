using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVAC_BacnetTCPIP.Plant_Controller
{
    public class Plant2nd
    {
        public float a1, a2, b1, b2;
        private float uk1, uk2, yk1, yk2;
        public Plant2nd(float a1, float a2, float b1, float b2)
        {
            this.a1 = a1;
            this.a2 = a2;
            this.b1 = b1;
            this.b2 = b2;
        }
        public float Feedback(float uk)
        {
            float yk = -b1 * yk1 - b2 * yk2 + a1 * uk1 + a2 * uk2;
            uk2 = uk1;
            uk1 = uk;
            yk2 = yk1;
            yk1 = yk;
            return yk;
        }
    }
}
