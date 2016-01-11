using System;
using System.Drawing;
using System.IO;

namespace Tanks
{
    internal class Floor : IPositionable, ISerializable, IDrawable
    {
        public Floor(int x, int y)
        {
            m_position = new Point(x, y);
        }
        public Floor()
        {

        }

        /*public bool Equal(IPositionable unit)
        {
            if (unit is Floor && unit != null)
            {
                if (unit.Position == m_position)
                {
                    return true;
                }
            }
            return false;
            //return (tank.Position == m_position) ? true : false;
        }*/

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

        #endregion

        #region IDrawable

        public void Draw(Graphics graphic)
        {
            graphic.DrawImage(m_floorImage, m_position.X * m_floorImage.Width, m_position.Y * m_floorImage.Height);
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
            outFile.WriteLine("floor");
            outFile.WriteLine("{0} {1}", m_position.X, m_position.Y);
        }

        #endregion

        private Point m_position;

        private Bitmap m_floorImage = Images.Floor;
    }
}