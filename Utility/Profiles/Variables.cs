namespace Iswenzz.CoD4.Utility.Profiles
{
    /// <remarks>
    /// Add CoD4 commands here, with the right name and var_ at the beginning and a default value.
    /// </remarks>
    public static partial class Profile
    {
        // Player
        public static bool var_cg_drawFps = true;
        public static bool var_cg_draw2D = true;
        public static bool var_cg_laserForceOn = false;
        public static bool var_hud_enable = true;
        public static float var_player_sprintCameraBob = 0.5f;
        // Graphics
        public static bool var_fx_enable = true;
        public static bool var_r_fullbright = false;
        public static bool var_r_drawDecals = true;
        public static bool var_r_detail = true;
        public static bool var_r_specular = true;
        public static int var_r_specularMap = 1;
        public static bool var_sm_enable = false;
        public static bool var_r_normal = true;
        // Viewmodel
        public static float var_cg_gun_x = 0f;
        public static float var_cg_gun_y = 0f;
        public static float var_cg_gun_z = 0f;
        public static float var_cg_fov = 80f;
        public static float var_cg_fovScale = 1f;
        // Vision
        public static bool var_r_filmUseTweaks = false;
        public static bool var_r_filmTweakEnable = false;
        public static float var_r_filmTweakBrightness = 0f;
        public static float var_r_filmTweakContrast = 1f;
        public static float var_r_filmTweakDesaturation = 1f;
        public static float[] var_r_filmTweakLightTint = new float[] { 1f, 1f, 1f };
        public static float[] var_r_filmTweakDarkTint = new float[] { 1f, 1f, 1f };
        // Not Implemented
        public static float var_r_lightTweakSunLight = 1f;
        public static float[] var_r_lightTweakSunColor = new float[] { 0f, 1f, 0f };
        public static float[] var_r_lightTweakSunDiffuseColor = new float[] { 0f, 0f, 1f };
        public static float[] var_r_lightTweakSunDirection = new float[] { 0f, 0f, 0f };
    }
}
