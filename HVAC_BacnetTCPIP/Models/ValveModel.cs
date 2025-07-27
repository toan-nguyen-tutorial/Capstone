using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HVAC_BacnetTCPIP.Plant_Controller;
using Main;

namespace HVAC_BacnetTCPIP.Classes
{
    public class ValveModel
    {

        //Mode 
        public bool Mode;

        // Control Signals
        public bool Open;
        public bool Close;
        public bool Reset;
        public float SetPosition ; // 0 - 100 percent Convert to ( 0 - 4.438 ) voltage
        public float preSetPosition;
        public bool CMD;


        // Monitor Signals
        public bool Fault;
        public bool OpenFeedBack;   
        public float uk;            // PID control signal
        public float yValve;        // Flow Rate (cm^3/min)
        public float yFlowSensor;   // Flow Rate Sensor (Voltage)
        public float valvePosition;


        //Simulate Fault
        public bool simFault;

        //Transfer Functions (discrete-time is 0.1 seconds)
        public FirstOrderPlusDeadTime G_Valve = new FirstOrderPlusDeadTime(3.152f, 2.89f, 0.1f, 0.6f);
        public PIDController G_PID = new PIDController(1.375f, 1.375f / 2, 0);
        public FirstOrder G_FlowSensor = new FirstOrder(0.316f, 0.317f, 0.1f);
    }
}
