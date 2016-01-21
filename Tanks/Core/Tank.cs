using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace Tanks
{
    public class Tank : IPositionable, ISerializable, IDrawable, IExecutable, IDirectinable, IScorable
    {
        #region Constructors

        public Tank()
        {
            m_direction = Direction.Up;
            m_position = new Point(0, 0);
            InitializeCommands();
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

        #region IDirectable

        public Direction Direction
        {
            get
            {
                return m_direction;
            }

            set
            {
                m_direction = value;
            }
        }


        #endregion

        #region Action of tank

        public CommandResult TurnLeft()
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
            return CommandResult.Turned;
        }

        public CommandResult TurnRight()
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
            return CommandResult.Turned;
        }

        public CommandResult Move()
        {
            Radar.RadarResult result = m_radar.CheckCell(m_position, m_direction);
            if(result == Radar.RadarResult.Free)
            {
                switch(m_direction)
                {
                    case Direction.Up:
                        m_position.Offset(0, -1);
                        break;
                    case Direction.Down:
                        m_position.Offset(0, 1);
                        break;
                    case Direction.Left:
                        m_position.Offset(-1, 0);
                        break;
                    case Direction.Right:
                        m_position.Offset(1, 0);
                        break;
                }
                return CommandResult.Moved;
            }
            return CommandResult.MoveFail;
        }

        public CommandResult Fire()
        {
            Radar.RadarResult result = m_radar.CheckCell(m_position, m_direction);
            if(result == Radar.RadarResult.Free)
            {
                return CommandResult.Fire;
            }
            else if(result == Radar.RadarResult.Enemy)
            {
                return CommandResult.TankKill;
            }
            return CommandResult.FireFail;
        }

        public CommandResult CheckEnemy()
        {
            isEnemyVisible = (m_radar.CheckEnemy(m_position, m_direction) == Radar.RadarResult.Enemy) ? true : false;
            return (isEnemyVisible) ? CommandResult.EnemyVisible : CommandResult.EnemyNotVisible;
        }

        public CommandResult CheckCell()
        {
            isCanMove = (m_radar.CheckCell(m_position, m_direction) == Radar.RadarResult.Free) ? true : false;
            return (isCanMove) ? CommandResult.CanMove : CommandResult.CantMove;
        }

        #endregion

        #region Additional methods

        public void SetColor(string color)
        {
            m_tankColor = GetColor(color);
            switch(m_tankColor)
            {
                case Colors.Black:
                    m_tankImage = Images.Black;
                    break;
                case Colors.Blue:
                    m_tankImage = Images.Blue;
                    break;
                case Colors.Green:
                    m_tankImage = Images.Green;
                    break;
                case Colors.Orange:
                    m_tankImage = Images.Orange;
                    break;
                case Colors.Pink:
                    m_tankImage = Images.Pink;
                    break;
                case Colors.Purple:
                    m_tankImage = Images.Purple;
                    break;
                case Colors.Red:
                    m_tankImage = Images.Red;
                    break;
                case Colors.Yellow:
                    m_tankImage = Images.Yellow;
                    break;
            }
        }

        private Colors GetColor(string color)
        {
            switch(color)
            {
                case "черный":
                    return Colors.Red;
                case "голубой":
                    return Colors.Blue;
                case "зеленый":
                    return Colors.Green;
                case "оранжевый":
                    return Colors.Yellow;
                case "розовый":
                    return Colors.Pink;
                case "малиновый":
                    return Colors.Purple;
                case "красный":
                    return Colors.Red;
                case "желтый":
                    return Colors.Yellow;
                default:
                    return Colors.Unknown;
            }
        }

        public void SetRadar(Radar radar)
        {
            m_radar = radar;
        }

        public void SetPlayer(Player plaer)
        {
            m_player = plaer;
        }

        public CommandResult NextComand()
        {
            // TODO Доделать следующую комманду
            if(m_currentCommand == Commands.CheckCell || m_currentCommand == Commands.CheckEnemy)
            {
                if(m_currentCommand == Commands.CheckCell)
                {
                    m_currentCommand = m_player.NextComand(isCanMove);
                }
                else
                {
                    m_currentCommand = m_player.NextComand(isEnemyVisible);
                }
            }
            else
            {
                m_currentCommand = m_player.NextComand();
            }
            if(m_commands.ContainsKey(m_currentCommand))
            {
                return m_commands[m_currentCommand]();
            }
            else
            {
                return CommandResult.Unknown;
            }            
        }

        public Player SaveResult()
        {
            return m_player;
        }

        private void InitializeCommands()
        {
            m_commands.Add(Commands.Left, TurnLeft);
            m_commands.Add(Commands.Right, TurnRight);
            m_commands.Add(Commands.Move, Move);
            m_commands.Add(Commands.Fire, Fire);
            m_commands.Add(Commands.CheckCell, CheckCell);
            m_commands.Add(Commands.CheckEnemy, CheckEnemy);
        }

        #endregion

        #region Delegate

        public delegate CommandResult Action();

        #endregion

        #region Variables

        private Direction m_direction;

        private Bitmap m_tankImage = Images.Tank;

        private Point m_position;

        private Player m_player;

        private Radar m_radar;

        private Colors m_tankColor;

        public bool isCanMove;

        public bool isEnemyVisible;

        private Commands m_currentCommand = Commands.Unknown;

        private Dictionary<Commands, Action> m_commands = new Dictionary<Commands, Action>();

        #endregion

        #region Enums

        private enum Colors
        {
            Black,
            Blue,
            Green,
            Orange,
            Pink,
            Purple,
            Red,
            Yellow,
            Unknown
        }
        
        #endregion
    }
}
