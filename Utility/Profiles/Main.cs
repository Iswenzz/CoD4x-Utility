using System;
using System.Threading;
using System.Threading.Tasks;

using Iswenzz.CoD4.Utility.Threads;

namespace Iswenzz.CoD4.Utility.Profiles
{
    public partial class Profile
    {
        public static float Version { get; set; } = 1.22f;
        public static string UpdateString { get; set; } = "";
        public static int Form1_X { get; set; }
        public static int Form1_Y { get; set; }
        public static bool IsFormAbout { get; set; }
        public static bool IsCoD4Running { get; set; }
        public static bool IsFirstTime { get; set; }

        public static CancellationTokenSource TokenSource { get; set; }

        /// <summary>
        /// Load XML Profile and start the injection task.
        /// </summary>
        public static void Start()
        {
            Xml.Load();

            if (IsFirstTime)
                FirstLoad();
            else
            {
                TokenSource = new CancellationTokenSource();
                Task.Run(new Action(() => Update.Init(TokenSource.Token)), TokenSource.Token);
            }
        }
    }
}