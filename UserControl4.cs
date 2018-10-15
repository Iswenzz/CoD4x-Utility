using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using cod4_memory;

namespace form_hack
{
    public partial class UserControl4 : UserControl
    {
        public UserControl4()
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
            Command cmd = new Command();
            cmd.command_vector_rw(Profile.r_filmTweakLightTint, Profile.var_r_filmTweakLightTint);
        }

        private void b0_g_ValueChanged(object sender, EventArgs e)
        {
            Profile.var_r_filmTweakLightTint[1] = slider_output_1(b0_g.Value);
            t0_g.Text = Profile.var_r_filmTweakLightTint[1].ToString();
            Command cmd = new Command();
            cmd.command_vector_rw(Profile.r_filmTweakLightTint, Profile.var_r_filmTweakLightTint);
        }

        private void b0_b_ValueChanged(object sender, EventArgs e)
        {
            Profile.var_r_filmTweakLightTint[2] = slider_output_1(b0_b.Value);
            t0_b.Text = Profile.var_r_filmTweakLightTint[2].ToString();
            Command cmd = new Command();
            cmd.command_vector_rw(Profile.r_filmTweakLightTint, Profile.var_r_filmTweakLightTint);
        }

        private void b1_r_ValueChanged(object sender, EventArgs e)
        {
            Profile.var_r_filmTweakDarkTint[0] = slider_output_1(b1_r.Value);
            t1_r.Text = Profile.var_r_filmTweakDarkTint[0].ToString();
            Command cmd = new Command();
            cmd.command_vector_rw(Profile.r_filmTweakDarkTint, Profile.var_r_filmTweakDarkTint);
        }

        private void b1_g_ValueChanged(object sender, EventArgs e)
        {
            Profile.var_r_filmTweakDarkTint[1] = slider_output_1(b1_g.Value);
            t1_g.Text = Profile.var_r_filmTweakDarkTint[1].ToString();
            Command cmd = new Command();
            cmd.command_vector_rw(Profile.r_filmTweakDarkTint, Profile.var_r_filmTweakDarkTint);
        }

        private void b1_b_ValueChanged(object sender, EventArgs e)
        {
            Profile.var_r_filmTweakDarkTint[2] = slider_output_1(b1_b.Value);
            t1_b.Text = Profile.var_r_filmTweakDarkTint[2].ToString();
            Command cmd = new Command();
            cmd.command_vector_rw(Profile.r_filmTweakDarkTint, Profile.var_r_filmTweakDarkTint);
        }

        private void b2_r_ValueChanged(object sender, EventArgs e)
        {
            Profile.var_r_lightTweakSunColor[0] = slider_output_1(b2_r.Value);
            Command cmd = new Command();
            cmd.command_vector_rw(Profile.r_lightTweakSunColor, Profile.var_r_lightTweakSunColor);
        }

        private void b2_g_ValueChanged(object sender, EventArgs e)
        {
            Profile.var_r_lightTweakSunColor[1] = slider_output_1(b2_g.Value);
            Command cmd = new Command();
            cmd.command_vector_rw(Profile.r_lightTweakSunColor, Profile.var_r_lightTweakSunColor);
        }

        private void b2_b_ValueChanged(object sender, EventArgs e)
        {
            Profile.var_r_lightTweakSunColor[2] = slider_output_1(b2_b.Value);
            Command cmd = new Command();
            cmd.command_vector_rw(Profile.r_lightTweakSunColor, Profile.var_r_lightTweakSunColor);
        }

        private void b3_r_ValueChanged(object sender, EventArgs e)
        {
            Profile.var_r_lightTweakSunDiffuseColor[0] = slider_output_1(b3_r.Value);
            Command cmd = new Command();
            cmd.command_vector_rw(Profile.r_lightTweakSunDiffuseColor, Profile.var_r_lightTweakSunDiffuseColor);
        }

