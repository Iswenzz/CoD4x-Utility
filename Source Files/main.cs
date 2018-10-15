using MemoryApi;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Xml;
using first_run;

namespace cod4_memory
{
    public class Profile
    {
        public static Thread[] thread = new Thread[4];

        public static float Version = 1.1f;
        public static string Update_String = "";

        public static int Form1_X;
        public static int Form1_Y;
        public static bool isFormAbout = false;
        public static bool isCoD4Running = false;
        public static bool isFirstTime;

        public static bool var_cg_drawFps;
        public static bool var_cg_draw2D;
        public static bool var_cg_laserForceOn;
        public static bool var_hud_enable;
        public static float var_player_sprintCameraBob;
        public static bool var_fx_enable;
        public static bool var_r_fullbright;
        public static bool var_r_drawDecals;
        public static bool var_r_detail;
        public static bool var_r_specular;
        public static int var_r_specularMap;
        public static bool var_sm_enable;
        public static bool var_r_normal;
        public static float var_cg_gun_x;
        public static float var_cg_gun_y;
        public static float var_cg_gun_z;
        public static float var_cg_fov;
        public static float var_cg_fovScale;
        public static bool var_r_filmUseTweaks;
        public static bool var_r_filmTweakEnable;
        public static float var_r_filmTweakBrightness;
        public static float var_r_filmTweakContrast;
        public static float var_r_filmTweakDesaturation;
        public static float[] var_r_filmTweakLightTint = new float[3];
        public static float[] var_r_filmTweakDarkTint = new float[3];
        public static float var_r_lightTweakSunLight;
        public static float[] var_r_lightTweakSunColor = new float[3];
        public static float[] var_r_lightTweakSunDiffuseColor = new float[3];
        public static float[] var_r_lightTweakSunDirection = new float[3];

        /* save = command_w
         * load = command_r */

        // Background
        public static uint[] post_process = new uint[2] { 0xD584070, 0x0 };
        public static uint[] lighting = new uint[2] { 0xD584074, 0x0 };
        public static uint[] fx = new uint[2] { 0xD584078, 0x0 };

        /* save = command_rw 
         * load = command_rr */

        // Player
        public static uint[] cg_drawFps = new uint[2] { 0x748634, 0xC };
        public static uint[] cg_draw2D = new uint[2] { 0x74A8BC, 0xC };
        public static uint[] cg_laserForceOn = new uint[2] { 0x8C62FC, 0xC };
        public static uint[] hud_enable = new uint[2] { 0x8C9468, 0xC };
        public static uint[] player_sprintCameraBob = new uint[2] { 0x734B7C, 0xC };
        
        // Graphics
        public static uint[] fx_enable = new uint[2] { 0x110CE88, 0xC };
        public static uint[] r_specular = new uint[2] { 0xD56958C, 0xC };
        public static uint[] r_fullbright = new uint[2] { 0xD569680, 0xC };
        public static uint[] r_specularMap = new uint[2] { 0xD5696B4, 0xC };
        public static uint[] r_drawDecals = new uint[2] { 0xD5697C4, 0xC };
        public static uint[] sm_enable = new uint[2] { 0xD56971C, 0xC };
        public static uint[] r_detail = new uint[2] { 0xD5696CC, 0xC };
        public static uint[] r_normal = new uint[2] { 0xD569764, 0xC };
        
        // Viewmodel
        public static uint[] cg_gun_x = new uint[2] { 0x74A8C0, 0xC };
        public static uint[] cg_gun_y = new uint[2] { 0x746FA0, 0xC };
        public static uint[] cg_gun_z = new uint[2] { 0x74A86C, 0xC };
        public static uint[] cg_fov = new uint[2] { 0x8C93D8, 0xC };
        public static uint[] cg_fovScale = new uint[2] { 0x8C62E4, 0xC };
        
