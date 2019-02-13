using System;
using System.Diagnostics;
using System.Linq;

namespace Iswenzz.CoD4.Utility.Command
{
    public static partial class CMD
    {
        /// <summary>
        /// Reads a pointer at the address location and Read to the pointing location.
        /// </summary>
        /// <param name="array">address + offset</param>
        /// <param name="var">result</param>
        public static bool command_rr(this bool var, uint[] array)
        {
            Process process = Process.GetProcessesByName("iw3mp").ToList().FirstOrDefault();

            uint Base_Address = array[0];
            uint Offset = array[1];
            uint Value = Convert.ToUInt32(var);

            if (process != null)
            {
                mreader.ReadProcess = process;
                mreader.OpenProcess();

                uint Address = BitConverter.ToUInt32(mreader.ReadMemory((IntPtr)Base_Address, sizeof(uint), out NULL), 0);
                uint Target = Address + Offset;

                uint val = BitConverter.ToUInt32(mreader.ReadMemory((IntPtr)Target, sizeof(uint), out NULL), 0);
                bool ret = Convert.ToBoolean(val);

                return ret;
            }

            return false;
        }

        /// <summary>
        /// Reads a pointer at the address location and Read to the pointing location.
        /// </summary>
        /// <param name="array">address + offset</param>
        /// <param name="var">result</param>
        public static float command_rr(this float var, uint[] array)
        {
            Process process = Process.GetProcessesByName("iw3mp").ToList().FirstOrDefault();

            uint Base_Address = array[0];
            uint Offset = array[1];
            float Value = var;

            if (process != null)
            {
                mreader.ReadProcess = process;
                mreader.OpenProcess();

                uint Address = BitConverter.ToUInt32(mreader.ReadMemory((IntPtr)Base_Address, sizeof(uint), out NULL), 0);
                uint Target = Address + Offset;

                float val = BitConverter.ToSingle(mreader.ReadMemory((IntPtr)Target, sizeof(uint), out NULL), 0);

                return val;
            }

            return 0;
        }

        /// <summary>
        /// Reads a pointer at the address location and Read to the pointing location.
        /// </summary>
        /// <param name="array">address + offset</param>
        /// <param name="var">result</param>
        public static int command_rr(this int var, uint[] array)
        {
            Process process = Process.GetProcessesByName("iw3mp").ToList().FirstOrDefault();

            uint Base_Address = array[0];
            uint Offset = array[1];
            int Value = var;

            if (process != null)
            {
                mreader.ReadProcess = process;
                mreader.OpenProcess();

                uint Address = BitConverter.ToUInt32(mreader.ReadMemory((IntPtr)Base_Address, sizeof(uint), out NULL), 0);
                uint Target = Address + Offset;

                int val = BitConverter.ToInt32(mreader.ReadMemory((IntPtr)Target, sizeof(uint), out NULL), 0);

                return val;
            }

            return 0x0;
        }
    }
}
