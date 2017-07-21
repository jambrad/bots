namespace Robot
{
    partial class SoccerField
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
            this.components = new System.ComponentModel.Container();
            this.Refresher = new System.Windows.Forms.Timer(this.components);
            this.LeftBar = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Field = new System.Windows.Forms.Panel();
            this.RightBar = new System.Windows.Forms.TrackBar();
            this.leftSpeed = new System.Windows.Forms.Label();
            this.rightSpeed = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.LeftBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightBar)).BeginInit();
            this.SuspendLayout();
            // 
            // Refresher
            // 
            this.Refresher.Enabled = true;
            this.Refresher.Interval = 10;
            this.Refresher.Tick += new System.EventHandler(this.Refresher_Tick);
            // 
            // LeftBar
            // 
            this.LeftBar.Location = new System.Drawing.Point(9, 459);
            this.LeftBar.Margin = new System.Windows.Forms.Padding(2);
            this.LeftBar.Maximum = 100;
            this.LeftBar.Minimum = -100;
            this.LeftBar.Name = "LeftBar";
            this.LeftBar.Size = new System.Drawing.Size(570, 45);
            this.LeftBar.TabIndex = 1;
            this.LeftBar.TickFrequency = 10;
            this.LeftBar.Scroll += new System.EventHandler(this.LeftBar_Scroll);
            this.LeftBar.ValueChanged += new System.EventHandler(this.LeftBar_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(583, 459);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "Left Wheel";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(583, 508);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 21);
            this.label4.TabIndex = 5;
            this.label4.Text = "Right Wheel";
            // 
            // Field
            // 
            this.Field.BackColor = System.Drawing.Color.White;
            this.Field.Location = new System.Drawing.Point(9, 10);
            this.Field.Margin = new System.Windows.Forms.Padding(2);
            this.Field.Name = "Field";
            this.Field.Size = new System.Drawing.Size(782, 445);
            this.Field.TabIndex = 7;
            this.Field.Paint += new System.Windows.Forms.PaintEventHandler(this.Field_Paint);
            this.Field.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Field_MouseClick);
            // 
            // RightBar
            // 
            this.RightBar.Location = new System.Drawing.Point(9, 508);
            this.RightBar.Margin = new System.Windows.Forms.Padding(2);
            this.RightBar.Maximum = 100;
            this.RightBar.Minimum = -100;
            this.RightBar.Name = "RightBar";
            this.RightBar.Size = new System.Drawing.Size(570, 45);
            this.RightBar.TabIndex = 8;
            this.RightBar.TickFrequency = 10;
            this.RightBar.Scroll += new System.EventHandler(this.RightBar_Scroll);
            // 
            // leftSpeed
            // 
            this.leftSpeed.AutoSize = true;
            this.leftSpeed.Location = new System.Drawing.Point(708, 465);
            this.leftSpeed.Name = "leftSpeed";
            this.leftSpeed.Size = new System.Drawing.Size(13, 13);
            this.leftSpeed.TabIndex = 9;
            this.leftSpeed.Text = "0";
            // 
            // rightSpeed
            // 
            this.rightSpeed.AutoSize = true;
            this.rightSpeed.Location = new System.Drawing.Point(707, 515);
            this.rightSpeed.Name = "rightSpeed";
            this.rightSpeed.Size = new System.Drawing.Size(13, 13);
            this.rightSpeed.TabIndex = 10;
            this.rightSpeed.Text = "0";
            // 
            // SoccerField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(802, 564);
            this.Controls.Add(this.rightSpeed);
            this.Controls.Add(this.leftSpeed);
            this.Controls.Add(this.RightBar);
            this.Controls.Add(this.LeftBar);
            this.Controls.Add(this.Field);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SoccerField";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Roooboooot Soccah";
            this.Load += new System.EventHandler(this.BotField_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LeftBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer Refresher;
        private System.Windows.Forms.TrackBar LeftBar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel Field;
        private System.Windows.Forms.TrackBar RightBar;
        private System.Windows.Forms.Label leftSpeed;
        private System.Windows.Forms.Label rightSpeed;
    }
}

