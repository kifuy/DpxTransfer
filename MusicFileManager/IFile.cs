using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicFileManager
{
    public interface IFile
    {
        void Load(string filepath);
        void SaveThumb();
        void LoadThumb();
    }
}
