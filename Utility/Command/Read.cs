using System;
using System.Diagnostics;
using System.Linq;

namespace Iswenzz.CoD4.Utility.Command
{
    public static partial class CMD
    {
        private static ProcessMemoryReader mreader = new ProcessMemoryReader();
        private static int NULL = 0;

        /// <summary>
        /// Read to the address location.
        /// </summary>
        /// <param name="array">address + offset</param>
        /// <param name="var">result</param>
        public static bool Read(uint[] array, bool var)
        {
            Process process = Process.GetProcessesByName("iw3mp").ToList().FirstOrDefault();

            uint Base_Address = array[0];
            uint Offset = array[1];
            uint Value = Convert.ToUInt32(var);

            if (process != null)
            {
                mreader.ReadProcess = process;
                mreader.OpenProcess();

                uint Target = Base_Address + Offset;

                uint val = BitConverter.ToUInt32(mreader.ReadMemory((IntPtr)Target, sizeof(uint), out NULL), 0);
                bool ret = Convert.ToBoolean(val);

                return ret;
            }

            return false;
        }

        /// <summary>
        /// Read to the address location.
        /// </summary>
        /// <param name="array">address + offset</param>
        /// <param name="var">result</param>
        public static float Read(uint[] array, float var)
        {
            Process process = Process.GetProcessesByName("iw3mp").ToList().FirstOrDefault();

            uint Base_Address = array[0];
            uint Offset = array[1];
            float Value = var;

            if (process != null)
            {
                mreader.ReadProcess = process;
                mreader.OpenProcess();

                uint Target = Base_Address + Offset;

                float val = BitConverter.ToSingle(mreader.ReadMemory((IntPtr)Target, sizeof(uint), out NULL), 0);

                return val;
            }

            return 0;
        }

        /// <summary>
        /// Read to the address location.
        /// </summary>
        /// <param name="array">address + offset</param>
        /// <param name="var">result</param>
        public static int Read(uint[] array, int var)
        {
            Process process = Process.GetProcessesByName("iw3mp").ToList().FirstOrDefault();

            uint Base_Address = array[0];
            uint Offset = array[1];
            int Value = var;

            if (process != null)
            {
                mreader.ReadProcess = process;
                mreader.OpenProcess();

                uint Target = Base_Address + Offset;

                int val = BitConverter.ToInt32(mreader.ReadMemory((IntPtr)Target, sizeof(uint), out NULL), 0);

                return val;
            }

            return 0x0;
        }
    }
}
