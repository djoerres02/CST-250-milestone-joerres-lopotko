namespace MineSweeperGUI
{
    partial class FrmMineSweeper
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            pnlGame = new Panel();
            label1 = new Label();
            lblTime = new Label();
            label2 = new Label();
            lblScore = new Label();
            btnRestart = new Button();
            tmrStopWatch = new System.Windows.Forms.Timer(components);
            btnUseReward = new Button();
            label3 = new Label();
            btnExit = new Button();
            grpMusic = new GroupBox();
            rbnMusic3 = new RadioButton();
            rbnMusic2 = new RadioButton();
            rbnMusicOff = new RadioButton();
            rbnMusic1 = new RadioButton();
            grpMusic.SuspendLayout();
            SuspendLayout();
            // 
            // pnlGame
            // 
            pnlGame.Location = new Point(82, 12);
            pnlGame.Name = "pnlGame";
            pnlGame.Size = new Size(400, 400);
            pnlGame.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(570, 29);
            label1.Name = "label1";
            label1.Size = new Size(64, 15);
            label1.TabIndex = 0;
            label1.Text = "Start Time:";
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.Location = new Point(570, 56);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(34, 15);
            lblTime.TabIndex = 1;
            lblTime.Text = "Time";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(570, 81);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 0;
            label2.Text = "Score:";
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.Location = new Point(570, 106);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(13, 15);
            lblScore.TabIndex = 1;
            lblScore.Text = "0";
            // 
            // btnRestart
            // 
            btnRestart.Location = new Point(571, 176);
            btnRestart.Name = "btnRestart";
            btnRestart.Size = new Size(75, 23);
            btnRestart.TabIndex = 2;
            btnRestart.Text = "Restart";
            btnRestart.UseVisualStyleBackColor = true;
            btnRestart.Click += BtnRestartClickEH;
            // 
            // tmrStopWatch
            // 
            tmrStopWatch.Interval = 1000;
            tmrStopWatch.Tick += TmrStopwatchTickEH;
            // 
            // btnUseReward
            // 
            btnUseReward.AutoSize = true;
            btnUseReward.Location = new Point(571, 136);
            btnUseReward.Name = "btnUseReward";
            btnUseReward.Size = new Size(89, 25);
            btnUseReward.TabIndex = 3;
            btnUseReward.Text = "Use Reward";
            btnUseReward.UseVisualStyleBackColor = true;
            btnUseReward.Visible = false;
            btnUseReward.Click += BtnUseRewardClickEH;
            // 
            // label3
            // 
            label3.Location = new Point(550, 223);
            label3.Name = "label3";
            label3.Size = new Size(146, 56);
            label3.TabIndex = 4;
            label3.Text = "Left Click to visit a cell, Right Click to flag a cell";
            // 
            // btnExit
            // 
            btnExit.Location = new Point(571, 282);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(75, 23);
            btnExit.TabIndex = 5;
            btnExit.Text = "Exit Game";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += BtnExitClickEH;
            // 
            // grpMusic
            // 
            grpMusic.Controls.Add(rbnMusic3);
            grpMusic.Controls.Add(rbnMusic2);
            grpMusic.Controls.Add(rbnMusicOff);
            grpMusic.Controls.Add(rbnMusic1);
            grpMusic.Location = new Point(576, 318);
            grpMusic.Margin = new Padding(3, 2, 3, 2);
            grpMusic.Name = "grpMusic";
            grpMusic.Padding = new Padding(3, 2, 3, 2);
            grpMusic.Size = new Size(70, 121);
            grpMusic.TabIndex = 6;
            grpMusic.TabStop = false;
            grpMusic.Text = "Music";
            // 
            // rbnMusic3
            // 
            rbnMusic3.AutoSize = true;
            rbnMusic3.Location = new Point(15, 87);
            rbnMusic3.Margin = new Padding(3, 2, 3, 2);
            rbnMusic3.Name = "rbnMusic3";
            rbnMusic3.Size = new Size(31, 19);
            rbnMusic3.TabIndex = 2;
            rbnMusic3.Text = "3";
            rbnMusic3.UseVisualStyleBackColor = true;
            rbnMusic3.CheckedChanged += RbnMusicCheckedChangedEH;
            // 
            // rbnMusic2
            // 
            rbnMusic2.AutoSize = true;
            rbnMusic2.Location = new Point(15, 65);
            rbnMusic2.Margin = new Padding(3, 2, 3, 2);
            rbnMusic2.Name = "rbnMusic2";
            rbnMusic2.Size = new Size(31, 19);
            rbnMusic2.TabIndex = 1;
            rbnMusic2.Text = "2";
            rbnMusic2.UseVisualStyleBackColor = true;
            rbnMusic2.CheckedChanged += RbnMusicCheckedChangedEH;
            // 
            // rbnMusicOff
            // 
            rbnMusicOff.AutoSize = true;
            rbnMusicOff.Location = new Point(15, 20);
            rbnMusicOff.Margin = new Padding(3, 2, 3, 2);
            rbnMusicOff.Name = "rbnMusicOff";
            rbnMusicOff.Size = new Size(42, 19);
            rbnMusicOff.TabIndex = 0;
            rbnMusicOff.Text = "Off";
            rbnMusicOff.UseVisualStyleBackColor = true;
            rbnMusicOff.CheckedChanged += RbnMusicCheckedChangedEH;
            // 
            // rbnMusic1
            // 
            rbnMusic1.AutoSize = true;
            rbnMusic1.Checked = true;
            rbnMusic1.Location = new Point(15, 42);
            rbnMusic1.Margin = new Padding(3, 2, 3, 2);
            rbnMusic1.Name = "rbnMusic1";
            rbnMusic1.Size = new Size(31, 19);
            rbnMusic1.TabIndex = 0;
            rbnMusic1.TabStop = true;
            rbnMusic1.Text = "1";
            rbnMusic1.UseVisualStyleBackColor = true;
            rbnMusic1.CheckedChanged += RbnMusicCheckedChangedEH;
            // 
            // FrmMineSweeper
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(707, 450);
            Controls.Add(grpMusic);
            Controls.Add(btnExit);
            Controls.Add(label3);
            Controls.Add(btnUseReward);
            Controls.Add(btnRestart);
            Controls.Add(lblScore);
            Controls.Add(label2);
            Controls.Add(lblTime);
            Controls.Add(label1);
            Controls.Add(pnlGame);
            Name = "FrmMineSweeper";
            Text = "Minesweeper";
            grpMusic.ResumeLayout(false);
            grpMusic.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlGame;
        private Label label1;
        private Label lblTime;
        private Label label2;
        private Label lblScore;
        private Button btnRestart;
        private System.Windows.Forms.Timer tmrStopWatch;
        private Button btnUseReward;
        private Label label3;
        private Button btnExit;
        private GroupBox grpMusic;
        private RadioButton rbnMusic3;
        private RadioButton rbnMusic2;
        private RadioButton rbnMusic1;
        private RadioButton rbnMusicOff;
    }
}
