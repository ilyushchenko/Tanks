using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace Tanks
{
    public class Tank : IPositionable, ISerializable, IDrawable, IMoveble
    {
        #region Constructors

        public Tank()
        {
            InitializeCommands();
            m_direction = Direction.Up;
            m_position = new Point(0, 0);
        }

        public Tank(Point position, Direction direction)
        {
            InitializeCommands();
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

        public void Move(ExecuteMovableAction swapPosition)
        {
            if(enemyIsVisivle)
            {
                Fire(swapPosition);
                enemyIsVisivle = false;

            }
            
            /*ISerializable unit = swapPosition(Position, m_direction);
            Point currentPosition = new Point(Position.X, Position.Y);
            if(unit is Floor)
            {
                Position = (unit as IPositionable).Position;
                (unit as IPositionable).Position = currentPosition;
            }*/
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

        /*public void Move()
        {
            switch(m_direction)
            {
                case Direction.Up:
                    //check(new Point(Position.X, Position.Y + 1));
                    break;
                case Direction.Down:
                    m_position.Offset(0, 40);
                    break;
                case Direction.Left:
                    m_position.Offset(-40, 0);
                    break;
                case Direction.Right:
                    m_position.Offset(40, 0);
                    break;
                default:
                    break;
            }
        }*/

        public void CheckCell(ExecuteMovableAction swapPosition)
        {
            ISerializable unit = swapPosition(Position, m_direction);
            Point currentPosition = new Point(Position.X, Position.Y);
            if(unit is Floor)
            {
                Position = (unit as IPositionable).Position;
                (unit as IPositionable).Position = currentPosition;
            }
        }

        public void CheckEnemy(ExecuteMovableAction swapPosition)
        {
            ISerializable unit;
            Point positionOfNextUnit = m_position;
            do
            {
                unit = swapPosition(positionOfNextUnit, m_direction);
                positionOfNextUnit = (unit as IPositionable).Position;

            } while(unit is Floor);
            enemyIsVisivle = (unit is Tank) ? true : false; 
        }

        public void Fire(ExecuteMovableAction swapPosition)
        {
            ISerializable unit = swapPosition(Position, m_direction);
            if(!(unit is Wall))
            {
                if(unit is Floor)
                {
                    unit = new Projectile((unit as IPositionable).Position, m_direction); 
                }
            }
        }

        #endregion

        #region Additional methods

        /*public void ExecuteCommand(Commands command)
        {
            if (m_commands.ContainsKey(command))
            {
                ExecuteAction Action = m_commands[command];
                Action();
            }
        }*/

        public void ExecuteCommand(Commands command, ExecuteMovableAction swapPosition)
        {
            if(m_commandsWithOutCheck.ContainsKey(command))
            {
                ExecuteAction Action = m_commandsWithOutCheck[command];
                Action();
            }
            if(m_commandsWithCheck.ContainsKey(command))
            {
                ExecuteMyAction Action = m_commandsWithCheck[command];
                Action(swapPosition);
            }
        }

        public void SetColor(string color)
        {
            m_tankColor = GetColor(color);
            switch (m_tankColor)
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

        private void InitializeCommands()
        {
            m_commandsWithOutCheck.Add(Commands.Left, new ExecuteAction(TurnLeft));
            m_commandsWithOutCheck.Add(Commands.Right, new ExecuteAction(TurnRight));
            m_commandsWithCheck.Add(Commands.Move, new ExecuteMyAction(Move));
            m_commandsWithCheck.Add(Commands.CheckCell, new ExecuteMyAction(CheckCell));
            m_commandsWithCheck.Add(Commands.CheckEnemy, new ExecuteMyAction(CheckEnemy));
            m_commandsWithCheck.Add(Commands.Fire, new ExecuteMyAction(Fire));
        }

        private Colors GetColor(string color)
        {
            switch (color)
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

        public delegate void ExecuteAction();
        public delegate void ExecuteMyAction(ExecuteMovableAction action);

        //public delegate void ExecuteMovableAction(Point swapPosition, Point currentPosition);

        public delegate ISerializable ExecuteMovableAction(Point swapPosition, Direction direction);

        #endregion

        #region Variables

        private Direction m_direction;

        private Bitmap m_tankImage;

        private Point m_position;
        
        private Colors m_tankColor;

        private Dictionary<Commands, ExecuteAction> m_commandsWithOutCheck = new Dictionary<Commands, ExecuteAction>();
        private Dictionary<Commands, ExecuteMyAction> m_commandsWithCheck = new Dictionary<Commands, ExecuteMyAction>();


        private bool enemyIsVisivle = true;

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

        /*public bool Equal(IPositionable unit)
        {
            if (unit is Tank && unit != null)
            {
                if (unit.Position == m_position)
                {
                    return true;
                }
            }
            return false;
            //return (tank.Position == m_position) ? true : false;
        }*/
    }
}
