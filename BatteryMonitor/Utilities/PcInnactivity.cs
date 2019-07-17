using System;
using System.Runtime.InteropServices;

namespace BatteryMonitor.Utilities
{
    internal struct Lastinputinfo
    {
        public uint CbSize;

        public uint DwTime;
    }

    public class PcInnactivity
    {
        public uint MaxIdleTime { get; private set; } = 5;

        [DllImport("User32.dll")]
        private static extern bool GetLastInputInfo(ref Lastinputinfo plii);

        public static uint GetIdleTime()
        {
            Lastinputinfo lastInPut = new Lastinputinfo();
            lastInPut.CbSize = (uint)Marshal.SizeOf(lastInPut);
            GetLastInputInfo(ref lastInPut);

            return ((uint)Environment.TickCount - lastInPut.DwTime);
        }

        public static uint GetIdleTimeMin()
        {
            var time = GetIdleTime() / 1000;
            var idleTime = time == 0 ? 0 : time / 60;
            return idleTime;
        }

        public void ChangeMaxIdleTime(uint maxIdleTime) => MaxIdleTime = maxIdleTime;

        internal void ChangeMaxIdleTime(object idleTime)
        {
            throw new NotImplementedException();
        }
    }
}