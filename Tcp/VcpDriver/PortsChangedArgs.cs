using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VcpDriver
{
    public class PortsChangedArgs : EventArgs
    {
        private readonly SerialPortService.EventType _eventType;

        private readonly string[] _serialPorts;

        public PortsChangedArgs(SerialPortService.EventType eventType, string[] serialPorts)
        {
            _eventType = eventType;
            _serialPorts = serialPorts;
        }

        public string[] SerialPorts
        {
            get
            {
                return _serialPorts;
            }
        }

        public SerialPortService.EventType EventType
        {
            get
            {
                return _eventType;
            }
        }
    }
}