        // Vision
        public static uint[] r_filmUseTweaks = new uint[2] { 0xD5695D8, 0xC };
        public static uint[] r_filmTweakEnable = new uint[2] { 0xD569700, 0xC };
        public static uint[] r_filmTweakBrightness = new uint[2] { 0xD5697D4, 0xC };
        public static uint[] r_filmTweakContrast = new uint[2] { 0xD569694, 0xC };
        public static uint[] r_filmTweakDesaturation = new uint[2] { 0xD569698, 0xC };
        public static uint[] r_filmTweakLightTint = new uint[4] { 0xD5696F0, 0xC, 0x10, 0x14 };
        public static uint[] r_filmTweakDarkTint = new uint[4] { 0xD569758, 0xC, 0x10, 0x14 };
        public static uint[] r_lightTweakSunLight = new uint[2] { 0xD569588, 0xC };
        public static uint[] r_lightTweakSunColor = new uint[4] { 0xD56974C, 0x10, 0x14, 0x18};
        public static uint[] r_lightTweakSunDiffuseColor = new uint[4] { 0xD56973C, 0x10, 0x14, 0x18 };
        public static uint[] r_lightTweakSunDirection = new uint[4] { 0xD5696EC, 0xC, 0x10, 0x14};

        public static void Start()
        {
            XmlReader xml = XmlReader.Create("profile.xml");

            while (xml.ReadToFollowing("command"))
            {
                if (!xml.HasAttributes)
                    continue;

                isFirstTime = Xml.LoadAttribute(xml, isFirstTime, "First_Time");
            }

            xml.Close();

            if (isFirstTime)
                First_Run.First_Load();
            else
                Load();
        }

