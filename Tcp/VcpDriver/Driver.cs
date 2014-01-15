using System;
using System.Collections.Generic;
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

        #region singleton
        private static readonly Lazy<Driver> lazy =
        new Lazy<Driver>(() => new Driver());

        public static Driver Instance { get { return lazy.Value; } }

        private Driver()
        {
            _serialPort = new SerialPort(GetAvailablePorts().First(), _baudRate, Parity.None, _dataBits, _stopBits);

            if (_serialPort.IsOpen)
            {
                _serialPort.Close();
            }
                _serialPort.Open();

                _serialPort.RtsEnable = true;
                _serialPort.DtrEnable = true;

                _serialPort.DataReceived += serialPort_dataReceived;
            
            

        }
        #endregion


        #region privates

        private int _baudRate = 9600;
        private int _dataBits = 8;
        private StopBits _stopBits = System.IO.Ports.StopBits.One;
        private SerialPort _serialPort;
        private string _lastScannedBadge;
        #endregion

        #region events

        public delegate void BadgeScannedHandler(int badgeId);

        public event BadgeScannedHandler BadgeScanned;
        #endregion

        #region privateMethdos

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

      



        #endregion

        public void Dispose()
        {
            if (_serialPort.IsOpen)
            {
                _serialPort.Close();
            }
        }

        void IDisposable.Dispose()
        {
            Dispose();
        }

        ~Driver()
        {
            if (_serialPort.IsOpen)
            {
                _serialPort.Close();
            }
            _serialPort.Dispose();
        }
    }
}
