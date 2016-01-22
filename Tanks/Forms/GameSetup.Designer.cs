namespace Tanks
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
            this.btnSelectLevel = new System.Windows.Forms.Button();
            this.lblHelpSelectLevel = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnAddRed = new System.Windows.Forms.Button();
            this.btnAddBlue = new System.Windows.Forms.Button();
            this.btnAddGreen = new System.Windows.Forms.Button();
            this.btnAddPink = new System.Windows.Forms.Button();
            this.btnAddOrange = new System.Windows.Forms.Button();
            this.btnAddPurple = new System.Windows.Forms.Button();
            this.btnAddYellow = new System.Windows.Forms.Button();
            this.btnAddBlack = new System.Windows.Forms.Button();
            this.pnlAdd = new System.Windows.Forms.Panel();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.pnlAdd.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbxLevelPath
            // 
            this.tbxLevelPath.Location = new System.Drawing.Point(82, 14);
            this.tbxLevelPath.Name = "tbxLevelPath";
            this.tbxLevelPath.Size = new System.Drawing.Size(103, 20);
            this.tbxLevelPath.TabIndex = 0;
            // 
            // btnSelectLevel
            // 
            this.btnSelectLevel.Location = new System.Drawing.Point(191, 12);
            this.btnSelectLevel.Name = "btnSelectLevel";
            this.btnSelectLevel.Size = new System.Drawing.Size(75, 23);
            this.btnSelectLevel.TabIndex = 1;
            this.btnSelectLevel.Text = "Обзор";
            this.btnSelectLevel.UseVisualStyleBackColor = true;
            this.btnSelectLevel.Click += new System.EventHandler(this.btnSelectLevel_Click);
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
            // btnAddRed
            // 
            this.btnAddRed.Location = new System.Drawing.Point(3, 3);
            this.btnAddRed.Name = "btnAddRed";
            this.btnAddRed.Size = new System.Drawing.Size(97, 51);
            this.btnAddRed.TabIndex = 34;
            this.btnAddRed.Tag = "red";
            this.btnAddRed.Text = "Красный";
            this.btnAddRed.UseVisualStyleBackColor = true;
            this.btnAddRed.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnAddBlue
            // 
            this.btnAddBlue.Location = new System.Drawing.Point(111, 3);
            this.btnAddBlue.Name = "btnAddBlue";
            this.btnAddBlue.Size = new System.Drawing.Size(97, 51);
            this.btnAddBlue.TabIndex = 35;
            this.btnAddBlue.Tag = "blue";
            this.btnAddBlue.Text = "Голубой";
            this.btnAddBlue.UseVisualStyleBackColor = true;
            this.btnAddBlue.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnAddGreen
            // 
            this.btnAddGreen.Location = new System.Drawing.Point(3, 60);
            this.btnAddGreen.Name = "btnAddGreen";
            this.btnAddGreen.Size = new System.Drawing.Size(97, 51);
            this.btnAddGreen.TabIndex = 36;
            this.btnAddGreen.Tag = "green";
            this.btnAddGreen.Text = "Зеленый";
            this.btnAddGreen.UseVisualStyleBackColor = true;
            this.btnAddGreen.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnAddPink
            // 
            this.btnAddPink.Location = new System.Drawing.Point(111, 60);
            this.btnAddPink.Name = "btnAddPink";
            this.btnAddPink.Size = new System.Drawing.Size(97, 51);
            this.btnAddPink.TabIndex = 37;
            this.btnAddPink.Tag = "pink";
            this.btnAddPink.Text = "Розовый";
            this.btnAddPink.UseVisualStyleBackColor = true;
            this.btnAddPink.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnAddOrange
            // 
            this.btnAddOrange.Location = new System.Drawing.Point(3, 117);
            this.btnAddOrange.Name = "btnAddOrange";
            this.btnAddOrange.Size = new System.Drawing.Size(97, 51);
            this.btnAddOrange.TabIndex = 38;
            this.btnAddOrange.Tag = "orange";
            this.btnAddOrange.Text = "Орнжевый";
            this.btnAddOrange.UseVisualStyleBackColor = true;
            this.btnAddOrange.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnAddPurple
            // 
            this.btnAddPurple.Location = new System.Drawing.Point(111, 117);
            this.btnAddPurple.Name = "btnAddPurple";
            this.btnAddPurple.Size = new System.Drawing.Size(97, 51);
            this.btnAddPurple.TabIndex = 39;
            this.btnAddPurple.Tag = "purple";
            this.btnAddPurple.Text = "Малиновый";
            this.btnAddPurple.UseVisualStyleBackColor = true;
            this.btnAddPurple.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnAddYellow
            // 
            this.btnAddYellow.Location = new System.Drawing.Point(3, 174);
            this.btnAddYellow.Name = "btnAddYellow";
            this.btnAddYellow.Size = new System.Drawing.Size(97, 51);
            this.btnAddYellow.TabIndex = 40;
            this.btnAddYellow.Tag = "yellow";
            this.btnAddYellow.Text = "Желтый";
            this.btnAddYellow.UseVisualStyleBackColor = true;
            this.btnAddYellow.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnAddBlack
            // 
            this.btnAddBlack.Location = new System.Drawing.Point(111, 174);
            this.btnAddBlack.Name = "btnAddBlack";
            this.btnAddBlack.Size = new System.Drawing.Size(97, 51);
            this.btnAddBlack.TabIndex = 41;
            this.btnAddBlack.Tag = "black";
            this.btnAddBlack.Text = "Черный";
            this.btnAddBlack.UseVisualStyleBackColor = true;
            this.btnAddBlack.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // pnlAdd
            // 
            this.pnlAdd.Controls.Add(this.btnAddRed);
            this.pnlAdd.Controls.Add(this.btnAddBlack);
            this.pnlAdd.Controls.Add(this.btnPlay);
            this.pnlAdd.Controls.Add(this.btnAddBlue);
            this.pnlAdd.Controls.Add(this.btnAddYellow);
            this.pnlAdd.Controls.Add(this.btnAddGreen);
            this.pnlAdd.Controls.Add(this.btnAddPurple);
            this.pnlAdd.Controls.Add(this.btnAddPink);
            this.pnlAdd.Controls.Add(this.btnAddOrange);
            this.pnlAdd.Enabled = false;
            this.pnlAdd.Location = new System.Drawing.Point(82, 46);
            this.pnlAdd.Name = "pnlAdd";
            this.pnlAdd.Size = new System.Drawing.Size(213, 291);
            this.pnlAdd.TabIndex = 42;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(267, 12);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "Загрузить";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnPlay.Location = new System.Drawing.Point(3, 231);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(205, 46);
            this.btnPlay.TabIndex = 1;
            this.btnPlay.Text = "Загрузить";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // GameSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 349);
            this.Controls.Add(this.pnlAdd);
            this.Controls.Add(this.lblHelpSelectLevel);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnSelectLevel);
            this.Controls.Add(this.tbxLevelPath);
            this.Name = "GameSetup";
            this.Text = ".";
            this.pnlAdd.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxLevelPath;
        private System.Windows.Forms.Button btnSelectLevel;
        private System.Windows.Forms.Label lblHelpSelectLevel;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button btnAddRed;
        private System.Windows.Forms.Button btnAddBlue;
        private System.Windows.Forms.Button btnAddGreen;
        private System.Windows.Forms.Button btnAddPink;
        private System.Windows.Forms.Button btnAddOrange;
        private System.Windows.Forms.Button btnAddPurple;
        private System.Windows.Forms.Button btnAddYellow;
        private System.Windows.Forms.Button btnAddBlack;
        private System.Windows.Forms.Panel pnlAdd;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnPlay;
    }
}