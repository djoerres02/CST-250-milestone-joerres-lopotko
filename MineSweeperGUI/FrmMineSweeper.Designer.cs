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
            pnlGame.Location = new Point(94, 16);
            pnlGame.Margin = new Padding(3, 4, 3, 4);
            pnlGame.Name = "pnlGame";
            pnlGame.Size = new Size(457, 533);
            pnlGame.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(651, 85);
            label1.Name = "label1";
            label1.Size = new Size(80, 20);
            label1.TabIndex = 0;
            label1.Text = "Start Time:";
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.Location = new Point(651, 120);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(42, 20);
            lblTime.TabIndex = 1;
            lblTime.Text = "Time";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(651, 179);
            label2.Name = "label2";
            label2.Size = new Size(49, 20);
            label2.TabIndex = 0;
            label2.Text = "Score:";
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.Location = new Point(651, 213);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(17, 20);
            lblScore.TabIndex = 1;
            lblScore.Text = "0";
            // 
            // btnRestart
            // 
            btnRestart.Location = new Point(651, 335);
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
            tmrStopWatch.Tick += TmrStopwatchTickEH;
            // 
            // btnUseReward
            // 
            btnUseReward.AutoSize = true;
            btnUseReward.Location = new Point(651, 281);
            btnUseReward.Margin = new Padding(3, 4, 3, 4);
            btnUseReward.Name = "btnUseReward";
            btnUseReward.Size = new Size(102, 31);
            btnUseReward.TabIndex = 3;
            btnUseReward.Text = "Use Reward";
            btnUseReward.UseVisualStyleBackColor = true;
            btnUseReward.Visible = false;
            btnUseReward.Click += BtnUseRewardClickEH;
            // 
            // FrmMineSweeper
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(808, 600);
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
