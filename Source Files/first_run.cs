using MemoryApi;
using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using cod4_memory;

namespace first_run
{
    public class First_Run : Profile
    {
        public static void First_Load()
        {
            Command cmd = new Command();

            // Player
            var_cg_drawFps = cmd.command_rr(cg_drawFps, var_cg_drawFps);
            var_cg_draw2D = cmd.command_rr(cg_draw2D, var_cg_draw2D);
            var_cg_laserForceOn = cmd.command_rr(cg_laserForceOn, var_cg_laserForceOn);
            var_hud_enable = cmd.command_rr(hud_enable, var_hud_enable);
            var_player_sprintCameraBob = cmd.command_rr(player_sprintCameraBob, var_player_sprintCameraBob);
            
            // Graphics
            var_fx_enable = cmd.command_rr(fx_enable, var_fx_enable);
            var_r_specular = cmd.command_rr(r_specular, var_r_specular);
            var_r_fullbright = cmd.command_rr(r_fullbright, var_r_fullbright);
            var_r_specularMap = cmd.command_rr(r_specularMap, var_r_specularMap);
            var_r_drawDecals = cmd.command_rr(r_drawDecals, var_r_drawDecals);
            var_sm_enable = cmd.command_rr(sm_enable, var_sm_enable);
            var_r_detail = cmd.command_rr(r_detail, var_r_detail);
            var_r_normal = cmd.command_rr(r_normal, var_r_normal);
            
            // Viewmodel
            var_cg_gun_x = cmd.command_rr(cg_gun_x, var_cg_gun_x);
            var_cg_gun_y = cmd.command_rr(cg_gun_y, var_cg_gun_y);
            var_cg_gun_z = cmd.command_rr(cg_gun_z, var_cg_gun_z);
            var_cg_fov = cmd.command_rr(cg_fov, var_cg_fov);
            var_cg_fovScale = cmd.command_rr(cg_fovScale, var_cg_fovScale);
            
            // Vision
            var_r_filmTweakLightTint = cmd.command_vector_rr(r_filmTweakLightTint, var_r_filmTweakLightTint);
            var_r_filmTweakDarkTint = cmd.command_vector_rr(r_filmTweakDarkTint, var_r_filmTweakDarkTint);
            /*var_r_lightTweakSunColor = cmd.command_vector_rr(r_lightTweakSunColor, var_r_lightTweakSunColor);
            var_r_lightTweakSunDiffuseColor = cmd.command_vector_rr(r_lightTweakSunDiffuseColor, var_r_lightTweakSunDiffuseColor);
            var_r_lightTweakSunDirection = cmd.command_vector_rr(r_lightTweakSunDirection, var_r_lightTweakSunDirection);
            var_r_lightTweakSunLight = cmd.command_rr(r_lightTweakSunLight, var_r_lightTweakSunLight);*/
            var_r_filmTweakBrightness = cmd.command_rr(r_filmTweakBrightness, var_r_filmTweakBrightness);
            var_r_filmTweakContrast = cmd.command_rr(r_filmTweakContrast, var_r_filmTweakContrast);
            var_r_filmTweakDesaturation = cmd.command_rr(r_filmTweakDesaturation, var_r_filmTweakDesaturation);
            var_r_filmTweakEnable = cmd.command_rr(r_filmUseTweaks, var_r_filmUseTweaks);

            isFirstTime = false;
            Save();
            Application.Restart();
        }
    }

    public class Command
    {
        ProcessMemoryReader mreader = new ProcessMemoryReader();

        int NULL = 0;

        // command read read
        public bool command_rr(uint[] array, bool var)
        {
            Process process = Process.GetProcessesByName("iw3mp").ToList().FirstOrDefault();

            uint Base_Address = array[0];
            uint Offset = array[1];
            uint Value = Convert.ToUInt32(var);

            if (process != null)
            {
                mreader.ReadProcess = process;
                mreader.OpenProcess();

                uint Address = BitConverter.ToUInt32(mreader.ReadMemory((IntPtr)Base_Address, sizeof(uint), out NULL), 0);
                uint Target = Address + Offset;

                uint val = BitConverter.ToUInt32(mreader.ReadMemory((IntPtr)Target, sizeof(uint), out NULL), 0);
                bool ret = Convert.ToBoolean(val);

                return ret;
            }

            return false;
        }

