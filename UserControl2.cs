using System;
using System.Drawing;
using System.Windows.Forms;
using cod4_memory;

namespace form_hack
{
    public partial class UserControl2 : UserControl
    {
        public UserControl2()
        {
            InitializeComponent();
        }

        private void b0_Click(object sender, EventArgs e)
        {
            if (!Profile.var_fx_enable)
            {
                Profile.var_fx_enable = true;
                Command cmd = new Command();
                cmd.command_rw(Profile.fx_enable, Profile.var_fx_enable);
                b0.Normalcolor = Color.FromArgb(46, 139, 87);
                b0.OnHovercolor = Color.FromArgb(46, 139, 87);
                b0.Activecolor = Color.FromArgb(46, 139, 87);
            }

            else
            {
                Profile.var_fx_enable = false;
                Command cmd = new Command();
                cmd.command_rw(Profile.fx_enable, Profile.var_fx_enable);
                b0.Normalcolor = Color.FromArgb(178, 34, 34);
                b0.OnHovercolor = Color.FromArgb(178, 34, 34);
                b0.Activecolor = Color.FromArgb(178, 34, 34);
            }
        }

        private void b1_Click(object sender, EventArgs e)
        {
            if (!Profile.var_r_specular)
            {
                Profile.var_r_specular = true;
                Command cmd = new Command();
                cmd.command_rw(Profile.r_specular, Profile.var_r_specular);
                b1.Normalcolor = Color.FromArgb(46, 139, 87);
                b1.OnHovercolor = Color.FromArgb(46, 139, 87);
                b1.Activecolor = Color.FromArgb(46, 139, 87);
            }

            else
            {
                Profile.var_r_specular = false;
                Command cmd = new Command();
                cmd.command_rw(Profile.r_specular, Profile.var_r_specular);
                b1.Normalcolor = Color.FromArgb(178, 34, 34);
                b1.OnHovercolor = Color.FromArgb(178, 34, 34);
                b1.Activecolor = Color.FromArgb(178, 34, 34);
            }
        }

        private void b2_Click(object sender, EventArgs e)
        {
            if (!Profile.var_r_fullbright)
            {
                Profile.var_r_fullbright = true;
                Command cmd = new Command();
                cmd.command_rw(Profile.r_fullbright, Profile.var_r_fullbright);
                cmd.command_w(Profile.post_process, 1);
                cmd.command_w(Profile.lighting, 4);
                cmd.command_w(Profile.fx, 4);
                b2.Normalcolor = Color.FromArgb(46, 139, 87);
                b2.OnHovercolor = Color.FromArgb(46, 139, 87);
                b2.Activecolor = Color.FromArgb(46, 139, 87);
            }

            else
            {
                Profile.var_r_fullbright = false;
                Command cmd = new Command();
                cmd.command_rw(Profile.r_fullbright, Profile.var_r_fullbright);
                cmd.command_w(Profile.post_process, 3);
                cmd.command_w(Profile.lighting, 7);
                cmd.command_w(Profile.fx, 5);
                b2.Normalcolor = Color.FromArgb(178, 34, 34);
                b2.OnHovercolor = Color.FromArgb(178, 34, 34);
                b2.Activecolor = Color.FromArgb(178, 34, 34);
            }
        }
        
        private void b3_ValueChanged(object sender, EventArgs e)
        {
            Profile.var_r_specularMap = b3.Value;
            Command cmd = new Command();
            cmd.command_rw(Profile.r_specularMap, Profile.var_r_specularMap);
        }

        private void b4_Click(object sender, EventArgs e)
        {
            if (!Profile.var_r_drawDecals)
            {
                Profile.var_r_drawDecals = true;
                Command cmd = new Command();
                cmd.command_rw(Profile.r_drawDecals, Profile.var_r_drawDecals);
                b4.Normalcolor = Color.FromArgb(46, 139, 87);
                b4.OnHovercolor = Color.FromArgb(46, 139, 87);
                b4.Activecolor = Color.FromArgb(46, 139, 87);
            }

            else
            {
                Profile.var_r_drawDecals = false;
                Command cmd = new Command();
                cmd.command_rw(Profile.r_drawDecals, Profile.var_r_drawDecals);
                b4.Normalcolor = Color.FromArgb(178, 34, 34);
                b4.OnHovercolor = Color.FromArgb(178, 34, 34);
                b4.Activecolor = Color.FromArgb(178, 34, 34);
            }
        }

        private void b5_Click(object sender, EventArgs e)
        {
            if (!Profile.var_sm_enable)
            {
                Profile.var_sm_enable = true;
                Command cmd = new Command();
                cmd.command_rw(Profile.sm_enable, Profile.var_sm_enable);
                b5.Normalcolor = Color.FromArgb(46, 139, 87);
                b5.OnHovercolor = Color.FromArgb(46, 139, 87);
                b5.Activecolor = Color.FromArgb(46, 139, 87);
            }

            else
            {
                Profile.var_sm_enable = false;
                Command cmd = new Command();
                cmd.command_rw(Profile.sm_enable, Profile.var_sm_enable);
                b5.Normalcolor = Color.FromArgb(178, 34, 34);
                b5.OnHovercolor = Color.FromArgb(178, 34, 34);
                b5.Activecolor = Color.FromArgb(178, 34, 34);
            }
        }

