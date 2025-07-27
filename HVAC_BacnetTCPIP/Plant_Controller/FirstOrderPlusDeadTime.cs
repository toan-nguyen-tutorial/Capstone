using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVAC_BacnetTCPIP.Plant_Controller
{
    public class FirstOrderPlusDeadTime
    {
        //Discrete-time and system again
        private float a, b, K;

        private float yk1;

        //Buffer to implement the time delay
        private Queue<float> uBuffer;

        //Time delays in discrete steps
        private int delaySteps;

        public FirstOrderPlusDeadTime(float K, float T, float dt, float timeDelay)
        {

            this.K = K;

            //Calc coefficients for discrete-time approximation
            a = T / (T + dt);
            b = dt / (T + dt);

            //Calc delay in discrete steps
            delaySteps = (int)(timeDelay / dt);
            if (delaySteps < 0) delaySteps = 0;

            // Initialize the delay buffer with zeros
            uBuffer = new Queue<float>(delaySteps + 1);
            for (int i = 0; i < delaySteps; i++)
            {
                uBuffer.Enqueue(0);
            }

            yk1 = 0;
        }

        public float Update(float uk)
        {
            // Add the current input to the buffer
            uBuffer.Enqueue(uk);

            // Remove the oldest input to simulate delay
            float uk_delayed = uBuffer.Dequeue();

            // Calculate current output using the discrete-time equation
            float yk = a * yk1 + b * K * uk_delayed;

            // Store current output as previous output for next update
            yk1 = yk;

            // Return the current output
            return yk;
        }
    }
}
