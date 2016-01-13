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
        
        

        private Point GetNextPosition(Point position, Direction direction)
        {
            switch(direction)
            {
                case Direction.Up:
                    return new Point(position.X, position.Y - 1);
                case Direction.Down:
                    return new Point(position.X, position.Y + 1);
                case Direction.Left:
                    return new Point(position.X - 1, position.Y);
                case Direction.Right:
                    return new Point(position.X + 1, position.Y);
                default:
                    return position;
            }
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
                Point position = new Point(x, y);
                if(!m_field.Exist(position))
                {
                    tank.Position = position;
                    m_field.Add(tank);
                    notSet = false;
                }
            } while(notSet);
        }



        public void NextStep()
        {
            for(int i = 0; i < m_field.GetCount(); i++)
            {

                if(m_field[i] is IExecutable)
                {
                    IExecutable executableUnit = m_field[i] as IExecutable;
                    CommandResult resultUnit = executableUnit.NextComand(m_field.GetUnit);
                    Point position, nextPosition;
                    Direction direction;
                    switch(resultUnit)
                    {
                        case CommandResult.Moved:
                            break;
                        case CommandResult.MoveFail:
                            break;
                        case CommandResult.Turned:
                            break;
                        case CommandResult.Fire:
                            position = (m_field[i] as IPositionable).Position;
                            direction = (m_field[i] as IDirectinable).Direction;
                            nextPosition = GetNextPosition(position, direction);
                            m_field.Add(new Projectile(nextPosition, direction));
                            break;
                        case CommandResult.TankKill:
                            position = (m_field[i] as IPositionable).Position;
                            direction = (m_field[i] as IDirectinable).Direction;
                            nextPosition = GetNextPosition(position, direction);
                            m_field.Remove(nextPosition);
                            m_field.Add(new DestroyedTank(nextPosition));
                            break;
                        case CommandResult.FireFail:
                            break;
                        case CommandResult.OK:
                            break;
                        case CommandResult.ProjectileDestoyed:
                            position = (m_field[i] as IPositionable).Position;
                            m_field.Remove(position);
                            break;
                        case CommandResult.ProjectileKill:
                            position = (m_field[i] as IPositionable).Position;
                            direction = (m_field[i] as IDirectinable).Direction;
                            nextPosition = GetNextPosition(position, direction);
                            m_field.Remove(position);
                            m_field.Remove(nextPosition);
                            m_field.Add(new DestroyedTank(nextPosition));
                            break;
                        default:
                            break;
                    }
                    /*if(resultUnit is Tank)
                    {
                        m_field.Remove((resultUnit as IPositionable).Position);
                        m_field.Add(new DestroyedTank((resultUnit as IPositionable).Position));
                    }
                    else if(resultUnit is Projectile)
                    {
                        m_field.Add(resultUnit);
                    }
                    else if(resultUnit is Wall)
                    {
                        m_field.Remove((resultUnit as IPositionable).Position);
                        m_field.Add(new Wall((resultUnit as IPositionable).Position));
                    }*/
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

        public bool CheckIsFree(Point position, Direction direction)
        {
            Point newPosition = GetNewPosition(position, direction);
            if(m_field.GetUnit(newPosition) is Floor)
            {
                return true;
            }
            return false;
            
        }

        public ISerializable Check(Point position, Direction direction)
        {
            Point newPosition = GetNewPosition(position, direction);
            return m_field.GetUnit(newPosition);
        }

        

        private Point GetNewPosition(Point position, Direction direction)
        {
            switch(direction)
            {
                case Direction.Up:
                    return new Point(position.X, position.Y - 1);
                case Direction.Down:
                    return new Point(position.X, position.Y + 1);
                case Direction.Left:
                    return new Point(position.X - 1, position.Y);
                case Direction.Right:
                    return new Point(position.X + 1, position.Y);
                default:
                    return position;
            }
        }
    }
}