        public static void XML_Load()
        {
            if(!File.Exists("profile.xml"))
            {
                XmlDocument xml = new XmlDocument();
                XmlNode root_command = xml.CreateElement("command");
                xml.AppendChild(root_command);
                Xml.XmlWrite(xml, "True", "First_Time");
                xml.Save("profile.xml");
            }

            else
            {
                XmlReader xml = XmlReader.Create("profile.xml");

                while (xml.ReadToFollowing("command"))
                {
                    if (!xml.HasAttributes)
                        continue;

                    // Player
                    var_cg_drawFps = Xml.LoadAttribute(xml, var_cg_drawFps, "DrawFPS");
                    var_cg_draw2D = Xml.LoadAttribute(xml, var_cg_draw2D, "Draw2D");
                    var_cg_laserForceOn = Xml.LoadAttribute(xml, var_cg_laserForceOn, "Laser");
                    var_hud_enable = Xml.LoadAttribute(xml, var_hud_enable, "Hud_Enable");
                    var_player_sprintCameraBob = Xml.LoadAttribute(xml, var_player_sprintCameraBob, "Camera_Bob");

                    // Graphics
                    var_fx_enable = Xml.LoadAttribute(xml, var_fx_enable, "Effects");
                    var_r_specular = Xml.LoadAttribute(xml, var_r_specular, "Specular");
                    var_r_fullbright = Xml.LoadAttribute(xml, var_r_fullbright, "Fullbright");
                    var_r_specularMap = Xml.LoadAttribute(xml, var_r_specularMap, "Specular_Mode");
                    var_r_drawDecals = Xml.LoadAttribute(xml, var_r_drawDecals, "Decals");
                    var_sm_enable = Xml.LoadAttribute(xml, var_sm_enable, "AA_Shadow");
                    var_r_detail = Xml.LoadAttribute(xml, var_r_detail, "Detail");
                    var_r_normal = Xml.LoadAttribute(xml, var_r_normal, "Normal");

                    // Viewmodel
                    var_cg_gun_x = Xml.LoadAttribute(xml, var_cg_gun_x, "Gun_X");
                    var_cg_gun_y = Xml.LoadAttribute(xml, var_cg_gun_y, "Gun_Y");
                    var_cg_gun_z = Xml.LoadAttribute(xml, var_cg_gun_z, "Gun_Z");
                    var_cg_fov = Xml.LoadAttribute(xml, var_cg_fov, "FOV");
                    var_cg_fovScale = Xml.LoadAttribute(xml, var_cg_fovScale, "FOV_Scale");

                    // Vision
                    var_r_filmTweakLightTint[0] = Xml.LoadAttribute(xml, var_r_filmTweakLightTint[0], "Light_Tint_0");
                    var_r_filmTweakLightTint[1] = Xml.LoadAttribute(xml, var_r_filmTweakLightTint[1], "Light_Tint_1");
                    var_r_filmTweakLightTint[2] = Xml.LoadAttribute(xml, var_r_filmTweakLightTint[2], "Light_Tint_2");
                    var_r_filmTweakDarkTint[0] = Xml.LoadAttribute(xml, var_r_filmTweakDarkTint[0], "Dark_Tint_0");
                    var_r_filmTweakDarkTint[1] = Xml.LoadAttribute(xml, var_r_filmTweakDarkTint[1], "Dark_Tint_1");
                    var_r_filmTweakDarkTint[2] = Xml.LoadAttribute(xml, var_r_filmTweakDarkTint[2], "Dark_Tint_2");
                    /*var_r_lightTweakSunColor[0] = Xml.LoadAttribute(xml, var_r_lightTweakSunColor[0], "Sun_Color_0");
                    var_r_lightTweakSunColor[1] = Xml.LoadAttribute(xml, var_r_lightTweakSunColor[1], "Sun_Color_1");
                    var_r_lightTweakSunColor[2] = Xml.LoadAttribute(xml, var_r_lightTweakSunColor[2], "Sun_Color_2");
                    var_r_lightTweakSunDiffuseColor[0] = Xml.LoadAttribute(xml, var_r_lightTweakSunDiffuseColor[0], "Sun_Diffuse_Color_0");
                    var_r_lightTweakSunDiffuseColor[1] = Xml.LoadAttribute(xml, var_r_lightTweakSunDiffuseColor[1], "Sun_Diffuse_Color_1");
                    var_r_lightTweakSunDiffuseColor[2] = Xml.LoadAttribute(xml, var_r_lightTweakSunDiffuseColor[2], "Sun_Diffuse_Color_2");
                    var_r_lightTweakSunDirection[0] = Xml.LoadAttribute(xml, var_r_lightTweakSunDirection[0], "Sun_Direction_0");
                    var_r_lightTweakSunDirection[1] = Xml.LoadAttribute(xml, var_r_lightTweakSunDirection[1], "Sun_Direction_1");
                    var_r_lightTweakSunDirection[2] = Xml.LoadAttribute(xml, var_r_lightTweakSunDirection[2], "Sun_Direction_2");*/
                    var_r_lightTweakSunLight = Xml.LoadAttribute(xml, var_r_lightTweakSunLight, "Sun_Light");
                    var_r_filmTweakBrightness = Xml.LoadAttribute(xml, var_r_filmTweakBrightness, "Brightness");
                    var_r_filmTweakContrast = Xml.LoadAttribute(xml, var_r_filmTweakContrast, "Contrast");
                    var_r_filmTweakDesaturation = Xml.LoadAttribute(xml, var_r_filmTweakDesaturation, "Desaturation");
                    var_r_filmUseTweaks = Xml.LoadAttribute(xml, var_r_filmUseTweaks, "Tweak_Use");
                }

                xml.Close();
            }
        }

        public static void Load()
        {
            isCoD4Running = true;

            thread[2] = new Thread(() =>
            {
                Thread_Load();
            });

            thread[2].Start();
            thread[2].IsBackground = true;
        }

