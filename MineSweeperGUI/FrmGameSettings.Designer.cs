namespace MineSweeperGUI
{
    partial class FrmGameSettings
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
            trkSizeBoard = new TrackBar();
            label1 = new Label();
            label3 = new Label();
            grpLevel = new GroupBox();
            radDifficult = new RadioButton();
            radMedium = new RadioButton();
            radEasy = new RadioButton();
            lblSize = new Label();
            btnStartGame = new Button();
            btnExit = new Button();
            ((System.ComponentModel.ISupportInitialize)trkSizeBoard).BeginInit();
            grpLevel.SuspendLayout();
            SuspendLayout();
            // 
            // trkSizeBoard
            // 
            trkSizeBoard.Location = new Point(14, 76);
            trkSizeBoard.Margin = new Padding(3, 4, 3, 4);
            trkSizeBoard.Maximum = 12;
            trkSizeBoard.Minimum = 4;
            trkSizeBoard.Name = "trkSizeBoard";
            trkSizeBoard.Size = new Size(337, 56);
            trkSizeBoard.TabIndex = 0;
            trkSizeBoard.Value = 4;
            trkSizeBoard.ValueChanged += TrkSizeBoardValueChangedEH;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 52);
            label1.Name = "label1";
            label1.Size = new Size(39, 20);
            label1.TabIndex = 1;
            label1.Text = "Size:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(14, 12);
            label3.Name = "label3";
            label3.Size = new Size(128, 20);
            label3.TabIndex = 2;
            label3.Text = "Play Minesweeper";
            // 
            // grpLevel
            // 
            grpLevel.Controls.Add(radDifficult);
            grpLevel.Controls.Add(radMedium);
            grpLevel.Controls.Add(radEasy);
            grpLevel.Location = new Point(41, 144);
            grpLevel.Margin = new Padding(3, 4, 3, 4);
            grpLevel.Name = "grpLevel";
            grpLevel.Padding = new Padding(3, 4, 3, 4);
            grpLevel.Size = new Size(229, 133);
            grpLevel.TabIndex = 3;
            grpLevel.TabStop = false;
            grpLevel.Text = "Choose A Difficulty";
            // 
            // radDifficult
            // 
            radDifficult.AutoSize = true;
            radDifficult.Location = new Point(7, 100);
            radDifficult.Margin = new Padding(3, 4, 3, 4);
            radDifficult.Name = "radDifficult";
            radDifficult.Size = new Size(83, 24);
            radDifficult.TabIndex = 0;
            radDifficult.TabStop = true;
            radDifficult.Text = "Difficult";
            radDifficult.UseVisualStyleBackColor = true;
            radDifficult.CheckedChanged += DifficultyCheckedChangedEH;
            // 
            // radMedium
            // 
            radMedium.AutoSize = true;
            radMedium.Location = new Point(7, 63);
            radMedium.Margin = new Padding(3, 4, 3, 4);
            radMedium.Name = "radMedium";
            radMedium.Size = new Size(85, 24);
            radMedium.TabIndex = 0;
            radMedium.TabStop = true;
            radMedium.Text = "Medium";
            radMedium.UseVisualStyleBackColor = true;
            radMedium.CheckedChanged += DifficultyCheckedChangedEH;
            // 
            // radEasy
            // 
            radEasy.AutoSize = true;
            radEasy.Location = new Point(7, 29);
            radEasy.Margin = new Padding(3, 4, 3, 4);
            radEasy.Name = "radEasy";
            radEasy.Size = new Size(59, 24);
            radEasy.TabIndex = 0;
            radEasy.TabStop = true;
            radEasy.Text = "Easy";
            radEasy.UseVisualStyleBackColor = true;
            radEasy.CheckedChanged += DifficultyCheckedChangedEH;
            // 
            // lblSize
            // 
            lblSize.AutoSize = true;
            lblSize.Location = new Point(55, 52);
            lblSize.Name = "lblSize";
            lblSize.Size = new Size(17, 20);
            lblSize.TabIndex = 1;
            lblSize.Text = "4";
            // 
            // btnStartGame
            // 
            btnStartGame.Location = new Point(55, 313);
            btnStartGame.Margin = new Padding(3, 4, 3, 4);
            btnStartGame.Name = "btnStartGame";
            btnStartGame.Size = new Size(86, 31);
            btnStartGame.TabIndex = 4;
            btnStartGame.Text = "Start Game";
            btnStartGame.UseVisualStyleBackColor = true;
            btnStartGame.Click += BtnStartGameClickEH;
            // 
            // btnExit
            // 
            btnExit.AutoSize = true;
            btnExit.Location = new Point(173, 313);
            btnExit.Margin = new Padding(3, 4, 3, 4);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(172, 31);
            btnExit.TabIndex = 5;
            btnExit.Text = "Exit Settings and Game";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += BtnExitClickEH;
            // 
            // FrmGameSettings
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(369, 380);
            Controls.Add(btnExit);
            Controls.Add(btnStartGame);
            Controls.Add(grpLevel);
            Controls.Add(label3);
            Controls.Add(lblSize);
            Controls.Add(label1);
            Controls.Add(trkSizeBoard);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmGameSettings";
            Text = "Start a New Game";
            ((System.ComponentModel.ISupportInitialize)trkSizeBoard).EndInit();
            grpLevel.ResumeLayout(false);
            grpLevel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TrackBar trkSizeBoard;
        private Label label1;
        private Label label3;
        private GroupBox grpLevel;
        private RadioButton radDifficult;
        private RadioButton radMedium;
        private RadioButton radEasy;
        private Label lblSize;
        private Button btnStartGame;
        private Button btnExit;
    }
}