using System.Collections.Generic;
using System.IO;

namespace Tanks
{
    public class CommandController
    {
        #region Properties

        public string Title
        {
            get
            {
                return m_title;
            }
        }

        #endregion

        #region Load

        public void LoadCommands(string path)
        {
            using(StreamReader sr = new StreamReader(path))
            {
                m_title = sr.ReadLine();
                while(!sr.EndOfStream)
                {
                    m_commnads.Add(GetCommand(sr.ReadLine()));
                }
            }
        }

        #endregion

        #region Execute

        public void SetTrueBranch()
        {
            m_result = CommandResult.True;
        }

        public void SetFalseBranch()
        {
            m_result = CommandResult.False;
        }

        public Commands NextComand()
        {
            Commands command;
            if(m_result == CommandResult.True)
            {
                command = m_commnads[GetNextIndex()];
                GetNextIndex();
                m_result = CommandResult.Void;
            }
            else if(m_result == CommandResult.False)
            {
                GetNextIndex();
                command = m_commnads[GetNextIndex()];
                m_result = CommandResult.Void;
            }
            else
            {
                command = m_commnads[GetNextIndex()];
            }
            return command;
        }

        #endregion

        #region Additional methods

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

        private int GetNextIndex()
        {
            nextStep++;
            if(nextStep == m_commnads.Count)
            {
                nextStep = 0;
            }
            return nextStep;
        }

        #endregion

        #region Variables

        private int nextStep = 0;

        private string m_title;

        private CommandResult m_result = CommandResult.Void;

        private List<Commands> m_commnads = new List<Commands>();

        #endregion

        #region Enums

        private enum CommandResult
        {
            True,
            False,
            Void
        }

        #endregion
    }
}