        private void b3_g_ValueChanged(object sender, EventArgs e)
        {
            Profile.var_r_lightTweakSunDiffuseColor[1] = slider_output_1(b3_g.Value);
            Command cmd = new Command();
            cmd.command_vector_rw(Profile.r_lightTweakSunDiffuseColor, Profile.var_r_lightTweakSunDiffuseColor);
        }

        private void b3_b_ValueChanged(object sender, EventArgs e)
        {
            Profile.var_r_lightTweakSunDiffuseColor[2] = slider_output_1(b3_b.Value);
            Command cmd = new Command();
            cmd.command_vector_rw(Profile.r_lightTweakSunDiffuseColor, Profile.var_r_lightTweakSunDiffuseColor);
        }

        private void b4_r_ValueChanged(object sender, EventArgs e)
        {
            Profile.var_r_lightTweakSunDirection[0] = slider_output_2(b4_r.Value);
            Profile.var_r_lightTweakSunDirection[2] = 0.0f;
            Command cmd = new Command();
            cmd.command_vector_rw(Profile.r_lightTweakSunDirection, Profile.var_r_lightTweakSunDirection);
        }

        private void b4_g_ValueChanged(object sender, EventArgs e)
        {
            Profile.var_r_lightTweakSunDirection[1] = slider_output_2(b4_g.Value);
            Profile.var_r_lightTweakSunDirection[2] = 0.0f;
            Command cmd = new Command();
            cmd.command_vector_rw(Profile.r_lightTweakSunDirection, Profile.var_r_lightTweakSunDirection);
        }

        private void b5_ValueChanged(object sender, EventArgs e)
        {
            Profile.var_r_lightTweakSunLight = slider_output_1(b5.Value);
            Command cmd = new Command();
            cmd.command_rw(Profile.r_lightTweakSunLight, Profile.var_r_lightTweakSunLight);
        }

        private void b6_ValueChanged(object sender, EventArgs e)
        {
            Profile.var_r_filmTweakBrightness = slider_output_1(b6.Value);
            t6.Text = Profile.var_r_filmTweakBrightness.ToString();
            Command cmd = new Command();
            cmd.command_rw(Profile.r_filmTweakBrightness, Profile.var_r_filmTweakBrightness);
        }

        private void b7_ValueChanged(object sender, EventArgs e)
        {
            Profile.var_r_filmTweakContrast = slider_output_1(b7.Value);
            t7.Text = Profile.var_r_filmTweakContrast.ToString();
            Command cmd = new Command();
            cmd.command_rw(Profile.r_filmTweakContrast, Profile.var_r_filmTweakContrast);
        }

        private void b8_ValueChanged(object sender, EventArgs e)
        {
            Profile.var_r_filmTweakDesaturation = slider_output_1(b8.Value);
            t8.Text = Profile.var_r_filmTweakDesaturation.ToString();
            Command cmd = new Command();
            cmd.command_rw(Profile.r_filmTweakDesaturation, Profile.var_r_filmTweakDesaturation);
        }

        private void b_toggle_Click(object sender, EventArgs e)
        {
            if (!Profile.var_r_filmUseTweaks)
            {
                Profile.var_r_filmTweakEnable = true;
                Profile.var_r_filmUseTweaks = true;
                Command cmd = new Command();
                cmd.command_rw(Profile.r_filmTweakEnable, Profile.var_r_filmTweakEnable);
                cmd.command_rw(Profile.r_filmUseTweaks, Profile.var_r_filmUseTweaks);
                b_toggle.Normalcolor = Color.FromArgb(46, 139, 87);
                b_toggle.OnHovercolor = Color.FromArgb(46, 139, 87);
                b_toggle.Activecolor = Color.FromArgb(46, 139, 87);
            }

            else
            {
                Profile.var_r_filmTweakEnable = false;
                Profile.var_r_filmUseTweaks = false;
                Command cmd = new Command();
                cmd.command_rw(Profile.r_filmTweakEnable, Profile.var_r_filmTweakEnable);
                cmd.command_rw(Profile.r_filmUseTweaks, Profile.var_r_filmUseTweaks);
                b_toggle.Normalcolor = Color.FromArgb(178, 34, 34);
                b_toggle.OnHovercolor = Color.FromArgb(178, 34, 34);
                b_toggle.Activecolor = Color.FromArgb(178, 34, 34);
            }
        }

