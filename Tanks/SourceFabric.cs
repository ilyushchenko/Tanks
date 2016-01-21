using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    public class SourceFabric
    {
        public EditorController GetEditorController()
        {
            return m_editorController;
        }

        public GameController GetGameController()
        {
            return m_gameController;
        }

        public ScoreTableController GetScoreTable()
        {
            return m_scoreTable;
        }

        public ProgramEditorController GetProgramEditor()
        {
            return m_programEditor;
        }

        private EditorController m_editorController = new EditorController();

        private GameController m_gameController = new GameController();

        private ScoreTableController m_scoreTable = new ScoreTableController();

        private ProgramEditorController m_programEditor = new ProgramEditorController();
    }
}
