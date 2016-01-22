using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tanks
{
    public partial class GameSetup : Form
    {
        GameController m_gameController;

        public GameSetup(GameController gameController)
        {
            InitializeComponent();
            m_gameController = gameController;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            m_gameController.LoadLevel(tbxLevelPath.Text);
            pnlAdd.Enabled = true;
        }

        public GameController GetLevelSetup()
        {
            return m_gameController;
        }

        private void btnSelectLevel_Click(object sender, EventArgs e)
        {
            DialogResult dialog = openFileDialog.ShowDialog();
            if(dialog == DialogResult.OK)
            {
                tbxLevelPath.Text = openFileDialog.FileName;
            }
        }
        
        private void AddTank(string color, string program)
        {
            Tank tank = new Tank();
            CommandController tankController = new CommandController();
            Radar radar = new Radar(m_gameController.GetField());
            tankController.LoadCommands(program);
            tank.SetColor(color);
            tank.SetCommandController(tankController);
            tank.SetRadar(radar);
            m_gameController.PutTank(tank);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DialogResult dialog = openFileDialog.ShowDialog();
            if(dialog == DialogResult.OK)
            {
                AddTank((sender as Button).Text, openFileDialog.FileName);
                (sender as Button).Enabled = false;
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
