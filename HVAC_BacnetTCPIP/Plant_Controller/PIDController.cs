using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVAC_BacnetTCPIP.Classes
{
    public class PIDController
    {
        public float Kp, Ki, Kd;
        private float integral, lastError;
        public PIDController(float kp, float ki, float kd)
        {
            this.Kp = kp;
            this.Ki = ki;
            this.Kd = kd;
            integral = 0.0f;
            lastError = 0.0f;
        }

        public float Output(float setpoint, float presentValue, float dt)
        {
            float error = setpoint - presentValue;
            integral += error * dt;
            float derivative = (error - lastError) / dt;
            float output = Kp * error + Ki * integral + Kd * derivative;

            lastError = error;
            return output;
        }
    }
}
