namespace MineSweeperGUI
{
    partial class FrmGameScores
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
            dgvGameScores = new DataGridView();
            mnsFileActions = new MenuStrip();
            tsmFile = new ToolStripMenuItem();
            tsmSave = new ToolStripMenuItem();
            tsmLoad = new ToolStripMenuItem();
            tsmExit = new ToolStripMenuItem();
            tsmSort = new ToolStripMenuItem();
            tsmByName = new ToolStripMenuItem();
            tsmByScore = new ToolStripMenuItem();
            tsmByTime = new ToolStripMenuItem();
            label1 = new Label();
            btnOk = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvGameScores).BeginInit();
            mnsFileActions.SuspendLayout();
            SuspendLayout();
            // 
            // dgvGameScores
            // 
            dgvGameScores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGameScores.Location = new Point(14, 97);
            dgvGameScores.Margin = new Padding(3, 4, 3, 4);
            dgvGameScores.Name = "dgvGameScores";
            dgvGameScores.RowHeadersWidth = 51;
            dgvGameScores.Size = new Size(733, 456);
            dgvGameScores.TabIndex = 0;
            // 
            // mnsFileActions
            // 
            mnsFileActions.ImageScalingSize = new Size(20, 20);
            mnsFileActions.Items.AddRange(new ToolStripItem[] { tsmFile, tsmSort });
            mnsFileActions.Location = new Point(0, 0);
            mnsFileActions.Name = "mnsFileActions";
            mnsFileActions.Padding = new Padding(7, 3, 0, 3);
            mnsFileActions.Size = new Size(782, 30);
            mnsFileActions.TabIndex = 1;
            mnsFileActions.Text = "menuStrip1";
            // 
            // tsmFile
            // 
            tsmFile.DropDownItems.AddRange(new ToolStripItem[] { tsmSave, tsmLoad, tsmExit });
            tsmFile.Name = "tsmFile";
            tsmFile.Size = new Size(46, 24);
            tsmFile.Text = "File";
            // 
            // tsmSave
            // 
            tsmSave.Name = "tsmSave";
            tsmSave.Size = new Size(125, 26);
            tsmSave.Text = "Save";
            tsmSave.Click += TsmSaveClickEH;
            // 
            // tsmLoad
            // 
            tsmLoad.Name = "tsmLoad";
            tsmLoad.Size = new Size(125, 26);
            tsmLoad.Text = "Load";
            tsmLoad.Click += TsmLoadClickEH;
            // 
            // tsmExit
            // 
            tsmExit.Name = "tsmExit";
            tsmExit.Size = new Size(125, 26);
            tsmExit.Text = "Exit";
            // 
            // tsmSort
            // 
            tsmSort.DropDownItems.AddRange(new ToolStripItem[] { tsmByName, tsmByScore, tsmByTime });
            tsmSort.Name = "tsmSort";
            tsmSort.Size = new Size(50, 24);
            tsmSort.Text = "Sort";
            // 
            // tsmByName
            // 
            tsmByName.Name = "tsmByName";
            tsmByName.Size = new Size(152, 26);
            tsmByName.Text = "By Name";
            tsmByName.Click += TsmByNameClickEH;
            // 
            // tsmByScore
            // 
            tsmByScore.Name = "tsmByScore";
            tsmByScore.Size = new Size(152, 26);
            tsmByScore.Text = "By Score";
            tsmByScore.Click += TsmByScoreClickEH;
            // 
            // tsmByTime
            // 
            tsmByTime.Name = "tsmByTime";
            tsmByTime.Size = new Size(152, 26);
            tsmByTime.Text = "By Time";
            tsmByTime.Click += TsmByTimeClickEH;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 61);
            label1.Name = "label1";
            label1.Size = new Size(88, 20);
            label1.TabIndex = 2;
            label1.Text = "High Scores";
            // 
            // btnOk
            // 
            btnOk.Location = new Point(14, 565);
            btnOk.Margin = new Padding(3, 4, 3, 4);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(86, 31);
            btnOk.TabIndex = 3;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += BtnOkClickEH;
            // 
            // FrmGameScores
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 612);
            Controls.Add(btnOk);
            Controls.Add(label1);
            Controls.Add(dgvGameScores);
            Controls.Add(mnsFileActions);
            MainMenuStrip = mnsFileActions;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmGameScores";
            Text = "FrmGameScores";
            ((System.ComponentModel.ISupportInitialize)dgvGameScores).EndInit();
            mnsFileActions.ResumeLayout(false);
            mnsFileActions.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvGameScores;
        private MenuStrip mnsFileActions;
        private ToolStripMenuItem tsmFile;
        private ToolStripMenuItem tsmSave;
        private ToolStripMenuItem tsmLoad;
        private ToolStripMenuItem tsmExit;
        private ToolStripMenuItem tsmSort;
        private ToolStripMenuItem tsmByName;
        private ToolStripMenuItem tsmByScore;
        private ToolStripMenuItem tsmByTime;
        private Label label1;
        private Button btnOk;
    }
}