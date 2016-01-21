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
            Random rand = new Random();
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
            if(Status == Status.Playing)
            {
                CheckGameStatus();
                foreach(IPositionable unit in m_field)
                {
                    if(unit is IExecutable)
                    {
                        IExecutable executableUnit = unit as IExecutable;
                        CommandResult resultUnit = executableUnit.NextComand();
                        switch(resultUnit)
                        {
                            case CommandResult.Fire:
                                Fire(unit);
                                break;
                            case CommandResult.TankKill:
                                KillByTank(unit);
                                break;
                            case CommandResult.FireFail:
                                break;
                            case CommandResult.ProjectileMoved:
                                ProjectileMoved(unit);
                                break;
                        }
                    }
                }
            }           
        }

        private void ProjectileMoved(IPositionable unit)
        {
            IPositionable searchedUnit = m_field.GetUnit(unit.Position);
        }

        private void CheckGameStatus()
        {
            int count = 0;
            Tank winner = null;
            foreach(ISerializable unit in m_field)
            {
                if(unit is Tank)
                {
                    winner = unit as Tank;
                    count++;
                }
            }
            if(count == 1)
            {
                Status = Status.End;
            }
        }

        public IScorable GetWinner()
        {
            foreach(ISerializable unit in m_field)
            {
                if(unit is Tank )
                {
                    return unit as IScorable;
                }
            }
            return null;
        }

        #region Методы обработки результата

        private void DestroyProjectile(IPositionable unit)
        {
            Point currentPosition = unit.Position;
            m_field.Remove(currentPosition);
        }

        private void KillByProjectile(IPositionable unit)
        {
            Point position = unit.Position;
            Direction direction = (unit as IDirectinable).Direction;
            Point nextPosition = GetNextPosition(position, direction);
            m_field.Remove(position);
            m_field.Remove(nextPosition);
            m_field.Add(new DestroyedTank(nextPosition));
        }

        private void Fire(IPositionable unit)
        {
            Point currentPosition = unit.Position;
            Direction direction = (unit as IDirectinable).Direction;
            Point nextPosition = GetNextPosition(currentPosition, direction);
            m_field.Add(new Projectile(nextPosition, direction));
        }

        private void KillByTank(IPositionable unit)
        {
            Point currentPosition = unit.Position;
            Direction direction = (unit as IDirectinable).Direction;
            Point nextPosition = GetNextPosition(currentPosition, direction);
            m_field.Remove(nextPosition);
            m_field.Add(new DestroyedTank(nextPosition));
        }

        #endregion
    }
}