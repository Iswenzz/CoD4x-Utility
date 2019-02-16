using System;
using System.Drawing;
using System.Windows.Forms;

using Iswenzz.CoD4.Utility.Profiles;
using Iswenzz.CoD4.Utility.Command;

namespace Iswenzz.CoD4.Utility
{
    public partial class Vision : UserControl
    {
        public Vision()
        {
            InitializeComponent();
        }

        public float slider_output_1(int val)
        {
            return (float)val / 1000;
        }

        public int slider_input_1(float val)
        {
            val *= 1000;
            return (int)val;
        }

        public float slider_output_2(int val)
        {
            val -= 360000;
            return (float)val / 1000;
        }

        public int slider_input_2(float val)
        {
            val *= 1000;
            val += 360000;
            return (int)val;
        }

        private void b0_r_ValueChanged(object sender, EventArgs e)
        {
            Profile.var_r_filmTweakLightTint[0] = slider_output_1(b0_r.Value);
            t0_r.Text = Profile.var_r_filmTweakLightTint[0].ToString();
            CMD.command_vector_rw(Profile.r_filmTweakLightTint, Profile.var_r_filmTweakLightTint);
        }

        private void b0_g_ValueChanged(object sender, EventArgs e)
        {
            Profile.var_r_filmTweakLightTint[1] = slider_output_1(b0_g.Value);
            t0_g.Text = Profile.var_r_filmTweakLightTint[1].ToString();
            CMD.command_vector_rw(Profile.r_filmTweakLightTint, Profile.var_r_filmTweakLightTint);
        }

        private void b0_b_ValueChanged(object sender, EventArgs e)
        {
            Profile.var_r_filmTweakLightTint[2] = slider_output_1(b0_b.Value);
            t0_b.Text = Profile.var_r_filmTweakLightTint[2].ToString();
            CMD.command_vector_rw(Profile.r_filmTweakLightTint, Profile.var_r_filmTweakLightTint);
        }

        private void b1_r_ValueChanged(object sender, EventArgs e)
        {
            Profile.var_r_filmTweakDarkTint[0] = slider_output_1(b1_r.Value);
            t1_r.Text = Profile.var_r_filmTweakDarkTint[0].ToString();
            CMD.command_vector_rw(Profile.r_filmTweakDarkTint, Profile.var_r_filmTweakDarkTint);
        }

        private void b1_g_ValueChanged(object sender, EventArgs e)
        {
            Profile.var_r_filmTweakDarkTint[1] = slider_output_1(b1_g.Value);
            t1_g.Text = Profile.var_r_filmTweakDarkTint[1].ToString();
            CMD.command_vector_rw(Profile.r_filmTweakDarkTint, Profile.var_r_filmTweakDarkTint);
        }

        private void b1_b_ValueChanged(object sender, EventArgs e)
        {
            Profile.var_r_filmTweakDarkTint[2] = slider_output_1(b1_b.Value);
            t1_b.Text = Profile.var_r_filmTweakDarkTint[2].ToString();
            CMD.command_vector_rw(Profile.r_filmTweakDarkTint, Profile.var_r_filmTweakDarkTint);
        }

        private void b6_ValueChanged(object sender, EventArgs e)
        {
            Profile.var_r_filmTweakBrightness = slider_output_1(b6.Value);
            t6.Text = Profile.var_r_filmTweakBrightness.ToString();
            CMD.command_rw(Profile.r_filmTweakBrightness, Profile.var_r_filmTweakBrightness);
        }

        private void b7_ValueChanged(object sender, EventArgs e)
        {
            Profile.var_r_filmTweakContrast = slider_output_1(b7.Value);
            t7.Text = Profile.var_r_filmTweakContrast.ToString();
            CMD.command_rw(Profile.r_filmTweakContrast, Profile.var_r_filmTweakContrast);
        }

        private void b8_ValueChanged(object sender, EventArgs e)
        {
            Profile.var_r_filmTweakDesaturation = slider_output_1(b8.Value);
            t8.Text = Profile.var_r_filmTweakDesaturation.ToString();
            CMD.command_rw(Profile.r_filmTweakDesaturation, Profile.var_r_filmTweakDesaturation);
        }

        private void b_toggle_Click(object sender, EventArgs e)
        {
            if (!Profile.var_r_filmUseTweaks)
            {
                Profile.var_r_filmTweakEnable = true;
                Profile.var_r_filmUseTweaks = true;
                CMD.command_rw(Profile.r_filmTweakEnable, Profile.var_r_filmTweakEnable);
                CMD.command_rw(Profile.r_filmUseTweaks, Profile.var_r_filmUseTweaks);
                b_toggle.ToggleButton(true);
            }

            else
            {
                Profile.var_r_filmTweakEnable = false;
                Profile.var_r_filmUseTweaks = false;
                CMD.command_rw(Profile.r_filmTweakEnable, Profile.var_r_filmTweakEnable);
                CMD.command_rw(Profile.r_filmUseTweaks, Profile.var_r_filmUseTweaks);
                b_toggle.ToggleButton(false);
            }
        }

        private void b_cfg_Click(object sender, EventArgs e)
        {
            SaveFile.Filter = "CFG|*.cfg";
            SaveFile.Title = "Save CFG File";
            DialogResult status = SaveFile.ShowDialog();

            if (status == DialogResult.OK)
                Cfg.Save(SaveFile.FileName);
        }

