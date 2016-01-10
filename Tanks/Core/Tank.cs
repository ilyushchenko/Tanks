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
        public Tank()
        {
            InitializeCommands();
            m_currentPosition = Positions.Up;
            m_position = new Point(0, 0);
        }

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
            switch (m_currentPosition)
            {
                case Positions.Up:
                    m_currentPosition = Positions.Left;
                    break;
                case Positions.Down:
                    m_currentPosition = Positions.Right;
                    break;
                case Positions.Left:
                    m_currentPosition = Positions.Down;
                    break;
                case Positions.Right:
                    m_currentPosition = Positions.Up;
                    break;
                default:
                    break;
            }
            m_tankImage.RotateFlip(RotateFlipType.Rotate270FlipNone);
        }

        public void TurnRight()
        {
            switch(m_currentPosition)
            {
                case Positions.Up:
                    m_currentPosition = Positions.Right;
                    break;
                case Positions.Down:
                    m_currentPosition = Positions.Left;
                    break;
                case Positions.Left:
                    m_currentPosition = Positions.Up;
                    break;
                case Positions.Right:
                    m_currentPosition = Positions.Down;
                    break;
                default:
                    break;
            }
            m_tankImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
        }

        public void Move()
        {
            switch (m_currentPosition)
            {
                case Positions.Up:
                    m_position.Offset(0, -40);
                    break;
                case Positions.Down:
                    m_position.Offset(0, 40);
                    break;
                case Positions.Left:
                    m_position.Offset(-40, 0);
                    break;
                case Positions.Right:
                    m_position.Offset(40, 0);
                    break;
                default:
                    break;
            }
        }

        public void CheckCell()
        {

        }

        public void CheckEnemy()
        {

        }

        public void Fire()
        {

        }

        #endregion

        public void ExecuteCommand(string command)
        {
            if (m_commands.ContainsKey(command))
            {
                CommandDelegate Action = m_commands[command];
                Action();
            }
        }

        public bool Equal(IPositionable unit)
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
            m_commands.Add("turn left", new CommandDelegate(TurnLeft));
            m_commands.Add("turn right", new CommandDelegate(TurnRight));
            m_commands.Add("move", new CommandDelegate(Move));
            m_commands.Add("check cell", new CommandDelegate(CheckCell));
            m_commands.Add("check enemy", new CommandDelegate(CheckEnemy));
            m_commands.Add("fire", new CommandDelegate(Fire));
        }

        private Colors GetColor(string color)
        {
            switch (color)
            {
                case "красный":
                    return Colors.Red;
                case "синий":
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

        private Positions m_currentPosition;

        private Bitmap m_tankImage;

        private Point m_position;
        
        private Colors m_tankColor;

        private delegate void CommandDelegate();

        private Dictionary<string, CommandDelegate> m_commands = new Dictionary<string, CommandDelegate>();

        private enum Positions
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

    }
}
