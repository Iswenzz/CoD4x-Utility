using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iswenzz.CoD4.Utility.Profiles
{
    /// <remarks>
    /// Add CoD4 commands here, with the right name.
    /// Be sure to add the command variable in Variables.cs and the command address in Addresses.cs
    /// </remarks>
    public static partial class Profile
    {
        /// <summary>
        /// List used to get variables and addresses with Reflection.
        /// </summary>
        public static List<string> Commands = new List<string>
        {
            // Player
            "cg_drawFps",
            "cg_draw2D",
            "cg_laserForceOn",
            "hud_enable",
            "player_sprintCameraBob",
            // Graphics
            "fx_enable",
            "r_fullbright",
            "r_drawDecals",
            "r_detail",
            "r_specular",
            "r_specularMap",
            "sm_enable",
            "r_normal",
            // Viewmodel
            "cg_gun_x",
            "cg_gun_y",
            "cg_gun_z",
            "cg_fov",
            "cg_fovScale",
            // Vision
            "r_filmUseTweaks",
            "r_filmTweakEnable",
            "r_filmTweakBrightness",
            "r_filmTweakContrast",
            "r_filmTweakDesaturation",
            "r_filmTweakLightTint",
            "r_filmTweakDarkTint",
            // Not Implemented
            /*"r_lightTweakSunLight",
            "r_lightTweakSunColor",
            "r_lightTweakSunDiffuseColor",
            "r_lightTweakSunDirection",*/
        };
    }
}
