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

        private EditorController m_editorController = new EditorController();
    }
}
