using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    public class Projectile : IPositionable, ISerializable, IDrawable, IMoveble
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

        public void Move(Tank.ExecuteMovableAction swapPosition)
        {
            ISerializable unit = swapPosition(Position, m_direction);
            Point currentPosition = new Point(Position.X, Position.Y);
            if(unit is Floor)
            {
                Position = (unit as IPositionable).Position;
                (unit as IPositionable).Position = currentPosition;
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
