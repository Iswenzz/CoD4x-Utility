using System.Reflection;

using Iswenzz.CoD4.Utility.Command;

namespace Iswenzz.CoD4.Utility.Profiles
{
    public partial class Profile
    {
        /// <summary>
        /// Gets all client settings and save them to XML Profile.
        /// </summary>
        public static void FirstLoad()
        {
            foreach (string cmd in Commands)
            {
                FieldInfo cmd_a = typeof(Profile).GetField(cmd);
                FieldInfo cmd_v = typeof(Profile).GetField("var_" + cmd);
                object obj_a = cmd_a.GetValue(null);
                object obj_v = cmd_v.GetValue(null);

                switch (true)
                {
                    case true when obj_v.GetType() == typeof(bool):
                        bool b = (bool)obj_v;
                        b.ReadRead((uint[])obj_a);
                        break;
                    case true when obj_v.GetType() == typeof(float):
                        float f = (float)obj_v;
                        f.ReadRead((uint[])obj_a);
                        break;
                    case true when obj_v.GetType() == typeof(int):
                        int i = (int)obj_v;
                        i.ReadRead((uint[])obj_a);
                        break;
                    case true when obj_v.GetType() == typeof(bool[]):
                        bool[] ba = (bool[])obj_v;
                        ba.VectorReadRead((uint[])obj_a);
                        break;
                    case true when obj_v.GetType() == typeof(float[]):
                        float[] fa = (float[])obj_v;
                        fa.VectorReadRead((uint[])obj_a);
                        break;
                    case true when obj_v.GetType() == typeof(int[]):
                        int[] ia = (int[])obj_v;
                        ia.VectorReadRead((uint[])obj_a);
                        break;
                }
            }
            IsFirstTime = false;
            Xml.Save();
            Start();
            //Application.Restart();
        }
    }
}