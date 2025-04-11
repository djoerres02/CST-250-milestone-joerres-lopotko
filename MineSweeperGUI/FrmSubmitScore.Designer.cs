namespace MineSweeperGUI
{
    partial class FrmSubmitScore
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
            label1 = new Label();
            lblStats = new Label();
            label2 = new Label();
            txtName = new TextBox();
            btnSubmit = new Button();
            lblWarning = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(141, 9);
            label1.Name = "label1";
            label1.Size = new Size(58, 15);
            label1.TabIndex = 0;
            label1.Text = "Congrats!";
            // 
            // lblStats
            // 
            lblStats.AutoSize = true;
            lblStats.Location = new Point(29, 55);
            lblStats.Name = "lblStats";
            lblStats.Size = new Size(122, 15);
            lblStats.TabIndex = 1;
            lblStats.Text = "(placeholder for stats)";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(29, 94);
            label2.Name = "label2";
            label2.Size = new Size(247, 15);
            label2.TabIndex = 1;
            label2.Text = "Please enter your name for Score Submission:";
            // 
            // txtName
            // 
            txtName.Location = new Point(29, 123);
            txtName.Name = "txtName";
            txtName.Size = new Size(186, 23);
            txtName.TabIndex = 2;
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(221, 123);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(75, 23);
            btnSubmit.TabIndex = 3;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += BtnSubmitClickEH;
            // 
            // lblWarning
            // 
            lblWarning.AutoSize = true;
            lblWarning.ForeColor = Color.Red;
            lblWarning.Location = new Point(92, 149);
            lblWarning.Name = "lblWarning";
            lblWarning.Size = new Size(143, 15);
            lblWarning.TabIndex = 1;
            lblWarning.Text = "Please enter a valid name.";
            lblWarning.Visible = false;
            // 
            // FrmSubmitScore
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(342, 204);
            Controls.Add(btnSubmit);
            Controls.Add(txtName);
            Controls.Add(lblWarning);
            Controls.Add(label2);
            Controls.Add(lblStats);
            Controls.Add(label1);
            Name = "FrmSubmitScore";
            Text = "Submit Score";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label lblStats;
        private Label label2;
        private TextBox txtName;
        private Button btnSubmit;
        private Label lblWarning;
    }
}