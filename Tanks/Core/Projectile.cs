using System.Drawing;

namespace Tanks
{
    public class Projectile : IPositionable, IDrawable, IExecutable, IDirectinable, IEqual
    {
        #region Constructors

        public Projectile(Point position, Direction direction)
        {
            m_direction = direction;
            m_position = position;
        }

        #endregion

        #region IDirectinable

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

        #region IEqual

        public bool Equal(IEqual unit)
        {
            if(unit != null && unit is Projectile)
            {
                if((unit as IPositionable).Position == Position)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region IExecutable

        public CommandResult Move()
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
            return CommandResult.ProjectileMoved;
        }

        public CommandResult NextComand()
        {
            return Move();
        }

        #endregion

        #region Variables

        private Direction m_direction;

        private Bitmap m_tankImage = Images.Projectile;

        private Point m_position;

        #endregion

    }
}
