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
    public partial class GameField : Form
    {
        Level m_level = new Level();
        //GameController gc = new GameController();
        public GameField()
        {
            InitializeComponent();
        }

        private void GameField_Load(object sender, EventArgs e)
        {

        }

        private void btnGameSetup_Click(object sender, EventArgs e)
        {
            GameSetup gameSetup = new GameSetup();
            if (DialogResult.OK == gameSetup.ShowDialog())
            {
                m_level = gameSetup.GetLevelSetup();
                userControl11.Width = m_level.N * 40;
                userControl11.Height = m_level.M * 40;
                m_level.PutTanks();
                gameSetup.Dispose();
                userControl11.Invalidate();
            }
            else
            {
                gameSetup.Dispose();
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            m_level.NextStep();
            userControl11.Invalidate();
        }

        private void userControl11_Paint(object sender, PaintEventArgs e)
        {
            m_level.Draw(e.Graphics);
        }
    }
}
