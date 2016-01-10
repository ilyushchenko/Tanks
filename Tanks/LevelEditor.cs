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
    public partial class LevelEditor : Form
    {
        EditorController m_editor;

        Bitmap buf;

        public LevelEditor(EditorController editor)
        {
            InitializeComponent();
            //m_editor = editor;
        }

        private void btnLoadLevel_Click(object sender, EventArgs e)
        {
            buf = new Bitmap(pnlBattlefield.Width, pnlBattlefield.Height);
            int m = Convert.ToInt32(nudLevelMSize.Value);
            int n = Convert.ToInt32(nudLevelNSize.Value);
            m_editor = new EditorController(n, m);
            pnlBattlefield.Width = n * m_editor.Width;
            pnlBattlefield.Height = m * m_editor.Height;
            if (rbnLevelLoad.Checked)
            {
                m_editor.LoadLevel(tbxLevelLoad.Text);
            }
            else
            {
                //m_editor.CreateField(n, m);
            }
            pnlBattlefield.Invalidate();
        }

        private void LevelEditor_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void btnLevelSave_Click(object sender, EventArgs e)
        {
            if (tbxSaveName.TextLength > 0 && tbxSavePath.TextLength > 0)
            {
                m_editor.SaveLevel(tbxSaveName.Text);
                MessageBox.Show("Done!");
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

        private void pnlBattlefield_Paint(object sender, PaintEventArgs e)
        {
            if (m_editor != null)
            {
                Graphics bufG = Graphics.FromImage(buf);
                m_editor.Draw(bufG);
                //m_editor.Draw(e.Graphics);
                e.Graphics.DrawImage(buf, 0, 0);
            }
        }

        private void pnlBattlefield_MouseMove(object sender, MouseEventArgs e)
        {
            tbxSaveName.Text = string.Format("{0} {1}", e.X, e.Y);
            //pnlBattlefield.Invalidate();
        }

        private void pnlBattlefield_MouseDown(object sender, MouseEventArgs e)
        {
            m_editor.CheckWall(e.X, e.Y);
            //pnlBattlefield.Refresh();
            pnlBattlefield.Invalidate();
        }
    }
}
