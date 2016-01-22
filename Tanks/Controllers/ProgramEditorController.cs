using System.IO;

namespace Tanks
{
    public class ProgramEditorController
    {
        public void Load(string path)
        {
            using(StreamReader sr = new StreamReader(path))
            {
                m_title = sr.ReadLine();
                m_program = "";
                while(!sr.EndOfStream)
                {
                    m_program += sr.ReadLine() + '\n';
                }
                m_program = m_program.TrimEnd('\n');
            }
        }

        public void Save(string path)
        {
            using(StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(m_title);
                string[] lines = m_program.Split('\n');
                foreach(string line in lines)
                {
                    sw.WriteLine(line);
                }
            }
        }

        public string GetTitle()
        {
            return m_title;
        }

        public string GetProgram()
        {
            return m_program;
        }

        public void SaveChenges(string title, string program)
        {
            m_title = title;
            m_program = program;
        }

        private string m_title;
        private string m_program;
    }
}