        private void b_reset_Click(object sender, EventArgs e)
        {
            Profile.var_r_filmTweakLightTint[0] = 1.0f;
            Profile.var_r_filmTweakLightTint[1] = 1.0f;
            Profile.var_r_filmTweakLightTint[2] = 1.0f;
            Profile.var_r_filmTweakDarkTint[0] = 1.0f;
            Profile.var_r_filmTweakDarkTint[1] = 1.0f;
            Profile.var_r_filmTweakDarkTint[2] = 1.0f;
            Profile.var_r_filmTweakBrightness = 0.0f;
            Profile.var_r_filmTweakContrast = 1.0f;
            Profile.var_r_filmTweakDesaturation = 0.0f;
            
            CMD.command_vector_rw(Profile.r_filmTweakLightTint, Profile.var_r_filmTweakLightTint);
            CMD.command_vector_rw(Profile.r_filmTweakDarkTint, Profile.var_r_filmTweakDarkTint);
            CMD.command_rw(Profile.r_filmTweakBrightness, Profile.var_r_filmTweakBrightness);
            CMD.command_rw(Profile.r_filmTweakContrast, Profile.var_r_filmTweakContrast);
            CMD.command_rw(Profile.r_filmTweakDesaturation, Profile.var_r_filmTweakDesaturation);
            
            b0_r.Value = slider_input_1(Profile.var_r_filmTweakLightTint[0]);
            b0_g.Value = slider_input_1(Profile.var_r_filmTweakLightTint[1]);
            b0_b.Value = slider_input_1(Profile.var_r_filmTweakLightTint[2]);
            b1_r.Value = slider_input_1(Profile.var_r_filmTweakDarkTint[0]);
            b1_g.Value = slider_input_1(Profile.var_r_filmTweakDarkTint[1]);
            b1_b.Value = slider_input_1(Profile.var_r_filmTweakDarkTint[2]);
            b6.Value = slider_input_1(Profile.var_r_filmTweakBrightness);
            b7.Value = slider_input_1(Profile.var_r_filmTweakContrast);
            b8.Value = slider_input_1(Profile.var_r_filmTweakDesaturation);
            
            t0_r.Text = Profile.var_r_filmTweakLightTint[0].ToString();
            t0_g.Text = Profile.var_r_filmTweakLightTint[1].ToString();
            t0_b.Text = Profile.var_r_filmTweakLightTint[2].ToString();
            t1_r.Text = Profile.var_r_filmTweakDarkTint[0].ToString();
            t1_g.Text = Profile.var_r_filmTweakDarkTint[1].ToString();
            t1_b.Text = Profile.var_r_filmTweakDarkTint[2].ToString();
            t6.Text = Profile.var_r_filmTweakBrightness.ToString();
            t7.Text = Profile.var_r_filmTweakContrast.ToString();
            t8.Text = Profile.var_r_filmTweakDesaturation.ToString();
        }

        private void b0_r_Load(object sender, EventArgs e)
        {
            b0_r.Value = slider_input_1(Profile.var_r_filmTweakLightTint[0]);
            t0_r.Text = Profile.var_r_filmTweakLightTint[0].ToString();
        }

        private void b0_g_Load(object sender, EventArgs e)
        {
            b0_g.Value = slider_input_1(Profile.var_r_filmTweakLightTint[1]);
            t0_g.Text = Profile.var_r_filmTweakLightTint[1].ToString();
        }

        private void b0_b_Load(object sender, EventArgs e)
        {
            b0_b.Value = slider_input_1(Profile.var_r_filmTweakLightTint[2]);
            t0_b.Text = Profile.var_r_filmTweakLightTint[2].ToString();
        }

        private void b1_r_Load(object sender, EventArgs e)
        {
            b1_r.Value = slider_input_1(Profile.var_r_filmTweakDarkTint[0]);
            t1_r.Text = Profile.var_r_filmTweakDarkTint[0].ToString();
        }

        private void b1_g_Load(object sender, EventArgs e)
        {
            b1_g.Value = slider_input_1(Profile.var_r_filmTweakDarkTint[1]);
            t1_g.Text = Profile.var_r_filmTweakDarkTint[1].ToString();
        }

        private void b1_b_Load(object sender, EventArgs e)
        {
            b1_b.Value = slider_input_1(Profile.var_r_filmTweakDarkTint[2]);
            t1_b.Text = Profile.var_r_filmTweakDarkTint[2].ToString();
        }

        private void b6_Load(object sender, EventArgs e)
        {
            b6.Value = slider_input_1(Profile.var_r_filmTweakBrightness);
            t6.Text = Profile.var_r_filmTweakBrightness.ToString();
        }

        private void b7_Load(object sender, EventArgs e)
        {
            b7.Value = slider_input_1(Profile.var_r_filmTweakContrast);
            t7.Text = Profile.var_r_filmTweakContrast.ToString();
        }

        private void b8_Load(object sender, EventArgs e)
        {
            b8.Value = slider_input_1(Profile.var_r_filmTweakDesaturation);
            t8.Text = Profile.var_r_filmTweakDesaturation.ToString();
        }

        private void b_toggle_Load(object sender, EventArgs e)
        {
            if (Profile.var_r_filmUseTweaks)
                b_toggle.ToggleButton(true);

            else
                b_toggle.ToggleButton(false);
        }
    }
}
