using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Tetris
{
    class Model
    {
        Field field = new Field();

        public Rectangle[] Load_Panel_Rectangle()
        {
            return field.square_dimensions();
        }
        public Color[] Load_Panel_Color()
        {
            return field.color_name();
        }
        public void Startgame()
        {
            field.Draw_figure();
        }
    }
}
