using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace Tanks
{
    public class UnitCollection
    {
        #region Add/Remove/Get/Exist

        public void Add(IPositionable unit)
        {
            m_units.Add(unit);
        }

        public void Remove(IEqual unit)
        {
            m_units.Remove(m_units.Find(p => unit.Equal(p as IEqual)));
        }

        public void Remove(Point position)
        {
            m_units.Remove(m_units.Find(p => p.Position == position));
        }

        public IPositionable GetUnit(Point position)
        {
            return m_units.Find(p => p.Position == position);
        }

        public List<IPositionable> GetAllUnitsOnCell(IPositionable unit)
        {
            return m_units.FindAll(p => p.Position == unit.Position);
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

        #endregion

        #region Draw

        public void Draw(Graphics graphics)
        {
            foreach (IDrawable unit in m_units)
            {
                unit.Draw(graphics);
            }
        }

        #endregion

        #region Save/Load

        public void Save(StreamWriter sw)
        {
            foreach(ISerializable unit in m_units)
            {
                unit.Save(sw);
            }
        }

        public void Load(StreamReader sr)
        {
            while(!sr.EndOfStream)
            {
                string type = sr.ReadLine();
                ISerializable unit;
                // Switch, для будущих модификаций
                switch(type)
                {
                    case "wall":
                        unit = new Wall();
                        break;
                    default:
                        unit = new Wall();
                        break;
                }
                unit.Load(sr);
                Add(unit as IPositionable);
            }
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < m_units.Count; i++)
            {
                yield return m_units[i];
            }
        }

        #endregion

        #region Variables

        private List<IPositionable> m_units = new List<IPositionable>();

        #endregion
    }
}