        private void b6_Click(object sender, EventArgs e)
        {
            if (!Profile.var_r_detail)
            {
                Profile.var_r_detail = true;
                Command cmd = new Command();
                cmd.command_rw(Profile.r_detail, Profile.var_r_detail);
                b6.Normalcolor = Color.FromArgb(46, 139, 87);
                b6.OnHovercolor = Color.FromArgb(46, 139, 87);
                b6.Activecolor = Color.FromArgb(46, 139, 87);
            }

            else
            {
                Profile.var_r_detail = false;
                Command cmd = new Command();
                cmd.command_rw(Profile.r_detail, Profile.var_r_detail);
                b6.Normalcolor = Color.FromArgb(178, 34, 34);
                b6.OnHovercolor = Color.FromArgb(178, 34, 34);
                b6.Activecolor = Color.FromArgb(178, 34, 34);
            }
        }

        private void b7_Click(object sender, EventArgs e)
        {
            if (!Profile.var_r_normal)
            {
                Profile.var_r_normal = true;
                Command cmd = new Command();
                cmd.command_rw(Profile.r_normal, Profile.var_r_normal);
                b7.Normalcolor = Color.FromArgb(46, 139, 87);
                b7.OnHovercolor = Color.FromArgb(46, 139, 87);
                b7.Activecolor = Color.FromArgb(46, 139, 87);
            }

            else
            {
                Profile.var_r_normal = false;
                Command cmd = new Command();
                cmd.command_rw(Profile.r_normal, Profile.var_r_normal);
                b7.Normalcolor = Color.FromArgb(178, 34, 34);
                b7.OnHovercolor = Color.FromArgb(178, 34, 34);
                b7.Activecolor = Color.FromArgb(178, 34, 34);
            }
        }

        private void b0_Load(object sender, EventArgs e)
        {
            if (Profile.var_fx_enable)
            {
                b0.Normalcolor = Color.FromArgb(46, 139, 87);
                b0.OnHovercolor = Color.FromArgb(46, 139, 87);
                b0.Activecolor = Color.FromArgb(46, 139, 87);
            }

            else
            {
                b0.Normalcolor = Color.FromArgb(178, 34, 34);
                b0.OnHovercolor = Color.FromArgb(178, 34, 34);
                b0.Activecolor = Color.FromArgb(178, 34, 34);
            }
        }

        private void b1_Load(object sender, EventArgs e)
        {
            if (Profile.var_r_specular)
            {
                b1.Normalcolor = Color.FromArgb(46, 139, 87);
                b1.OnHovercolor = Color.FromArgb(46, 139, 87);
                b1.Activecolor = Color.FromArgb(46, 139, 87);
            }

            else
            {
                b1.Normalcolor = Color.FromArgb(178, 34, 34);
                b1.OnHovercolor = Color.FromArgb(178, 34, 34);
                b1.Activecolor = Color.FromArgb(178, 34, 34);
            }
        }

        private void b2_Load(object sender, EventArgs e)
        {
            if (Profile.var_r_fullbright)
            {
                b2.Normalcolor = Color.FromArgb(46, 139, 87);
                b2.OnHovercolor = Color.FromArgb(46, 139, 87);
                b2.Activecolor = Color.FromArgb(46, 139, 87);
            }

            else
            {
                b2.Normalcolor = Color.FromArgb(178, 34, 34);
                b2.OnHovercolor = Color.FromArgb(178, 34, 34);
                b2.Activecolor = Color.FromArgb(178, 34, 34);
            }
        }

        private void b3_Load(object sender, EventArgs e)
        {
            b3.Value = Profile.var_r_specularMap;
        }

        private void b4_Load(object sender, EventArgs e)
        {
            if (Profile.var_r_drawDecals)
            {
                b4.Normalcolor = Color.FromArgb(46, 139, 87);
                b4.OnHovercolor = Color.FromArgb(46, 139, 87);
                b4.Activecolor = Color.FromArgb(46, 139, 87);
            }

            else
            {
                b4.Normalcolor = Color.FromArgb(178, 34, 34);
                b4.OnHovercolor = Color.FromArgb(178, 34, 34);
                b4.Activecolor = Color.FromArgb(178, 34, 34);
            }
        }

        private void b5_Load(object sender, EventArgs e)
        {
            if (Profile.var_sm_enable)
            {
                b5.Normalcolor = Color.FromArgb(46, 139, 87);
                b5.OnHovercolor = Color.FromArgb(46, 139, 87);
                b5.Activecolor = Color.FromArgb(46, 139, 87);
            }

            else
            {
                b5.Normalcolor = Color.FromArgb(178, 34, 34);
                b5.OnHovercolor = Color.FromArgb(178, 34, 34);
                b5.Activecolor = Color.FromArgb(178, 34, 34);
            }
        }

        private void b6_Load(object sender, EventArgs e)
        {
            if (Profile.var_r_detail)
            {
                b6.Normalcolor = Color.FromArgb(46, 139, 87);
                b6.OnHovercolor = Color.FromArgb(46, 139, 87);
                b6.Activecolor = Color.FromArgb(46, 139, 87);
            }

            else
            {
                b6.Normalcolor = Color.FromArgb(178, 34, 34);
                b6.OnHovercolor = Color.FromArgb(178, 34, 34);
                b6.Activecolor = Color.FromArgb(178, 34, 34);
            }
        }

        private void b7_Load(object sender, EventArgs e)
        {
            if (Profile.var_r_normal)
            {
                b7.Normalcolor = Color.FromArgb(46, 139, 87);
                b7.OnHovercolor = Color.FromArgb(46, 139, 87);
                b7.Activecolor = Color.FromArgb(46, 139, 87);
            }

            else
            {
                b7.Normalcolor = Color.FromArgb(178, 34, 34);
                b7.OnHovercolor = Color.FromArgb(178, 34, 34);
                b7.Activecolor = Color.FromArgb(178, 34, 34);
            }
        }
    }
}
