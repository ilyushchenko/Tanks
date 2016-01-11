using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace Tanks
{
    public class Tank : IPositionable, ISerializable, IDrawable, IExecutable
    {
        #region Constructors

        public Tank()
        {
            m_direction = Direction.Up;
            m_position = new Point(0, 0);
        }

        public Tank(Point position, Direction direction)
        {
            m_direction = direction;
            m_position = position;
        }

        #endregion

        #region IPositionable

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

        #endregion

        #region IDrawable

        public void Draw(Graphics graphic)
        {
            graphic.DrawImage(m_tankImage, m_position.X * m_tankImage.Width, m_position.Y * m_tankImage.Height);
        }

        #endregion

        #region ISerializable

        public void Load(StreamReader inFile)
        {
            string[] data = inFile.ReadLine().Split();
            m_position.X = Convert.ToInt32(data[0]);
            m_position.Y = Convert.ToInt32(data[1]);
            SetColor(data[2]);
        }

        public void Save(StreamWriter outFile)
        {
            outFile.WriteLine("tank");
            outFile.WriteLine("{0} {1} {2}", m_position.X, m_position.Y, m_tankColor.ToString().ToLower());
        }

        #endregion

        #region Action of tank

        public void TurnLeft()
        {
            switch (m_direction)
            {
                case Direction.Up:
                    m_direction = Direction.Left;
                    break;
                case Direction.Down:
                    m_direction = Direction.Right;
                    break;
                case Direction.Left:
                    m_direction = Direction.Down;
                    break;
                case Direction.Right:
                    m_direction = Direction.Up;
                    break;
                default:
                    break;
            }
            m_tankImage.RotateFlip(RotateFlipType.Rotate270FlipNone);
        }

        public void TurnRight()
        {
            switch(m_direction)
            {
                case Direction.Up:
                    m_direction = Direction.Right;
                    break;
                case Direction.Down:
                    m_direction = Direction.Left;
                    break;
                case Direction.Left:
                    m_direction = Direction.Up;
                    break;
                case Direction.Right:
                    m_direction = Direction.Down;
                    break;
                default:
                    break;
            }
            m_tankImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
        }

        public void Move(Func<Point, ISerializable> GetUnit, Action<ISerializable> SetUnit)
        {
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




            /*ISerializable unit = swapPosition(Position, m_direction);
            Point currentPosition = new Point(Position.X, Position.Y);
            if(unit is Floor)
            {
                Position = (unit as IPositionable).Position;
                (unit as IPositionable).Position = currentPosition;
            }*/
        }

        public void Fire(Func<Point, ISerializable> GetUnit, Action<ISerializable> SetUnit)
        {
            Point nextPosition = GetNextPosition(m_position, m_direction);
            ISerializable nextUnit = GetUnit(nextPosition);
            if(nextUnit is Floor)
            {
                nextUnit = new Projectile(nextPosition, m_direction);
                SetUnit(nextUnit);
            }
        }

        public void CheckEnemy(Func<Point, ISerializable> GetUnit)
        {
            Point nextPosition = GetNextPosition(m_position, m_direction);
            ISerializable nextUnit = GetUnit(nextPosition);
            if(nextUnit is Tank)
            {
                IsCanMove = true;
            }
            else
            {
                IsCanMove = false;
            }
        }

        public void CheckCell(Func<Point, ISerializable> GetUnit)
        {
            Point nextPosition = GetNextPosition(m_position, m_direction);
            ISerializable nextUnit = GetUnit(nextPosition);
            if(nextUnit is Floor)
            {
                IsEnemyVisible = true;
            }
            else
            {
                IsEnemyVisible = false;
            }
        }

        #endregion

        #region Additional methods

        public void SetColor(string color)
        {
            m_tankColor = GetColor(color);
            switch(m_tankColor)
            {
                case Colors.Red:
                    m_tankImage = Images.Red;
                    break;
                case Colors.Green:
                    break;
                case Colors.Blue:
                    m_tankImage = Images.Blue;
                    break;
                default:
                    break;
            }
        }

        public void SetPlayer(Player plaer)
        {
            m_player = plaer;
        }

        public void NextComand(Func<Point, ISerializable> GetUnit, Action<ISerializable> SetUnit)
        {
            Commands command = m_player.NextComand();
            switch(command)
            {
                case Commands.Left:
                    TurnLeft();
                    break;
                case Commands.Right:
                    TurnRight();
                    break;
                case Commands.Move:
                    Move(GetUnit, SetUnit);
                    break;
                case Commands.CheckCell:
                    CheckCell(GetUnit);
                    break;
                case Commands.CheckEnemy:
                    CheckEnemy(GetUnit);
                    break;
                case Commands.Fire:
                    Fire(GetUnit, SetUnit);
                    break;
                case Commands.Unknown:
                    break;
                default:
                    break;
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

        /*private void InitializeCommands()
        {
            m_commandsWithOutCheck.Add(Commands.Left, new ExecuteAction(TurnLeft));
            m_commandsWithOutCheck.Add(Commands.Right, new ExecuteAction(TurnRight));
            m_commandsWithCheck.Add(Commands.Move, new ExecuteMyAction(Move));
            m_commandsWithCheck.Add(Commands.CheckCell, new ExecuteMyAction(CheckCell));
            m_commandsWithCheck.Add(Commands.CheckEnemy, new ExecuteMyAction(CheckEnemy));
            m_commandsWithCheck.Add(Commands.Fire, new ExecuteMyAction(Fire));
        }*/

        private Colors GetColor(string color)
        {
            switch(color)
            {
                case "красный":
                case "red":
                    return Colors.Red;
                case "голубой":
                case "blue":
                    return Colors.Blue;
                case "зеленый":
                    return Colors.Green;
                case "желтый":
                    return Colors.Yellow;
                case "фиолетовый":
                    return Colors.Unknown;
                case "малиновый":
                    return Colors.Unknown;
                case "черный":
                    return Colors.Unknown;
                case "коричневый":
                    return Colors.Unknown;
                default:
                    return Colors.Unknown;
            }
        }

        #endregion

        #region Delegates

        //public delegate void ExecuteAction();

        //public delegate void ExecuteMyAction(ExecuteMovableAction action);

        //public delegate void ExecuteMovableAction(Point swapPosition, Point currentPosition);

        //public delegate ISerializable ExecuteMovableAction(Point swapPosition, Direction direction);

        #endregion

        #region Variables

        private Direction m_direction;

        private Bitmap m_tankImage = Images.Tank;

        private Point m_position;

        private Player m_player;

        private Colors m_tankColor;

        //private Dictionary<Commands, ExecuteAction> m_commandsWithOutCheck = new Dictionary<Commands, ExecuteAction>();
        //private Dictionary<Commands, ExecuteMyAction> m_commandsWithCheck = new Dictionary<Commands, ExecuteMyAction>();

        public bool IsCanMove { get; set; }

        public bool IsEnemyVisible { get; set; }

        #endregion

        #region Enums

        public enum Direction
        {
            Up, Down, Left, Right
        }

        private enum Colors
        {
            Red,
            Green,
            Blue,
            Yellow,
            Unknown
        }



        #endregion
    }
}
