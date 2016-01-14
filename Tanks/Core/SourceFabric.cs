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

        private EditorController m_editorController = new EditorController();

        private GameController m_gameController = new GameController();
    }
}