        public static void Thread_Load()
        {
            while (isCoD4Running)
            {
                Command cmd = new Command();
                
                if(var_r_fullbright)
                {
                    cmd.command_w(post_process, 1);
                    cmd.command_w(lighting, 4);
                    cmd.command_w(fx, 4);
                }

                else
                {
                    cmd.command_w(post_process, 3);
                    cmd.command_w(lighting, 7);
                    cmd.command_w(fx, 5);
                }

                if (var_r_filmUseTweaks)
                    var_r_filmTweakEnable = true;
                else
                    var_r_filmTweakEnable = false;

                // Player
                cmd.command_rw(cg_drawFps, var_cg_drawFps);
                cmd.command_rw(cg_draw2D, var_cg_draw2D);
                cmd.command_rw(cg_laserForceOn, var_cg_laserForceOn);
                cmd.command_rw(hud_enable, var_hud_enable);
                cmd.command_rw(player_sprintCameraBob,var_player_sprintCameraBob);

                // Graphics
                cmd.command_rw(fx_enable, var_fx_enable);
                cmd.command_rw(r_specular, var_r_specular);
                cmd.command_rw(r_fullbright, var_r_fullbright);
                cmd.command_rw(r_specularMap, var_r_specularMap);
                cmd.command_rw(r_drawDecals, var_r_drawDecals);
                cmd.command_rw(sm_enable, var_sm_enable);
                cmd.command_rw(r_detail, var_r_detail);
                cmd.command_rw(r_normal, var_r_normal);

                // Viewmodel
                cmd.command_rw(cg_gun_x, var_cg_gun_x);
                cmd.command_rw(cg_gun_y, var_cg_gun_y);
                cmd.command_rw(cg_gun_z, var_cg_gun_z);
                cmd.command_rw(cg_fov, var_cg_fov);
                cmd.command_rw(cg_fovScale, var_cg_fovScale);

                // Vision
                cmd.command_vector_rw(r_filmTweakLightTint, var_r_filmTweakLightTint);
                cmd.command_vector_rw(r_filmTweakDarkTint, var_r_filmTweakDarkTint);
                /*cmd.command_vector_rw(r_lightTweakSunColor, var_r_lightTweakSunColor);
                cmd.command_vector_rw(r_lightTweakSunDiffuseColor, var_r_lightTweakSunDiffuseColor);
                cmd.command_vector_rw(r_lightTweakSunDirection, var_r_lightTweakSunDirection);
                cmd.command_vector_rw(r_lightTweakSunLight, var_r_lightTweakSunLight;*/
                cmd.command_rw(r_filmTweakBrightness, var_r_filmTweakBrightness);
                cmd.command_rw(r_filmTweakContrast, var_r_filmTweakContrast);
                cmd.command_rw(r_filmTweakDesaturation, var_r_filmTweakDesaturation);
                cmd.command_rw(r_filmUseTweaks, var_r_filmUseTweaks);
                cmd.command_rw(r_filmTweakEnable, var_r_filmTweakEnable);

                Save();
                Thread.Sleep(1000);
            }
        }

        public static void Save()
        {
            XmlDocument xml = new XmlDocument();
            XmlNode root_command = xml.CreateElement("command");
            xml.AppendChild(root_command);

            // Player
            Xml.XmlWrite(xml, var_cg_drawFps, "DrawFPS");
            Xml.XmlWrite(xml, var_cg_draw2D, "Draw2D");
            Xml.XmlWrite(xml, var_cg_laserForceOn, "Laser");
            Xml.XmlWrite(xml, var_hud_enable, "Hud_Enable");
            Xml.XmlWrite(xml, var_player_sprintCameraBob, "Camera_Bob");

            // Graphics
            Xml.XmlWrite(xml, var_fx_enable, "Effects");
            Xml.XmlWrite(xml, var_r_specular, "Specular");
            Xml.XmlWrite(xml, var_r_fullbright, "Fullbright");
            Xml.XmlWrite(xml, var_r_specularMap, "Specular_Mode");
            Xml.XmlWrite(xml, var_r_drawDecals, "Decals");
            Xml.XmlWrite(xml, var_sm_enable, "AA_Shadow");
            Xml.XmlWrite(xml, var_r_detail, "Detail");
            Xml.XmlWrite(xml, var_r_normal, "Normal");

            // Viewmodel
            Xml.XmlWrite(xml, var_cg_gun_x, "Gun_X");
            Xml.XmlWrite(xml, var_cg_gun_y, "Gun_Y");
            Xml.XmlWrite(xml, var_cg_gun_z, "Gun_Z");
            Xml.XmlWrite(xml, var_cg_fov, "FOV");
            Xml.XmlWrite(xml, var_cg_fovScale, "FOV_Scale");

            // Vision
            Xml.XmlWrite(xml, var_r_filmTweakLightTint[0], "Light_Tint_0");
            Xml.XmlWrite(xml, var_r_filmTweakLightTint[1], "Light_Tint_1");
            Xml.XmlWrite(xml, var_r_filmTweakLightTint[2], "Light_Tint_2");
            Xml.XmlWrite(xml, var_r_filmTweakDarkTint[0], "Dark_Tint_0");
            Xml.XmlWrite(xml, var_r_filmTweakDarkTint[1], "Dark_Tint_1");
            Xml.XmlWrite(xml, var_r_filmTweakDarkTint[2], "Dark_Tint_2");
            /*Xml.XmlWrite(xml, var_r_lightTweakSunColor[0], "Sun_Color_0");
            Xml.XmlWrite(xml, var_r_lightTweakSunColor[1], "Sun_Color_1");
            Xml.XmlWrite(xml, var_r_lightTweakSunColor[2], "Sun_Color_2");
            Xml.XmlWrite(xml, var_r_lightTweakSunDiffuseColor[0], "Sun_Diffuse_Color_0");
            Xml.XmlWrite(xml, var_r_lightTweakSunDiffuseColor[1], "Sun_Diffuse_Color_1");
            Xml.XmlWrite(xml, var_r_lightTweakSunDiffuseColor[2], "Sun_Diffuse_Color_2");
            Xml.XmlWrite(xml, var_r_lightTweakSunDirection[0], "Sun_Direction_0");
            Xml.XmlWrite(xml, var_r_lightTweakSunDirection[1], "Sun_Direction_1");
            Xml.XmlWrite(xml, var_r_lightTweakSunDirection[2], "Sun_Direction_2");*/
            Xml.XmlWrite(xml, var_r_lightTweakSunLight, "Sun_Light");
            Xml.XmlWrite(xml, var_r_filmTweakBrightness, "Brightness");
            Xml.XmlWrite(xml, var_r_filmTweakContrast, "Contrast");
            Xml.XmlWrite(xml, var_r_filmTweakDesaturation, "Desaturation");
            Xml.XmlWrite(xml, var_r_filmUseTweaks, "Tweak_Use");

            xml.Save("profile.xml");
        }

