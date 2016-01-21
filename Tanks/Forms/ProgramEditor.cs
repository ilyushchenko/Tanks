using System;
using System.Windows.Forms;

namespace Tanks
{
    public partial class ProgramEditor : Form
    {
        private ProgramEditorController m_programEditorController;

        public ProgramEditor(ProgramEditorController programEditorController)
        {
            InitializeComponent();
            m_programEditorController = programEditorController;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if(tbxTitle.TextLength > 0 && rbxProgram.TextLength>0)
            {
                DialogResult dialog = saveFileDialog.ShowDialog();

                if(dialog == DialogResult.OK)
                {
                    m_programEditorController.SaveChenges(tbxTitle.Text, rbxProgram.Text);
                    m_programEditorController.Save(saveFileDialog.FileName);
                    MessageBox.Show("Программа сохранена!");
                }
            }
            else
            {
                MessageBox.Show("Имя программы или программа не заданы!");
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            DialogResult dialog = openFileDialog.ShowDialog();

            if(dialog == DialogResult.OK)
            {
                m_programEditorController.Load(openFileDialog.FileName);
                tbxTitle.Text = m_programEditorController.GetTitle();
                rbxProgram.Text = m_programEditorController.GetProgram();
            }
        }
    }
}
