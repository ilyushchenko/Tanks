namespace Tanks
{
    partial class LevelEditor
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSelectPath = new System.Windows.Forms.Button();
            this.lblLevelHelpCreate = new System.Windows.Forms.Label();
            this.tbxLevelLoad = new System.Windows.Forms.TextBox();
            this.lbxLevelHelpMN = new System.Windows.Forms.Label();
            this.rbnLevelLoad = new System.Windows.Forms.RadioButton();
            this.rbnLevelCreate = new System.Windows.Forms.RadioButton();
            this.nudLevelNSize = new System.Windows.Forms.NumericUpDown();
            this.nudLevelMSize = new System.Windows.Forms.NumericUpDown();
            this.btnLevelLoad = new System.Windows.Forms.Button();
            this.gbxSave = new System.Windows.Forms.GroupBox();
            this.btnSavePath = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxSavePath = new System.Windows.Forms.TextBox();
            this.btnLevelSave = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.ucField = new Tanks.Field();
            this.pnlLoad = new System.Windows.Forms.Panel();
            this.pnlCreate = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLevelNSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLevelMSize)).BeginInit();
            this.gbxSave.SuspendLayout();
            this.pnlLoad.SuspendLayout();
            this.pnlCreate.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pnlCreate);
            this.panel1.Controls.Add(this.pnlLoad);
            this.panel1.Controls.Add(this.rbnLevelLoad);
            this.panel1.Controls.Add(this.rbnLevelCreate);
            this.panel1.Controls.Add(this.btnLevelLoad);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(229, 168);
            this.panel1.TabIndex = 0;
            // 
            // btnSelectPath
            // 
            this.btnSelectPath.Location = new System.Drawing.Point(167, 23);
            this.btnSelectPath.Name = "btnSelectPath";
            this.btnSelectPath.Size = new System.Drawing.Size(57, 24);
            this.btnSelectPath.TabIndex = 1;
            this.btnSelectPath.Text = "Обзор";
            this.btnSelectPath.UseVisualStyleBackColor = true;
            this.btnSelectPath.Click += new System.EventHandler(this.btnSelectPath_Click);
            // 
            // lblLevelHelpCreate
            // 
            this.lblLevelHelpCreate.AutoSize = true;
            this.lblLevelHelpCreate.Location = new System.Drawing.Point(4, 10);
            this.lblLevelHelpCreate.Name = "lblLevelHelpCreate";
            this.lblLevelHelpCreate.Size = new System.Drawing.Size(31, 13);
            this.lblLevelHelpCreate.TabIndex = 4;
            this.lblLevelHelpCreate.Text = "Путь";
            // 
            // tbxLevelLoad
            // 
            this.tbxLevelLoad.Location = new System.Drawing.Point(7, 26);
            this.tbxLevelLoad.Name = "tbxLevelLoad";
            this.tbxLevelLoad.Size = new System.Drawing.Size(154, 20);
            this.tbxLevelLoad.TabIndex = 0;
            // 
            // lbxLevelHelpMN
            // 
            this.lbxLevelHelpMN.AutoSize = true;
            this.lbxLevelHelpMN.Location = new System.Drawing.Point(59, 12);
            this.lbxLevelHelpMN.Name = "lbxLevelHelpMN";
            this.lbxLevelHelpMN.Size = new System.Drawing.Size(12, 13);
            this.lbxLevelHelpMN.TabIndex = 4;
            this.lbxLevelHelpMN.Text = "x";
            // 
            // rbnLevelLoad
            // 
            this.rbnLevelLoad.AutoSize = true;
            this.rbnLevelLoad.Location = new System.Drawing.Point(4, 56);
            this.rbnLevelLoad.Name = "rbnLevelLoad";
            this.rbnLevelLoad.Size = new System.Drawing.Size(121, 17);
            this.rbnLevelLoad.TabIndex = 3;
            this.rbnLevelLoad.TabStop = true;
            this.rbnLevelLoad.Text = "Загрузить уровень";
            this.rbnLevelLoad.UseVisualStyleBackColor = true;
            this.rbnLevelLoad.CheckedChanged += new System.EventHandler(this.rbnLevelLoad_CheckedChanged);
            // 
            // rbnLevelCreate
            // 
            this.rbnLevelCreate.AutoSize = true;
            this.rbnLevelCreate.Checked = true;
            this.rbnLevelCreate.Location = new System.Drawing.Point(4, 3);
            this.rbnLevelCreate.Name = "rbnLevelCreate";
            this.rbnLevelCreate.Size = new System.Drawing.Size(111, 17);
            this.rbnLevelCreate.TabIndex = 3;
            this.rbnLevelCreate.TabStop = true;
            this.rbnLevelCreate.Text = "Создать уровень";
            this.rbnLevelCreate.UseVisualStyleBackColor = true;
            this.rbnLevelCreate.CheckedChanged += new System.EventHandler(this.rbnLevelCreate_CheckedChanged);
            // 
            // nudLevelNSize
            // 
            this.nudLevelNSize.Location = new System.Drawing.Point(3, 10);
            this.nudLevelNSize.Name = "nudLevelNSize";
            this.nudLevelNSize.Size = new System.Drawing.Size(50, 20);
            this.nudLevelNSize.TabIndex = 2;
            this.nudLevelNSize.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // nudLevelMSize
            // 
            this.nudLevelMSize.Location = new System.Drawing.Point(77, 10);
            this.nudLevelMSize.Name = "nudLevelMSize";
            this.nudLevelMSize.Size = new System.Drawing.Size(50, 20);
            this.nudLevelMSize.TabIndex = 1;
            this.nudLevelMSize.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // btnLevelLoad
            // 
            this.btnLevelLoad.Location = new System.Drawing.Point(148, 140);
            this.btnLevelLoad.Name = "btnLevelLoad";
            this.btnLevelLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLevelLoad.TabIndex = 0;
            this.btnLevelLoad.Text = "Загрузить";
            this.btnLevelLoad.UseVisualStyleBackColor = true;
            this.btnLevelLoad.Click += new System.EventHandler(this.btnLoadLevel_Click);
            // 
            // gbxSave
            // 
            this.gbxSave.Controls.Add(this.btnSavePath);
            this.gbxSave.Controls.Add(this.label1);
            this.gbxSave.Controls.Add(this.tbxSavePath);
            this.gbxSave.Controls.Add(this.btnLevelSave);
            this.gbxSave.Location = new System.Drawing.Point(13, 213);
            this.gbxSave.Name = "gbxSave";
            this.gbxSave.Size = new System.Drawing.Size(229, 124);
            this.gbxSave.TabIndex = 3;
            this.gbxSave.TabStop = false;
            this.gbxSave.Text = "Сохранение";
            // 
            // btnSavePath
            // 
            this.btnSavePath.Location = new System.Drawing.Point(164, 46);
            this.btnSavePath.Name = "btnSavePath";
            this.btnSavePath.Size = new System.Drawing.Size(57, 24);
            this.btnSavePath.TabIndex = 6;
            this.btnSavePath.Text = "Обзор";
            this.btnSavePath.UseVisualStyleBackColor = true;
            this.btnSavePath.Click += new System.EventHandler(this.btnSavePath_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Путь";
            // 
            // tbxSavePath
            // 
            this.tbxSavePath.Location = new System.Drawing.Point(14, 48);
            this.tbxSavePath.Name = "tbxSavePath";
            this.tbxSavePath.Size = new System.Drawing.Size(146, 20);
            this.tbxSavePath.TabIndex = 5;
            // 
            // btnLevelSave
            // 
            this.btnLevelSave.Location = new System.Drawing.Point(148, 86);
            this.btnLevelSave.Name = "btnLevelSave";
            this.btnLevelSave.Size = new System.Drawing.Size(75, 23);
            this.btnLevelSave.TabIndex = 0;
            this.btnLevelSave.Text = "Сохранить";
            this.btnLevelSave.UseVisualStyleBackColor = true;
            this.btnLevelSave.Click += new System.EventHandler(this.btnLevelSave_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // ucField
            // 
            this.ucField.BackColor = System.Drawing.Color.DarkGray;
            this.ucField.Location = new System.Drawing.Point(249, 13);
            this.ucField.Name = "ucField";
            this.ucField.Size = new System.Drawing.Size(10, 10);
            this.ucField.TabIndex = 5;
            this.ucField.Visible = false;
            this.ucField.Paint += new System.Windows.Forms.PaintEventHandler(this.ucField_Paint);
            this.ucField.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ucField_MouseDown);
            // 
            // pnlLoad
            // 
            this.pnlLoad.Controls.Add(this.btnSelectPath);
            this.pnlLoad.Controls.Add(this.lblLevelHelpCreate);
            this.pnlLoad.Controls.Add(this.tbxLevelLoad);
            this.pnlLoad.Enabled = false;
            this.pnlLoad.Location = new System.Drawing.Point(1, 79);
            this.pnlLoad.Name = "pnlLoad";
            this.pnlLoad.Size = new System.Drawing.Size(228, 55);
            this.pnlLoad.TabIndex = 6;
            // 
            // pnlCreate
            // 
            this.pnlCreate.Controls.Add(this.nudLevelNSize);
            this.pnlCreate.Controls.Add(this.lbxLevelHelpMN);
            this.pnlCreate.Controls.Add(this.nudLevelMSize);
            this.pnlCreate.Location = new System.Drawing.Point(0, 20);
            this.pnlCreate.Name = "pnlCreate";
            this.pnlCreate.Size = new System.Drawing.Size(229, 35);
            this.pnlCreate.TabIndex = 6;
            // 
            // LevelEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(247, 362);
            this.Controls.Add(this.ucField);
            this.Controls.Add(this.gbxSave);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Name = "LevelEditor";
            this.Text = "LevelEditor";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLevelNSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLevelMSize)).EndInit();
            this.gbxSave.ResumeLayout(false);
            this.gbxSave.PerformLayout();
            this.pnlLoad.ResumeLayout(false);
            this.pnlLoad.PerformLayout();
            this.pnlCreate.ResumeLayout(false);
            this.pnlCreate.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbnLevelCreate;
        private System.Windows.Forms.NumericUpDown nudLevelNSize;
        private System.Windows.Forms.NumericUpDown nudLevelMSize;
        private System.Windows.Forms.Button btnLevelLoad;
        private System.Windows.Forms.Label lbxLevelHelpMN;
        private System.Windows.Forms.RadioButton rbnLevelLoad;
        private System.Windows.Forms.Label lblLevelHelpCreate;
        private System.Windows.Forms.Button btnSelectPath;
        private System.Windows.Forms.TextBox tbxLevelLoad;
        private System.Windows.Forms.Button btnLevelSave;
        private System.Windows.Forms.GroupBox gbxSave;
        private System.Windows.Forms.Button btnSavePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxSavePath;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private Field ucField;
        private System.Windows.Forms.Panel pnlCreate;
        private System.Windows.Forms.Panel pnlLoad;
    }
}