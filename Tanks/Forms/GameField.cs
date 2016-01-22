using System;
using System.Windows.Forms;

namespace Tanks
{
    public partial class GameField : Form
    {
        GameController m_gameController;
        GameSetup gameSetup;

        public GameField(GameController gameController)
        {
            InitializeComponent();
            m_gameController = gameController;
        }

        private void btnGameSetup_Click(object sender, EventArgs e)
        {
            gameSetup = new GameSetup(m_gameController);
            if (DialogResult.OK == gameSetup.ShowDialog())
            {
                m_gameController = gameSetup.GetLevelSetup();
                ucField.Width = m_gameController.N * m_gameController.Width;
                ucField.Height = m_gameController.M * m_gameController.Height;
                Height = ucField.Height + 75;
                Width = ucField.Width + 200;

                ucField.Visible = true;
                gameSetup.Dispose();
                ucField.Invalidate();
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if(m_gameController.GameStatus == Level.Status.Playing)
            {
                m_gameController.NextStep();
                ucField.Invalidate();
            }
            else if(m_gameController.GameStatus == Level.Status.End)
            {
                timer.Enabled = false;
                MessageBox.Show("Игра окончена!");
                ScoreTableController scoreTable = new ScoreTableController();
                scoreTable.Add(m_gameController.GetWinner());
                scoreTable.Save();
            }
        }

        private void userControl11_Paint(object sender, PaintEventArgs e)
        {
            m_gameController.Draw(e.Graphics);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            timer.Enabled = true;
            m_gameController.GameStatus = Level.Status.Playing;
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
            m_gameController.RestartGame();
            ucField.Invalidate();
        }
    }
}
