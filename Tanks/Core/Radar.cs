using System.Drawing;

namespace Tanks
{
    public class Radar
    {
        public enum RadarResult
        {
            Enemy,
            Wall,
            Free,
            EnemyVisible,
            EnemyNotVisible
        }

        public Radar(UnitCollection field)
        {
            m_field = field;
        }

        public RadarResult CheckEnemy(Point unitPosition, Direction unitDirection)
        {
            Point nextPosition = unitPosition;
            IPositionable nextUnit;
            do
            {
                nextPosition = GetNextPosition(nextPosition, unitDirection);
                nextUnit = m_field.GetUnit(nextPosition);
            }
            while(nextUnit == null);
            if(nextUnit is Tank)
            {
                return RadarResult.EnemyVisible;
            }
            else
            {
                return RadarResult.EnemyNotVisible;
            }
        }

        public RadarResult CheckCell(Point unitPosition, Direction unitDirection)
        {
            Point nextPosition = GetNextPosition(unitPosition, unitDirection);
            IPositionable nextUnit = m_field.GetUnit(nextPosition);
            if(nextUnit == null)
            {
                return RadarResult.Free;
            }
            else if(nextUnit is Wall)
            {
                return RadarResult.Wall;
            }
            else
            {
                return RadarResult.Enemy;
            }
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

        private UnitCollection m_field;
    }
}
