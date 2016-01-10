using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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
            //levelEditor.Show();
            levelEditor.Show();
        }

        private void btnGameStart_Click(object sender, EventArgs e)
        {
            GameField gameField = new GameField();
            gameField.Show();
        }
    }
}
