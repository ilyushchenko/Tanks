using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    public class Wall : IPositionable, ISerializable, IDrawable
    {
        public Wall(int x, int y)
        {
            m_position = new Point(x, y);
        }

        public Wall()
        {

        }

        #region IPositionable

        public Point Position
        {
            get
            {
                return m_position;
            }

            set
            {
                m_position = value;
            }
        }

        public bool Equal(IPositionable unit)
        {
            if (unit is Wall && unit != null)
            {
                if (unit.Position == m_position)
                {
                    return true;
                }
            }
            return false;
            //return (tank.Position == m_position) ? true : false;
        }

        #endregion

        #region IDrawable

        public void Draw(Graphics graphic)
        {
            graphic.DrawImage(m_wallImage, m_position.X * m_wallImage.Width, m_position.Y * m_wallImage.Height);
        }

        #endregion

        #region ISerializable

        public void Load(StreamReader inFile)
        {
            string[] data = inFile.ReadLine().Split();
            m_position.X = Convert.ToInt32(data[0]);
            m_position.Y = Convert.ToInt32(data[1]);
        }

        public void Save(StreamWriter outFile)
        {
            outFile.WriteLine("wall");
            outFile.WriteLine("{0} {1}", m_position.X, m_position.Y);
        }

        #endregion

        //public bool Equal(ISerializable unit)
        //{
        //    Wall wall = unit as Wall;
        //    if (unit != null)
        //    {
        //        if (m_position == wall.m_position)
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}

        private Bitmap m_wallImage = Images.Wall;
        private Point m_position;
    }
}
