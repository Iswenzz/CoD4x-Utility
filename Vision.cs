using System;
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
            VisibleChanged += Vision_VisibleChanged;
        }

        private void Vision_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
                LoadButtons();
        }

        public float SliderOut1(int val) => (float)val / 1000;
        public int SliderIn1(float val) => (int)(val * 1000);
        public float SlideOut2(int val) => (float)(val - 360000) / 1000;
        public int SliderIn2(float val) => (int)((val * 1000) + 360000);

        private void b0_r_ValueChanged(object sender, EventArgs e)
        {
            Profile.var_r_filmTweakLightTint[0] = SliderOut1(b0_r.Value);
            t0_r.Text = Profile.var_r_filmTweakLightTint[0].ToString();
            CMD.VectorReadWrite(Profile.r_filmTweakLightTint, Profile.var_r_filmTweakLightTint);
        }

        private void b0_g_ValueChanged(object sender, EventArgs e)
        {
            Profile.var_r_filmTweakLightTint[1] = SliderOut1(b0_g.Value);
            t0_g.Text = Profile.var_r_filmTweakLightTint[1].ToString();
            CMD.VectorReadWrite(Profile.r_filmTweakLightTint, Profile.var_r_filmTweakLightTint);
        }

        private void b0_b_ValueChanged(object sender, EventArgs e)
        {
            Profile.var_r_filmTweakLightTint[2] = SliderOut1(b0_b.Value);
            t0_b.Text = Profile.var_r_filmTweakLightTint[2].ToString();
            CMD.VectorReadWrite(Profile.r_filmTweakLightTint, Profile.var_r_filmTweakLightTint);
        }

        private void b1_r_ValueChanged(object sender, EventArgs e)
        {
            Profile.var_r_filmTweakDarkTint[0] = SliderOut1(b1_r.Value);
            t1_r.Text = Profile.var_r_filmTweakDarkTint[0].ToString();
            CMD.VectorReadWrite(Profile.r_filmTweakDarkTint, Profile.var_r_filmTweakDarkTint);
        }

        private void b1_g_ValueChanged(object sender, EventArgs e)
        {
            Profile.var_r_filmTweakDarkTint[1] = SliderOut1(b1_g.Value);
            t1_g.Text = Profile.var_r_filmTweakDarkTint[1].ToString();
            CMD.VectorReadWrite(Profile.r_filmTweakDarkTint, Profile.var_r_filmTweakDarkTint);
        }

        private void b1_b_ValueChanged(object sender, EventArgs e)
        {
            Profile.var_r_filmTweakDarkTint[2] = SliderOut1(b1_b.Value);
            t1_b.Text = Profile.var_r_filmTweakDarkTint[2].ToString();
            CMD.VectorReadWrite(Profile.r_filmTweakDarkTint, Profile.var_r_filmTweakDarkTint);
        }

        private void b6_ValueChanged(object sender, EventArgs e)
        {
            Profile.var_r_filmTweakBrightness = SliderOut1(b6.Value);
            t6.Text = Profile.var_r_filmTweakBrightness.ToString();
            CMD.ReadWrite(Profile.r_filmTweakBrightness, Profile.var_r_filmTweakBrightness);
        }

        private void b7_ValueChanged(object sender, EventArgs e)
        {
            Profile.var_r_filmTweakContrast = SliderOut1(b7.Value);
            t7.Text = Profile.var_r_filmTweakContrast.ToString();
            CMD.ReadWrite(Profile.r_filmTweakContrast, Profile.var_r_filmTweakContrast);
        }

        private void b8_ValueChanged(object sender, EventArgs e)
        {
            Profile.var_r_filmTweakDesaturation = SliderOut1(b8.Value);
            t8.Text = Profile.var_r_filmTweakDesaturation.ToString();
            CMD.ReadWrite(Profile.r_filmTweakDesaturation, Profile.var_r_filmTweakDesaturation);
        }

        private void b_toggle_Click(object sender, EventArgs e)
        {
            if (!Profile.var_r_filmUseTweaks)
            {
                Profile.var_r_filmTweakEnable = true;
                Profile.var_r_filmUseTweaks = true;
                CMD.ReadWrite(Profile.r_filmTweakEnable, Profile.var_r_filmTweakEnable);
                CMD.ReadWrite(Profile.r_filmUseTweaks, Profile.var_r_filmUseTweaks);
                b_toggle.ToggleButton(true);
            }
            else
            {
                Profile.var_r_filmTweakEnable = false;
                Profile.var_r_filmUseTweaks = false;
                CMD.ReadWrite(Profile.r_filmTweakEnable, Profile.var_r_filmTweakEnable);
                CMD.ReadWrite(Profile.r_filmUseTweaks, Profile.var_r_filmUseTweaks);
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
            
            CMD.VectorReadWrite(Profile.r_filmTweakLightTint, Profile.var_r_filmTweakLightTint);
            CMD.VectorReadWrite(Profile.r_filmTweakDarkTint, Profile.var_r_filmTweakDarkTint);
            CMD.ReadWrite(Profile.r_filmTweakBrightness, Profile.var_r_filmTweakBrightness);
            CMD.ReadWrite(Profile.r_filmTweakContrast, Profile.var_r_filmTweakContrast);
            CMD.ReadWrite(Profile.r_filmTweakDesaturation, Profile.var_r_filmTweakDesaturation);
            
            b0_r.Value = SliderIn1(Profile.var_r_filmTweakLightTint[0]);
            b0_g.Value = SliderIn1(Profile.var_r_filmTweakLightTint[1]);
            b0_b.Value = SliderIn1(Profile.var_r_filmTweakLightTint[2]);
            b1_r.Value = SliderIn1(Profile.var_r_filmTweakDarkTint[0]);
            b1_g.Value = SliderIn1(Profile.var_r_filmTweakDarkTint[1]);
            b1_b.Value = SliderIn1(Profile.var_r_filmTweakDarkTint[2]);
            b6.Value = SliderIn1(Profile.var_r_filmTweakBrightness);
            b7.Value = SliderIn1(Profile.var_r_filmTweakContrast);
            b8.Value = SliderIn1(Profile.var_r_filmTweakDesaturation);
            
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

        public void LoadButtons()
        {
            b0_r.Value = SliderIn1(Profile.var_r_filmTweakLightTint[0]);
            t0_r.Text = Profile.var_r_filmTweakLightTint[0].ToString();
            b0_g.Value = SliderIn1(Profile.var_r_filmTweakLightTint[1]);
            t0_g.Text = Profile.var_r_filmTweakLightTint[1].ToString();
            b0_b.Value = SliderIn1(Profile.var_r_filmTweakLightTint[2]);
            t0_b.Text = Profile.var_r_filmTweakLightTint[2].ToString();

            b1_r.Value = SliderIn1(Profile.var_r_filmTweakDarkTint[0]);
            t1_r.Text = Profile.var_r_filmTweakDarkTint[0].ToString();
            b1_g.Value = SliderIn1(Profile.var_r_filmTweakDarkTint[1]);
            t1_g.Text = Profile.var_r_filmTweakDarkTint[1].ToString();
            b1_b.Value = SliderIn1(Profile.var_r_filmTweakDarkTint[2]);
            t1_b.Text = Profile.var_r_filmTweakDarkTint[2].ToString();

            b6.Value = SliderIn1(Profile.var_r_filmTweakBrightness);
            t6.Text = Profile.var_r_filmTweakBrightness.ToString();

            b7.Value = SliderIn1(Profile.var_r_filmTweakContrast);
            t7.Text = Profile.var_r_filmTweakContrast.ToString();

            b8.Value = SliderIn1(Profile.var_r_filmTweakDesaturation);
            t8.Text = Profile.var_r_filmTweakDesaturation.ToString();

            if (Profile.var_r_filmUseTweaks)
                b_toggle.ToggleButton(true);
            else
                b_toggle.ToggleButton(false);
        }
    }
}
