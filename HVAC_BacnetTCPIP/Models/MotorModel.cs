using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HVAC_BacnetTCPIP.Classes;
using HVAC_BacnetTCPIP.Plant_Controller;

namespace HVAC_BacnetTCPIP.Models
{
    public class MotorModel
    {
        public bool Mode;
        // Input
        public bool Start;
        public bool Stop;
        public bool Reset;
        public bool Fault;
        public float setSpeed;
        public bool simFault;

        // Output
        public bool CMD;
        public bool RunFeedBack;
        public int Runtime;
        public float Speed;
        public float uk;

        //Plant and Controller
        
        //dt = 0.001s
        public DiscreteSecondOrderSystem plant = new DiscreteSecondOrderSystem(
         new float[] { 0.000000497015419918313f, 0.000000994030839836627f, 0.000000497015419918313f },
         new float[] {1.0f , -1.988051729424547f, 0.988071629921961f }
         );
        public PIDController pid = new PIDController(4.2090f, 1.2012f, 0.2539f);
    }
}