        private void b_reset_Click(object sender, EventArgs e)
        {
            Command cmd = new Command();
            
            Profile.var_r_filmTweakLightTint[0] = 1.0f;
            Profile.var_r_filmTweakLightTint[1] = 1.0f;
            Profile.var_r_filmTweakLightTint[2] = 1.0f;
            Profile.var_r_filmTweakDarkTint[0] = 1.0f;
            Profile.var_r_filmTweakDarkTint[1] = 1.0f;
            Profile.var_r_filmTweakDarkTint[2] = 1.0f;
            Profile.var_r_filmTweakBrightness = 0.0f;
            Profile.var_r_filmTweakContrast = 1.0f;
            Profile.var_r_filmTweakDesaturation = 0.0f;
            
            cmd.command_vector_rw(Profile.r_filmTweakLightTint, Profile.var_r_filmTweakLightTint);
            cmd.command_vector_rw(Profile.r_filmTweakDarkTint, Profile.var_r_filmTweakDarkTint);
            cmd.command_rw(Profile.r_filmTweakBrightness, Profile.var_r_filmTweakBrightness);
            cmd.command_rw(Profile.r_filmTweakContrast, Profile.var_r_filmTweakContrast);
            cmd.command_rw(Profile.r_filmTweakDesaturation, Profile.var_r_filmTweakDesaturation);
            
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

        private void b2_r_Load(object sender, EventArgs e)
        {
            //b2_r.Value = slider_input_1(Profile.var_r_lightTweakSunColor[0]);
        }

        private void b2_g_Load(object sender, EventArgs e)
        {
            //b2_g.Value = slider_input_1(Profile.var_r_lightTweakSunColor[1]);
        }

        private void b2_b_Load(object sender, EventArgs e)
        {
            //b2_b.Value = slider_input_1(Profile.var_r_lightTweakSunColor[2]);
        }

        private void b3_r_Load(object sender, EventArgs e)
        {
            //b3_r.Value = slider_input_1(Profile.var_r_lightTweakSunDiffuseColor[0]);
        }

        private void b3_g_Load(object sender, EventArgs e)
        {
            //b3_g.Value = slider_input_1(Profile.var_r_lightTweakSunDiffuseColor[1]);
        }

        private void b3_b_Load(object sender, EventArgs e)
        {
            //b3_b.Value = slider_input_1(Profile.var_r_lightTweakSunDiffuseColor[2]);
        }

        private void b4_r_Load(object sender, EventArgs e)
        {
            //b4_r.Value = slider_input_2(Profile.var_r_lightTweakSunDirection[0]);
        }

        private void b4_g_Load(object sender, EventArgs e)
        {
            //b4_g.Value = slider_input_2(Profile.var_r_lightTweakSunDirection[1]);
        }

        private void b5_Load(object sender, EventArgs e)
        {
            //b5.Value = slider_input_1(Profile.var_r_lightTweakSunLight);
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
            {
                b_toggle.Normalcolor = Color.FromArgb(46, 139, 87);
                b_toggle.OnHovercolor = Color.FromArgb(46, 139, 87);
                b_toggle.Activecolor = Color.FromArgb(46, 139, 87);
            }

            else
            {
                b_toggle.Normalcolor = Color.FromArgb(178, 34, 34);
                b_toggle.OnHovercolor = Color.FromArgb(178, 34, 34);
                b_toggle.Activecolor = Color.FromArgb(178, 34, 34);
            }
        }
    }
}
