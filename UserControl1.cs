using cod4_memory;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace form_hack
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        private void b0_Click(object sender, EventArgs e)
        {
            if (!Profile.var_cg_drawFps)
            {
                Profile.var_cg_drawFps = true;
                Command cmd = new Command();
                cmd.command_rw(Profile.cg_drawFps, Profile.var_cg_drawFps);
                b0.Normalcolor = Color.FromArgb(46, 139, 87);
                b0.OnHovercolor = Color.FromArgb(46, 139, 87);
                b0.Activecolor = Color.FromArgb(46, 139, 87);
            }

            else
            {
                Profile.var_cg_drawFps = false;
                Command cmd = new Command();
                cmd.command_rw(Profile.cg_drawFps, Profile.var_cg_drawFps);
                b0.Normalcolor = Color.FromArgb(178, 34, 34);
                b0.OnHovercolor = Color.FromArgb(178, 34, 34);
                b0.Activecolor = Color.FromArgb(178, 34, 34);
            }
        }

        private void b1_Click(object sender, EventArgs e)
        {
            if (!Profile.var_cg_draw2D)
            {
                Profile.var_cg_draw2D = true;
                Command cmd = new Command();
                cmd.command_rw(Profile.cg_draw2D, Profile.var_cg_draw2D);
                b1.Normalcolor = Color.FromArgb(46, 139, 87);
                b1.OnHovercolor = Color.FromArgb(46, 139, 87);
                b1.Activecolor = Color.FromArgb(46, 139, 87);
            }

            else
            {
                Profile.var_cg_draw2D = false;
                Command cmd = new Command();
                cmd.command_rw(Profile.cg_draw2D, Profile.var_cg_draw2D);
                b1.Normalcolor = Color.FromArgb(178, 34, 34);
                b1.OnHovercolor = Color.FromArgb(178, 34, 34);
                b1.Activecolor = Color.FromArgb(178, 34, 34);
            }
        }

        private void b2_Click(object sender, EventArgs e)
        {
            if (!Profile.var_cg_laserForceOn)
            {
                Profile.var_cg_laserForceOn = true;
                Command cmd = new Command();
                cmd.command_rw(Profile.cg_laserForceOn, Profile.var_cg_laserForceOn);
                b2.Normalcolor = Color.FromArgb(46, 139, 87);
                b2.OnHovercolor = Color.FromArgb(46, 139, 87);
                b2.Activecolor = Color.FromArgb(46, 139, 87);
            }

            else
            {
                Profile.var_cg_laserForceOn = false;
                Command cmd = new Command();
                cmd.command_rw(Profile.cg_laserForceOn, Profile.var_cg_laserForceOn);
                b2.Normalcolor = Color.FromArgb(178, 34, 34);
                b2.OnHovercolor = Color.FromArgb(178, 34, 34);
                b2.Activecolor = Color.FromArgb(178, 34, 34);
            }
        }

        private void b3_Click(object sender, EventArgs e)
        {
            if (!Profile.var_hud_enable)
            {
                Profile.var_hud_enable = true;
                Command cmd = new Command();
                cmd.command_rw(Profile.hud_enable, Profile.var_hud_enable);
                b3.Normalcolor = Color.FromArgb(46, 139, 87);
                b3.OnHovercolor = Color.FromArgb(46, 139, 87);
                b3.Activecolor = Color.FromArgb(46, 139, 87);
            }

            else
            {
                Profile.var_hud_enable = false;
                Command cmd = new Command();
                cmd.command_rw(Profile.hud_enable, Profile.var_hud_enable);
                b3.Normalcolor = Color.FromArgb(178, 34, 34);
                b3.OnHovercolor = Color.FromArgb(178, 34, 34);
                b3.Activecolor = Color.FromArgb(178, 34, 34);
            }
        }

        private void b4_Click(object sender, EventArgs e)
        {
            if (Profile.var_player_sprintCameraBob == 0f)
            {
                Profile.var_player_sprintCameraBob = 0.5f;
                Command cmd = new Command();
                cmd.command_rw(Profile.player_sprintCameraBob, Profile.var_player_sprintCameraBob);
                b4.Normalcolor = Color.FromArgb(46, 139, 87);
                b4.OnHovercolor = Color.FromArgb(46, 139, 87);
                b4.Activecolor = Color.FromArgb(46, 139, 87);
            }

            else
            {
                Profile.var_player_sprintCameraBob = 0f;
                Command cmd = new Command();
                cmd.command_rw(Profile.player_sprintCameraBob, Profile.var_player_sprintCameraBob);
                b4.Normalcolor = Color.FromArgb(178, 34, 34);
                b4.OnHovercolor = Color.FromArgb(178, 34, 34);
                b4.Activecolor = Color.FromArgb(178, 34, 34);
            }
        }

        private void b0_Load(object sender, EventArgs e)
        {
            if (Profile.var_cg_drawFps)
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
            if (Profile.var_cg_draw2D)
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
            if (Profile.var_cg_laserForceOn)
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
            if (Profile.var_hud_enable)
            {
                b3.Normalcolor = Color.FromArgb(46, 139, 87);
                b3.OnHovercolor = Color.FromArgb(46, 139, 87);
                b3.Activecolor = Color.FromArgb(46, 139, 87);
            }

            else
            {
                b3.Normalcolor = Color.FromArgb(178, 34, 34);
                b3.OnHovercolor = Color.FromArgb(178, 34, 34);
                b3.Activecolor = Color.FromArgb(178, 34, 34);
            }
        }

        private void b4_Load(object sender, EventArgs e)
        {
            if (Profile.var_player_sprintCameraBob == 0.5f)
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
    }
}
