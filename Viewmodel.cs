using System;
using System.Windows.Forms;

using Iswenzz.CoD4.Utility.Command;
using Iswenzz.CoD4.Utility.Profiles;

namespace Iswenzz.CoD4.Utility
{
    public partial class Viewmodel : UserControl
    {
        public Viewmodel()
        {
            InitializeComponent();
            VisibleChanged += Viewmodel_VisibleChanged;
        }

        private void Viewmodel_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
                LoadButtons();
        }

        public float SliderOut1(int val) => (float)(val - 10000) / 1000;
        public int SliderIn1(float val) => (int)((val * 1000) + 10000);
        public float SliderOut2(int val) => (float)val / 1000;
        public int SliderIn2(float val) => (int)(val * 1000);
        public float SliderOut3(int val) => ((float)val / 100) + 65;
        public int SliderIn3(float val) => val == 0 ? 0 : (int)((val - 65) * 100);

        private void b0_ValueChanged(object sender, EventArgs e)
        {
            t0.Text = Profile.var_cg_gun_x.ToString();
            Profile.var_cg_gun_x = SliderOut1(b0.Value);
            CMD.ReadWrite(Profile.cg_gun_x, Profile.var_cg_gun_x);
        }

        private void b1_ValueChanged(object sender, EventArgs e)
        {
            t1.Text = Profile.var_cg_gun_y.ToString();
            Profile.var_cg_gun_y = SliderOut1(b1.Value);
            CMD.ReadWrite(Profile.cg_gun_y, Profile.var_cg_gun_y);
        }

        private void b2_ValueChanged(object sender, EventArgs e)
        {
            t2.Text = Profile.var_cg_gun_z.ToString();
            Profile.var_cg_gun_z = SliderOut1(b2.Value);
            CMD.ReadWrite(Profile.cg_gun_z, Profile.var_cg_gun_z);
        }

        private void b3_ValueChanged(object sender, EventArgs e)
        {
            t3.Text = Profile.var_cg_fov.ToString();
            Profile.var_cg_fov = SliderOut3(b3.Value);
            CMD.ReadWrite(Profile.cg_fov, Profile.var_cg_fov);
        }

        private void b4_ValueChanged(object sender, EventArgs e)
        {
            t4.Text = Profile.var_cg_fovScale.ToString();
            Profile.var_cg_fovScale = SliderOut2(b4.Value);
            CMD.ReadWrite(Profile.cg_fovScale, Profile.var_cg_fovScale);
        }

        public void LoadButtons()
        {
            b0.Value = SliderIn1(Profile.var_cg_gun_x);
            t0.Text = Profile.var_cg_gun_x.ToString();

            b1.Value = SliderIn1(Profile.var_cg_gun_y);
            t1.Text = Profile.var_cg_gun_y.ToString();

            b2.Value = SliderIn1(Profile.var_cg_gun_z);
            t2.Text = Profile.var_cg_gun_z.ToString();

            b3.Value = SliderIn3(Profile.var_cg_fov);
            t3.Text = Profile.var_cg_fov.ToString();

            b4.Value = SliderIn2(Profile.var_cg_fovScale);
            t4.Text = Profile.var_cg_fovScale.ToString();
        }

        private void b_reset_Click(object sender, EventArgs e)
        {
            Profile.var_cg_gun_x = 0.0f;
            Profile.var_cg_gun_y = 0.0f;
            Profile.var_cg_gun_z = 0.0f;
            
            CMD.ReadWrite(Profile.cg_gun_x, Profile.var_cg_gun_x);
            CMD.ReadWrite(Profile.cg_gun_y, Profile.var_cg_gun_y);
            CMD.ReadWrite(Profile.cg_gun_z, Profile.var_cg_gun_z);
            
            b0.Value = SliderIn1(Profile.var_cg_gun_x);
            b1.Value = SliderIn1(Profile.var_cg_gun_y);
            b2.Value = SliderIn1(Profile.var_cg_gun_z);
            
            t0.Text = Profile.var_cg_gun_x.ToString();
            t1.Text = Profile.var_cg_gun_y.ToString();
            t2.Text = Profile.var_cg_gun_z.ToString();
        }

        private void b_reset1_Click(object sender, EventArgs e)
        {
            Profile.var_cg_fov = 65.0f;
            Profile.var_cg_fovScale = 1.0f;
            
            CMD.ReadWrite(Profile.cg_fov, Profile.var_cg_fov);
            CMD.ReadWrite(Profile.cg_fovScale, Profile.var_cg_fovScale);
            
            b3.Value = SliderIn3(Profile.var_cg_fov);
            b4.Value = SliderIn2(Profile.var_cg_fovScale);
            
            t3.Text = Profile.var_cg_fov.ToString();
            t4.Text = Profile.var_cg_fovScale.ToString();
        }
    }
}
