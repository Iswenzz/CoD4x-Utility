using System;
using System.Diagnostics;
using System.Linq;

namespace Iswenzz.CoD4.Utility.Command
{
    public static partial class CMD
    {
        /// <summary>
        /// Reads a pointer at the address location and Write to the pointing location.
        /// </summary>
        /// <param name="array">address + offset</param>
        /// <param name="var">result</param>
        public static void ReadWrite(uint[] array, bool var)
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

                mreader.WriteMemory((IntPtr)Target, BitConverter.GetBytes(Value), out NULL);
            }
        }

        /// <summary>
        /// Reads a pointer at the address location and Write to the pointing location.
        /// </summary>
        /// <param name="array">address + offset</param>
        /// <param name="var">result</param>
        public static void ReadWrite(uint[] array, float var)
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

                mreader.WriteMemory((IntPtr)Target, BitConverter.GetBytes(Value), out NULL);
            }
        }

        /// <summary>
        /// Reads a pointer at the address location and Write to the pointing location.
        /// </summary>
        /// <param name="array">address + offset</param>
        /// <param name="var">result</param>
        public static void ReadWrite(uint[] array, int var)
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

                mreader.WriteMemory((IntPtr)Target, BitConverter.GetBytes(Value), out NULL);
            }
        }
    }
}
