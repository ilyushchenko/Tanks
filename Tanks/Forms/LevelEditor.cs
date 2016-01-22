using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tanks
{
    public partial class LevelEditor : Form
    {
        EditorController m_editor;

        public LevelEditor(EditorController editor)
        {
            InitializeComponent();
        }

        private void btnLoadLevel_Click(object sender, EventArgs e)
        {
            if(rbnLevelCreate.Checked)
            {
                int m = Convert.ToInt32(nudLevelMSize.Value);
                int n = Convert.ToInt32(nudLevelNSize.Value);
                m_editor = new EditorController(n, m);
            }
            else
            {
                if(tbxLevelLoad.TextLength > 0)
                {
                    m_editor = new EditorController();
                    m_editor.LoadLevel(tbxLevelLoad.Text);
                }
                else
                {
                    MessageBox.Show("Путь не выбран!");
                    return;
                }
            }
            ucField.Visible = true;
            ucField.Size = new Size(m_editor.N * m_editor.Width, m_editor.M * m_editor.Height);
            Width += ucField.Width + 10;
            if(ucField.Height + 50> Height)
            {
                Height = ucField.Height + 60;
            }
            ucField.Invalidate();
        }

        private void btnLevelSave_Click(object sender, EventArgs e)
        {
            if (tbxSavePath.TextLength > 0)
            {
                m_editor.SaveLevel(tbxSavePath.Text);
                MessageBox.Show("Уровень сохранен!");
            }
            else
            {
                MessageBox.Show("Не все поля заполнены!");
            }
        }

        private void btnSelectPath_Click(object sender, EventArgs e)
        {
            DialogResult dialog = openFileDialog.ShowDialog();
            if (dialog == DialogResult.OK)
            {
                tbxLevelLoad.Text = openFileDialog.FileName;
            }
        }

        private void btnSavePath_Click(object sender, EventArgs e)
        {
            DialogResult dialog = saveFileDialog.ShowDialog();
            if(dialog == DialogResult.OK)
            {
                tbxSavePath.Text = saveFileDialog.FileName;
            }
        }

        private void ucField_Paint(object sender, PaintEventArgs e)
        {
            m_editor.Draw(e.Graphics);
        }

        private void ucField_MouseDown(object sender, MouseEventArgs e)
        {
            m_editor.CheckWall(e.X, e.Y);
            ucField.Invalidate();
        }

        private void rbnLevelLoad_CheckedChanged(object sender, EventArgs e)
        {
            pnlLoad.Enabled = true;
            pnlCreate.Enabled = false;
        }

        private void rbnLevelCreate_CheckedChanged(object sender, EventArgs e)
        {
            pnlCreate.Enabled = true;
            pnlLoad.Enabled = false;
        }
    }
}
