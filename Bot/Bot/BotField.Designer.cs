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
            this.LeftBar = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Field = new System.Windows.Forms.Panel();
            this.RightBar = new System.Windows.Forms.TrackBar();
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
            this.LeftBar.Location = new System.Drawing.Point(939, 12);
            this.LeftBar.Maximum = 100;
            this.LeftBar.Minimum = -100;
            this.LeftBar.Name = "LeftBar";
            this.LeftBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.LeftBar.Size = new System.Drawing.Size(56, 525);
            this.LeftBar.TabIndex = 1;
            this.LeftBar.TickFrequency = 10;
            this.LeftBar.ValueChanged += new System.EventHandler(this.LeftBar_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(944, 540);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "L";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1008, 540);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 23);
            this.label4.TabIndex = 5;
            this.label4.Text = "R";
            // 
            // Field
            // 
            this.Field.BackColor = System.Drawing.Color.White;
            this.Field.Location = new System.Drawing.Point(12, 12);
            this.Field.Name = "Field";
            this.Field.Size = new System.Drawing.Size(893, 572);
            this.Field.TabIndex = 7;
            this.Field.Paint += new System.Windows.Forms.PaintEventHandler(this.Field_Paint);
            // 
            // RightBar
            // 
            this.RightBar.Location = new System.Drawing.Point(1001, 12);
            this.RightBar.Maximum = 100;
            this.RightBar.Minimum = -100;
            this.RightBar.Name = "RightBar";
            this.RightBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.RightBar.Size = new System.Drawing.Size(56, 525);
            this.RightBar.TabIndex = 8;
            this.RightBar.TickFrequency = 10;
            this.RightBar.Scroll += new System.EventHandler(this.RightBar_Scroll);
            // 
            // BotField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1069, 593);
            this.Controls.Add(this.RightBar);
            this.Controls.Add(this.Field);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LeftBar);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BotField";
            this.Text = "BOTS OF LEGENDS";
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
    }
}

