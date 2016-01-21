using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    public class Player
    {
        public string Title
        {
            get
            {
                return m_title;
            }

            set
            {
                m_title = value;
            }
        }

        public void LoadCommands(string path)
        {
            using(StreamReader sr = new StreamReader(path))
            {
                while(!sr.EndOfStream)
                {
                    m_commnads.Add(GetCommand(sr.ReadLine()));
                }
            }
        }

        public Commands NextComand()
        {
            Commands command = m_commnads[step++];
            if(step == m_commnads.Count)
            {
                step = 0;
            }
            return command;
        }

        private Commands GetCommand(string command)
        {
            switch(command.ToLower())
            {
                case "left": return Commands.Left;
                case "right": return Commands.Right;
                case "move": return Commands.Move;
                case "check cell": return Commands.CheckCell;
                case "check enemy": return Commands.CheckEnemy;
                case "fire": return Commands.Fire;
                default: return Commands.Unknown;
            }
        }

        private int step = 0;

        private string m_title;

        private List<Commands> m_commnads = new List<Commands>();

        public Commands NextComand(bool isResult)
        {
            Commands command;
            if(isResult)
            {
                command = m_commnads[step++];
                step++;
            }
            else
            {
                step++;
                if(step == m_commnads.Count)
                {
                    step = 0;
                }
                command = m_commnads[step++];
            }
            if(step >= m_commnads.Count)
            {
                step = 0;
            }
            return command;
        }
    }
}
