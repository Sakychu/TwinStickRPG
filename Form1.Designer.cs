namespace RpgRougeliketest
{
    partial class DrawFrom
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
            timer1 = new System.Windows.Forms.Timer(components);
            NextBtn = new Button();
            MovePlayer0 = new Button();
            MovePlayer1 = new Button();
            MovePlayer2 = new Button();
            MovePlayer3 = new Button();
            MovePlayer4 = new Button();
            MovePlayer5 = new Button();
            MovePlayer6 = new Button();
            MovePlayer7 = new Button();
            MovePlayer8 = new Button();
            SuspendLayout();
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 66;
            timer1.Tick += timer1_Tick;
            // 
            // NextBtn
            // 
            NextBtn.Location = new Point(207, 617);
            NextBtn.Name = "NextBtn";
            NextBtn.Size = new Size(75, 23);
            NextBtn.TabIndex = 0;
            NextBtn.Text = "Next";
            NextBtn.UseVisualStyleBackColor = true;
            NextBtn.Visible = false;
            NextBtn.Click += NextBtn_Click;
            // 
            // MovePlayer0
            // 
            MovePlayer0.Enabled = false;
            MovePlayer0.Location = new Point(67, 588);
            MovePlayer0.Name = "MovePlayer0";
            MovePlayer0.Size = new Size(20, 23);
            MovePlayer0.TabIndex = 1;
            MovePlayer0.TabStop = false;
            MovePlayer0.UseVisualStyleBackColor = true;
            MovePlayer0.Visible = false;
            MovePlayer0.Click += MovePlayer0_Click;
            // 
            // MovePlayer1
            // 
            MovePlayer1.Enabled = false;
            MovePlayer1.Location = new Point(93, 588);
            MovePlayer1.Name = "MovePlayer1";
            MovePlayer1.Size = new Size(20, 23);
            MovePlayer1.TabIndex = 1;
            MovePlayer1.TabStop = false;
            MovePlayer1.UseVisualStyleBackColor = true;
            MovePlayer1.Visible = false;
            MovePlayer1.Click += MovePlayer1_Click;
            // 
            // MovePlayer2
            // 
            MovePlayer2.Enabled = false;
            MovePlayer2.Location = new Point(119, 588);
            MovePlayer2.Name = "MovePlayer2";
            MovePlayer2.Size = new Size(20, 23);
            MovePlayer2.TabIndex = 1;
            MovePlayer2.TabStop = false;
            MovePlayer2.UseVisualStyleBackColor = true;
            MovePlayer2.Visible = false;
            MovePlayer2.Click += MovePlayer2_Click;
            // 
            // MovePlayer3
            // 
            MovePlayer3.Enabled = false;
            MovePlayer3.Location = new Point(67, 617);
            MovePlayer3.Name = "MovePlayer3";
            MovePlayer3.Size = new Size(20, 23);
            MovePlayer3.TabIndex = 1;
            MovePlayer3.TabStop = false;
            MovePlayer3.UseVisualStyleBackColor = true;
            MovePlayer3.Visible = false;
            MovePlayer3.Click += MovePlayer3_Click;
            // 
            // MovePlayer4
            // 
            MovePlayer4.Enabled = false;
            MovePlayer4.Location = new Point(93, 617);
            MovePlayer4.Name = "MovePlayer4";
            MovePlayer4.Size = new Size(20, 23);
            MovePlayer4.TabIndex = 1;
            MovePlayer4.TabStop = false;
            MovePlayer4.UseVisualStyleBackColor = true;
            MovePlayer4.Visible = false;
            MovePlayer4.Click += MovePlayer4_Click;
            // 
            // MovePlayer5
            // 
            MovePlayer5.Enabled = false;
            MovePlayer5.Location = new Point(119, 617);
            MovePlayer5.Name = "MovePlayer5";
            MovePlayer5.Size = new Size(20, 23);
            MovePlayer5.TabIndex = 1;
            MovePlayer5.TabStop = false;
            MovePlayer5.UseVisualStyleBackColor = true;
            MovePlayer5.Visible = false;
            MovePlayer5.Click += MovePlayer5_Click;
            // 
            // MovePlayer6
            // 
            MovePlayer6.Enabled = false;
            MovePlayer6.Location = new Point(67, 646);
            MovePlayer6.Name = "MovePlayer6";
            MovePlayer6.Size = new Size(20, 23);
            MovePlayer6.TabIndex = 1;
            MovePlayer6.TabStop = false;
            MovePlayer6.UseVisualStyleBackColor = true;
            MovePlayer6.Visible = false;
            MovePlayer6.Click += MovePlayer6_Click;
            // 
            // MovePlayer7
            // 
            MovePlayer7.Enabled = false;
            MovePlayer7.Location = new Point(93, 646);
            MovePlayer7.Name = "MovePlayer7";
            MovePlayer7.Size = new Size(20, 23);
            MovePlayer7.TabIndex = 1;
            MovePlayer7.TabStop = false;
            MovePlayer7.UseVisualStyleBackColor = true;
            MovePlayer7.Visible = false;
            MovePlayer7.Click += MovePlayer7_Click;
            // 
            // MovePlayer8
            // 
            MovePlayer8.Enabled = false;
            MovePlayer8.Location = new Point(119, 646);
            MovePlayer8.Name = "MovePlayer8";
            MovePlayer8.Size = new Size(20, 23);
            MovePlayer8.TabIndex = 1;
            MovePlayer8.TabStop = false;
            MovePlayer8.UseVisualStyleBackColor = true;
            MovePlayer8.Visible = false;
            MovePlayer8.Click += MovePlayer8_Click;
            // 
            // DrawFrom
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(1264, 681);
            Controls.Add(MovePlayer8);
            Controls.Add(MovePlayer7);
            Controls.Add(MovePlayer6);
            Controls.Add(MovePlayer5);
            Controls.Add(MovePlayer4);
            Controls.Add(MovePlayer3);
            Controls.Add(MovePlayer2);
            Controls.Add(MovePlayer1);
            Controls.Add(MovePlayer0);
            Controls.Add(NextBtn);
            DoubleBuffered = true;
            KeyPreview = true;
            Name = "DrawFrom";
            Text = "Form1";
            Load += Form1_Load;
            Paint += Form1_Paint;
            KeyDown += Form1_KeyDown;
            KeyPress += Form1_KeyPress;
            KeyUp += Form1_KeyUp;
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private Button NextBtn;
        private Button MovePlayer0;
        private Button MovePlayer1;
        private Button MovePlayer2;
        private Button MovePlayer3;
        private Button MovePlayer4;
        private Button MovePlayer5;
        private Button MovePlayer6;
        private Button MovePlayer7;
        private Button MovePlayer8;
    }
}