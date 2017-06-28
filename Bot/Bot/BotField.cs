using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bot
{
    public partial class BotField : Form
    {
        public BotField()
        {
            InitializeComponent();
        }

        private void BotField_Load(object sender, EventArgs e)
        {
            myBot = new Bot(Field.Width / 2, Field.Height / 2);

            myPen = new Pen(Color.Black);

            testPen = new Pen(Color.Red, 5);
        }

        private void BotField_Paint(object sender, PaintEventArgs e)
        {
            var boundaries = new RectangleF[1] { myBot.Boundaries };
            e.Graphics.RotateTransform(myBot.Angle);
            e.Graphics.DrawEllipse(myPen, myBot.Boundaries);
        }

        private void Refresher_Tick(object sender, EventArgs e)
        {
            myBot.Move(LeftValue, RightValue);
            Field.Refresh();
        }

        private void LeftBar_Scroll(object sender, EventArgs e)
        {
            LeftValue = (LeftBar.Value / (float)LeftBar.Maximum);
        }

        private void RightBar_Scroll(object sender, EventArgs e)
        {
            RightValue = (RightBar.Value / (float)RightBar.Maximum);
        }

        private void Field_Paint(object sender, PaintEventArgs e)
        {
            var boundaries = new RectangleF[1] { myBot.Boundaries };
            e.Graphics.DrawEllipse(myPen, myBot.Boundaries);
        }

        private Bot myBot;

        private Pen myPen;
        private Pen testPen;

        private float LeftValue;
        private float RightValue;
    }
}
