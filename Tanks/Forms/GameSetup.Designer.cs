﻿namespace Tanks
{
    partial class GameSetup
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
            this.tbxLevelPath = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lblHelpSelectLevel = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.lblHelpCountOfPlayers = new System.Windows.Forms.Label();
            this.nudCountOfTanks = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudCountOfTanks)).BeginInit();
            this.SuspendLayout();
            // 
            // tbxLevelPath
            // 
            this.tbxLevelPath.Location = new System.Drawing.Point(120, 15);
            this.tbxLevelPath.Name = "tbxLevelPath";
            this.tbxLevelPath.Size = new System.Drawing.Size(100, 20);
            this.tbxLevelPath.TabIndex = 0;
            this.tbxLevelPath.Text = "test.txt";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(248, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button2.Location = new System.Drawing.Point(335, 53);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblHelpSelectLevel
            // 
            this.lblHelpSelectLevel.AutoSize = true;
            this.lblHelpSelectLevel.Location = new System.Drawing.Point(13, 18);
            this.lblHelpSelectLevel.Name = "lblHelpSelectLevel";
            this.lblHelpSelectLevel.Size = new System.Drawing.Size(54, 13);
            this.lblHelpSelectLevel.TabIndex = 3;
            this.lblHelpSelectLevel.Text = "Уровень:";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(248, 53);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // lblHelpCountOfPlayers
            // 
            this.lblHelpCountOfPlayers.AutoSize = true;
            this.lblHelpCountOfPlayers.Location = new System.Drawing.Point(13, 63);
            this.lblHelpCountOfPlayers.Name = "lblHelpCountOfPlayers";
            this.lblHelpCountOfPlayers.Size = new System.Drawing.Size(101, 13);
            this.lblHelpCountOfPlayers.TabIndex = 3;
            this.lblHelpCountOfPlayers.Text = "Количество таков:";
            // 
            // nudCountOfTanks
            // 
            this.nudCountOfTanks.Location = new System.Drawing.Point(121, 56);
            this.nudCountOfTanks.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.nudCountOfTanks.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudCountOfTanks.Name = "nudCountOfTanks";
            this.nudCountOfTanks.Size = new System.Drawing.Size(120, 20);
            this.nudCountOfTanks.TabIndex = 10;
            this.nudCountOfTanks.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // GameSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 400);
            this.Controls.Add(this.nudCountOfTanks);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.lblHelpCountOfPlayers);
            this.Controls.Add(this.lblHelpSelectLevel);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbxLevelPath);
            this.Name = "GameSetup";
            this.Text = ".";
            ((System.ComponentModel.ISupportInitialize)(this.nudCountOfTanks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxLevelPath;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblHelpSelectLevel;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label lblHelpCountOfPlayers;
        private System.Windows.Forms.NumericUpDown nudCountOfTanks;
    }
}