using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    public class GameController : Level
    {
        public GameController()
        {

        }

        public void PutTanks()
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            for(int i = 0; i < m_players.Count; i++)
            {
                bool notSet = false;
                do
                {
                    notSet = true;

                    int x = rand.Next(1, m_n);
                    int y = rand.Next(1, m_m);
                    if(m_field[x, y] is Floor)
                    {
                        m_players[i].Tank.Position = new Point(x, y);
                        m_field[x, y] = m_players[i].Tank;
                        notSet = false;
                    }
                    //for(int j = 0; j < m_walls.GetCount(); j++)
                    //{
                    //    if(m_tanks[i].Position == m_walls[j].Position)
                    //    {
                    //        notSet = true;
                    //        break;
                    //    }
                    //}
                    //for(int k = 0; k < m_tanks.GetCount(); k++)
                    //{
                    //    if(m_tanks[i].Position == m_tanks[k].Position && i != k)
                    //    {
                    //        notSet = true;
                    //        break;
                    //    }
                    //}

                } while(notSet);
            }
        }

        public void NextStep()
        {
            foreach(Player user in m_players)
            {
                Commands IsFree = user.NextComand();
                if(IsFree != Commands.Left && IsFree != Commands.Right && IsFree != Commands.Unknown)
                {
                    user.ExecuteCommand(command);
                }
                else
                {
                    user.ExecuteCommand(command, IsFree);
                }
            }
        }

        public void AddPlayer(Player player)
        {
            m_players.Add(player);
        }

        public bool IsFree(Point position)
        {
            if(m_field[position.X, position.Y] is Floor)
            {
                return true;
            }
            return false;
            //return m_field.Exists(p => unit.Equal(p));
        }

        private List<Player> m_players = new List<Player>();
    }
}
