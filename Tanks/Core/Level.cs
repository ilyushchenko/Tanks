using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tanks
{
    public class Level
    {
        public void Draw(Graphics graphics)
        {
            foreach (IDrawable unit in m_field)
            {
                unit.Draw(graphics);
            }
        }

        public Level(int n, int m)
        {
            m_n = n;
            m_m = m;
            m_field = new IPositionable[m_n, m_m];
        }

        public Level()
        {
            m_field = new IPositionable[0, 0];
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
                    IPositionable positionOfUnit = unit as IPositionable;
                    m_field[positionOfUnit.Position.X, positionOfUnit.Position.Y] = positionOfUnit;
                }
            }
        }

        /*internal void PutTanks()
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < m_tanks.GetCount(); i++)
            {
                bool notSet = false;
                do
                {
                    notSet = false;
                    int x = rand.Next(1, m_n) * 40;
                    int y = rand.Next(1, m_m) * 40;
                    m_tanks[i].Position = new Point(x, y);
                    for (int j = 0; j < m_walls.GetCount(); j++)
                    {
                        if (m_tanks[i].Position == m_walls[j].Position)
                        {
                            notSet = true;
                            break;
                        }
                    }
                    for (int k = 0; k < m_tanks.GetCount(); k++)
                    {
                        if (m_tanks[i].Position == m_tanks[k].Position && i != k)
                        {
                            notSet = true;
                            break;
                        }
                    }

                } while (notSet);
            }
        }*/

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

        public bool IsFree(IPositionable unit)
        {
            if (m_field[unit.Position.X, unit.Position.Y] != null && m_field[unit.Position.X, unit.Position.Y] is Floor)
            {
                return true;
            }
            return false;
            //return m_field.Exists(p => unit.Equal(p));
        }

        //public void PutTanks()
        //{
        //    Random rand = new Random(DateTime.Now.Millisecond);
        //    for (int i = 0; i < m_tanks.GetCount(); i++)
        //    {
        //        bool notSet = false;
        //        do
        //        {
        //            notSet = false;
        //            int x = rand.Next(1, m_n) * 40;
        //            int y = rand.Next(1, m_m) * 40;
        //            m_tanks[i].Position = new Point(x, y);
        //            for (int j = 0; j < m_walls.GetCount(); j++)
        //            {
        //                if (m_tanks[i].Position == m_walls[j].Position)
        //                {
        //                    notSet = true;
        //                    break;
        //                }
        //            }
        //            for (int k = 0; k < m_tanks.GetCount(); k++)
        //            {
        //                if (m_tanks[i].Position == m_tanks[k].Position && i != k )
        //                {
        //                    notSet = true;
        //                    break;
        //                }
        //            }

        //        } while (notSet);
        //    }
        //}
        protected IPositionable[,] m_field;
        protected int m_m;
        protected int m_n;

        public int M
        {
            get
            {
                return m_m;
            }

            set
            {
                m_m = value;
            }
        }

        public int N
        {
            get
            {
                return m_n;
            }

            set
            {
                m_n = value;
            }
        }
    }
}
