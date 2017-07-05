using System;
using System.Drawing;
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
            myBot = new Bot(Field.Width / 2, Field.Height / 2, Refresher.Interval);

            myPen = new Pen(Color.Black);

            testPen = new Pen(Color.Red, 5);
        }

        private void Refresher_Tick(object sender, EventArgs e)
        {
            myBot.Move(LeftValue, RightValue);
            Field.Refresh();
        }

        private void LeftBar_Scroll(object sender, EventArgs e)
        {
            LeftValue = (LeftBar.Value / (float)LeftBar.Maximum);
            //printLeftRightValues();
        }

        private void RightBar_Scroll(object sender, EventArgs e)
        {
            RightValue = (RightBar.Value / (float)RightBar.Maximum);
            //printLeftRightValues();
        }

        private void printLeftRightValues()
        {
            Console.WriteLine("(" + LeftValue + ", " + RightValue + ")");
        }

        private void Field_Paint(object sender, PaintEventArgs e)
        {
            myBot.Draw(e);
        }

        private Bot myBot;

        private Pen myPen;
        private Pen testPen;

        private float LeftValue;
        private float RightValue;
    }
}
