using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    public class Player
    {
        private int step = 0;
        private string m_nick;

        public string Nick
        {
            get
            {
                return m_nick;
            }

            set
            {
                m_nick = value;
            }
        }

        public Tank Tank
        {
            get
            {
                return m_tank;
            }

            set
            {
                m_tank = value;
            }
        }

        private Tank m_tank;

        private List<string> m_commnads = new List<string>();

        public void LoadCommands(string path)
        {
            using(StreamReader sr = new StreamReader(path))
            {
                while(!sr.EndOfStream)
                {
                    m_commnads.Add(sr.ReadLine());
                }
            }
        }

        public void NextComand()
        {
            m_tank.ExecuteCommand(m_commnads[step++]);
            if(step == m_commnads.Count)
            {
                step = 0;
            }
        }
    }
}
