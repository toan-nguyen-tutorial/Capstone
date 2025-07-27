using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HVAC_BacnetTCPIP.Classes;
using HVAC_BacnetTCPIP.Plant_Controller;

namespace HVAC_BacnetTCPIP.Models
{
    public class DamperModel
    {
        // Control Signals
        public bool Mode;
        public bool Open;
        public bool Close;
        public bool Reset;
        public float SetPosition;
        public bool Fault;

        // Monitor Signals
        public bool CMD;
        public bool OpenFeedBack;
        public float DamperPosition;
        public float uk;

        //dt = 0.001s
        public DiscreteSecondOrderSystem plant = new DiscreteSecondOrderSystem(
           new float[] { 0.0000002488f, 0.0000004975f, 0.0000002488f },
           new float[] { 1.0f, -1.9900f, 0.9900f }
        );
        public PIDController pid = new PIDController(300f, 160f, 10f);
    }
}
