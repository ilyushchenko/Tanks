using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tanks
{
    public enum Status
    {
        Unplayed,
        Playing,
        End,
    }
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

        public int Width
        {
            get { return Images.Tank.Width; }
        }

        public int Height
        {
            get { return Images.Tank.Height; }
        }

        public Status Status
        {
            get
            {
                return m_status;
            }

            set
            {
                m_status = value;
            }
        }

        public Level()
        {
        }

        public Level(int n, int m)
        {
            m_n = n;
            m_m = m;
        }

        public void Draw(Graphics graphics)
        {
            foreach(IDrawable unit in m_field.GetCollection())
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
                while (!sr.EndOfStream)
                {
                    string type = sr.ReadLine();
                    ISerializable unit;
                    switch (type)
                    {
                        case "wall":
                            unit = new Wall();
                            break;
                        case "tank":
                            unit = new Tank();
                            break;
                        default:
                            unit = new Wall();
                            break;
                    }
                    unit.Load(sr);
                    m_field.Add(unit as IPositionable);
                }
            }
        }

        public void SaveLevel(string path)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(m_n);
                sw.WriteLine(m_m);
                foreach (ISerializable unit in m_field.GetCollection())
                {
                    unit.Save(sw);
                }
            }
        }

        public UnitCollection GetField()
        {
            return m_field;
        }

        protected UnitCollection m_field = new UnitCollection();

        protected int m_m;

        protected int m_n;

        protected Status m_status = Status.Unplayed;


    }
}
