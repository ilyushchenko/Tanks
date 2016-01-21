using System;
using System.Collections.Generic;
using System.IO;

namespace Tanks
{
    public class ScoreTableController
    {
        #region Constructors

        public ScoreTableController()
        {
            Load();
        }

        #endregion

        #region Save/Load

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

        #endregion

        #region Add/Get

        public void Add(IScorable unit)
        {
            CommandController player = unit.SaveResult();
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

        #endregion

        #region Constants and variables

        private const string FILE = "score.txt";

        private const string DIRECTORY = "Private";

        private const string PATH = DIRECTORY + "\\" + FILE;

        Dictionary<string, int> m_records = new Dictionary<string, int>();

        #endregion
    }
}