        public static void Thread_Check_Process()
        {
            bool run = false;

            while(true)
            {
                if(Process.GetProcessesByName("iw3mp").Length == 0)
                {
                    isCoD4Running = false;
                    run = false;
                }
                    
                else
                {
                    if(!run)
                    {
                        run = true;
                        Thread.Sleep(1000);
                        Start();
                    }
                }

                Thread.Sleep(1000);
            }
        }
    }

    public class Command
    {
        ProcessMemoryReader mreader = new ProcessMemoryReader();

        int NULL = 0;

        // command read write
        public void command_rw(uint[] array, bool var)
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

                mreader.WriteMemory((IntPtr)Target, BitConverter.GetBytes(Value), out NULL);
            }
        }

        public void command_rw(uint[] array, float var)
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

                mreader.WriteMemory((IntPtr)Target, BitConverter.GetBytes(Value), out NULL);
            }
        }

        public void command_rw(uint[] array, int var)
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

                mreader.WriteMemory((IntPtr)Target, BitConverter.GetBytes(Value), out NULL);
            }
        }

        // command read write (vector)
        public void command_vector_rw(uint[] array, bool[] var)
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

            if (process != null)
            {
                mreader.ReadProcess = process;
                mreader.OpenProcess();

                uint Address_0 = BitConverter.ToUInt32(mreader.ReadMemory((IntPtr)Base_Address_0, sizeof(uint), out NULL), 0);
                uint Target_0 = Address_0 + Offset_0;
                mreader.WriteMemory((IntPtr)Target_0, BitConverter.GetBytes(Value_0), out NULL);
                uint Address_1 = BitConverter.ToUInt32(mreader.ReadMemory((IntPtr)Base_Address_1, sizeof(uint), out NULL), 0);
                uint Target_1 = Address_1 + Offset_1;
                mreader.WriteMemory((IntPtr)Target_1, BitConverter.GetBytes(Value_1), out NULL);
                uint Address_2 = BitConverter.ToUInt32(mreader.ReadMemory((IntPtr)Base_Address_2, sizeof(uint), out NULL), 0);
                uint Target_2 = Address_2 + Offset_2;
                mreader.WriteMemory((IntPtr)Target_2, BitConverter.GetBytes(Value_2), out NULL);
            } 
        }

        public void command_vector_rw(uint[] array, float[] var)
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

            if (process != null)
            {
                mreader.ReadProcess = process;
                mreader.OpenProcess();

                uint Address_0 = BitConverter.ToUInt32(mreader.ReadMemory((IntPtr)Base_Address_0, sizeof(uint), out NULL), 0);
                uint Target_0 = Address_0 + Offset_0;
                mreader.WriteMemory((IntPtr)Target_0, BitConverter.GetBytes(Value_0), out NULL);
                uint Address_1 = BitConverter.ToUInt32(mreader.ReadMemory((IntPtr)Base_Address_1, sizeof(uint), out NULL), 0);
                uint Target_1 = Address_1 + Offset_1;
                mreader.WriteMemory((IntPtr)Target_1, BitConverter.GetBytes(Value_1), out NULL);
                uint Address_2 = BitConverter.ToUInt32(mreader.ReadMemory((IntPtr)Base_Address_2, sizeof(uint), out NULL), 0);
                uint Target_2 = Address_2 + Offset_2;
                mreader.WriteMemory((IntPtr)Target_2, BitConverter.GetBytes(Value_2), out NULL);
            } 
        }

        public void command_vector_rw(uint[] array, int[] var)
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

            if (process != null)
            {
                mreader.ReadProcess = process;
                mreader.OpenProcess();

                uint Address_0 = BitConverter.ToUInt32(mreader.ReadMemory((IntPtr)Base_Address_0, sizeof(uint), out NULL), 0);
                uint Target_0 = Address_0 + Offset_0;
                mreader.WriteMemory((IntPtr)Target_0, BitConverter.GetBytes(Value_0), out NULL);
                uint Address_1 = BitConverter.ToUInt32(mreader.ReadMemory((IntPtr)Base_Address_1, sizeof(uint), out NULL), 0);
                uint Target_1 = Address_1 + Offset_1;
                mreader.WriteMemory((IntPtr)Target_1, BitConverter.GetBytes(Value_1), out NULL);
                uint Address_2 = BitConverter.ToUInt32(mreader.ReadMemory((IntPtr)Base_Address_2, sizeof(uint), out NULL), 0);
                uint Target_2 = Address_2 + Offset_2;
                mreader.WriteMemory((IntPtr)Target_2, BitConverter.GetBytes(Value_2), out NULL);
            }
        }

        // command write
        public void command_w(uint[] array, bool var)
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

                mreader.WriteMemory((IntPtr)Target, BitConverter.GetBytes(Value), out NULL);
            }
        }

        public void command_w(uint[] array, float var)
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

                mreader.WriteMemory((IntPtr)Target, BitConverter.GetBytes(Value), out NULL);
            }
        }

        public void command_w(uint[] array, int var)
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

                mreader.WriteMemory((IntPtr)Target, BitConverter.GetBytes(Value), out NULL);
            }
        }
    }

    class Xml
    {
        public static XmlDocument XmlWrite(XmlDocument xml, dynamic var, string str)
        {
            XmlNode root_command = xml.DocumentElement;
            XmlNode command = xml.CreateElement("command");
            XmlAttribute name = xml.CreateAttribute("name");
            XmlAttribute value = xml.CreateAttribute("value");
            name.Value = str;
            value.Value = var.ToString();
            command.Attributes.Append(name);
            command.Attributes.Append(value);
            root_command.AppendChild(command);

            return xml;
        }

        public static bool LoadAttribute(XmlReader xml, bool var, string name)
        {
            if (xml.GetAttribute("name") == name)
                var = Convert.ToBoolean(xml.GetAttribute("value"));
            return var;
        }

        public static float LoadAttribute(XmlReader xml, float var, string name)
        {
            if (xml.GetAttribute("name") == name)
                var = Convert.ToSingle(xml.GetAttribute("value"));
            return var;
        }

        public static int LoadAttribute(XmlReader xml, int var, string name)
        {
            if (xml.GetAttribute("name") == name)
                var = Convert.ToInt32(xml.GetAttribute("value"));
            return var;
        }
    }
}