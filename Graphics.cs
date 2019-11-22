using System;
using System.Windows.Forms;

using Iswenzz.CoD4.Utility.Command;
using Iswenzz.CoD4.Utility.Profiles;

namespace Iswenzz.CoD4.Utility
{
    public partial class Graphics : UserControl
    {
        public Graphics()
        {
            InitializeComponent();
            VisibleChanged += Graphics_VisibleChanged;
        }

        private void Graphics_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
                LoadButtons();
        }

        private void b0_Click(object sender, EventArgs e)
        {
            if (!Profile.var_fx_enable)
            {
                Profile.var_fx_enable = true;
                CMD.ReadWrite(Profile.fx_enable, Profile.var_fx_enable);
                b0.ToggleButton(true);
            }
            else
            {
                Profile.var_fx_enable = false;
                CMD.ReadWrite(Profile.fx_enable, Profile.var_fx_enable);
                b0.ToggleButton(false);
            }
        }

        private void b1_Click(object sender, EventArgs e)
        {
            if (!Profile.var_r_specular)
            {
                Profile.var_r_specular = true;
                CMD.ReadWrite(Profile.r_specular, Profile.var_r_specular);
                b1.ToggleButton(true);
            }
            else
            {
                Profile.var_r_specular = false;
                CMD.ReadWrite(Profile.r_specular, Profile.var_r_specular);
                b1.ToggleButton(false);
            }
        }

        private void b2_Click(object sender, EventArgs e)
        {
            if (!Profile.var_r_fullbright)
            {
                Profile.var_r_fullbright = true;
                CMD.ReadWrite(Profile.r_fullbright, Profile.var_r_fullbright);
                CMD.Write(Profile.post_process, 1);
                CMD.Write(Profile.lighting, 4);
                CMD.Write(Profile.fx, 4);
                b2.ToggleButton(true);
            }
            else
            {
                Profile.var_r_fullbright = false;
                CMD.ReadWrite(Profile.r_fullbright, Profile.var_r_fullbright);
                CMD.Write(Profile.post_process, 3);
                CMD.Write(Profile.lighting, 7);
                CMD.Write(Profile.fx, 5);
                b2.ToggleButton(false);
            }
        }
        
        private void b3_ValueChanged(object sender, EventArgs e)
        {
            Profile.var_r_specularMap = b3.Value;
            CMD.ReadWrite(Profile.r_specularMap, Profile.var_r_specularMap);
        }

        private void b4_Click(object sender, EventArgs e)
        {
            if (!Profile.var_r_drawDecals)
            {
                Profile.var_r_drawDecals = true;
                CMD.ReadWrite(Profile.r_drawDecals, Profile.var_r_drawDecals);
                b4.ToggleButton(true);
            }
            else
            {
                Profile.var_r_drawDecals = false;
                CMD.ReadWrite(Profile.r_drawDecals, Profile.var_r_drawDecals);
                b4.ToggleButton(false);
            }
        }

        private void b5_Click(object sender, EventArgs e)
        {
            if (!Profile.var_sm_enable)
            {
                Profile.var_sm_enable = true;
                CMD.ReadWrite(Profile.sm_enable, Profile.var_sm_enable);
                b5.ToggleButton(true);
            }
            else
            {
                Profile.var_sm_enable = false;
                CMD.ReadWrite(Profile.sm_enable, Profile.var_sm_enable);
                b5.ToggleButton(false);
            }
        }

        private void b6_Click(object sender, EventArgs e)
        {
            if (!Profile.var_r_detail)
            {
                Profile.var_r_detail = true;
                CMD.ReadWrite(Profile.r_detail, Profile.var_r_detail);
                b6.ToggleButton(true);
            }
            else
            {
                Profile.var_r_detail = false;
                CMD.ReadWrite(Profile.r_detail, Profile.var_r_detail);
                b6.ToggleButton(false);
            }
        }

        private void b7_Click(object sender, EventArgs e)
        {
            if (!Profile.var_r_normal)
            {
                Profile.var_r_normal = true;
                CMD.ReadWrite(Profile.r_normal, Profile.var_r_normal);
                b7.ToggleButton(true);
            }
            else
            {
                Profile.var_r_normal = false;
                CMD.ReadWrite(Profile.r_normal, Profile.var_r_normal);
                b7.ToggleButton(false);
            }
        }

        public void LoadButtons()
        {
            if (Profile.var_fx_enable)
                b0.ToggleButton(true);
            else
                b0.ToggleButton(false);

            if (Profile.var_r_specular)
                b1.ToggleButton(true);
            else
                b1.ToggleButton(false);

            if (Profile.var_r_fullbright)
                b2.ToggleButton(true);
            else
                b2.ToggleButton(false);

            b3.Value = Profile.var_r_specularMap;

            if (Profile.var_r_drawDecals)
                b4.ToggleButton(true);
            else
                b4.ToggleButton(false);

            if (Profile.var_sm_enable)
                b5.ToggleButton(true);
            else
                b5.ToggleButton(false);

            if (Profile.var_r_detail)
                b6.ToggleButton(true);
            else
                b6.ToggleButton(false);

            if (Profile.var_r_normal)
                b7.ToggleButton(true);
            else
                b7.ToggleButton(false);
        }
    }
}
