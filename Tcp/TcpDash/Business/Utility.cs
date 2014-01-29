using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace TcpDash.Business
{
    public static class Utility
    {
        public static DateTime GetFirst(DateTime dt)
        {
            switch (dt.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    {
                        return dt.Date;
                    }
                case DayOfWeek.Tuesday:
                    {
                        return dt.AddDays(-1).Date;
                    }
                case DayOfWeek.Wednesday:
                    {
                        return dt.AddDays(-2).Date;
                    }
                case DayOfWeek.Thursday:
                    {
                        return dt.AddDays(-3).Date;
                    }
                case DayOfWeek.Friday:
                    {
                        return dt.AddDays(-4).Date;
                    }
                case DayOfWeek.Saturday:
                    {
                        return dt.AddDays(-5).Date;
                    }
                case DayOfWeek.Sunday:
                    {
                        return dt.AddDays(-6).Date;
                    }
                default:
                    return dt;
            }
        }

        public static void ToggleExplorer()
        {
            Process[] proc = System.Diagnostics.Process.GetProcessesByName("explorer");
            if (proc.Any())
            {
                StopExplorer();
            }
            else
            {
                StartExplorer();
            }
        }
        public static void StartExplorer()
        {
            //RegistryKey ourKey = Registry.LocalMachine;
            //ourKey = ourKey.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon", true);
            //ourKey.SetValue("AutoRestartShell", 1);
            string explorer = string.Format("{0}\\{1}", Environment.GetEnvironmentVariable("WINDIR"), "explorer.exe");
            Process process = new Process();
            process.StartInfo.FileName = explorer;
            process.StartInfo.UseShellExecute = true;
            process.Start();

        }

        public static void StopExplorer()
        {
            //RegistryKey ourKey = Registry.LocalMachine;
            //ourKey = ourKey.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon", true);
            //ourKey.SetValue("AutoRestartShell", 0);
            Process[] proc = System.Diagnostics.Process.GetProcessesByName("explorer");
            if (proc.Any())
            {
                ForceKill(proc.First());
            }
            //ExitExplorer();

            //proc.Kill();
        }

        public static bool IsExplorerRunning()
        {
            Process[] proc = System.Diagnostics.Process.GetProcessesByName("explorer");
            return proc.Any();
        }

        [DllImport("user32.dll")]
        public static extern int FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        public static extern int SendMessage(int hWnd, uint Msg, int wParam, int lParam);

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool PostMessage(int hWnd, uint Msg, int wParam, int lParam);

        static void ExitExplorer()
        {
            int hwnd;
            hwnd = FindWindow("Progman", null);
            PostMessage(hwnd, /*WM_QUIT*/ 0x12, 0, 0);
            return;
        }

        public static void ForceKill(this Process process)
        {
            using (Process killer = new Process())
            {
                killer.StartInfo.FileName = "taskkill";
                killer.StartInfo.Arguments = string.Format("/f /PID {0}", process.Id);
                killer.StartInfo.CreateNoWindow = true;
                killer.StartInfo.UseShellExecute = false;
                killer.Start();
                killer.WaitForExit();
                if (killer.ExitCode != 0)
                {
                    throw new Win32Exception(killer.ExitCode);
                }
            }
        }

        #region idleDetector

        [DllImport("User32.dll")]
        private static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

        [DllImport("Kernel32.dll")]
        private static extern uint GetLastError();

        public static uint GetIdleTime()
        {
            LASTINPUTINFO lastInPut = new LASTINPUTINFO();
            lastInPut.cbSize = (uint)System.Runtime.InteropServices.Marshal.SizeOf(lastInPut);
            GetLastInputInfo(ref lastInPut);

            return ((uint)Environment.TickCount - lastInPut.dwTime);
        }
        /// <summary>
        /// Get the Last input time in ticks
        /// </summary>
        /// <returns></returns>
        public static long GetLastInputTime()
        {
            LASTINPUTINFO lastInPut = new LASTINPUTINFO();
            lastInPut.cbSize = (uint)System.Runtime.InteropServices.Marshal.SizeOf(lastInPut);
            if (!GetLastInputInfo(ref lastInPut))
            {
                throw new Exception(GetLastError().ToString());
            }
            return lastInPut.dwTime;
        }

        public static long GetLastInputTimeMinutes()
        {
            return GetLastInputTime()/10000000/60;
        }

        internal struct LASTINPUTINFO
        {
            public uint cbSize;

            public uint dwTime;
        }

        #endregion


    }
}
