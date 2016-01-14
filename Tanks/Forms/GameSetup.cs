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
        List<ComboBox> cbxList = new List<ComboBox>();
        List<TextBox> tbxList = new List<TextBox>();
        int count;

        public GameSetup(GameController gameController)
        {
            InitializeComponent();
            m_gameController = gameController;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            count = Convert.ToInt32(nudCountOfTanks.Value);
            for (int i = 0; i < count; i++)
            {
                ComboBox comboBox = new ComboBox();
                comboBox.Location = new Point(20, 200 + i*30);
                comboBox.Items.Add("голубой");
                comboBox.Items.Add("зеленый");
                comboBox.Items.Add("красный");

                TextBox tbx = new TextBox();
                tbx.Location = new Point(140, 200 + i * 30);
                tbx.Text = "1.txt";
                tbxList.Add(tbx);
                cbxList.Add(comboBox);
                Controls.Add(comboBox);
                Controls.Add(tbx);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            m_gameController.LoadLevel(tbxLevelPath.Text);

            for (int i = 0; i < count; i++)
            {
                Tank tank = new Tank();
                Player player = new Player();
                player.LoadCommands(tbxList[i].Text);
                tank.SetColor(cbxList[i].SelectedItem.ToString());
                tank.SetPlayer(player);
                m_gameController.PutTank(tank);
            }

        }

        public GameController GetLevelSetup()
        {
            return m_gameController;
        }
    }
}
