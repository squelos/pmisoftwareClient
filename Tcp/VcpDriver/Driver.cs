using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO.Ports;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace VcpDriver
{
    public class Driver : IDisposable
    {
        public Driver()
        {
            //
            if (GetAvailablePorts().Count() != 0)
            {
                Connect();
            }

            SerialPortService.PortsChanged += SerialPortServiceOnPortsChanged;
        }

        private void SerialPortServiceOnPortsChanged(object sender, PortsChangedArgs portsChangedArgs)
        {
            if (portsChangedArgs.EventType == SerialPortService.EventType.Insertion)
            {
                //its an insertion
                Connect();
            }
            else
            {
                Clean();
                //its a removal
            }
           
        }

        


        #region privates

        private int _baudRate = 9600;
        private int _dataBits = 8;
        private StopBits _stopBits = System.IO.Ports.StopBits.One;
        private SerialPort _serialPort;
        private string _lastScannedBadge;
        private bool _connected = false;
        #endregion

        #region events

        public delegate void BadgeScannedHandler(int badgeId);
        public delegate void ConnectedStatusHandler(bool stat);
        public event BadgeScannedHandler BadgeScanned;
        public event ConnectedStatusHandler ConnectedStatusChanged;
        #endregion

        #region privateMethdos

        private void Clean()
        {
            if (_serialPort != null)
            {
                _serialPort.DataReceived -= serialPort_dataReceived;
                if (_serialPort.IsOpen)
                {
                    _serialPort.Close();
                }
                _serialPort.Dispose();
                Connected = false;
            }
        }

        private void Connect()
        {
            _serialPort = new SerialPort(GetAvailablePorts().First(), _baudRate, Parity.None, _dataBits, _stopBits);
            //_serialPort.Dispose();

            _serialPort.Open();

            _serialPort.RtsEnable = true;
            _serialPort.DtrEnable = true;

            _serialPort.DataReceived += serialPort_dataReceived;
            Connected = true;
        }
        #endregion

        private void serialPort_dataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            byte[] buffer = new byte[4];
            int bytesToRead = _serialPort.BytesToRead;
            _serialPort.Read(buffer, 0, _serialPort.BytesToRead);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < bytesToRead; i++)
            {
                sb.Append(buffer[i].ToString("X"));
            }

            int intConvert =
                int.Parse(sb.ToString(), System.Globalization.NumberStyles.HexNumber);
            if (BadgeScanned != null)
            {
                BadgeScanned(intConvert);
            }
            _lastScannedBadge = intConvert.ToString();
        }

        #region publics
        public static string[] GetAvailablePorts()
        {
            string[] ports = SerialPort.GetPortNames();
            return ports;
        }

        public bool Connected
        {
            get { return _connected; }
            set
            {
                _connected = value;
                RaiseConnectedStatusChanded(value);
            }
        }

        #endregion



        /// <summary>
        /// Raises a new event concerning the serial port connection status
        /// </summary>
        /// <param name="state"></param>
        private void RaiseConnectedStatusChanded(bool state)
        {
            if (ConnectedStatusChanged != null)
            {
                ConnectedStatusChanged(state);
            }
        }

     
        ~Driver()
        {
            Dispose(false);
        }


        protected void Dispose(bool disposing)
        {
            SerialPortService.CleanUp();
            if (_serialPort != null)
            {
                _serialPort.Dispose();
            }
        }
        public void Dispose()
        {
            Dispose(true); 
        }
    }
}
