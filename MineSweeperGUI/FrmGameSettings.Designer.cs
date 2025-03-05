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
            ((System.ComponentModel.ISupportInitialize)trkSizeBoard).BeginInit();
            grpLevel.SuspendLayout();
            SuspendLayout();
            // 
            // trkSizeBoard
            // 
            trkSizeBoard.Location = new Point(12, 57);
            trkSizeBoard.Maximum = 12;
            trkSizeBoard.Minimum = 4;
            trkSizeBoard.Name = "trkSizeBoard";
            trkSizeBoard.Size = new Size(295, 45);
            trkSizeBoard.TabIndex = 0;
            trkSizeBoard.Value = 4;
            trkSizeBoard.ValueChanged += TrkSizeBoardValueChangedEH;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 39);
            label1.Name = "label1";
            label1.Size = new Size(30, 15);
            label1.TabIndex = 1;
            label1.Text = "Size:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 9);
            label3.Name = "label3";
            label3.Size = new Size(102, 15);
            label3.TabIndex = 2;
            label3.Text = "Play Minesweeper";
            // 
            // grpLevel
            // 
            grpLevel.Controls.Add(radDifficult);
            grpLevel.Controls.Add(radMedium);
            grpLevel.Controls.Add(radEasy);
            grpLevel.Location = new Point(36, 108);
            grpLevel.Name = "grpLevel";
            grpLevel.Size = new Size(200, 100);
            grpLevel.TabIndex = 3;
            grpLevel.TabStop = false;
            grpLevel.Text = "Choose A Difficulty";
            // 
            // radDifficult
            // 
            radDifficult.AutoSize = true;
            radDifficult.Location = new Point(6, 75);
            radDifficult.Name = "radDifficult";
            radDifficult.Size = new Size(67, 19);
            radDifficult.TabIndex = 0;
            radDifficult.TabStop = true;
            radDifficult.Text = "Difficult";
            radDifficult.UseVisualStyleBackColor = true;
            // 
            // radMedium
            // 
            radMedium.AutoSize = true;
            radMedium.Location = new Point(6, 47);
            radMedium.Name = "radMedium";
            radMedium.Size = new Size(70, 19);
            radMedium.TabIndex = 0;
            radMedium.TabStop = true;
            radMedium.Text = "Medium";
            radMedium.UseVisualStyleBackColor = true;
            // 
            // radEasy
            // 
            radEasy.AutoSize = true;
            radEasy.Location = new Point(6, 22);
            radEasy.Name = "radEasy";
            radEasy.Size = new Size(48, 19);
            radEasy.TabIndex = 0;
            radEasy.TabStop = true;
            radEasy.Text = "Easy";
            radEasy.UseVisualStyleBackColor = true;
            radEasy.CheckedChanged += DifficultyCheckedChangedEH;
            // 
            // lblSize
            // 
            lblSize.AutoSize = true;
            lblSize.Location = new Point(48, 39);
            lblSize.Name = "lblSize";
            lblSize.Size = new Size(13, 15);
            lblSize.TabIndex = 1;
            lblSize.Text = "4";
            // 
            // FrmGameSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(323, 252);
            Controls.Add(grpLevel);
            Controls.Add(label3);
            Controls.Add(lblSize);
            Controls.Add(label1);
            Controls.Add(trkSizeBoard);
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
    }
}