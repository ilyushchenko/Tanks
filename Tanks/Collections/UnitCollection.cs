using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    public class UnitCollection
    {
        // TODO Почитстить код
        /*public IPositionable this[int i]
        {
            get
            {
                return m_units[i];
            }
            set
            {
                m_units[i] = value;
            }
        }*/

        public int GetCount()
        {
            return m_units.Count;
        }
        private List<IPositionable> m_units = new List<IPositionable>();

        public List<IPositionable> GetCollection()
        {
            return m_units;
        }

        public void Add(IPositionable unit)
        {
            m_units.Add(unit);
        }

        internal void Remove(Point position)
        {
            for(int i = 0; i < m_units.Count; i++)
            {
                if(m_units[i].Position == position)
                {
                    int index = m_units.IndexOf(m_units[i]);
                    m_units.RemoveAt(index);
                }
            }
        }

        public void Draw(Graphics graphics)
        {
            foreach (IDrawable unit in m_units)
            {
                unit.Draw(graphics);
            }
        }

        public bool Exist(Point position)
        {
            foreach(IPositionable unit in m_units)
            {
                if(unit.Position == position)
                {
                    return true;
                }
            }
            return false;
        }

        public IPositionable GetUnit(Point position)
        {
            for(int i = 0; i < m_units.Count; i++)
            {
                if(m_units[i].Position == position)
                {
                    return m_units[i];
                }
            }
            return null;
        }

        public void SetUnit(IPositionable unit)
        {
            for(int i = 0; i < m_units.Count; i++)
            {
                if(m_units[i].Position == unit.Position)
                {
                    m_units[i] = unit;
                }
            }
        }

        // TODO Почитстить код
        /*public void Save(string path)
        {
            throw new Exception();
        }

        public void Load(string path)
        {
            throw new Exception();
        }*/

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < m_units.Count; i++)
            {
                yield return m_units[i];
            }
        }
    }
}
