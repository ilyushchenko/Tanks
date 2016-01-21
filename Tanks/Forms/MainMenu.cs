using System;
using System.Windows.Forms;

namespace Tanks
{
    public partial class MainMenu : Form
    {
        SourceFabric m_source;
        public MainMenu(SourceFabric source)
        {
            InitializeComponent();
            m_source = source;
        }

        private void btnLevelEditor_Click(object sender, EventArgs e)
        {
            LevelEditor levelEditor = new LevelEditor(m_source.GetEditorController());
            levelEditor.Show();
        }

        private void btnGameStart_Click(object sender, EventArgs e)
        {
            GameField gameField = new GameField(m_source.GetGameController());
            gameField.Show();
        }

        private void btnScoreTable_Click(object sender, EventArgs e)
        {
            ScoreTable scoreTable = new ScoreTable(m_source.GetScoreTable());
            scoreTable.Show();
        }

        private void btnProgramEditor_Click(object sender, EventArgs e)
        {
            ProgramEditor programEditor = new ProgramEditor(m_source.GetProgramEditor());
            programEditor.Show();
        }
    }
}
