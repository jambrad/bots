namespace Bot
{
    partial class BotField
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
            this.TurnBar = new System.Windows.Forms.TrackBar();
            this.SpeedBar = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Field = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.TurnBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedBar)).BeginInit();
            this.SuspendLayout();
            // 
            // Refresher
            // 
            this.Refresher.Enabled = true;
            this.Refresher.Interval = 10;
            this.Refresher.Tick += new System.EventHandler(this.Refresher_Tick);
            // 
            // TurnBar
            // 
            this.TurnBar.Location = new System.Drawing.Point(61, 582);
            this.TurnBar.Maximum = 100;
            this.TurnBar.Minimum = -100;
            this.TurnBar.Name = "TurnBar";
            this.TurnBar.Size = new System.Drawing.Size(753, 56);
            this.TurnBar.TabIndex = 0;
            this.TurnBar.TickFrequency = 10;
            this.TurnBar.Scroll += new System.EventHandler(this.TurnBar_Scroll);
            // 
            // SpeedBar
            // 
            this.SpeedBar.Location = new System.Drawing.Point(860, 54);
            this.SpeedBar.Maximum = 100;
            this.SpeedBar.Name = "SpeedBar";
            this.SpeedBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.SpeedBar.Size = new System.Drawing.Size(56, 525);
            this.SpeedBar.TabIndex = 1;
            this.SpeedBar.TickFrequency = 5;
            this.SpeedBar.Scroll += new System.EventHandler(this.SpeedBar_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(57, 556);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Left";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(757, 556);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Right";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(856, 582);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Slow";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(856, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 23);
            this.label4.TabIndex = 5;
            this.label4.Text = "Fast";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(400, 556);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 23);
            this.label5.TabIndex = 6;
            this.label5.Text = "Center";
            // 
            // Field
            // 
            this.Field.BackColor = System.Drawing.Color.White;
            this.Field.Location = new System.Drawing.Point(12, 12);
            this.Field.Name = "Field";
            this.Field.Size = new System.Drawing.Size(815, 520);
            this.Field.TabIndex = 7;
            this.Field.Paint += new System.Windows.Forms.PaintEventHandler(this.Field_Paint);
            // 
            // BotField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(928, 650);
            this.Controls.Add(this.Field);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SpeedBar);
            this.Controls.Add(this.TurnBar);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BotField";
            this.Text = "BOTS OF LEGENDS";
            this.Load += new System.EventHandler(this.BotField_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.BotField_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.TurnBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer Refresher;
        private System.Windows.Forms.TrackBar TurnBar;
        private System.Windows.Forms.TrackBar SpeedBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel Field;
    }
}

