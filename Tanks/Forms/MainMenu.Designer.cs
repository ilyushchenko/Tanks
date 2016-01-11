namespace Tanks
{
    partial class MainMenu
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGameStart = new System.Windows.Forms.Button();
            this.btnLevelEditor = new System.Windows.Forms.Button();
            this.btnScoreTable = new System.Windows.Forms.Button();
            this.btnProgramEditor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGameStart
            // 
            this.btnGameStart.Location = new System.Drawing.Point(84, 28);
            this.btnGameStart.Name = "btnGameStart";
            this.btnGameStart.Size = new System.Drawing.Size(100, 40);
            this.btnGameStart.TabIndex = 0;
            this.btnGameStart.Text = "Старт игры";
            this.btnGameStart.UseVisualStyleBackColor = true;
            this.btnGameStart.Click += new System.EventHandler(this.btnGameStart_Click);
            // 
            // btnLevelEditor
            // 
            this.btnLevelEditor.Location = new System.Drawing.Point(84, 74);
            this.btnLevelEditor.Name = "btnLevelEditor";
            this.btnLevelEditor.Size = new System.Drawing.Size(100, 40);
            this.btnLevelEditor.TabIndex = 0;
            this.btnLevelEditor.Text = "Редактор уровней";
            this.btnLevelEditor.UseVisualStyleBackColor = true;
            this.btnLevelEditor.Click += new System.EventHandler(this.btnLevelEditor_Click);
            // 
            // btnScoreTable
            // 
            this.btnScoreTable.Location = new System.Drawing.Point(84, 166);
            this.btnScoreTable.Name = "btnScoreTable";
            this.btnScoreTable.Size = new System.Drawing.Size(100, 40);
            this.btnScoreTable.TabIndex = 0;
            this.btnScoreTable.Text = "Таблица рекордов";
            this.btnScoreTable.UseVisualStyleBackColor = true;
            // 
            // btnProgramEditor
            // 
            this.btnProgramEditor.Location = new System.Drawing.Point(84, 120);
            this.btnProgramEditor.Name = "btnProgramEditor";
            this.btnProgramEditor.Size = new System.Drawing.Size(100, 40);
            this.btnProgramEditor.TabIndex = 0;
            this.btnProgramEditor.Text = "Редактор программ";
            this.btnProgramEditor.UseVisualStyleBackColor = true;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnProgramEditor);
            this.Controls.Add(this.btnScoreTable);
            this.Controls.Add(this.btnLevelEditor);
            this.Controls.Add(this.btnGameStart);
            this.Name = "MainMenu";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGameStart;
        private System.Windows.Forms.Button btnLevelEditor;
        private System.Windows.Forms.Button btnScoreTable;
        private System.Windows.Forms.Button btnProgramEditor;
    }
}

