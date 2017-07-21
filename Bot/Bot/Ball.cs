using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bot
{
    class Ball
    {
        private int x;
        private int y;
        private int width;
        private int height;

        public Ball(int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        public Ball()
        {
            this.x = 0;
            this.y = 0;
            this.width = 0;
            this.height = 0;
        }

        public void draw(PaintEventArgs e)
        {
            Pen p = new Pen(Color.Red);
            e.Graphics.DrawEllipse(p, new Rectangle(x, y, width, height));
        }

        public int X
        {
            get { return x; }
            set { x = value; }
        }
        public int Y
        {
            get { return y; }
            set { y = value; }
        }
    }
}
