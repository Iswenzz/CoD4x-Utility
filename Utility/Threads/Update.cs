using System;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection;

using Iswenzz.CoD4.Utility.Command;
using Iswenzz.CoD4.Utility.Profiles;

namespace Iswenzz.CoD4.Utility.Threads
{
    public static class Update
    {
        /// <summary>
        /// Task to loop the injection, also saves changes to XML Profile.
        /// </summary>
        /// <param name="Token">Token Cancellation</param>
        public static async void Init(CancellationToken Token)
        {
            while (!Token.IsCancellationRequested)
            {
                // Fullbright State
                if (Profile.var_r_fullbright)
                {
                    CMD.command_w(Profile.post_process, 1);
                    CMD.command_w(Profile.lighting, 4);
                    CMD.command_w(Profile.fx, 4);
                }
                else
                {
                    CMD.command_w(Profile.post_process, 3);
                    CMD.command_w(Profile.lighting, 7);
                    CMD.command_w(Profile.fx, 5);
                }

                // Allow Vision
                if (Profile.var_r_filmUseTweaks)
                    Profile.var_r_filmTweakEnable = true;
                else
                    Profile.var_r_filmTweakEnable = false;

                // Exec all command using Reflection
                foreach (string cmd in Profile.Commands)
                {
                    FieldInfo cmd_a = typeof(Profile).GetField(cmd);
                    FieldInfo cmd_v = typeof(Profile).GetField("var_" + cmd);
                    object obj_a = cmd_a.GetValue(null);
                    object obj_v = cmd_v.GetValue(null);

                    switch (true)
                    {
                        case true when obj_v.GetType() == typeof(bool):
                            CMD.command_rw((uint[])obj_a, (bool)obj_v);
                            break;
                        case true when obj_v.GetType() == typeof(float):
                            CMD.command_rw((uint[])obj_a, (float)obj_v);
                            break;
                        case true when obj_v.GetType() == typeof(int):
                            CMD.command_rw((uint[])obj_a, (int)obj_v);
                            break;
                        case true when obj_v.GetType() == typeof(bool[]):
                            CMD.command_vector_rw((uint[])obj_a, (bool[])obj_v);
                            break;
                        case true when obj_v.GetType() == typeof(float[]):
                            CMD.command_vector_rw((uint[])obj_a, (float[])obj_v);
                            break;
                        case true when obj_v.GetType() == typeof(int[]):
                            CMD.command_vector_rw((uint[])obj_a, (int[])obj_v);
                            break;
                    }
                }
                Xml.Save();
                await Task.Delay(1000);
            }
        }
    }
}
