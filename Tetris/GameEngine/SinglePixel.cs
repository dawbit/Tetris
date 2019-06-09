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
        private readonly int x = 10;
        private readonly int y = 10;
        private const int dimension = 20;

        public SinglePixel(int x, int y, string color)
        {
            this.x = x * dimension;
            this.y = y * dimension;
            this.color = Color.DarkSlateGray;
        }

        public Color check_color()
        {
            return color;
        }
        public Rectangle square_return()
        {
            return rec = new Rectangle(x, y, dimension, dimension);

        }
        public void change_color(string name)
        {
            this.color = Color.FromName(name);
        }
        public string get_color()
        {
            return color.Name;
        }
    }
}
