using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HVAC_BacnetTCPIP.Classes;
using HVAC_BacnetTCPIP.Plant_Controller;
using Main;

namespace HVAC_BacnetTCPIP.Models
{
    public class ChillerModel
    {
        // Input

        public float setpoint_PID1; // 0 - 5 voltage
        public float setpoint_PID2;
        public bool Start;
        public bool Stop;
        public bool Reset;
        public bool CMD;
        public bool Fault;

        // Output

        public bool S1, S2, S3, S4, S5;
        public float uk_1_PID1;
        public float uk_2_PID1;
        public float yFlowRateSensor_PID1;
        public float yValve_PID1;
        public float yHeatExchanger_PID1;
        public float yTemperatureSensor_PID1;

        public float uk_1_PID2;
        public float uk_2_PID2;
        public float yFlowRateSensor_PID2;
        public float yValve_PID2;
        public float yHeatExchanger_PID2;
        public float yTemperatureSensor_PID2;



        // Controller 1
            // Outer Loop (Primary controller)
            public FirstOrderPlusDeadTime heatExchanger_PID1 = new FirstOrderPlusDeadTime(1.44f, 90.77f, 0.1f, 26.53f);
            public PIDController primary_controller_1_PID1 = new PIDController(2.85f, 2.85f / 53.08f, 2.85f * 13.265f);
            public FirstOrder temperatureSensor_PID1= new FirstOrder(4.1f, 0.05f, 0.1f);

            // Inter Loop (Secondary controller)
            public FirstOrderPlusDeadTime valve_1_PID1 = new FirstOrderPlusDeadTime(3.152f, 2.89f, 0.1f, 0.6f);
            public PIDController secondary_controller_1_PID1 = new PIDController(1.834f, 1.2f, 0.0f);
            public FirstOrder flowSensor_1_PID1 = new FirstOrder(0.316f, 0.317f, 0.1f);

        // Controller 2 
            // Outer Loop (Primary controller)
            public FirstOrderPlusDeadTime heatExchanger_PID2 = new FirstOrderPlusDeadTime(1.44f, 90.77f, 0.1f, 26.53f);
            public PIDController primary_controller_1_PID2 = new PIDController(2.85f, 2.85f / 53.08f, 2.85f * 13.265f);
            public FirstOrder temperatureSensor_PID2 = new FirstOrder(4.1f, 0.05f, 0.1f);

            // Inter Loop (Secondary controller)
            public FirstOrderPlusDeadTime valve_1_PID2 = new FirstOrderPlusDeadTime(3.152f, 2.89f, 0.1f, 0.6f);
            public PIDController secondary_controller_1_PID2 = new PIDController(1.834f, 1.2f, 0.0f);
            public FirstOrder flowSensor_1_PID2 = new FirstOrder(0.316f, 0.317f, 0.1f);

    }
}
