﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace Robot
{
    public partial class SoccerField : Form
    {
        public SoccerField()
        {
            InitializeComponent();
        }

        private void BotField_Load(object sender, EventArgs e)
        {
            myBot = new Robot(Field.Width / 2, Field.Height / 2, Refresher.Interval);

            myPen = new Pen(Color.Black);

            testPen = new Pen(Color.Red, 5);

            
        }

        private void Refresher_Tick(object sender, EventArgs e)
        {
            myBot.moveRobot(LeftValue, RightValue);
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
            CreateGraphics().SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            myBot.draw(e);
        }

        private Robot myBot;

        private Pen myPen;
        private Pen testPen;

        private float LeftValue;
        private float RightValue;
    }
}