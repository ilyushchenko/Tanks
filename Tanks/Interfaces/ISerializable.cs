using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    public interface ISerializable
    {
        void Load(StreamReader inFile);
        void Save(StreamWriter outFile);

        //bool Equal(ISerializable unit);
    }
}
