using System;
using System.Diagnostics;
using System.Linq;

namespace Iswenzz.CoD4.Utility.Command
{
    public static partial class CMD
    {
        /// <summary>
        /// Write to the address location.
        /// </summary>
        /// <param name="array">address + offset</param>
        /// <param name="var">result</param>
        public static void Write(uint[] array, bool var)
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

                mreader.WriteMemory((IntPtr)Target, BitConverter.GetBytes(Value), out NULL);
            }
        }

        /// <summary>
        /// Write to the address location.
        /// </summary>
        /// <param name="array">address + offset</param>
        /// <param name="var">result</param>
        public static void Write(uint[] array, float var)
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

                mreader.WriteMemory((IntPtr)Target, BitConverter.GetBytes(Value), out NULL);
            }
        }

        /// <summary>
        /// Write to the address location.
        /// </summary>
        /// <param name="array">address + offset</param>
        /// <param name="var">result</param>
        public static void Write(uint[] array, int var)
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

                mreader.WriteMemory((IntPtr)Target, BitConverter.GetBytes(Value), out NULL);
            }
        }
    }
}
