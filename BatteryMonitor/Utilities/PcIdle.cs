using System;
using System.Runtime.InteropServices;

namespace BatteryMonitor.Utilities
{
    internal struct LastInputInfo
    {
        public uint CbSize;

        public uint DwTime;
    }

    public class PcIdle
    {
        public uint MaxIdleTime { get; private set; } = 5;

        [DllImport("User32.dll")]
        private static extern bool GetLastInputInfo(ref LastInputInfo lastInputInfo);

        public uint GetIdleTime()
        {
            // ReSharper disable once SuggestVarOrType_SimpleTypes
            LastInputInfo lastInputInfo = new LastInputInfo();
            lastInputInfo.CbSize = (uint)Marshal.SizeOf(lastInputInfo);
            GetLastInputInfo(ref lastInputInfo);

            return ((uint)Environment.TickCount - lastInputInfo.DwTime);
        }

        public uint GetIdleTimeMin()
        {
            var time = GetIdleTime() / 1000;
            var idleTime = time == 0 ? 0 : time / 60;
            return idleTime;
        }

        public void ChangeMaxIdleTime(uint maxIdleTime) => MaxIdleTime = maxIdleTime;
    }
}