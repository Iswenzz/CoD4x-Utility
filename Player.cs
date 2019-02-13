using System;
using System.Windows.Forms;

using Iswenzz.CoD4.Utility.Command;
using Iswenzz.CoD4.Utility.Profiles;

namespace Iswenzz.CoD4.Utility
{
    public partial class Player : UserControl
    {
        public Player()
        {
            InitializeComponent();
        }

        private void b0_Click(object sender, EventArgs e)
        {
            if (!Profile.var_cg_drawFps)
            {
                Profile.var_cg_drawFps = true;
                CMD.command_rw(Profile.cg_drawFps, Profile.var_cg_drawFps);
                b0.ToggleButton(true);
            }

            else
            {
                Profile.var_cg_drawFps = false;
                CMD.command_rw(Profile.cg_drawFps, Profile.var_cg_drawFps);
                b0.ToggleButton(false);
            }
        }

        private void b1_Click(object sender, EventArgs e)
        {
            if (!Profile.var_cg_draw2D)
            {
                Profile.var_cg_draw2D = true;
                CMD.command_rw(Profile.cg_draw2D, Profile.var_cg_draw2D);
                b1.ToggleButton(true);
            }

            else
            {
                Profile.var_cg_draw2D = false;
                CMD.command_rw(Profile.cg_draw2D, Profile.var_cg_draw2D);
                b1.ToggleButton(false);
            }
        }

        private void b2_Click(object sender, EventArgs e)
        {
            if (!Profile.var_cg_laserForceOn)
            {
                Profile.var_cg_laserForceOn = true;
                CMD.command_rw(Profile.cg_laserForceOn, Profile.var_cg_laserForceOn);
                b2.ToggleButton(true);
            }

            else
            {
                Profile.var_cg_laserForceOn = false;
                CMD.command_rw(Profile.cg_laserForceOn, Profile.var_cg_laserForceOn);
                b2.ToggleButton(false);
            }
        }

        private void b3_Click(object sender, EventArgs e)
        {
            if (!Profile.var_hud_enable)
            {
                Profile.var_hud_enable = true;
                CMD.command_rw(Profile.hud_enable, Profile.var_hud_enable);
                b3.ToggleButton(true);
            }

            else
            {
                Profile.var_hud_enable = false;
                CMD.command_rw(Profile.hud_enable, Profile.var_hud_enable);
                b3.ToggleButton(false);
            }
        }

        private void b4_Click(object sender, EventArgs e)
        {
            if (Profile.var_player_sprintCameraBob == 0f)
            {
                Profile.var_player_sprintCameraBob = 0.5f;
                CMD.command_rw(Profile.player_sprintCameraBob, Profile.var_player_sprintCameraBob);
                b4.ToggleButton(true);
            }

            else
            {
                Profile.var_player_sprintCameraBob = 0f;
                CMD.command_rw(Profile.player_sprintCameraBob, Profile.var_player_sprintCameraBob);
                b4.ToggleButton(false);
            }
        }

        private void b0_Load(object sender, EventArgs e)
        {
            if (Profile.var_cg_drawFps)
                b0.ToggleButton(true);

            else
                b0.ToggleButton(false);
        }

        private void b1_Load(object sender, EventArgs e)
        {
            if (Profile.var_cg_draw2D)
                b1.ToggleButton(true);

            else
                b1.ToggleButton(false);
        }

        private void b2_Load(object sender, EventArgs e)
        {
            if (Profile.var_cg_laserForceOn)
                b2.ToggleButton(true);

            else
                b2.ToggleButton(false);
        }

        private void b3_Load(object sender, EventArgs e)
        {
            if (Profile.var_hud_enable)
                b3.ToggleButton(true);

            else
                b3.ToggleButton(false);
        }

        private void b4_Load(object sender, EventArgs e)
        {
            if (Profile.var_player_sprintCameraBob == 0.5f)
                b4.ToggleButton(true);

            else
                b4.ToggleButton(false);
        }
    }
}
