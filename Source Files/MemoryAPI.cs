using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace MemoryApi
{
    class ProcessMemoryReaderApi
    {
        [Flags]
        public enum ProcessAccessType
        {
            PROCESS_TERMINATE = (0x0001),
            PROCESS_CREATE_THREAD = (0x0002),
            PROCESS_SET_SESSIONID = (0x0004),
            PROCESS_VM_OPERATION = (0x0008),
            PROCESS_VM_READ = (0x0010),
            PROCESS_VM_WRITE = (0x0020),
            PROCESS_DUP_HANDLE = (0x0040),
            PROCESS_CREATE_PROCESS = (0x0080),
            PROCESS_SET_QUOTA = (0x0100),
            PROCESS_SET_INFORMATION = (0x0200),
            PROCESS_QUERY_INFORMATION = (0x0400),
            PROCESS_QUERY_LIMITED_INFORMATION = (0x1000)
        }

        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(
            UInt32 dwDesiredAccess,
            Int32 bInheritHandle,
            UInt32 dwProcessId
        );

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern Int32 WriteProcessMemory(
            IntPtr hProcess,
            IntPtr lpBaseAddress,
            [In, Out] byte[] lpBuffer,
            UInt32 dwSize,
            out IntPtr lpNumberOfBytesWritten
        );

        [DllImport("kernel32.dll")]
        public static extern Int32 ReadProcessMemory(
            IntPtr hProcess,
            IntPtr lpBaseAddress,
            [In, Out] byte[] lpBuffer,
            UInt32 dwSize,
            out IntPtr lpNumberOfBytesRead
        );
    }

    public class ProcessMemoryReader
    {
        public Process ReadProcess { get; set; }
        private IntPtr handle;

        public void OpenProcess()
        {
            ProcessMemoryReaderApi.ProcessAccessType access = ProcessMemoryReaderApi.ProcessAccessType.PROCESS_QUERY_INFORMATION |
                ProcessMemoryReaderApi.ProcessAccessType.PROCESS_VM_READ |
                ProcessMemoryReaderApi.ProcessAccessType.PROCESS_VM_WRITE |
                ProcessMemoryReaderApi.ProcessAccessType.PROCESS_VM_OPERATION;

            handle = ProcessMemoryReaderApi.OpenProcess((uint)access, 1, (uint)ReadProcess.Id);
        }

        public byte[] ReadMemory(IntPtr memoryAddress, uint bytesToRead, out int bytesRead)
        {
            byte[] buffer = new byte[bytesToRead];
            IntPtr pBytesRead = IntPtr.Zero;
            ProcessMemoryReaderApi.ReadProcessMemory(handle, memoryAddress, buffer, bytesToRead, out pBytesRead);
            bytesRead = pBytesRead.ToInt32();
            return buffer;
        }

        public void WriteMemory(IntPtr memoryAddress, byte[] buffer, out int bytesWritten)
        {
            IntPtr pBytesWritten = IntPtr.Zero;
            ProcessMemoryReaderApi.WriteProcessMemory(handle, memoryAddress, buffer, (uint)buffer.Length, out pBytesWritten);
            bytesWritten = pBytesWritten.ToInt32();
        }
    }
}