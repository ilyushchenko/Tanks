using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tanks
{
    public abstract class Level
    {
        public int M
        {
            get
            {
                return m_m;
            }
        }

        public int N
        {
            get
            {
                return m_n;
            }
        }

        public Level()
        {
            m_field = new IPositionable[0, 0];
        }

        public Level(int n, int m)
        {
            m_n = n;
            m_m = m;
            m_field = new IPositionable[m_n, m_m];
        }

        public void Draw(Graphics graphics)
        {
            foreach(IDrawable unit in m_field)
            {
                unit.Draw(graphics);
            }
        }

        public void LoadLevel(string path)
        {
            using(StreamReader sr = new StreamReader(path))
            {
                m_n = Convert.ToInt32(sr.ReadLine());
                m_m = Convert.ToInt32(sr.ReadLine());
                m_field = new IPositionable[m_n, m_m];
                while (!sr.EndOfStream)
                {
                    string type = sr.ReadLine();
                    ISerializable unit;
                    switch (type)
                    {
                        case "floor":
                            unit = new Floor();
                            break;
                        case "wall":
                            unit = new Wall();
                            break;
                        case "tank":
                            unit = new Tank();
                            break;
                        default:
                            unit = new Floor();
                            break;
                    }
                    unit.Load(sr);
                    Point position = ((IPositionable)unit).Position;
                    m_field[position.X, position.Y] = unit as IPositionable;
                }
            }
        }

        public void SaveLevel(string path)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(m_n);
                sw.WriteLine(m_m);
                foreach (ISerializable unit in m_field)
                {
                    unit.Save(sw);
                }
            }
        }

        protected IPositionable[,] m_field;

        protected int m_m;

        protected int m_n;
    }
}
