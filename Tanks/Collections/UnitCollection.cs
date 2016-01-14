﻿using System;
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
        public ISerializable this[int i]
        {
            // Аксессор для получения данных,
            get
            {
                return m_units[i];
            }
            // Аксессор для установки данных,
            set
            {
                m_units[i] = value;
            }
        }


        public int GetCount()
        {
            return m_units.Count;
        }
        private List<ISerializable> m_units = new List<ISerializable>();

        public List<ISerializable> GetCollection()
        {
            return m_units;
        }

        public void Add(ISerializable unit)
        {
            m_units.Add(unit);
        }

        internal void Remove(Point position)
        {
            for(int i = 0; i < m_units.Count; i++)
            {
                if((m_units[i] as IPositionable).Position == position)
                {
                    int index = m_units.IndexOf(m_units[i]);
                    m_units.RemoveAt(index);
                }
            }
        }

        //public void Remove(ISerializable unit)
        //{
        //    m_units.RemoveAll(p => (unit.Equal(p)));
        //}

        //public bool Exist(ISerializable unit)
        //{
        //    return m_units.Exists(p => unit.Equal(p));
        //}

        public void Draw(Graphics graphics)
        {
            foreach (IDrawable unit in m_units)
            {
                unit.Draw(graphics);
            }
        }

        public bool Exist(Point position)
        {
            foreach(ISerializable unit in m_units)
            {
                if((unit as IPositionable).Position == position)
                {
                    return true;
                }
            }
            return false;
        }

        public ISerializable GetUnit(Point position)
        {
            /*foreach(IPositionable unit in m_units)
            {
                if(unit.Position == position)
                {
                    return unit as ISerializable;
                }
            }*/
            for(int i = 0; i < m_units.Count; i++)
            {
                IPositionable unit = m_units[i] as IPositionable;
                if(unit.Position == position)
                {
                    return m_units[i];
                }
            }
            return null;
        }

        public void SetUnit(ISerializable unit)
        {
            for(int i = 0; i < m_units.Count; i++)
            {
                if((m_units[i] as IPositionable).Position == (unit as IPositionable).Position)
                {
                    m_units[i] = unit;
                }
            }
        }

        public void Save(string path)
        {
            throw new Exception();
        }

        public void Load(string path)
        {
            throw new Exception();
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < m_units.Count; i++)
            {
                yield return m_units[i];
            }
        }
    }
}