        public float command_rr(uint[] array, float var)
        {
            Process process = Process.GetProcessesByName("iw3mp").ToList().FirstOrDefault();

            uint Base_Address = array[0];
            uint Offset = array[1];
            float Value = var;

            if (process != null)
            {
                mreader.ReadProcess = process;
                mreader.OpenProcess();

                uint Address = BitConverter.ToUInt32(mreader.ReadMemory((IntPtr)Base_Address, sizeof(uint), out NULL), 0);
                uint Target = Address + Offset;

                float val = BitConverter.ToSingle(mreader.ReadMemory((IntPtr)Target, sizeof(uint), out NULL), 0);

                return val;
            }

            return 0;
        }

        public int command_rr(uint[] array, int var)
        {
            Process process = Process.GetProcessesByName("iw3mp").ToList().FirstOrDefault();

            uint Base_Address = array[0];
            uint Offset = array[1];
            int Value = var;

            if (process != null)
            {
                mreader.ReadProcess = process;
                mreader.OpenProcess();

                uint Address = BitConverter.ToUInt32(mreader.ReadMemory((IntPtr)Base_Address, sizeof(uint), out NULL), 0);
                uint Target = Address + Offset;

                int val = BitConverter.ToInt32(mreader.ReadMemory((IntPtr)Target, sizeof(uint), out NULL), 0);

                return val;
            }

            return 0x0;
        }

        // command read read (vector)
        public bool[] command_vector_rr(uint[] array, bool[] var)
        {
            Process process = Process.GetProcessesByName("iw3mp").ToList().FirstOrDefault();

            uint Base_Address_0 = array[0];
            uint Offset_0 = array[1];
            uint Value_0 = Convert.ToUInt32(var[0]);
            uint Base_Address_1 = array[0];
            uint Offset_1 = array[2];
            uint Value_1 = Convert.ToUInt32(var[1]);
            uint Base_Address_2 = array[0];
            uint Offset_2 = array[3];
            uint Value_2 = Convert.ToUInt32(var[2]);

            bool[] ret = new bool[3];

            if (process != null)
            {
                mreader.ReadProcess = process;
                mreader.OpenProcess();

                uint Address_0 = BitConverter.ToUInt32(mreader.ReadMemory((IntPtr)Base_Address_0, sizeof(uint), out NULL), 0);
                uint Target_0 = Address_0 + Offset_0;
                uint val_0 = BitConverter.ToUInt32(mreader.ReadMemory((IntPtr)Target_0, sizeof(uint), out NULL), 0);
                ret[0] = Convert.ToBoolean(val_0);

                uint Address_1 = BitConverter.ToUInt32(mreader.ReadMemory((IntPtr)Base_Address_1, sizeof(uint), out NULL), 0);
                uint Target_1 = Address_1 + Offset_1;
                uint val_1 = BitConverter.ToUInt32(mreader.ReadMemory((IntPtr)Target_1, sizeof(uint), out NULL), 0);
                ret[1] = Convert.ToBoolean(val_1);

                uint Address_2 = BitConverter.ToUInt32(mreader.ReadMemory((IntPtr)Base_Address_2, sizeof(uint), out NULL), 0);
                uint Target_2 = Address_2 + Offset_2;
                uint val_2 = BitConverter.ToUInt32(mreader.ReadMemory((IntPtr)Target_2, sizeof(uint), out NULL), 0);
                ret[2] = Convert.ToBoolean(val_2);

                return ret;
            }

            return ret;
        }

        public float[] command_vector_rr(uint[] array, float[] var)
        {
            Process process = Process.GetProcessesByName("iw3mp").ToList().FirstOrDefault();

            uint Base_Address_0 = array[0];
            uint Offset_0 = array[1];
            float Value_0 = var[0];
            uint Base_Address_1 = array[0];
            uint Offset_1 = array[2];
            float Value_1 = var[1];
            uint Base_Address_2 = array[0];
            uint Offset_2 = array[3];
            float Value_2 = var[2];

            float[] ret = new float[3];

            if (process != null)
            {
                mreader.ReadProcess = process;
                mreader.OpenProcess();

                uint Address_0 = BitConverter.ToUInt32(mreader.ReadMemory((IntPtr)Base_Address_0, sizeof(uint), out NULL), 0);
                uint Target_0 = Address_0 + Offset_0;
                float val_0 = BitConverter.ToSingle(mreader.ReadMemory((IntPtr)Target_0, sizeof(uint), out NULL), 0);
                ret[0] = val_0;

                uint Address_1 = BitConverter.ToUInt32(mreader.ReadMemory((IntPtr)Base_Address_1, sizeof(uint), out NULL), 0);
                uint Target_1 = Address_1 + Offset_1;
                float val_1 = BitConverter.ToSingle(mreader.ReadMemory((IntPtr)Target_1, sizeof(uint), out NULL), 0);
                ret[1] = val_1;

                uint Address_2 = BitConverter.ToUInt32(mreader.ReadMemory((IntPtr)Base_Address_2, sizeof(uint), out NULL), 0);
                uint Target_2 = Address_2 + Offset_2;
                float val_2 = BitConverter.ToSingle(mreader.ReadMemory((IntPtr)Target_2, sizeof(uint), out NULL), 0);
                ret[2] = val_2;

                return ret;
            }

            return ret;
        }

