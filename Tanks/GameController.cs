using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    public class GameController
    {
        Level m_level;
        public GameController(Level level)
        {
            m_level = level;
        }

        public void Draw(Graphics graphic)
        {
            //m_level.DrawLevel(graphic);
        }

    }
}
