using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;

namespace VcpDriver
{
    public class Driver : IDisposable
    {
        public Driver()
        {
            if (GetAvailablePorts().Count() != 0)
            {
                //TODO foreach we connect
                Connect();
            }
            SerialPortService.PortsChanged += SerialPortServiceOnPortsChanged;
        }

        private void SerialPortServiceOnPortsChanged(object sender, PortsChangedArgs portsChangedArgs)
        {
            if (portsChangedArgs.EventType == SerialPortService.EventType.Insertion)
            {
                //its an insertion
                // we should try to connect
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
        private List<SerialPort> _serialsPorts = new List<SerialPort>(); 
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
            foreach (var availablePort in GetAvailablePorts())
            {
                if (_serialsPorts.Any(port => port.PortName == availablePort))
                {
                    //then we already have it
                }
                else
                {
                    // we want to connect to it
                    SerialPort port = new SerialPort(availablePort, _baudRate, Parity.None, _dataBits, _stopBits);
                    try
                    {
                        port.Open();

                        port.RtsEnable = true;
                        port.DtrEnable = true;
                        port.DataReceived += serialPort_dataReceived;
                        _serialsPorts.Add(port);
                    }
                    catch (Exception ex )
                    {
                        Console.Out.WriteLine(ex);
                    }
                }
            }
            Connected = _serialsPorts.Any();
        }
        #endregion

        private void serialPort_dataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            //sender is a serialPort
            SerialPort callerPort = sender as SerialPort;
            
            byte[] buffer = new byte[4];

            int bytesToRead = callerPort.BytesToRead;
            callerPort.Read(buffer, 0, callerPort.BytesToRead);
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
            foreach (var serialsPort in _serialsPorts)
            {
                serialsPort.Dispose();
            }
        }
        public void Dispose()
        {
            Dispose(true); 
        }
    }
}
