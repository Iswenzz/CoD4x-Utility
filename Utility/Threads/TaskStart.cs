using System;
using System.Threading.Tasks;

namespace Iswenzz.CoD4.Utility.Threads
{
    public static class TaskStart
    {
        /// <summary>
        /// Start software tasks
        /// </summary>
        public async static void Start()
        {
            await Task.Run(() => UpdateSoftware.Init());
            await Task.Run(() => CoD4.Init());
        }
    }
}
