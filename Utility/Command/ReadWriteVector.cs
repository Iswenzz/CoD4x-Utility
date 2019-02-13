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
        /// <param name="array">address + offset + offset + offset</param>
        /// <param name="var">result</param>
        public static void command_vector_rw(uint[] array, bool[] var)
        {
            Process process = Process.GetProcessesByName("iw3mp").ToList().FirstOrDefault();

            uint Base_Address_0 = array[0];
            uint Offset_0 = array[1];
            uint Value_0 = Convert.ToUInt32(var[0]);
            uint Base_Address_1 = array[0];
            uint Offset_1 = array[2];
            uint Value_1 = Convert.ToUInt32(var[1]);
            uint Base_Address_2 = array[0];
            uint Offset_2 = array[3];
            uint Value_2 = Convert.ToUInt32(var[2]);

            if (process != null)
            {
                mreader.ReadProcess = process;
                mreader.OpenProcess();

                uint Address_0 = BitConverter.ToUInt32(mreader.ReadMemory((IntPtr)Base_Address_0, sizeof(uint), out NULL), 0);
                uint Target_0 = Address_0 + Offset_0;
                mreader.WriteMemory((IntPtr)Target_0, BitConverter.GetBytes(Value_0), out NULL);
                uint Address_1 = BitConverter.ToUInt32(mreader.ReadMemory((IntPtr)Base_Address_1, sizeof(uint), out NULL), 0);
                uint Target_1 = Address_1 + Offset_1;
                mreader.WriteMemory((IntPtr)Target_1, BitConverter.GetBytes(Value_1), out NULL);
                uint Address_2 = BitConverter.ToUInt32(mreader.ReadMemory((IntPtr)Base_Address_2, sizeof(uint), out NULL), 0);
                uint Target_2 = Address_2 + Offset_2;
                mreader.WriteMemory((IntPtr)Target_2, BitConverter.GetBytes(Value_2), out NULL);
            }
        }

        /// <summary>
        /// Reads a pointer at the address location and Write to the pointing location.
        /// </summary>
        /// <param name="array">address + offset + offset + offset</param>
        /// <param name="var">result</param>
        public static void command_vector_rw(uint[] array, float[] var)
        {
            Process process = Process.GetProcessesByName("iw3mp").ToList().FirstOrDefault();

            uint Base_Address_0 = array[0];
            uint Offset_0 = array[1];
            float Value_0 = var[0];
            uint Base_Address_1 = array[0];
            uint Offset_1 = array[2];
            float Value_1 = var[1];
            uint Base_Address_2 = array[0];
            uint Offset_2 = array[3];
            float Value_2 = var[2];

            if (process != null)
            {
                mreader.ReadProcess = process;
                mreader.OpenProcess();

                uint Address_0 = BitConverter.ToUInt32(mreader.ReadMemory((IntPtr)Base_Address_0, sizeof(uint), out NULL), 0);
                uint Target_0 = Address_0 + Offset_0;
                mreader.WriteMemory((IntPtr)Target_0, BitConverter.GetBytes(Value_0), out NULL);
                uint Address_1 = BitConverter.ToUInt32(mreader.ReadMemory((IntPtr)Base_Address_1, sizeof(uint), out NULL), 0);
                uint Target_1 = Address_1 + Offset_1;
                mreader.WriteMemory((IntPtr)Target_1, BitConverter.GetBytes(Value_1), out NULL);
                uint Address_2 = BitConverter.ToUInt32(mreader.ReadMemory((IntPtr)Base_Address_2, sizeof(uint), out NULL), 0);
                uint Target_2 = Address_2 + Offset_2;
                mreader.WriteMemory((IntPtr)Target_2, BitConverter.GetBytes(Value_2), out NULL);
            }
        }

        /// <summary>
        /// Reads a pointer at the address location and Write to the pointing location.
        /// </summary>
        /// <param name="array">address + offset + offset + offset</param>
        /// <param name="var">result</param>
        public static void command_vector_rw(uint[] array, int[] var)
        {
            Process process = Process.GetProcessesByName("iw3mp").ToList().FirstOrDefault();

            uint Base_Address_0 = array[0];
            uint Offset_0 = array[1];
            int Value_0 = var[0];
            uint Base_Address_1 = array[0];
            uint Offset_1 = array[2];
            int Value_1 = var[1];
            uint Base_Address_2 = array[0];
            uint Offset_2 = array[3];
            int Value_2 = var[2];

            if (process != null)
            {
                mreader.ReadProcess = process;
                mreader.OpenProcess();

                uint Address_0 = BitConverter.ToUInt32(mreader.ReadMemory((IntPtr)Base_Address_0, sizeof(uint), out NULL), 0);
                uint Target_0 = Address_0 + Offset_0;
                mreader.WriteMemory((IntPtr)Target_0, BitConverter.GetBytes(Value_0), out NULL);
                uint Address_1 = BitConverter.ToUInt32(mreader.ReadMemory((IntPtr)Base_Address_1, sizeof(uint), out NULL), 0);
                uint Target_1 = Address_1 + Offset_1;
                mreader.WriteMemory((IntPtr)Target_1, BitConverter.GetBytes(Value_1), out NULL);
                uint Address_2 = BitConverter.ToUInt32(mreader.ReadMemory((IntPtr)Base_Address_2, sizeof(uint), out NULL), 0);
                uint Target_2 = Address_2 + Offset_2;
                mreader.WriteMemory((IntPtr)Target_2, BitConverter.GetBytes(Value_2), out NULL);
            }
        }
    }
}
