using System.Linq;
using System.IO;
using System.Xml.Linq;
using System;

namespace Iswenzz.CoD4.Utility.Profiles
{
    public static class Cfg
    {
        /// <summary>
        /// Save all settings to a .cfg file to be executed in CoD4.
        /// </summary>
        /// <param name="path"></param>
        public static void Save(string path)
        {
            string file = "";
            foreach (XElement elem in XDocument.Load("profile.xml").Root.Elements() ?? Enumerable.Empty<XElement>())
            {
                if (elem.Attribute("Value").Value.ToLower() == "true" || elem.Attribute("Value").Value.ToLower() == "false")
                    file += $"seta {elem.Name} \"{Convert.ToUInt32(Convert.ToBoolean(elem.Attribute("Value").Value))}\"\n";
                else
                    file += $"seta {elem.Name} \"{elem.Attribute("Value").Value}\"\n";
            }
            File.WriteAllText(path, file);
        }
    }
}
