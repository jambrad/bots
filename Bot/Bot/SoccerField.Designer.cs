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
            this.Field = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // Refresher
            // 
            this.Refresher.Enabled = true;
            this.Refresher.Interval = 10;
            this.Refresher.Tick += new System.EventHandler(this.Refresher_Tick);
            // 
            // Field
            // 
            this.Field.BackColor = System.Drawing.Color.White;
            this.Field.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Field.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Field.Location = new System.Drawing.Point(0, 0);
            this.Field.Margin = new System.Windows.Forms.Padding(2);
            this.Field.Name = "Field";
            this.Field.Size = new System.Drawing.Size(993, 564);
            this.Field.TabIndex = 7;
            this.Field.Paint += new System.Windows.Forms.PaintEventHandler(this.Field_Paint);
            this.Field.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Field_MouseClick);
            // 
            // SoccerField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(993, 564);
            this.Controls.Add(this.Field);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SoccerField";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Roooboooot Soccah";
            this.Load += new System.EventHandler(this.BotField_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer Refresher;
        private System.Windows.Forms.Panel Field;
    }
}

