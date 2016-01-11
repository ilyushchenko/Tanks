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

        public void PutTank(Tank tank)
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            bool notSet = false;
            do
            {
                notSet = true;

                int x = rand.Next(1, m_n);
                int y = rand.Next(1, m_m);
                ISerializable unti = m_field.GetUnit(new Point(x, y));
                if(unti is Floor)
                {
                    tank.Position = new Point(x, y);
                    m_field.SetUnit(tank);
                    notSet = false;
                }
            } while(notSet);

        }



        public void NextStep()
        {
            foreach(ISerializable unit in m_field)
            {
                if(unit is IExecutable)
                {
                    IExecutable executableUnit = unit as IExecutable;
                    executableUnit.NextComand(m_field.GetUnit, m_field.SetUnit);
                }
            }
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
    }
}