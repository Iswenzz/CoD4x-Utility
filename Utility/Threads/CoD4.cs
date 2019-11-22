using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

using Iswenzz.CoD4.Utility.Profiles;

namespace Iswenzz.CoD4.Utility.Threads
{
    public static class CoD4
    {
        /// <summary>
        /// Task to check if CoD4 is running.
        /// </summary>
        public static async void Init()
        {
            bool run = false;
            while (true)
            {
                if (Process.GetProcessesByName("iw3mp").Length == 0)
                {
                    Profile.IsCoD4Running = false;
                    (Application.OpenForms[0] as Panel).HidePages(true);
                    Profile.TokenSource?.Cancel();
                    run = false;
                }
                else if (!run)
                {
                    Profile.IsCoD4Running = true;
                    (Application.OpenForms[0] as Panel).ShowDefaultPages();
                    run = true;
                    await Task.Delay(1000);
                    Profile.Start();
                }
                await Task.Delay(1000);
            }
        }
    }
}
