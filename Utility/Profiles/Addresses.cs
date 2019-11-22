namespace Iswenzz.CoD4.Utility.Profiles
{
    /// <remarks>
    /// Add CoD4 commands here, with the right name.
    /// Array[0] = Address
    /// Array[+] = Offsets
    /// </remarks>
    public static partial class Profile
    {
        // Background
        public static uint[] post_process = new uint[]              { 0xD584070, 0x0 };
        public static uint[] lighting = new uint[]                  { 0xD584074, 0x0 };
        public static uint[] fx = new uint[]                        { 0xD584078, 0x0 };
        // Player
        public static uint[] cg_drawFps = new uint[]                { 0x748634, 0xC };
        public static uint[] cg_draw2D = new uint[]                 { 0x74A8BC, 0xC };
        public static uint[] cg_laserForceOn = new uint[]           { 0x8C62FC, 0xC };
        public static uint[] hud_enable = new uint[]                { 0x8C9468, 0xC };
        public static uint[] player_sprintCameraBob = new uint[]    { 0x734B7C, 0xC };
        // Graphics
        public static uint[] fx_enable = new uint[]                 { 0x110CE88, 0xC };
        public static uint[] r_specular = new uint[]                { 0xD56958C, 0xC };
        public static uint[] r_fullbright = new uint[]              { 0xD569680, 0xC };
        public static uint[] r_specularMap = new uint[]             { 0xD5696B4, 0xC };
        public static uint[] r_drawDecals = new uint[]              { 0xD5697C4, 0xC };
        public static uint[] sm_enable = new uint[]                 { 0xD56971C, 0xC };
        public static uint[] r_detail = new uint[]                  { 0xD5696CC, 0xC };
        public static uint[] r_normal = new uint[]                  { 0xD569764, 0xC };
        // Viewmodel
        public static uint[] cg_gun_x = new uint[]                  { 0x74A8C0, 0xC };
        public static uint[] cg_gun_y = new uint[]                  { 0x746FA0, 0xC };
        public static uint[] cg_gun_z = new uint[]                  { 0x74A86C, 0xC };
        public static uint[] cg_fov = new uint[]                    { 0x8C93D8, 0xC };
        public static uint[] cg_fovScale = new uint[]               { 0x8C62E4, 0xC };
        // Vision
        public static uint[] r_filmUseTweaks = new uint[]           { 0xD5695D8, 0xC };
        public static uint[] r_filmTweakEnable = new uint[]         { 0xD569700, 0xC };
        public static uint[] r_filmTweakBrightness = new uint[]     { 0xD5697D4, 0xC };
        public static uint[] r_filmTweakContrast = new uint[]       { 0xD569694, 0xC };
        public static uint[] r_filmTweakDesaturation = new uint[]   { 0xD569698, 0xC };
        public static uint[] r_filmTweakLightTint = new uint[]      { 0xD5696F0, 0xC, 0x10, 0x14 };
        public static uint[] r_filmTweakDarkTint = new uint[]       { 0xD569758, 0xC, 0x10, 0x14 };
        // Not implemented
        public static uint[] r_lightTweakSunLight = new uint[]      { 0xD569588, 0xC };
        public static uint[] r_lightTweakSunColor = new uint[]      { 0xD56974C, 0x10, 0x14, 0x18 };
        public static uint[] r_lightTweakSunDiffuseColor = new uint[] { 0xD56973C, 0x10, 0x14, 0x18 };
        public static uint[] r_lightTweakSunDirection = new uint[]  { 0xD5696EC, 0xC, 0x10, 0x14 };
    }
}
