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
        }

        private void LoadPanel()
        {

            view.rec = model.Load_Panel_Rectangle();
            view.color = (model.Load_Panel_Color());

        }

        private void Startgame()
        {
            LoadPanel();
            model.Startgame();
            view.rec = model.Load_Panel_Rectangle();
            view.color = (model.Load_Panel_Color());
        }

        private void Move_figure_down()
        {
                view.rec = model.Load_Panel_Rectangle();
                view.color = (model.Load_Panel_Color());
            
            
        }
        
    }
}
