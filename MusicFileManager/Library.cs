using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace MusicFileManager
{
    public class Library
    {
        public Dictionary<string, IFile> Database { get; set; }
        public void Construct(string rootDir)
        {
            Database = new Dictionary<string, IFile>();
            foreach (var dir in System.IO.Directory.EnumerateDirectories(rootDir))
            {
                Construct(dir);
            }
            foreach (var f in System.IO.Directory.EnumerateFiles(rootDir))
            {
                if(Path.GetExtension(f) == ".flac")
                {
                    Flac flac = new Flac();
                    flac.Load(f);
                    Database.Add(f, flac);

                }
            }
            foreach (var item in Database)
            {
                Console.WriteLine("[{0}]\r\n{1}", item.Key, item.Value.ToString());
            }

            IFormatter formatter = new BinaryFormatter();
            Stream st = new FileStream("library.db" , FileMode.Create, FileAccess.Write);
            formatter.Serialize(st, Database);
            st.Close();

        }
        public void Load()
        {
            if (!File.Exists("library.db")) return;

            IFormatter formatter = new BinaryFormatter();
            Stream st = new FileStream("library.db" , FileMode.Open, FileAccess.Read);
            Database = formatter.Deserialize(st) as Dictionary<string, IFile>;
            st.Close();
        }
    }
}
