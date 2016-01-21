using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tanks
{
    public partial class ScoreTable : Form
    {
        private ScoreTableController m_scoreTable;

        public ScoreTable(ScoreTableController scoreTable)
        {
            InitializeComponent();
            m_scoreTable = scoreTable;
        }

        private void ScoreTable_Load(object sender, EventArgs e)
        {
            Dictionary<string, int> records = m_scoreTable.GetScoreTable();
            foreach(var item in records)
            {
                dgvScore.Rows.Add(item.Key, item.Value);
            }
        }
    }
}
