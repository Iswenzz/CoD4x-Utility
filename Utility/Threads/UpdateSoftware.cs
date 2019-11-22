using System;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

using Iswenzz.UI;
using Iswenzz.CoD4.Utility.Profiles;

namespace Iswenzz.CoD4.Utility.Threads
{
    public static class UpdateSoftware
    {
        /// <summary>
        /// Task to check if there is any update to this software.
        /// About popup shows if there is an update.
        /// </summary>
        public static async void Init()
        {
            float ver = 1.0f;
            try
            {
                using (WebClient client = new WebClient())
                    ver = float.Parse(client.DownloadString("http://213.32.18.205:1337/cod4x_utility/version.txt"));
            } catch { }
            await Task.Delay(1000);

            if (Profile.Version != ver)
            {
                Profile.IsFormAbout = false;
                Profile.UpdateString = "Update available on:";
                (Application.OpenForms[0] as Panel).ShowAbout();
            }
        }
    }
}
