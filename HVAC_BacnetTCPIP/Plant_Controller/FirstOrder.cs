using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public class FirstOrder
    {
        private float a, b;
        private float yk1;
        public FirstOrder(float T, float K, float Ts)
        {
        
            a = (float)Math.Exp(-Ts / T);  // a = e^(-Ts/T)
            b = K * (1 - a);         // b = K*(1 - a)

            yk1 = 0; 
        }

        public float Update(float uk)
        {
            float yk = a * yk1 + b * uk; 
            yk1 = yk;
            return yk;
        }
    }
}
