using System;
using System.Diagnostics;
using System.Windows.Forms;

using Iswenzz.CoD4.Utility.Profiles;

namespace Iswenzz.CoD4.Utility
{
    public partial class PopUp : Form
    {
        public PopUp()
        {
            InitializeComponent();
            t_version.Text = Profile.Version.ToString("F1");
        }

        public void t_update_TextChanged(object sender, EventArgs e) => t_update.Text = Profile.Update_String;
        private void PopUp_Load(object sender, EventArgs e) => SetDesktopLocation(Profile.Form1_X + 410, Profile.Form1_Y + 190);

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            Profile.isFormAbout = false;
            Hide();
        }

        int X, Y, isMoving;
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => Process.Start("https://iswenzz.com/");
        private void panel2_MouseUp(object sender, MouseEventArgs e) => isMoving = 0;

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            isMoving = 1;

            X = e.X;
            Y = e.Y;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMoving == 1)
                SetDesktopLocation(MousePosition.X - X, MousePosition.Y - Y);
        }
    }
}
