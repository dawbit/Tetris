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
            return field.Square_dimensions();
        }

        public Color[] Load_Panel_Color()
        {
            return field.Color_name();
        }

        public void Startgame()
        {
            field = new Field();
            field.Draw_Tertimino();
        }

        public int Figure_down()
        {
            return field.Figure_down();
        }

        public bool End_game_check()
        {
            return field.Return_game_over();
        }

        public void Left_Arrow_Model()
        {
            field.Figure_left();
        }

        public void Right_Arrow_Model()
        {
            field.Figure_right();
        }
    }
}
