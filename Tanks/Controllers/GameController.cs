using System;
using System.Collections.Generic;
using System.Drawing;

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

        public void RestartGame()
        {
            m_status = Status.Unplayed;
            List<IPositionable> units = m_field.GetCollections();
            for(int i = 0; i < units.Count; i++)
            {
                if(units[i] is Projectile)
                {
                    m_field.Remove(units[i] as IEqual);
                }
                if(units[i] is Tank)
                {
                    Tank tank = new Tank(units[i] as Tank);
                    PutTank(tank);
                    m_field.Remove(units[i] as IEqual);
                }
            }
        }

        public void NextStep()
        {
            if(m_status == Status.Playing)
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
                            case CommandResult.ProjectileMoved:
                                ProjectileMoved(unit);
                                break;
                        }
                    }
                }
            }           
        }

        private void CheckGameStatus()
        {
            int count = 0;
            foreach(IPositionable unit in m_field)
            {
                if(unit is Tank && (unit as Tank).TankStatus == Tank.Status.Alive)
                {
                    count++;
                }
            }
            if(count == 1)
            {
                GameStatus = Status.End;
            }
        }

        public IScorable GetWinner()
        {
            foreach(IPositionable unit in m_field)
            {
                if(unit is Tank && (unit as Tank).TankStatus == Tank.Status.Alive)
                {
                    return unit as IScorable;
                }
            }
            return null;
        }

        #region Методы обработки результата

        private void Fire(IPositionable unit)
        {
            Direction direction = (unit as IDirectinable).Direction;
            Point nextPosition = GetNextPosition(unit.Position, direction);
            m_field.Add(new Projectile(nextPosition, direction));
        }

        private void KillByProjectile(IPositionable unit)
        {
            IDestroyable destroyedTank = m_field.GetUnit(unit.Position) as IDestroyable;
            destroyedTank.Destroy();
            m_field.Remove(unit as IEqual);
        }

        private void ProjectileMoved(IPositionable unit)
        {
            List<IPositionable> units = m_field.GetAllUnitsOnCell(unit);
            if(units.Count > 1)
            {
                foreach(IPositionable item in units)
                {
                    if(item is Tank)
                    {
                        KillByProjectile(unit);
                    }
                    if(item is Wall)
                    {
                        m_field.Remove(unit as IEqual);
                    }
                }
            }
        }

        #endregion
    }
}