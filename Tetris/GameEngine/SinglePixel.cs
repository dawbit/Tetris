using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tetris
{
    class SinglePixel
    {
        Rectangle rec;
        private Color color;

        private readonly int x = 1;
        private readonly int y = 1;
        private const int dimension = 20;

        public SinglePixel(int x, int y, string color)
        {
            this.x = x * dimension;
            this.y = y * dimension;
            this.color = Color.DarkSlateGray;
        }

        public Rectangle Square_return()
        {
            return rec = new Rectangle(x, y, dimension, dimension);
        }

        public Color Check_color()
        {
            return color;
        }

        public void Change_color(string name)
        {
            this.color = Color.FromName(name);
        }

        public string Get_color()
        {
            return color.Name;
        }

    }
}
