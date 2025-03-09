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
            label1.Location = new Point(570, 64);
            label1.Name = "label1";
            label1.Size = new Size(64, 15);
            label1.TabIndex = 0;
            label1.Text = "Start Time:";
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.Location = new Point(570, 90);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(34, 15);
            lblTime.TabIndex = 1;
            lblTime.Text = "Time";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(570, 134);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 0;
            label2.Text = "Score:";
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.Location = new Point(570, 160);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(13, 15);
            lblScore.TabIndex = 1;
            lblScore.Text = "0";
            // 
            // btnRestart
            // 
            btnRestart.Location = new Point(570, 251);
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
            btnUseReward.Location = new Point(570, 211);
            btnUseReward.Name = "btnUseReward";
            btnUseReward.Size = new Size(89, 25);
            btnUseReward.TabIndex = 3;
            btnUseReward.Text = "Use Reward";
            btnUseReward.UseVisualStyleBackColor = true;
            btnUseReward.Visible = false;
            btnUseReward.Click += BtnUseRewardClickEH;
            // 
            // FrmMineSweeper
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(707, 450);
            Controls.Add(btnUseReward);
            Controls.Add(btnRestart);
            Controls.Add(lblScore);
            Controls.Add(label2);
            Controls.Add(lblTime);
            Controls.Add(label1);
            Controls.Add(pnlGame);
            Name = "FrmMineSweeper";
            Text = "Minesweeper";
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
    }
}
