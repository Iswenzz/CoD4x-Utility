using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using cod4_memory;

namespace form_hack
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            t_version.Text = Profile.Version.ToString("F1");
        }

        // Change text when update
        public void t_update_TextChanged(object sender, EventArgs e)
        {
            t_update.Text = Profile.Update_String;
        }

        // Form Position
        private void Form2_Load(object sender, EventArgs e)
        {
            SetDesktopLocation(Profile.Form1_X + 410, Profile.Form1_Y + 190);
        }

        // Close Button
        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            Profile.isFormAbout = false;
            Hide();
        }

        // Moving Frame
        int X, Y, isMoving;

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            isMoving = 1;

            X = e.X;
            Y = e.Y;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://iswenzz.com/");
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            isMoving = 0;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMoving == 1)
                SetDesktopLocation(MousePosition.X - X, MousePosition.Y - Y);
        }
    }
}
