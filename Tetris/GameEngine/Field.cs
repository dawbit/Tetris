using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Tetris
{
    class Field
    {
        private Figure figure;
        private Rectangle[] tab_rec;
        private Color[] color_field;
        private bool stop_moving_down = false;
        private bool game_over = false;
        private SinglePixel[,] tab_pixel= new SinglePixel[11, 20];
        private int licznik;
        //private string background_Color = "DarkSlateGray";
        private string background_Color = "DarkSlateGray";

        public Field()
        {
            licznik = 0;

            for (int i= 0; i<11; i++)
            {
                for (int j=0; j < 20; j++)
                {
                    tab_pixel[i, j] = new SinglePixel(i,j,background_Color);
                }
            }
        }
        public Rectangle[] square_dimensions()
        {
            
            int l = 0;
            tab_rec = new Rectangle[220];
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    tab_rec[l] = tab_pixel[i, j].square_return();
                    l++;
                }

            }
            return tab_rec;
        }
        public Color[] color_name()
        {
            int l = 0;
            color_field = new Color[250];
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    color_field[l] = tab_pixel[i, j].check_color();
                    l++;
                }
                
            }
            return color_field;
        }
        
        public void Draw_figure()
        {
            figure = new Figure();
            for (int i = 0; i < figure.wspolrzedne().Length; i++)
            {
                if (tab_pixel[figure.wspolrzedne()[i], figure.wspolrzedne()[i + 1]].get_color()=="Red")
                {
                    game_over = true;
                }
                i++;

            }
            if (game_over != true)
            {

                for (int i = 0; i < 8; i++)
                {
                    tab_pixel[figure.wspolrzedne()[i], figure.wspolrzedne()[i + 1]].change_color("Red");
                    i++;
                }
            }

        }
        public int figure_down()
        {
            try
            {
                for (int j = 0; j < figure.check_field_down().Length; j++)
                {
                    tab_pixel[figure.check_field_down()[j], figure.check_field_down()[j+1]].change_color(tab_pixel[figure.check_field_down()[j], figure.check_field_down()[j + 1]].get_color());
                        j++;
                }
                for (int l= 0; l < figure.check_field_down().Length; l++)
                {
                    if(tab_pixel[figure.check_field_down()[l], figure.check_field_down()[l + 1]].get_color() == "Red")
                    {
                        stop_moving_down = true;
                    }
                    l++;
                    
                }
                if (stop_moving_down == false)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        tab_pixel[figure.wspolrzedne()[i], figure.wspolrzedne()[i + 1]].change_color(background_Color);
                        i++;
                    }

                    figure.figura_wspolrzedne_down();



                    for (int i = 0; i < 8; i++)
                    {
                        tab_pixel[figure.wspolrzedne()[i], figure.wspolrzedne()[i + 1]].change_color("Red");
                        i++;
                    }
                }
                else
                {
                    stop_moving_down = false;
                    Draw_figure();
                }
            }
            catch (System.IndexOutOfRangeException)
            {
                Draw_figure();

            }

            return licznik;

        }

        public bool return_game_over()
        {
            //Field = new Field();
            return game_over;
        }
    }
    
}
