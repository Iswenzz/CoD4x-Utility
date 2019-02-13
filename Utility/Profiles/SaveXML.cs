using System;
using System.Reflection;
using System.Xml.Linq;

namespace Iswenzz.CoD4.Utility.Profiles
{
    public static partial class Xml
    {
        /// <summary>
        /// Save XML Profile using Reflection
        /// </summary>
        public static void Save()
        {
            XDocument xml = new XDocument(new XElement("Utility"));
            foreach (string cmd in Profile.Commands)
            {
                FieldInfo cmd_variable = typeof(Profile).GetField("var_" + cmd);
                object obj_v = cmd_variable.GetValue(null);
                Type obj_type = Type.GetType(obj_v.GetType().FullName);
                
                if (obj_type.FullName.Contains("[]"))
                {
                    Array obj_array = (Array)obj_v;
                    xml.Root.Add(new XElement(cmd, new XAttribute("Type", obj_type), 
                        new XAttribute("Value", obj_array.GetValue(0) + " " + obj_array.GetValue(1) + " " + obj_array.GetValue(2))));
                }
                else
                    xml.Root.Add(new XElement(cmd, new XAttribute("Type", obj_type), new XAttribute("Value", obj_v)));
            }
            xml.Save("profile.xml");
        }
    }
}
