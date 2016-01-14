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
            foreach(ISerializable unit in m_field)
            {
                if(unit is IExecutable)
                {
                    IExecutable executableUnit = unit as IExecutable;
                    CommandResult resultUnit = executableUnit.NextComand(m_field.GetUnit);
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
                        case CommandResult.ProjectileDestoyed:
                            DestroyProjectile(unit);
                            break;
                        case CommandResult.ProjectileKill:
                            KillByProjectile(unit);
                            break;
                    }
                }
            }
        }

        #region Методы обработки результата

        private void DestroyProjectile(ISerializable unit)
        {
            Point currentPosition = (unit as IPositionable).Position;
            m_field.Remove(currentPosition);
        }

        private void KillByProjectile(ISerializable unit)
        {
            Point position = (unit as IPositionable).Position;
            Direction direction = (unit as IDirectinable).Direction;
            Point nextPosition = GetNextPosition(position, direction);
            m_field.Remove(position);
            m_field.Remove(nextPosition);
            m_field.Add(new DestroyedTank(nextPosition));
        }

        private void Fire(ISerializable unit)
        {
            Point currentPosition = (unit as IPositionable).Position;
            Direction direction = (unit as IDirectinable).Direction;
            Point nextPosition = GetNextPosition(currentPosition, direction);
            m_field.Add(new Projectile(nextPosition, direction));
        }

        private void KillByTank(ISerializable unit)
        {
            Point currentPosition = (unit as IPositionable).Position;
            Direction direction = (unit as IDirectinable).Direction;
            Point nextPosition = GetNextPosition(currentPosition, direction);
            m_field.Remove(nextPosition);
            m_field.Add(new DestroyedTank(nextPosition));
        }

        #endregion

        private Level m_level;
    }
}