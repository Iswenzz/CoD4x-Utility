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
        /// <param name="array">address + offset + offset + offset</param>
        /// <param name="var">result</param>
        public static bool[] VectorReadRead(this bool[] var, uint[] array)
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

            bool[] ret = new bool[3];

            if (process != null)
            {
                mreader.ReadProcess = process;
                mreader.OpenProcess();

                uint Address_0 = BitConverter.ToUInt32(mreader.ReadMemory((IntPtr)Base_Address_0, sizeof(uint), out NULL), 0);
                uint Target_0 = Address_0 + Offset_0;
                uint val_0 = BitConverter.ToUInt32(mreader.ReadMemory((IntPtr)Target_0, sizeof(uint), out NULL), 0);
                ret[0] = Convert.ToBoolean(val_0);

                uint Address_1 = BitConverter.ToUInt32(mreader.ReadMemory((IntPtr)Base_Address_1, sizeof(uint), out NULL), 0);
                uint Target_1 = Address_1 + Offset_1;
                uint val_1 = BitConverter.ToUInt32(mreader.ReadMemory((IntPtr)Target_1, sizeof(uint), out NULL), 0);
                ret[1] = Convert.ToBoolean(val_1);

                uint Address_2 = BitConverter.ToUInt32(mreader.ReadMemory((IntPtr)Base_Address_2, sizeof(uint), out NULL), 0);
                uint Target_2 = Address_2 + Offset_2;
                uint val_2 = BitConverter.ToUInt32(mreader.ReadMemory((IntPtr)Target_2, sizeof(uint), out NULL), 0);
                ret[2] = Convert.ToBoolean(val_2);

                return ret;
            }

            return ret;
        }

        /// <summary>
        /// Reads a pointer at the address location and Read to the pointing location.
        /// </summary>
        /// <param name="array">address + offset + offset + offset</param>
        /// <param name="var">result</param>
        public static float[] VectorReadRead(this float[] var, uint[] array)
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

            float[] ret = new float[3];

            if (process != null)
            {
                mreader.ReadProcess = process;
                mreader.OpenProcess();

                uint Address_0 = BitConverter.ToUInt32(mreader.ReadMemory((IntPtr)Base_Address_0, sizeof(uint), out NULL), 0);
                uint Target_0 = Address_0 + Offset_0;
                float val_0 = BitConverter.ToSingle(mreader.ReadMemory((IntPtr)Target_0, sizeof(uint), out NULL), 0);
                ret[0] = val_0;

                uint Address_1 = BitConverter.ToUInt32(mreader.ReadMemory((IntPtr)Base_Address_1, sizeof(uint), out NULL), 0);
                uint Target_1 = Address_1 + Offset_1;
                float val_1 = BitConverter.ToSingle(mreader.ReadMemory((IntPtr)Target_1, sizeof(uint), out NULL), 0);
                ret[1] = val_1;

                uint Address_2 = BitConverter.ToUInt32(mreader.ReadMemory((IntPtr)Base_Address_2, sizeof(uint), out NULL), 0);
                uint Target_2 = Address_2 + Offset_2;
                float val_2 = BitConverter.ToSingle(mreader.ReadMemory((IntPtr)Target_2, sizeof(uint), out NULL), 0);
                ret[2] = val_2;

                return ret;
            }

            return ret;
        }

        /// <summary>
        /// Reads a pointer at the address location and Read to the pointing location.
        /// </summary>
        /// <param name="array">address + offset + offset + offset</param>
        /// <param name="var">result</param>
        public static int[] VectorReadRead(this int[] var, uint[] array)
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

            int[] ret = new int[3];

            if (process != null)
            {
                mreader.ReadProcess = process;
                mreader.OpenProcess();

                uint Address_0 = BitConverter.ToUInt32(mreader.ReadMemory((IntPtr)Base_Address_0, sizeof(uint), out NULL), 0);
                uint Target_0 = Address_0 + Offset_0;
                int val_0 = BitConverter.ToInt32(mreader.ReadMemory((IntPtr)Target_0, sizeof(uint), out NULL), 0);
                ret[0] = val_0;

                uint Address_1 = BitConverter.ToUInt32(mreader.ReadMemory((IntPtr)Base_Address_1, sizeof(uint), out NULL), 0);
                uint Target_1 = Address_1 + Offset_1;
                int val_1 = BitConverter.ToInt32(mreader.ReadMemory((IntPtr)Target_1, sizeof(uint), out NULL), 0);
                ret[1] = val_1;

                uint Address_2 = BitConverter.ToUInt32(mreader.ReadMemory((IntPtr)Base_Address_2, sizeof(uint), out NULL), 0);
                uint Target_2 = Address_2 + Offset_2;
                int val_2 = BitConverter.ToInt32(mreader.ReadMemory((IntPtr)Target_2, sizeof(uint), out NULL), 0);
                ret[2] = val_2;

                return ret;
            }

            return ret;
        }
    }
}
