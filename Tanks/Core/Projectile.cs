using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    public class Projectile : IPositionable, ISerializable, IDrawable, IExecutable
    {
        public Projectile()
        {
            m_direction = Tank.Direction.Up;
            m_position = new Point(0, 0);
        }

        public Projectile(Point position, Tank.Direction direction)
        {
            m_direction = direction;
            m_position = position;
        }

        public Point Position
        {
            get
            {
                return m_position;
            }

            set
            {
                m_position = value;
            }
        }


        public void Draw(Graphics graphic)
        {
            graphic.DrawImage(m_tankImage, m_position.X * m_tankImage.Width, m_position.Y * m_tankImage.Height);
        }

        public void Load(StreamReader inFile)
        {
            string[] data = inFile.ReadLine().Split();
            m_position.X = Convert.ToInt32(data[0]);
            m_position.Y = Convert.ToInt32(data[1]);
        }

        public void Save(StreamWriter outFile)
        {
            outFile.WriteLine("tank");
            outFile.WriteLine("{0} {1}", m_position.X, m_position.Y);
        }

        public void Move(ExecuteMovableAction swapPosition)
        {
            ISerializable unit = swapPosition(Position, m_direction);
            Point currentPosition = new Point(Position.X, Position.Y);
            if(unit is Floor)
            {
                Position = (unit as IPositionable).Position;
                (unit as IPositionable).Position = currentPosition;
            }
        }


        public void ExecuteCommand(Commands command, ExecuteMovableAction swapPosition)
        {
            Move(swapPosition);
        }

        public void NextComand(Func<Point, ISerializable> GetUnit, Action<ISerializable> SetUnit)
        {
            //Point currentPosition = GetNextPosition(m_position, m_direction);

            Point nextPosition = GetNextPosition(m_position, m_direction);
            Point currentPosition = new Point(m_position.X, m_position.Y);
            ISerializable swapUnit = GetUnit(nextPosition);
            ISerializable currentUnit = GetUnit(currentPosition);
            if(swapUnit is Floor)
            {
                Point tempUnit = currentPosition;
                ((IPositionable)currentUnit).Position = ((IPositionable)swapUnit).Position;
                ((IPositionable)swapUnit).Position = tempUnit;
                SetUnit(swapUnit);
                SetUnit(currentUnit);
            }
            else if(swapUnit is Tank)
            {
                // TODO Сделать можель разрушенного танка
                Wall tank = new Wall();
                tank.Position = ((IPositionable)swapUnit).Position;
                swapUnit = tank;
                currentUnit = new Floor(m_position.X, m_position.Y);
                SetUnit(currentUnit);
                SetUnit(swapUnit);


            }
            else
            {
                currentUnit = new Floor(m_position.X, m_position.Y);
                SetUnit(currentUnit);
            }
        }

        private Point GetNextPosition(Point position, Tank.Direction direction)
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

        public delegate void ExecuteAction();

        //public delegate void ExecuteMovableAction(Point swapPosition, Point currentPosition);

        public delegate ISerializable ExecuteMovableAction(Point swapPosition, Tank.Direction direction);


        private Tank.Direction m_direction;

        private Bitmap m_tankImage = Images.Projectile;

        private Point m_position;

    }
}
