using System;
using System.Collections.Generic;
using System.IO.BACnet;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVAC_BacnetTCPIP.Mapping
{
    public class ValveMapping
    {
        //Control Signals
        public BacnetObjectId Mode;
        public BacnetObjectId Open;
        public BacnetObjectId Close;
        public BacnetObjectId Reset;
        public BacnetObjectId SetPosition;

        //Monitor Signals
        public BacnetObjectId Fault;
        public BacnetObjectId OpenFeedBack;
        public BacnetObjectId FlowSensor;
        public BacnetObjectId ValvePosition;

        public ValveMapping(uint BASE_BV, uint BASE_AV)
        {
            // Binary Valve (BV120 => BV239)
            Mode = new BacnetObjectId(BacnetObjectTypes.OBJECT_BINARY_VALUE, BASE_BV);
            Open = new BacnetObjectId(BacnetObjectTypes.OBJECT_BINARY_VALUE, BASE_BV + 1);
            Close = new BacnetObjectId(BacnetObjectTypes.OBJECT_BINARY_VALUE, BASE_BV + 2);
            Reset = new BacnetObjectId(BacnetObjectTypes.OBJECT_BINARY_VALUE, BASE_BV + 3);
            OpenFeedBack = new BacnetObjectId(BacnetObjectTypes.OBJECT_BINARY_VALUE, BASE_BV + 4);
            Fault = new BacnetObjectId(BacnetObjectTypes.OBJECT_BINARY_VALUE, BASE_BV + 5);
            
            // Analog Value (AV40 -> AV99)
            SetPosition = new BacnetObjectId(BacnetObjectTypes.OBJECT_ANALOG_VALUE, BASE_AV);
            FlowSensor = new BacnetObjectId(BacnetObjectTypes.OBJECT_ANALOG_VALUE, BASE_AV + 1);
            ValvePosition = new BacnetObjectId(BacnetObjectTypes.OBJECT_ANALOG_VALUE, BASE_AV + 2);
        }
    }
}
