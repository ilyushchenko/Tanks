using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    public class GameController : Level
    {
        public GameController()
        {

        }

        public void PutTanks()
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            for(int i = 0; i < m_players.Count; i++)
            {
                bool notSet = false;
                do
                {
                    notSet = true;

                    int x = rand.Next(1, m_n);
                    int y = rand.Next(1, m_m);
                    ISerializable unti = m_field.GetUnit(new Point(x, y));
                    if(unti is Floor)
                    {
                        m_players[i].Tank.Position = new Point(x, y);
                        m_field.SetUnit(m_players[i].Tank);
                        notSet = false;
                    }
                } while(notSet);
            }
        }

        public void NextStep()
        {
            foreach(ISerializable item in m_field)
            {
                if(item is IMoveble)
                {
                    IMoveble dsa = (item as IMoveble);
                    dsa.Move(Check);
                }
                
            }
            /*foreach(Player user in m_players)
            {

                user.NextComand(Check);
            }*/
        }

        public void SwapPosition(Point swapPosition, Point currentPosition)
        {
            ISerializable swapUnit = m_field.GetUnit(swapPosition);
            ISerializable currentUnit = m_field.GetUnit(currentPosition);
            if(swapUnit is Floor)
            {
                Point tempUnit = currentPosition;
                ((IPositionable)currentUnit).Position = ((IPositionable)swapUnit).Position;
                ((IPositionable)swapUnit).Position = tempUnit;
                m_field.SetUnit(swapUnit);
                m_field.SetUnit(currentUnit);
            }
        }

        public void AddPlayer(Player player)
        {
            m_players.Add(player);
        }

        public bool CheckIsFree(Point position, Tank.Direction direction)
        {
            Point newPosition = GetNewPosition(position, direction);
            if(m_field.GetUnit(newPosition) is Floor)
            {
                return true;
            }
            return false;
            
        }

        public ISerializable Check(Point position, Tank.Direction direction)
        {
            Point newPosition = GetNewPosition(position, direction);
            return m_field.GetUnit(newPosition);
        }

        

        private Point GetNewPosition(Point position, Tank.Direction direction)
        {
            switch(direction)
            {
                case Tank.Direction.Up:
                    return new Point(position.X, position.Y - 1);
                case Tank.Direction.Down:
                    return new Point(position.X, position.Y + 1);
                case Tank.Direction.Left:
                    return new Point(position.X - 1, position.Y);
                case Tank.Direction.Right:
                    return new Point(position.X + 1, position.Y);
                default:
                    return position;
            }
        }

        private List<Player> m_players = new List<Player>();
    }
}