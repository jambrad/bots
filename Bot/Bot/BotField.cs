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
            myBot = new Bot(200f, 200f);

            myPen = new Pen(Color.Black);

            testPen = new Pen(Color.Red, 5);

            //Console.WriteLine(Math.Sin(35));
            //Console.WriteLine(Math.Sin((35 / (Math.PI * 2))) * 4.9);
        }

        private void BotField_Paint(object sender, PaintEventArgs e)
        {
            var boundaries = new RectangleF[1] { myBot.Boundaries };
            e.Graphics.RotateTransform(myBot.Angle);
            e.Graphics.DrawEllipse(myPen, myBot.Boundaries);
        }

        private void Refresher_Tick(object sender, EventArgs e)
        {
            myBot.Move(speed, turn);
            Field.Refresh();
        }

        private void TurnBar_Scroll(object sender, EventArgs e)
        {
            turn = (TurnBar.Value / (float)TurnBar.Maximum);
        }

        private void SpeedBar_Scroll(object sender, EventArgs e)
        {
            speed = (SpeedBar.Value / (float)SpeedBar.Maximum);
        }

        private void Field_Paint(object sender, PaintEventArgs e)
        {
            var boundaries = new RectangleF[1] { myBot.Boundaries };
            e.Graphics.DrawEllipse(myPen, myBot.Boundaries);
        }

        private Bot myBot;

        private Pen myPen;
        private Pen testPen;

        private float turn;
        private float speed;
    }
}
