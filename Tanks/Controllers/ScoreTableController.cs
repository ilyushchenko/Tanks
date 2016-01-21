using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    public class ScoreTableController
    {
        public ScoreTableController()
        {
            Load();
        }

        public void Load()
        {
            if(!Directory.Exists(DIRECTORY))
            {
                Directory.CreateDirectory(DIRECTORY);
            }
            if(!File.Exists(PATH))
            {
                using(FileStream fs = File.Create(PATH))
                {
                    fs.Close();
                }
            }
            using(StreamReader sr = new StreamReader(PATH))
            {
                while(!sr.EndOfStream)
                {
                    string[] data = sr.ReadLine().Split('|');
                    m_records.Add(data[0], Convert.ToInt32(data[1]));
                }
            }
        }

        public void Save()
        {
            using(StreamWriter sw = new StreamWriter(PATH))
            {
                foreach(var record in m_records)
                {
                    sw.WriteLine("{0}|{1}", record.Key, record.Value);
                }
            }
        }

        public void Add(IScorable unit)
        {
            Player player = unit.SaveResult();
            string title = player.Title;
            if(m_records.ContainsKey(title))
            {
                int count = m_records[title];
                m_records[title] = ++count;
            }
            else
            {
                m_records.Add(title, 1);
            }
        }

        public Dictionary<string, int> GetScoreTable()
        {
            return m_records;
        }

        private const string FILE = "score.txt";
        private const string DIRECTORY = "Private";
        private const string PATH = DIRECTORY + "\\" + FILE;

        Dictionary<string, int> m_records = new Dictionary<string, int>();
    }
}
