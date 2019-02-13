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
        }

        private void b0_Click(object sender, EventArgs e)
        {
            if (!Profile.var_fx_enable)
            {
                Profile.var_fx_enable = true;
                CMD.command_rw(Profile.fx_enable, Profile.var_fx_enable);
                b0.ToggleButton(true);
            }

            else
            {
                Profile.var_fx_enable = false;
                CMD.command_rw(Profile.fx_enable, Profile.var_fx_enable);
                b0.ToggleButton(false);
            }
        }

        private void b1_Click(object sender, EventArgs e)
        {
            if (!Profile.var_r_specular)
            {
                Profile.var_r_specular = true;
                CMD.command_rw(Profile.r_specular, Profile.var_r_specular);
                b1.ToggleButton(true);
            }

            else
            {
                Profile.var_r_specular = false;
                CMD.command_rw(Profile.r_specular, Profile.var_r_specular);
                b1.ToggleButton(false);
            }
        }

        private void b2_Click(object sender, EventArgs e)
        {
            if (!Profile.var_r_fullbright)
            {
                Profile.var_r_fullbright = true;
                CMD.command_rw(Profile.r_fullbright, Profile.var_r_fullbright);
                CMD.command_w(Profile.post_process, 1);
                CMD.command_w(Profile.lighting, 4);
                CMD.command_w(Profile.fx, 4);
                b2.ToggleButton(true);
            }

            else
            {
                Profile.var_r_fullbright = false;
                CMD.command_rw(Profile.r_fullbright, Profile.var_r_fullbright);
                CMD.command_w(Profile.post_process, 3);
                CMD.command_w(Profile.lighting, 7);
                CMD.command_w(Profile.fx, 5);
                b2.ToggleButton(false);
            }
        }
        
        private void b3_ValueChanged(object sender, EventArgs e)
        {
            Profile.var_r_specularMap = b3.Value;
            CMD.command_rw(Profile.r_specularMap, Profile.var_r_specularMap);
        }

        private void b4_Click(object sender, EventArgs e)
        {
            if (!Profile.var_r_drawDecals)
            {
                Profile.var_r_drawDecals = true;
                CMD.command_rw(Profile.r_drawDecals, Profile.var_r_drawDecals);
                b4.ToggleButton(true);
            }

            else
            {
                Profile.var_r_drawDecals = false;
                CMD.command_rw(Profile.r_drawDecals, Profile.var_r_drawDecals);
                b4.ToggleButton(false);
            }
        }

        private void b5_Click(object sender, EventArgs e)
        {
            if (!Profile.var_sm_enable)
            {
                Profile.var_sm_enable = true;
                CMD.command_rw(Profile.sm_enable, Profile.var_sm_enable);
                b5.ToggleButton(true);
            }

            else
            {
                Profile.var_sm_enable = false;
                CMD.command_rw(Profile.sm_enable, Profile.var_sm_enable);
                b5.ToggleButton(false);
            }
        }

        private void b6_Click(object sender, EventArgs e)
        {
            if (!Profile.var_r_detail)
            {
                Profile.var_r_detail = true;
                CMD.command_rw(Profile.r_detail, Profile.var_r_detail);
                b6.ToggleButton(true);
            }

            else
            {
                Profile.var_r_detail = false;
                CMD.command_rw(Profile.r_detail, Profile.var_r_detail);
                b6.ToggleButton(false);
            }
        }

        private void b7_Click(object sender, EventArgs e)
        {
            if (!Profile.var_r_normal)
            {
                Profile.var_r_normal = true;
                CMD.command_rw(Profile.r_normal, Profile.var_r_normal);
                b7.ToggleButton(true);
            }

            else
            {
                Profile.var_r_normal = false;
                CMD.command_rw(Profile.r_normal, Profile.var_r_normal);
                b7.ToggleButton(false);
            }
        }

        private void b0_Load(object sender, EventArgs e)
        {
            if (Profile.var_fx_enable)
                b0.ToggleButton(true);

            else
                b0.ToggleButton(false);
        }

        private void b1_Load(object sender, EventArgs e)
        {
            if (Profile.var_r_specular)
                b1.ToggleButton(true);

            else
                b1.ToggleButton(false);
        }

        private void b2_Load(object sender, EventArgs e)
        {
            if (Profile.var_r_fullbright)
                b2.ToggleButton(true);

            else
                b2.ToggleButton(false);
        }

        private void b3_Load(object sender, EventArgs e)
        {
            b3.Value = Profile.var_r_specularMap;
        }

        private void b4_Load(object sender, EventArgs e)
        {
            if (Profile.var_r_drawDecals)
                b4.ToggleButton(true);

            else
                b4.ToggleButton(false);
        }

        private void b5_Load(object sender, EventArgs e)
        {
            if (Profile.var_sm_enable)
                b5.ToggleButton(true);

            else
                b5.ToggleButton(false);
        }

        private void b6_Load(object sender, EventArgs e)
        {
            if (Profile.var_r_detail)
                b6.ToggleButton(true);

            else
                b6.ToggleButton(false);
        }

        private void b7_Load(object sender, EventArgs e)
        {
            if (Profile.var_r_normal)
                b7.ToggleButton(true);

            else
                b7.ToggleButton(false);
        }
    }
}
