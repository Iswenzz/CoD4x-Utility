using System;
using System.IO;
using System.Reflection;
using System.Xml.Linq;

namespace Iswenzz.CoD4.Utility.Profiles
{
    public static partial class Xml
    {
        /// <summary>
        /// Load XML Profile using Reflection
        /// </summary>
        public static void Load()
        {
            XDocument xml;
            if (!File.Exists("profile.xml"))
            {
                Profile.IsFirstTime = true;
                xml = new XDocument();
                xml.Add(new XElement("Utility"));
                xml.Save("profile.xml");
                return;
            }
            else
            {
                Profile.IsFirstTime = false;
                xml = XDocument.Load("profile.xml");
            }

            foreach (string cmd in Profile.Commands)
            {
                FieldInfo cmd_variable = typeof(Profile).GetField("var_" + cmd);
                object obj_v = cmd_variable.GetValue(null);
                Type obj_type = Type.GetType(xml.Root.Element(cmd).Attribute("Type").Value);

                if (obj_type.FullName.Contains("[]"))
                {
                    string[] tok;
                    switch (true)
                    {
                        case true when obj_type.FullName.Contains("Bool"):
                            tok = xml.Root.Element(cmd).Attribute("Value").Value.Split(' ');
                            cmd_variable.SetValue(null, new bool[] { bool.Parse(tok[0]), bool.Parse(tok[1]), bool.Parse(tok[2]) });
                            break;
                        case true when obj_type.FullName.Contains("Single"):
                            tok = xml.Root.Element(cmd).Attribute("Value").Value.Split(' ');
                            cmd_variable.SetValue(null, new float[] { float.Parse(tok[0]), float.Parse(tok[1]), float.Parse(tok[2]) });
                            break;
                        case true when obj_type.FullName.Contains("Int"):
                            tok = xml.Root.Element(cmd).Attribute("Value").Value.Split(' ');
                            cmd_variable.SetValue(null, new int[] { int.Parse(tok[0]), int.Parse(tok[1]), int.Parse(tok[2]) });
                            break;
                    }
                }
                else
                {
                    switch (true)
                    {
                        case true when obj_type.FullName.Contains("Bool"):
                            cmd_variable.SetValue(null, bool.Parse(xml.Root.Element(cmd).Attribute("Value").Value));
                            break;
                        case true when obj_type.FullName.Contains("Single"):
                            cmd_variable.SetValue(null, float.Parse(xml.Root.Element(cmd).Attribute("Value").Value));
                            break;
                        case true when obj_type.FullName.Contains("Int"):
                            cmd_variable.SetValue(null, int.Parse(xml.Root.Element(cmd).Attribute("Value").Value));
                            break;
                    }
                }
            }
        }
    }
}
