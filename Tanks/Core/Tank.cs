using System.Collections.Generic;
using System.Drawing;

namespace Tanks
{
    public class Tank : IPositionable, IDrawable, IExecutable, IDirectinable, IScorable, IEqual, IDestroyable
    {
        #region Constructors

        public Tank()
        {
            m_direction = Direction.Up;
            m_position = new Point(0, 0);
            InitializeCommands();
        }

        public Tank(Tank tank)
        {
            m_commandComtroller = tank.m_commandComtroller;
            m_radar = tank.m_radar;
            m_tankColor = tank.m_tankColor;
            m_status = Status.Alive;
            SetImage(m_tankColor);
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

        public Status TankStatus
        {
            get
            {
                return m_status;
            }
        }

        #endregion

        #region IEqual

        public bool Equal(IEqual unit)
        {
            if(unit != null && unit is Tank)
            {
                if((unit as IPositionable).Position == Position)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region IDestroyable

        public void Destroy()
        {
            m_status = Status.Dead;
            m_tankImage = Images.Fire;
        }

        #endregion

        #region Actions of tank

        public CommandResult NextComand()
        {
            if(m_status == Status.Alive)
            {
                Commands command = m_commandComtroller.NextComand();
                if(m_actions.ContainsKey(command))
                {
                    return m_actions[command]();
                }
            }
            return CommandResult.Unknown;
        }

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
            if(result == Radar.RadarResult.Free || result == Radar.RadarResult.Enemy)
            {
                return CommandResult.Fire;
            }
            return CommandResult.FireFail;
        }

        public CommandResult CheckEnemy()
        {
            bool isEnemyVisible = (m_radar.CheckEnemy(m_position, m_direction) == Radar.RadarResult.Enemy) ? true : false;
            if(isEnemyVisible)
            {
                m_commandComtroller.SetTrueBranch();
                return CommandResult.EnemyVisible;
            }
            else
            {
                m_commandComtroller.SetFalseBranch();
                return CommandResult.EnemyNotVisible;
            }
        }

        public CommandResult CheckCell()
        {
            bool isCanMove = (m_radar.CheckCell(m_position, m_direction) == Radar.RadarResult.Free) ? true : false;
            if(isCanMove)
            {
                m_commandComtroller.SetTrueBranch();
                return CommandResult.CanMove;
            }
            else
            {
                m_commandComtroller.SetFalseBranch();
                return CommandResult.CantMove;
            }
        }

        #endregion

        #region Additional methods

        public void SetColor(string color)
        {
            m_tankColor = GetColor(color.ToLower());
            SetImage(m_tankColor);
        }

        private void SetImage(Colors color)
        {
            switch(color)
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

        public void SetRadar(Radar radar)
        {
            m_radar = radar;
        }

        public void SetCommandController(CommandController plaer)
        {
            m_commandComtroller = plaer;
        }

        public CommandController SaveResult()
        {
            return m_commandComtroller;
        }

        private Colors GetColor(string color)
        {
            switch(color)
            {
                case "черный":
                    return Colors.Black;
                case "голубой":
                    return Colors.Blue;
                case "зеленый":
                    return Colors.Green;
                case "оранжевый":
                    return Colors.Orange;
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

        private void InitializeCommands()
        {
            m_actions.Add(Commands.Left, TurnLeft);
            m_actions.Add(Commands.Right, TurnRight);
            m_actions.Add(Commands.Move, Move);
            m_actions.Add(Commands.Fire, Fire);
            m_actions.Add(Commands.CheckCell, CheckCell);
            m_actions.Add(Commands.CheckEnemy, CheckEnemy);
        }


        #endregion

        #region Delegate

        public delegate CommandResult Action();

        #endregion

        #region Variables

        private Bitmap m_tankImage = Images.Tank;

        private Point m_position;

        private CommandController m_commandComtroller;

        private Radar m_radar;

        private Colors m_tankColor;

        private Direction m_direction;

        private Status m_status = Status.Alive;

        private Dictionary<Commands, Action> m_actions = new Dictionary<Commands, Action>();

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

        public enum Status
        {
            Alive,
            Dead
        }
        
        #endregion
    }
}
