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
                }
            }
        }
    }
}
