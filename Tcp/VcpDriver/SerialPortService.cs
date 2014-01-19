using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Diagnostics.Contracts;


namespace VcpDriver
{
    public static class SerialPortService
    {

        public enum EventType
        {
            Insertion,
            Removal,
        }

        private static string[] _serialPorts;
        private static ManagementEventWatcher arrival;
        private static ManagementEventWatcher removal;

        static SerialPortService()
        {
            _serialPorts = GetAvailableSerialPorts();
            MonitorDeviceChanges();
        }

        /// <summary>
        /// If this method isn't called, an InvalidComObjectException will be thrown (like below):
        /// System.Runtime.InteropServices.InvalidComObjectException was unhandled
        ///Message=COM object that has been separated from its underlying RCW cannot be used.
        ///Source=mscorlib
        ///StackTrace:
        ///     at System.StubHelpers.StubHelpers.StubRegisterRCW(Object pThis, IntPtr pThread)
        ///     at System.Management.IWbemServices.CancelAsyncCall_(IWbemObjectSink pSink)
        ///     at System.Management.SinkForEventQuery.Cancel()
        ///     at System.Management.ManagementEventWatcher.Stop()
        ///     at System.Management.ManagementEventWatcher.Finalize()
        ///InnerException: 
        /// </summary>
        public static void CleanUp()
        {
            try
            {
                arrival.Stop();
                removal.Stop();
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine(ex);   
            }
            
        }

        public static event EventHandler<PortsChangedArgs> PortsChanged;

        private static void MonitorDeviceChanges()
        {
            try
            {
                var deviceArrivalQuery = new WqlEventQuery("SELECT * FROM Win32_DeviceChangeEvent WHERE EventType = 2");
                var deviceRemovalQuery = new WqlEventQuery("SELECT * FROM Win32_DeviceChangeEvent WHERE EventType = 3");

                arrival = new ManagementEventWatcher(deviceArrivalQuery);
                removal = new ManagementEventWatcher(deviceRemovalQuery);

                arrival.EventArrived += (o, args) => RaisePortsChangedIfNecessary(EventType.Insertion);
                removal.EventArrived += (sender, eventArgs) => RaisePortsChangedIfNecessary(EventType.Removal);

                // Start listening for events
                arrival.Start();
                removal.Start();
            }
            catch (ManagementException err)
            {
                Console.Out.WriteLine(err);
            }
        }

        private static void RaisePortsChangedIfNecessary(EventType eventType)
        {
            lock (_serialPorts)
            {
                var availableSerialPorts = GetAvailableSerialPorts();
                if (!_serialPorts.SequenceEqual(availableSerialPorts))
                {
                    _serialPorts = availableSerialPorts;
                    RaisePortsChanged(null,new PortsChangedArgs(eventType, _serialPorts));
                }
            }
        }

        private static void RaisePortsChanged(Object obj, PortsChangedArgs args)
        {
            if (PortsChanged != null)
            {
                PortsChanged(obj, args);
            }
        }

        public static string[] GetAvailableSerialPorts()
        {
            return SerialPort.GetPortNames();
        }
    }
}
