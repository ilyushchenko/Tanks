using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    public interface IPositionable
    {
        Point Position { get; set; }
        //bool Equal(IPositionable unit);
    }
}
