using System;
using System.Threading.Tasks;
using System.Windows.Forms;

using Iswenzz.CoD4.Utility.Threads;
using Iswenzz.CoD4.Utility.Profiles;

namespace Iswenzz.CoD4.Utility
{
    public partial class Panel : Form
    {
        public Panel()
        {
            InitializeComponent();
            Task.Run(new Action(TaskStart.Start));

            WaitControl.Visible = true;
            PlayerControl.Visible = false;
            GraphicsControl.Visible = false;
            ViewmodelControl.Visible = false;
            VisionControl.Visible = false;
        }

        /// <summary>
        /// Simulate a click on the About button.
        /// </summary>
        public void ShowAbout() => b_about.Invoke(new Action(() => b_about_Click(null, null)));

        /// <summary>
        /// About button
        /// </summary>
        private void b_about_Click(object sender, EventArgs e)
        {
            if (!Profile.isFormAbout)
            {
                Profile.isFormAbout = true;
                Profile.Form1_X = Location.X;
                Profile.Form1_Y = Location.Y;
                PopUp about = new PopUp();
                about.Show();
                about.t_update.Invoke(new Action(() => about.t_update_TextChanged(null, null)));
            }
        }

        /// <summary>
        /// Player Button
        /// </summary>
        private void b0_Click(object sender, EventArgs e)
        {
            if(!Profile.isCoD4Running) return;
            Extension.MainButton(b0, b1, b2, b3);
            HidePages(false);
            PlayerControl.Visible = true;
        }

        /// <summary>
        /// Graphics Button
        /// </summary>
        private void b1_Click_1(object sender, EventArgs e)
        {
            if (!Profile.isCoD4Running) return;
            Extension.MainButton(b1, b0, b2, b3);
            HidePages(false);
            GraphicsControl.Visible = true;
        }

        /// <summary>
        /// Viewmodel Button
        /// </summary>
        private void b2_Click(object sender, EventArgs e)
        {
            if (!Profile.isCoD4Running) return;
            Extension.MainButton(b2, b0, b1, b3);
            HidePages(false);
            ViewmodelControl.Visible = true;
        }

        /// <summary>
        /// Vision Button
        /// </summary>
        private void b3_Click(object sender, EventArgs e)
        {
            if (!Profile.isCoD4Running) return;
            Extension.MainButton(b3, b0, b1, b2);
            HidePages(false);
            VisionControl.Visible = true;
        }

        /// <summary>
        /// Hide all pages and show the default page (player tab)
        /// </summary>
        public void ShowDefaultPages()
        {
            WaitControl.Invoke(new Action(() => WaitControl.Visible = false));
            PlayerControl.Invoke(new Action(() => PlayerControl.Visible = false));
            GraphicsControl.Invoke(new Action(() => GraphicsControl.Visible = false));
            ViewmodelControl.Invoke(new Action(() => ViewmodelControl.Visible = false));
            VisionControl.Invoke(new Action(() => VisionControl.Visible = false));
            b0.Invoke(new Action(() => b0_Click(null, null)));
        }

        /// <summary>
        /// Hide all pages.
        /// </summary>
        /// <param name="isWaitPage">Show the wait pages</param>
        public void HidePages(bool isWaitPage)
        {
            if (isWaitPage) WaitControl.Invoke(new Action(() => WaitControl.Visible = true));
            else WaitControl.Invoke(new Action(() => WaitControl.Visible = false));
            PlayerControl.Invoke(new Action(() => PlayerControl.Visible = false));
            GraphicsControl.Invoke(new Action(() => GraphicsControl.Visible = false));
            ViewmodelControl.Invoke(new Action(() => ViewmodelControl.Visible = false));
            VisionControl.Invoke(new Action(() => VisionControl.Visible = false));
        }

        int X, Y, isMoving;
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            isMoving = 1;

            X = e.X;
            Y = e.Y;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if(isMoving == 1)
                SetDesktopLocation(MousePosition.X - X, MousePosition.Y - Y);
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e) => isMoving = 0;
        private void bunifuFlatButton1_Click(object sender, EventArgs e) => Application.Exit();
        private void bunifuFlatButton2_Click(object sender, EventArgs e) => WindowState = FormWindowState.Minimized;
    }
}