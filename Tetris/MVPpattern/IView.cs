using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    interface IView
    {
        System.Drawing.Rectangle[] Rec { get; set; }
        System.Drawing.Color[] Color { get; set; }
        bool Game_over { get; set; }
        int Score { get; set; }

        event Action Load_Panel;
        event Action Start_game;
        event Action Move_Figure_down;
        event Action End_game_check;
        event Action Left_Arrow;
        event Action Right_Arrow;
    }
}
