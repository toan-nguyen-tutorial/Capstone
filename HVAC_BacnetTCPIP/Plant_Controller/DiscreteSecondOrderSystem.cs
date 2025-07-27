using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVAC_BacnetTCPIP.Plant_Controller
{
    public class DiscreteSecondOrderSystem
    {
        private float[] b = new float[3];
        private float[] a = new float[3];
        private float[] u = new float[3]; // input history
        private float[] y = new float[3]; // output history

        public DiscreteSecondOrderSystem(float[] bCoeffs, float[] aCoeffs)
        {
            for (int i = 0; i < 3; i++)
            {
                b[i] = bCoeffs[i];
                a[i] = aCoeffs[i];
            }
        }

        public float Update(float uk)
        {
            // Shift input history
            u[2] = u[1];
            u[1] = u[0];
            u[0] = uk;

            // Shift output history
            y[2] = y[1];
            y[1] = y[0];

            // Difference equation
            y[0] = b[0] * u[0] + b[1] * u[1] + b[2] * u[2]
                 - a[1] * y[1] - a[2] * y[2];

            return y[0];
        }
    }

}
