namespace Tanks
{
    partial class GameField
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnGameSetup = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.btnStart = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRestart = new System.Windows.Forms.Button();
            this.ucField = new Tanks.Field();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGameSetup
            // 
            this.btnGameSetup.Location = new System.Drawing.Point(3, 3);
            this.btnGameSetup.Name = "btnGameSetup";
            this.btnGameSetup.Size = new System.Drawing.Size(120, 57);
            this.btnGameSetup.TabIndex = 0;
            this.btnGameSetup.Text = "Загрузка уровня\r\nВыбор танка";
            this.btnGameSetup.UseVisualStyleBackColor = true;
            this.btnGameSetup.Click += new System.EventHandler(this.btnGameSetup_Click);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 200;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(24, 66);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 36);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Старт игры";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.btnRestart);
            this.panel1.Controls.Add(this.btnGameSetup);
            this.panel1.Controls.Add(this.btnStart);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(129, 373);
            this.panel1.TabIndex = 3;
            // 
            // btnRestart
            // 
            this.btnRestart.Location = new System.Drawing.Point(24, 108);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(75, 36);
            this.btnRestart.TabIndex = 3;
            this.btnRestart.Text = "Рестарт игры";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // ucField
            // 
            this.ucField.BackColor = System.Drawing.Color.DarkGray;
            this.ucField.Location = new System.Drawing.Point(159, 12);
            this.ucField.Name = "ucField";
            this.ucField.Size = new System.Drawing.Size(407, 373);
            this.ucField.TabIndex = 1;
            this.ucField.Visible = false;
            this.ucField.Paint += new System.Windows.Forms.PaintEventHandler(this.userControl11_Paint);
            // 
            // GameField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 398);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ucField);
            this.DoubleBuffered = true;
            this.Name = "GameField";
            this.Text = "GameField";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGameSetup;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRestart;
        private Field ucField;
    }
}