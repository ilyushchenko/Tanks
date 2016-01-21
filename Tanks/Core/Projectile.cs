using System.Drawing;

namespace Tanks
{
    public class Projectile : IPositionable, IDrawable, IExecutable, IDirectinable
    {
        public Projectile(Point position, Direction direction)
        {
            m_direction = direction;
            m_position = position;
        }

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

        private Direction m_direction;

        private Bitmap m_tankImage = Images.Projectile;

        private Point m_position;

    }
}
