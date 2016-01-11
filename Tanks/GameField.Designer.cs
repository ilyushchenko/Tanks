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
            this.userControl11 = new Tanks.UserControl1();
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
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // userControl11
            // 
            this.userControl11.Location = new System.Drawing.Point(12, 57);
            this.userControl11.Name = "userControl11";
            this.userControl11.Size = new System.Drawing.Size(390, 305);
            this.userControl11.TabIndex = 1;
            this.userControl11.Paint += new System.Windows.Forms.PaintEventHandler(this.userControl11_Paint);
            // 
            // GameField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 413);
            this.Controls.Add(this.userControl11);
            this.Controls.Add(this.btnGameSetup);
            this.DoubleBuffered = true;
            this.Name = "GameField";
            this.Text = "GameField";
            this.Load += new System.EventHandler(this.GameField_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGameSetup;
        private System.Windows.Forms.Timer timer;
        private UserControl1 userControl11;
    }
}