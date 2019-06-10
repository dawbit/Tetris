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
        #region private
        private Figure figure;
        private Rectangle[] tab_rec;
        private Color[] color_field;

        private bool stop_moving_down = false;
        private bool game_over = false;
        private bool move_availble = true;
        private bool full_line = false;

        private static readonly int Width = 11;
        private static readonly int Height = 20;
        private static readonly int WxH = 220;
        private int Score;

        private readonly SinglePixel[,] Single_pixel = new SinglePixel[Width, Height];
        private readonly string Background_Color = "DarkSlateGray";

        #endregion

        #region field
        public Field()
        {
            Score = 0;

            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    Single_pixel[i, j] = new SinglePixel(i, j, Background_Color);
                }
            }
        }

        #endregion

        #region methods
        public Rectangle[] Square_dimensions()
        {

            int l = 0;
            tab_rec = new Rectangle[WxH];

            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    tab_rec[l] = Single_pixel[i, j].Square_return();
                    l++;
                }

            }
            return tab_rec;
        }

        public Color[] Color_name()
        {
            int l = 0;
            color_field = new Color[250];
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    color_field[l] = Single_pixel[i, j].Check_color();
                    l++;
                }

            }
            return color_field;
        }

        public void Draw_figure()
        {
            figure = new Figure();
            for (int i = 0; i < figure.coordinate().Length; i++)
            {
                if (Single_pixel[figure.coordinate()[i], figure.coordinate()[i + 1]].Get_color() == "Red")
                {
                    game_over = true;
                }
                i++;

            }
            if (game_over != true)
            {

                for (int i = 0; i < 8; i++)
                {
                    Single_pixel[figure.coordinate()[i], figure.coordinate()[i + 1]].Change_color("Red");
                    i++;
                }
            }

        }

        public int Figure_down()
        {
            try
            {
                for (int j = 0; j < figure.check_floor_down().Length; j++)
                {
                    Single_pixel[figure.check_floor_down()[j], figure.check_floor_down()[j + 1]].Change_color(Single_pixel[figure.check_floor_down()[j], figure.check_floor_down()[j + 1]].Get_color());
                    j++;
                }
                for (int l = 0; l < figure.check_floor_down().Length; l++)
                {
                    if (Single_pixel[figure.check_floor_down()[l], figure.check_floor_down()[l + 1]].Get_color() == "Red")
                    {
                        stop_moving_down = true;
                    }
                    l++;

                }
                if (stop_moving_down == false)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        Single_pixel[figure.coordinate()[i], figure.coordinate()[i + 1]].Change_color(Background_Color);
                        i++;
                    }

                    figure.coordinates_down();



                    for (int i = 0; i < 8; i++)
                    {
                        Single_pixel[figure.coordinate()[i], figure.coordinate()[i + 1]].Change_color("Red");
                        i++;
                    }
                }
                else
                {
                    stop_moving_down = false;
                    Line_by_line();
                    Draw_figure();
                }
            }
            catch (System.IndexOutOfRangeException)
            {
                Line_by_line();
                Draw_figure();

            }

            return Score;

        }


        public void Figure_left()
        {
            try
            {
                for (int j = 0; j < figure.check_left_left().Length - 1; j++)
                {
                    Single_pixel[figure.check_left_left()[j], figure.check_left_left()[j + 1]].Change_color(Single_pixel[figure.check_left_left()[j], figure.check_left_left()[j + 1]].Get_color());
                    j++;
                }
                for (int l = 0; l < figure.check_left_left().Length; l++)
                {
                    if (Single_pixel[figure.check_left_left()[l], figure.check_left_left()[l + 1]].Get_color() == "Red")
                    {
                        move_availble = false;
                    }
                    l++;

                }
                if (move_availble == true)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        Single_pixel[figure.coordinate()[i], figure.coordinate()[i + 1]].Change_color(Background_Color);
                        i++;
                    }

                    figure.coordinates_left();


                    for (int i = 0; i < 8; i++)
                    {
                        Single_pixel[figure.coordinate()[i], figure.coordinate()[i + 1]].Change_color("Red");
                        i++;
                    }
                }
                else
                {
                    move_availble = true;
                }
            }
            catch (System.IndexOutOfRangeException)
            {
            }
        }

        public void Figure_right()
        {
            try
            {
                for (int j = 0; j < figure.check_right_right().Length - 1; j++)
                {
                    Single_pixel[figure.check_right_right()[j], figure.check_right_right()[j + 1]].Change_color(Single_pixel[figure.check_right_right()[j], figure.check_right_right()[j + 1]].Get_color());
                    j++;
                }
                for (int l = 0; l < figure.check_right_right().Length; l++)
                {
                    if (Single_pixel[figure.check_right_right()[l], figure.check_right_right()[l + 1]].Get_color() == "Red")
                    {
                        move_availble = false;
                    }
                    l++;

                }
                if (move_availble == true)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        Single_pixel[figure.coordinate()[i], figure.coordinate()[i + 1]].Change_color(Background_Color);
                        i++;
                    }

                    figure.coordinates_right();


                    for (int i = 0; i < 8; i++)
                    {
                        Single_pixel[figure.coordinate()[i], figure.coordinate()[i + 1]].Change_color("Red");
                        i++;
                    }
                }
                else
                {
                    move_availble = true;
                }
            }
            catch (System.IndexOutOfRangeException)
            {
            }
        }

        private void Line_by_line()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    if (Single_pixel[j, i].Get_color() == Background_Color)
                    {
                        full_line = false;
                    }
                }
                if (full_line == true)
                {
                    Score++;

                    for (int j = 0; j < Width; j++)
                    {
                        for (int k = i; k >= 0; k--)
                        {
                            if (k != 0)
                            {
                                Single_pixel[j, k].Change_color(Single_pixel[j, k - 1].Get_color());
                            }
                            else
                            {
                                Single_pixel[j, k].Change_color(Background_Color);
                            }

                        }

                    }

                }
                else full_line = true;
            }
        }

        public bool Return_game_over()
        {
            return game_over;
        }
    }

    #endregion

}
