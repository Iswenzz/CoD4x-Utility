using System;
using System.Threading;
using System.Threading.Tasks;

using Iswenzz.CoD4.Utility.Threads;

namespace Iswenzz.CoD4.Utility.Profiles
{
    public partial class Profile
    {
        public static float Version = 1.21f;
        public static string Update_String = "";
        public static int Form1_X;
        public static int Form1_Y;
        public static bool isFormAbout = false;
        public static bool isCoD4Running = false;
        public static bool isFirstTime;

        public static Task Inject;
        public static CancellationTokenSource TokenSource;
        public static CancellationToken Token;

        /// <summary>
        /// Load XML Profile and start the injection task.
        /// </summary>
        public static void Start()
        {
            Xml.Load();

            if (isFirstTime)
                FirstLoad();
            else
            {
                TokenSource = new CancellationTokenSource();
                Token = TokenSource.Token;
                Inject = Task.Run(new Action(() => Update.Init(Token)), Token);
            }
        }
    }
}