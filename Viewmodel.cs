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
        }

        public float slider_output_1(int val)
        {
            val -= 10000;
            return (float)val / 1000;
        }

        public int slider_input_1(float val)
        {
            val *= 1000;
            val += 10000;
            return (int)val;
        }
        
        public float slider_output_2(int val)
        {
            return (float)val / 1000;
        }

        public int slider_input_2(float val)
        {
            val *= 1000;
            return (int)val;
        }

        public float slider_output_3(int val)
        {
            float f = (float)val / 100;
            return f += 65;
        }

        public int slider_input_3(float val)
        {
            if (val == 0) return 0;
            val -= 65;
            val *= 100;
            return (int)val;
        }

        private void b0_ValueChanged(object sender, EventArgs e)
        {
            t0.Text = Profile.var_cg_gun_x.ToString();
            Profile.var_cg_gun_x = slider_output_1(b0.Value);
            CMD.command_rw(Profile.cg_gun_x, Profile.var_cg_gun_x);
        }

        private void b1_ValueChanged(object sender, EventArgs e)
        {
            t1.Text = Profile.var_cg_gun_y.ToString();
            Profile.var_cg_gun_y = slider_output_1(b1.Value);
            CMD.command_rw(Profile.cg_gun_y, Profile.var_cg_gun_y);
        }

        private void b2_ValueChanged(object sender, EventArgs e)
        {
            t2.Text = Profile.var_cg_gun_z.ToString();
            Profile.var_cg_gun_z = slider_output_1(b2.Value);
            CMD.command_rw(Profile.cg_gun_z, Profile.var_cg_gun_z);
        }

        private void b3_ValueChanged(object sender, EventArgs e)
        {
            t3.Text = Profile.var_cg_fov.ToString();
            Profile.var_cg_fov = slider_output_3(b3.Value);
            CMD.command_rw(Profile.cg_fov, Profile.var_cg_fov);
        }

        private void b4_ValueChanged(object sender, EventArgs e)
        {
            t4.Text = Profile.var_cg_fovScale.ToString();
            Profile.var_cg_fovScale = slider_output_2(b4.Value);
            CMD.command_rw(Profile.cg_fovScale, Profile.var_cg_fovScale);
        }

        private void b0_Load(object sender, EventArgs e)
        {
            b0.Value = slider_input_1(Profile.var_cg_gun_x);
            t0.Text = Profile.var_cg_gun_x.ToString();
        }

        private void b1_Load(object sender, EventArgs e)
        {
            b1.Value = slider_input_1(Profile.var_cg_gun_y);
            t1.Text = Profile.var_cg_gun_y.ToString();
        }

        private void b2_Load(object sender, EventArgs e)
        {
            b2.Value = slider_input_1(Profile.var_cg_gun_z);
            t2.Text = Profile.var_cg_gun_z.ToString();
        }

        private void b3_Load(object sender, EventArgs e)
        {
            b3.Value = slider_input_3(Profile.var_cg_fov);
            t3.Text = Profile.var_cg_fov.ToString();
        }

        private void b4_Load(object sender, EventArgs e)
        {
            b4.Value = slider_input_2(Profile.var_cg_fovScale);
            t4.Text = Profile.var_cg_fovScale.ToString();
        }

        private void b_reset_Click(object sender, EventArgs e)
        {
            Profile.var_cg_gun_x = 0.0f;
            Profile.var_cg_gun_y = 0.0f;
            Profile.var_cg_gun_z = 0.0f;
            
            CMD.command_rw(Profile.cg_gun_x, Profile.var_cg_gun_x);
            CMD.command_rw(Profile.cg_gun_y, Profile.var_cg_gun_y);
            CMD.command_rw(Profile.cg_gun_z, Profile.var_cg_gun_z);
            
            b0.Value = slider_input_1(Profile.var_cg_gun_x);
            b1.Value = slider_input_1(Profile.var_cg_gun_y);
            b2.Value = slider_input_1(Profile.var_cg_gun_z);
            
            t0.Text = Profile.var_cg_gun_x.ToString();
            t1.Text = Profile.var_cg_gun_y.ToString();
            t2.Text = Profile.var_cg_gun_z.ToString();
        }

        private void b_reset1_Click(object sender, EventArgs e)
        {
            Profile.var_cg_fov = 65.0f;
            Profile.var_cg_fovScale = 1.0f;
            
            CMD.command_rw(Profile.cg_fov, Profile.var_cg_fov);
            CMD.command_rw(Profile.cg_fovScale, Profile.var_cg_fovScale);
            
            b3.Value = slider_input_3(Profile.var_cg_fov);
            b4.Value = slider_input_2(Profile.var_cg_fovScale);
            
            t3.Text = Profile.var_cg_fov.ToString();
            t4.Text = Profile.var_cg_fovScale.ToString();
        }
    }
}
