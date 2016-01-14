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
        //Level m_level = new Level();


        GameController m_gameController;


        public GameField(GameController gameController)
        {
            InitializeComponent();
            m_gameController = gameController;
        }

        private void GameField_Load(object sender, EventArgs e)
        {

        }

        private void btnGameSetup_Click(object sender, EventArgs e)
        {
            GameSetup gameSetup = new GameSetup(m_gameController);
            if (DialogResult.OK == gameSetup.ShowDialog())
            {
                m_gameController = gameSetup.GetLevelSetup();
                userControl11.Width = m_gameController.N * 40;
                userControl11.Height = m_gameController.M * 40;
                
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
            m_gameController.NextStep();
            userControl11.Invalidate();
        }

        private void userControl11_Paint(object sender, PaintEventArgs e)
        {
            m_gameController.Draw(e.Graphics);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
            m_gameController.SaveLevel("test1.txt");
        }
    }
}
