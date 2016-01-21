using System;
using System.IO;
using System.Drawing;

namespace Tanks
{
    public abstract class Level
    {
        #region Properties

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

        public Status GameStatus
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

        #endregion

        #region Constants

        public int Width
        {
            get { return Images.Tank.Width; }
        }

        public int Height
        {
            get { return Images.Tank.Height; }
        }

        #endregion

        #region Constructors

        public Level()
        {

        }

        public Level(int n, int m)
        {
            m_n = n;
            m_m = m;
        }

        #endregion

        #region Drawing

        public void Draw(Graphics graphics)
        {
            foreach(IDrawable unit in m_field.GetCollection())
            {
                unit.Draw(graphics);
            }
        }

        #endregion

        #region Save/Load

        public void LoadLevel(string path)
        {
            using(StreamReader sr = new StreamReader(path))
            {
                m_n = Convert.ToInt32(sr.ReadLine());
                m_m = Convert.ToInt32(sr.ReadLine());
                m_field.Load(sr);
            }
        }

        public void SaveLevel(string path)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(m_n);
                sw.WriteLine(m_m);
                m_field.Save(sw);
            }
        }

        #endregion

        #region Access

        public UnitCollection GetField()
        {
            return m_field;
        }

        #endregion

        #region Varoables

        protected UnitCollection m_field = new UnitCollection();

        protected int m_m;

        protected int m_n;

        protected Status m_status = Status.Unplayed;

        #endregion

        #region Enum

        public enum Status
        {
            Unplayed,
            Playing,
            End,
        }

        #endregion
    }
}
