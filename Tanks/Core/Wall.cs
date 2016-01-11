﻿using System;
using System.Drawing;
using System.IO;

namespace Tanks
{
    public class Wall : IPositionable, ISerializable, IDrawable
    {
        #region Constructors

        public Wall(int x, int y)
        {
            m_position = new Point(x, y);
        }

        public Wall()
        {

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

        #region Variables

        private Bitmap m_wallImage = Images.Wall;
        private Point m_position;

        #endregion
    }
}