        public int[] command_vector_rr(uint[] array, int[] var)
        {
            Process process = Process.GetProcessesByName("iw3mp").ToList().FirstOrDefault();

            uint Base_Address_0 = array[0];
            uint Offset_0 = array[1];
            int Value_0 = var[0];
            uint Base_Address_1 = array[0];
            uint Offset_1 = array[2];
            int Value_1 = var[1];
            uint Base_Address_2 = array[0];
            uint Offset_2 = array[3];
            int Value_2 = var[2];

            int[] ret = new int[3];

            if (process != null)
            {
                mreader.ReadProcess = process;
                mreader.OpenProcess();

                uint Address_0 = BitConverter.ToUInt32(mreader.ReadMemory((IntPtr)Base_Address_0, sizeof(uint), out NULL), 0);
                uint Target_0 = Address_0 + Offset_0;
                int val_0 = BitConverter.ToInt32(mreader.ReadMemory((IntPtr)Target_0, sizeof(uint), out NULL), 0);
                ret[0] = val_0;

                uint Address_1 = BitConverter.ToUInt32(mreader.ReadMemory((IntPtr)Base_Address_1, sizeof(uint), out NULL), 0);
                uint Target_1 = Address_1 + Offset_1;
                int val_1 = BitConverter.ToInt32(mreader.ReadMemory((IntPtr)Target_1, sizeof(uint), out NULL), 0);
                ret[1] = val_1;

                uint Address_2 = BitConverter.ToUInt32(mreader.ReadMemory((IntPtr)Base_Address_2, sizeof(uint), out NULL), 0);
                uint Target_2 = Address_2 + Offset_2;
                int val_2 = BitConverter.ToInt32(mreader.ReadMemory((IntPtr)Target_2, sizeof(uint), out NULL), 0);
                ret[2] = val_2;

                return ret;
            }

            return ret;
        }

        // command read
        public bool command_r(uint[] array, bool var)
        {
            Process process = Process.GetProcessesByName("iw3mp").ToList().FirstOrDefault();

            uint Base_Address = array[0];
            uint Offset = array[1];
            uint Value = Convert.ToUInt32(var);

            if (process != null)
            {
                mreader.ReadProcess = process;
                mreader.OpenProcess();

                uint Target = Base_Address + Offset;

                uint val = BitConverter.ToUInt32(mreader.ReadMemory((IntPtr)Target, sizeof(uint), out NULL), 0);
                bool ret = Convert.ToBoolean(val);

                return ret;
            }

            return false;
        }

        public float command_r(uint[] array, float var)
        {
            Process process = Process.GetProcessesByName("iw3mp").ToList().FirstOrDefault();

            uint Base_Address = array[0];
            uint Offset = array[1];
            float Value = var;

            if (process != null)
            {
                mreader.ReadProcess = process;
                mreader.OpenProcess();

                uint Target = Base_Address + Offset;

                float val = BitConverter.ToSingle(mreader.ReadMemory((IntPtr)Target, sizeof(uint), out NULL), 0);

                return val;
            }

            return 0;
        }

        public int command_r(uint[] array, int var)
        {
            Process process = Process.GetProcessesByName("iw3mp").ToList().FirstOrDefault();

            uint Base_Address = array[0];
            uint Offset = array[1];
            int Value = var;

            if (process != null)
            {
                mreader.ReadProcess = process;
                mreader.OpenProcess();

                uint Target = Base_Address + Offset;

                int val = BitConverter.ToInt32(mreader.ReadMemory((IntPtr)Target, sizeof(uint), out NULL), 0);

                return val;
            }

            return 0x0;
        }
    }
}