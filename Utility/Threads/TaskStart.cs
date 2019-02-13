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
            await Task.Delay(500); // HandleCreated
            await Task.Run(new Action(UpdateSoftware.Init));
            await Task.Run(new Action(CoD4.Init));
        }
    }
}
