using System;
using System.Collections.Generic;
using System.IO.BACnet;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace HVAC_BacnetTCPIP.Mapping
{
    public class MotorMapping
    {
        public BacnetObjectId Mode;
        public BacnetObjectId Start;
        public BacnetObjectId Stop;
        public BacnetObjectId Reset;
        public BacnetObjectId RunFeedBack;
        public BacnetObjectId Fault;
        public BacnetObjectId Speed;   // Analog value
        public BacnetObjectId SetSpeed;
        public BacnetObjectId Runtime;  // DateTime value

        public MotorMapping(uint BASE_BV, uint BASE_AV, uint BASE_DTV)
        {
            // Binary Valve (BV0 => BV119)
            Mode = new BacnetObjectId(BacnetObjectTypes.OBJECT_BINARY_VALUE, BASE_BV);
            Start = new BacnetObjectId(BacnetObjectTypes.OBJECT_BINARY_VALUE, BASE_BV + 1);
            Stop = new BacnetObjectId(BacnetObjectTypes.OBJECT_BINARY_VALUE, BASE_BV + 2);
            Reset = new BacnetObjectId(BacnetObjectTypes.OBJECT_BINARY_VALUE, BASE_BV + 3);
            RunFeedBack = new BacnetObjectId(BacnetObjectTypes.OBJECT_BINARY_VALUE, BASE_BV + 4);
            Fault = new BacnetObjectId(BacnetObjectTypes.OBJECT_BINARY_VALUE, BASE_BV + 5);
            
            // Analog Value (AV0 -> AV39)
            Speed = new BacnetObjectId(BacnetObjectTypes.OBJECT_ANALOG_VALUE, BASE_AV);
            SetSpeed = new BacnetObjectId(BacnetObjectTypes.OBJECT_ANALOG_VALUE, BASE_AV + 1);

            //Date Time Value (DTV0 - DTV19)
            Runtime = new BacnetObjectId(BacnetObjectTypes.OBJECT_DATETIME_VALUE, BASE_DTV);
        }
    }
}
