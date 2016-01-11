using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tanks
{
    public class EditorController : Level
    {
        public EditorController()
        {

        }

        public int Width
        {
            get { return Images.Tank.Width; }
        }

        public int Height
        {
            get { return Images.Tank.Height; }
        }

        public EditorController(int n, int m) : base(n, m)
        {
            FillLevel();
            CreateBorder();
        }

        public void CheckWall(int x, int y)
        {
            int curX = x / Width;
            int curY = y / Height;
            ISerializable unit = m_field.GetUnit(new Point(curX, curY));
            if(!(unit is Tank))
            {
                if(unit is Floor)
                {
                    m_field.SetUnit(new Wall(curX, curY));
                }
                else
                {
                    m_field.SetUnit(new Floor(curX, curY));
                }
            }
        }

        private void CreateBorder()
        {
            for (int i = 0; i < m_n; i++)
            {
                m_field.SetUnit(new Wall(i, 0));
                m_field.SetUnit(new Wall(i, m_m - 1));
            }

            for (int i = 1; i < m_m - 1; i++)
            {
                m_field.SetUnit(new Wall(0, i));
                m_field.SetUnit(new Wall(m_n - 1, i));
            }
        }

        private void FillLevel()
        {
            for (int i = 0; i < m_n; i++)
            {
                for (int j = 0; j < m_m; j++)
                {
                    m_field.Add(new Floor(i, j));
                }
            }
        }

        private bool OnBorder(IPositionable unit)
        {
            if (((unit.Position.X >= 0 && unit.Position.X <= m_n) && (unit.Position.Y == 0 || unit.Position.Y == m_m)) ||
                ((unit.Position.Y >= 1 && unit.Position.Y <= m_m - 1) && (unit.Position.X == 0 || unit.Position.X == m_n)))
            {
                return true;
            }
            return false;
            //if (m_walls.Exist(unit))
            //{
            //    if ((unit.Position.X == 0 || unit.Position.X == (m_level.N - 1) * WIDTH) && (unit.Position.Y >= 0 || unit.Position.Y <= (m_level.M - 1) * HEIGHT) ||
            //        (unit.Position.Y == 0 || unit.Position.Y == (m_level.M - 1) * Height) && (unit.Position.X >= 0 || unit.Position.X <= (m_level.N - 1) * WIDTH))
            //    {
            //        return true;
            //    }
            //}
            //return false;
        }

        /*private void DrawGrid()
        {
            for(int i = 0; i < level.M; i++)
            {
                Point start = new Point(WIDTH * i, 0);
                Point end = new Point(WIDTH * i, pbxBattleField.Height);
                graphic.DrawLine(pen, start, end);
            }
            for(int i = 0; i < level.N; i++)
            {
                Point start = new Point(0, HEIGHT * i);
                Point end = new Point(pbxBattleField.Width, HEIGHT * i);
                graphic.DrawLine(pen, start, end);
            }
        }*/


        //public void Save(string path)
        //{
        //    m_level.Walls = m_walls;
        //    m_level.SaveLevel(path);
        //}

        //public void Load(string path)
        //{
        //    m_level.LoadLevel(path);
        //    m_walls = m_level.Walls;
        //}

        //private void CreateBorder(int n, int m)
        //{
        //    for (int i = 0; i < n; i++)
        //    {
        //        CreateBorderWall(i * WIDTH, 0);
        //        CreateBorderWall(i * WIDTH, (m - 1) * HEIGHT);
        //    }
        //    for (int j = 0; j < m; j++)
        //    {
        //        CreateBorderWall(0, HEIGHT * j);
        //        CreateBorderWall((n - 1) * WIDTH, HEIGHT * j);
        //    }
        //}

        //private void CreateBorderWall(int x, int y)
        //{
        //    Wall wall = new Wall(x, y);
        //    m_walls.Add(wall);
        //}
    }
}
