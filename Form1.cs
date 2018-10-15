using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using cod4_memory;

namespace form_hack
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Profile.XML_Load();

            // Check iw4mp
            Profile.thread[0] = new Thread(() =>
            {
                Profile.Thread_Check_Process();
            });

            // Window Switch
            Profile.thread[1] = new Thread(() =>
            {
                Thread_Check_Window();
            });

            // Update Checking
            Profile.thread[3] = new Thread(() =>
            {
                Thread_Update();
            });

            Profile.thread[0].Start();
            Profile.thread[1].Start();
            Profile.thread[3].Start();

            Profile.thread[0].IsBackground = true;
            Profile.thread[1].IsBackground = true;
            Profile.thread[3].IsBackground = true;
        }

        private void Thread_Update()
        {
            WebClient client = new WebClient();
            float ver = Convert.ToSingle(client.DownloadString("http://213.32.18.205:1337/cod4x_utility/version.txt"));

            while (!IsHandleCreated)
                Thread.Sleep(100);

            Thread.Sleep(1000);

            if (Profile.Version != ver)
            {
                Profile.isFormAbout = false;
                Profile.Update_String = "Update available on:";

                b_about.Invoke((Action)delegate()
                {
                    b_about_Click(null, null);
                });
            }
        }

        // About Button
        private void b_about_Click(object sender, EventArgs e)
        {
            if (!Profile.isFormAbout)
            {
                Profile.isFormAbout = true;
                Form2 about = new Form2();
                about.Show();

                about.t_update.Invoke((Action)delegate ()
                {
                    about.t_update_TextChanged(null, null);
                });
            }
        }

        // Player Button
        private void b0_Click(object sender, EventArgs e)
        {
            if(!Profile.isCoD4Running)
                return;

            // Button Color Reset
            b1.Normalcolor = Color.FromArgb(36, 35, 39);
            b2.Normalcolor = Color.FromArgb(36, 35, 39);
            b3.Normalcolor = Color.FromArgb(36, 35, 39);
            b1.OnHovercolor = Color.FromArgb(36, 35, 39);
            b2.OnHovercolor = Color.FromArgb(36, 35, 39);
            b3.OnHovercolor = Color.FromArgb(36, 35, 39);

            // Selected Color
            b0.Normalcolor = Color.FromArgb(72, 75, 81);
            b0.OnHovercolor = Color.FromArgb(72, 75, 81);

            // Hide Window
            userControlWait1.Visible = false;
            userControl21.Visible = false;
            userControl31.Visible = false;
            userControl41.Visible = false;

            // Show Window
            userControl11.Visible = true;
        }

        // Graphics Button
        private void b1_Click_1(object sender, EventArgs e)
        {
            if(!Profile.isCoD4Running)
                return;

            // Button Color Reset
            b0.Normalcolor = Color.FromArgb(36, 35, 39);
            b2.Normalcolor = Color.FromArgb(36, 35, 39);
            b3.Normalcolor = Color.FromArgb(36, 35, 39);
            b0.OnHovercolor = Color.FromArgb(36, 35, 39);
            b2.OnHovercolor = Color.FromArgb(36, 35, 39);
            b3.OnHovercolor = Color.FromArgb(36, 35, 39);

            // Selected Color
            b1.Normalcolor = Color.FromArgb(72, 75, 81);
            b1.OnHovercolor = Color.FromArgb(72, 75, 81);

            // Hide Window
            userControlWait1.Visible = false;
            userControl11.Visible = false;
            userControl31.Visible = false;
            userControl41.Visible = false;

            // Show Window
            userControl21.Visible = true;
        }

        // Viewmodel Button
        private void b2_Click(object sender, EventArgs e)
        {
            if (!Profile.isCoD4Running)
                return;

            // Button Color Reset
            b0.Normalcolor = Color.FromArgb(36, 35, 39);
            b1.Normalcolor = Color.FromArgb(36, 35, 39);
            b3.Normalcolor = Color.FromArgb(36, 35, 39);
            b0.OnHovercolor = Color.FromArgb(36, 35, 39);
            b1.OnHovercolor = Color.FromArgb(36, 35, 39);
            b3.OnHovercolor = Color.FromArgb(36, 35, 39);

            // Selected Color
            b2.Normalcolor = Color.FromArgb(72, 75, 81);
            b2.OnHovercolor = Color.FromArgb(72, 75, 81);

            // Hide Window
            userControlWait1.Visible = false;
            userControl11.Visible = false;
            userControl21.Visible = false;
            userControl41.Visible = false;

            // Show Window
            userControl31.Visible = true;
        }

        // Vision Button
        private void b3_Click(object sender, EventArgs e)
        {
            if (!Profile.isCoD4Running)
                return;

            // Button Color Reset
            b0.Normalcolor = Color.FromArgb(36, 35, 39);
            b1.Normalcolor = Color.FromArgb(36, 35, 39);
            b2.Normalcolor = Color.FromArgb(36, 35, 39);
            b0.OnHovercolor = Color.FromArgb(36, 35, 39);
            b1.OnHovercolor = Color.FromArgb(36, 35, 39);
            b2.OnHovercolor = Color.FromArgb(36, 35, 39);

            // Selected Color
            b3.Normalcolor = Color.FromArgb(72, 75, 81);
            b3.OnHovercolor = Color.FromArgb(72, 75, 81);

            // Hide Window
            userControlWait1.Visible = false;
            userControl11.Visible = false;
            userControl21.Visible = false;
            userControl31.Visible = false;

            // Show Window
            userControl41.Visible = true;
        }

        // Wait Tab
        private void userControlWait1_Load(object sender, EventArgs e)
        {
            userControlWait1.Visible = true;
        }

        private void Thread_Check_Window()
        {
            bool runned_on = false;
            bool runned_off = false;

            while(!IsHandleCreated)
                Thread.Sleep(100);

            while (true)
            {
                Profile.Form1_X = Location.X;
                Profile.Form1_Y = Location.Y;

                if (Profile.isCoD4Running)
                {
                    if(!runned_on)
                    {
                        runned_on = true;
                        runned_off = false;

                        userControlWait1.Invoke((Action)delegate { userControlWait1.Visible = false; });
                        userControl11.Invoke((Action)delegate { userControl11.Visible = true; });
                        userControl21.Invoke((Action)delegate { userControl21.Visible = false; });
                        userControl31.Invoke((Action)delegate { userControl21.Visible = false; });
                        userControl41.Invoke((Action)delegate { userControl21.Visible = false; });
                    }
                }

                else
                {
                    if(!runned_off)
                    {
                        runned_off = true;
                        runned_on = false;

                        userControlWait1.Invoke((Action)delegate { userControlWait1.Visible = true; });
                        userControl11.Invoke((Action)delegate { userControl11.Visible = false; });
                        userControl21.Invoke((Action)delegate { userControl21.Visible = false; });
                        userControl31.Invoke((Action)delegate { userControl21.Visible = false; });
                        userControl41.Invoke((Action)delegate { userControl21.Visible = false; });
                    }
                }

                Thread.Sleep(1000);
            }
        }

        // Player Tab
        private void userControl11_Load_1(object sender, EventArgs e)
        {
            userControl11.Visible = false;
        }

        // Graphics Tab
        private void userControl21_Load_1(object sender, EventArgs e)
        {
            userControl21.Visible = false;
        }

        // Viewmodel Tab
        private void userControl31_Load(object sender, EventArgs e)
        {
            userControl31.Visible = false;
        }

        // Vision Tab
        private void userControl41_Load(object sender, EventArgs e)
        {
            userControl41.Visible = false;
        }

        // Moving Frame
        int X, Y, isMoving;

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            isMoving = 1;

            X = e.X;
            Y = e.Y;
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            isMoving = 0;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if(isMoving == 1)
                SetDesktopLocation(MousePosition.X - X, MousePosition.Y - Y);
        }

        // Exit Button
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Minimize Button
        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}