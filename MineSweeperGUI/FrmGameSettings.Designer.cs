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
            trkSize = new TrackBar();
            trkPercentBombs = new TrackBar();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            grpLevel = new GroupBox();
            radEasy = new RadioButton();
            radMedium = new RadioButton();
            radDifficult = new RadioButton();
            lblSize = new Label();
            lblPercentBombs = new Label();
            ((System.ComponentModel.ISupportInitialize)trkSize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trkPercentBombs).BeginInit();
            grpLevel.SuspendLayout();
            SuspendLayout();
            // 
            // trkSize
            // 
            trkSize.Location = new Point(12, 57);
            trkSize.Name = "trkSize";
            trkSize.Size = new Size(295, 45);
            trkSize.TabIndex = 0;
            // 
            // trkPercentBombs
            // 
            trkPercentBombs.Location = new Point(12, 167);
            trkPercentBombs.Name = "trkPercentBombs";
            trkPercentBombs.Size = new Size(295, 45);
            trkPercentBombs.TabIndex = 0;
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
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 149);
            label2.Name = "label2";
            label2.Size = new Size(90, 15);
            label2.TabIndex = 1;
            label2.Text = "Percent Bombs:";
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
            grpLevel.Location = new Point(53, 233);
            grpLevel.Name = "grpLevel";
            grpLevel.Size = new Size(200, 100);
            grpLevel.TabIndex = 3;
            grpLevel.TabStop = false;
            grpLevel.Text = "Choose a level";
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
            // lblSize
            // 
            lblSize.AutoSize = true;
            lblSize.Location = new Point(48, 39);
            lblSize.Name = "lblSize";
            lblSize.Size = new Size(13, 15);
            lblSize.TabIndex = 1;
            lblSize.Text = "0";
            // 
            // lblPercentBombs
            // 
            lblPercentBombs.AutoSize = true;
            lblPercentBombs.Location = new Point(101, 149);
            lblPercentBombs.Name = "lblPercentBombs";
            lblPercentBombs.Size = new Size(17, 15);
            lblPercentBombs.TabIndex = 1;
            lblPercentBombs.Text = "%";
            // 
            // FrmGameSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(323, 345);
            Controls.Add(grpLevel);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(lblPercentBombs);
            Controls.Add(lblSize);
            Controls.Add(label1);
            Controls.Add(trkPercentBombs);
            Controls.Add(trkSize);
            Name = "FrmGameSettings";
            Text = "Start a New Game";
            ((System.ComponentModel.ISupportInitialize)trkSize).EndInit();
            ((System.ComponentModel.ISupportInitialize)trkPercentBombs).EndInit();
            grpLevel.ResumeLayout(false);
            grpLevel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TrackBar trkSize;
        private TrackBar trkPercentBombs;
        private Label label1;
        private Label label2;
        private Label label3;
        private GroupBox grpLevel;
        private RadioButton radDifficult;
        private RadioButton radMedium;
        private RadioButton radEasy;
        private Label lblSize;
        private Label lblPercentBombs;
    }
}