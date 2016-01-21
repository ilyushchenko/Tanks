using System.Drawing;

namespace Tanks
{
    public class EditorController : Level
    {
        public EditorController()
        {

        }

        public EditorController(int n, int m) : base(n, m)
        {
            CreateBorder();
        }

        public void CheckWall(int x, int y)
        {
            int curX = x / Width;
            int curY = y / Height;
            Point position = new Point(curX, curY);
            if(m_field.Exist(position))
            {
                IPositionable unit = m_field.GetUnit(new Point(curX, curY));
                if(!OnBorder(unit))
                {
                    m_field.Remove(position);
                }
            }
            else
            {
                m_field.Add(new Wall(position));
            }
        }

        private void CreateBorder()
        {
            for (int i = 0; i < m_n; i++)
            {
                m_field.Add(new Wall(i, 0));
                m_field.Add(new Wall(i, m_m - 1));
            }
            for (int i = 1; i < m_m - 1; i++)
            {
                m_field.Add(new Wall(0, i));
                m_field.Add(new Wall(m_n - 1, i));
            }
        }
        
        private bool OnBorder(IPositionable unit)
        {
            Point position = unit.Position;
            if (((position.X >= 0 && position.X <= m_n) && (position.Y == 0 || position.Y == m_m - 1)) ||
                ((position.Y >= 1 && position.Y <= m_m - 1) && (position.X == 0 || position.X == m_n - 1)))
            {
                return true;
            }
            return false;
        }
    }
}
