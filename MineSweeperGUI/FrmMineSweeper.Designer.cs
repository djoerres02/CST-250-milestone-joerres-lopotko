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
            groupBox1 = new GroupBox();
            rbnMusic3 = new RadioButton();
            rbnMusic2 = new RadioButton();
            rbnMusic1 = new RadioButton();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // pnlGame
            // 
            pnlGame.Location = new Point(94, 16);
            pnlGame.Margin = new Padding(3, 4, 3, 4);
            pnlGame.Name = "pnlGame";
            pnlGame.Size = new Size(457, 533);
            pnlGame.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(651, 39);
            label1.Name = "label1";
            label1.Size = new Size(80, 20);
            label1.TabIndex = 0;
            label1.Text = "Start Time:";
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.Location = new Point(651, 74);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(42, 20);
            lblTime.TabIndex = 1;
            lblTime.Text = "Time";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(651, 108);
            label2.Name = "label2";
            label2.Size = new Size(49, 20);
            label2.TabIndex = 0;
            label2.Text = "Score:";
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.Location = new Point(651, 142);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(17, 20);
            lblScore.TabIndex = 1;
            lblScore.Text = "0";
            // 
            // btnRestart
            // 
            btnRestart.Location = new Point(653, 235);
            btnRestart.Margin = new Padding(3, 4, 3, 4);
            btnRestart.Name = "btnRestart";
            btnRestart.Size = new Size(86, 31);
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
            btnUseReward.Location = new Point(653, 181);
            btnUseReward.Margin = new Padding(3, 4, 3, 4);
            btnUseReward.Name = "btnUseReward";
            btnUseReward.Size = new Size(102, 33);
            btnUseReward.TabIndex = 3;
            btnUseReward.Text = "Use Reward";
            btnUseReward.UseVisualStyleBackColor = true;
            btnUseReward.Visible = false;
            btnUseReward.Click += BtnUseRewardClickEH;
            // 
            // label3
            // 
            label3.Location = new Point(629, 297);
            label3.Name = "label3";
            label3.Size = new Size(167, 75);
            label3.TabIndex = 4;
            label3.Text = "Left Click to visit a cell, Right Click to flag a cell";
            // 
            // btnExit
            // 
            btnExit.Location = new Point(653, 376);
            btnExit.Margin = new Padding(3, 4, 3, 4);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(86, 31);
            btnExit.TabIndex = 5;
            btnExit.Text = "Exit Game";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += BtnExitClickEH;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rbnMusic3);
            groupBox1.Controls.Add(rbnMusic2);
            groupBox1.Controls.Add(rbnMusic1);
            groupBox1.Location = new Point(674, 424);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(65, 125);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Music";
            // 
            // rbnMusic3
            // 
            rbnMusic3.AutoSize = true;
            rbnMusic3.Location = new Point(17, 91);
            rbnMusic3.Name = "rbnMusic3";
            rbnMusic3.Size = new Size(38, 24);
            rbnMusic3.TabIndex = 2;
            rbnMusic3.Text = "3";
            rbnMusic3.UseVisualStyleBackColor = true;
            rbnMusic3.CheckedChanged += RbnMusic3CheckedChangedEH;
            // 
            // rbnMusic2
            // 
            rbnMusic2.AutoSize = true;
            rbnMusic2.Location = new Point(17, 61);
            rbnMusic2.Name = "rbnMusic2";
            rbnMusic2.Size = new Size(38, 24);
            rbnMusic2.TabIndex = 1;
            rbnMusic2.Text = "2";
            rbnMusic2.UseVisualStyleBackColor = true;
            rbnMusic2.CheckedChanged += RbnMusic2CheckedChangedEH;
            // 
            // rbnMusic1
            // 
            rbnMusic1.AutoSize = true;
            rbnMusic1.Checked = true;
            rbnMusic1.Location = new Point(17, 31);
            rbnMusic1.Name = "rbnMusic1";
            rbnMusic1.Size = new Size(38, 24);
            rbnMusic1.TabIndex = 0;
            rbnMusic1.TabStop = true;
            rbnMusic1.Text = "1";
            rbnMusic1.UseVisualStyleBackColor = true;
            rbnMusic1.CheckedChanged += RbnMusic1CheckedChangedEH;
            // 
            // FrmMineSweeper
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(808, 600);
            Controls.Add(groupBox1);
            Controls.Add(btnExit);
            Controls.Add(label3);
            Controls.Add(btnUseReward);
            Controls.Add(btnRestart);
            Controls.Add(lblScore);
            Controls.Add(label2);
            Controls.Add(lblTime);
            Controls.Add(label1);
            Controls.Add(pnlGame);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmMineSweeper";
            Text = "Minesweeper";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
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
        private GroupBox groupBox1;
        private RadioButton rbnMusic3;
        private RadioButton rbnMusic2;
        private RadioButton rbnMusic1;
    }
}
