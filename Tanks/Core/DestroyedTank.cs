using System;
using System.Drawing;
using System.IO;

namespace Tanks
{
    class DestroyedTank : ISerializable, IPositionable, IDrawable
    {
        #region Constructors

        public DestroyedTank(Point position)
        {
            m_position = position;
        }

        #endregion

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
            graphic.DrawImage(m_image, m_position.X * m_image.Width, m_position.Y * m_image.Height);
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
            outFile.WriteLine("destroyed tank");
            outFile.WriteLine("{0} {1}", m_position.X, m_position.Y);
        }

        #endregion

        #region Variables

        private Point m_position;

        private Bitmap m_image = Images.Tank;

        #endregion
    }
}
