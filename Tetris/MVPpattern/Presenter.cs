using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class Presenter
    {
        IView view = new Tetris();
        Model model = new Model();

        public Presenter(IView view, Model model)
        {
            this.view = view;
            this.model = model;

            this.view.Load_Panel += LoadPanel;
            this.view.Start_game += Startgame;
            this.view.Move_Figure_down += Move_figure_down;
            this.view.End_game_check += End_game_check;
            this.view.Right_Arrow += Right_Arrow_Presenter;
            this.view.Left_Arrow += Left_Arrow_Presenter;
        }

        private void LoadPanel()
        {
            view.Rec = model.Load_Panel_Rectangle();
            view.Color = (model.Load_Panel_Color());
        }

        private void Startgame()
        {
            LoadPanel();
            model.Startgame();
            view.Rec = model.Load_Panel_Rectangle();
            view.Color = (model.Load_Panel_Color());
        }

        private void Move_figure_down()
        {
            view.Score = model.Figure_down();
            view.Rec = model.Load_Panel_Rectangle();
            view.Color = (model.Load_Panel_Color());
        }

        private void End_game_check()
        {
            view.Game_over = model.End_game_check();
        }

        private void Right_Arrow_Presenter()
        {
            model.Right_side();
            LoadPanel();
        }

        private void Left_Arrow_Presenter()
        {
            model.Left_side();
            LoadPanel();
        }

    }
}
