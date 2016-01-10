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
            this.panel1 = new System.Windows.Forms.Panel();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btnGameSetup
            // 
            this.btnGameSetup.Location = new System.Drawing.Point(12, 12);
            this.btnGameSetup.Name = "btnGameSetup";
            this.btnGameSetup.Size = new System.Drawing.Size(75, 23);
            this.btnGameSetup.TabIndex = 0;
            this.btnGameSetup.Text = "button1";
            this.btnGameSetup.UseVisualStyleBackColor = true;
            this.btnGameSetup.Click += new System.EventHandler(this.btnGameSetup_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.Location = new System.Drawing.Point(12, 58);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(75, 56);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // GameField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 413);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnGameSetup);
            this.DoubleBuffered = true;
            this.Name = "GameField";
            this.Text = "GameField";
            this.Load += new System.EventHandler(this.GameField_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGameSetup;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timer;
    }
}