using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicFileManager
{
    public class Library
    {
        public void Construct(string rootDir)
        {
            foreach (var dir in System.IO.Directory.EnumerateDirectories(rootDir))
            {
                Construct(dir);
            }
            foreach (var f in System.IO.Directory.EnumerateFiles(rootDir))
            {
                if(System.IO.Path.GetExtension(f) == ".flac")
                {
                    Flac flac = new Flac();
                    flac.Load(f);
                    Console.WriteLine(flac.ToString());
                    //System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(typeof(Flac));
                    //System.IO.StreamWriter sw = new System.IO.StreamWriter("test.xml", false, new System.Text.UTF8Encoding(false));
                    //ser.Serialize(sw, flac);
                    //sw.Close();
                }
            }
        }
    }
}
