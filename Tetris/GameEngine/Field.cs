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

        private bool stop_falling = false;
        private bool game_over = false;
        private bool move_availble = true;
        private bool full_line = false;

        private static int Width = 11;
        private static int Height = 20;
        private static int WxH = Width*Height;
        private int Score;

        private readonly SinglePixel[,] Single_pixel = new SinglePixel[Width, Height];
        private readonly string Background_Color = "DarkSlateGray";
        private readonly string[] Colors_Table = { "Cyan",
                                                "DarkCyan",
                                                "CadetBlue",
                                                "LightSteelBlue",
                                                "SteelBlue",
                                                "LightSkyBlue",
                                                "SkyBlue",
                                                "DeepSkyBlue",
                                                "DodgerBlue",
                                                "RoyalBlue",
                                                "Teal" };
        private string tertimino_color;

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
            color_field = new Color[WxH];

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

        public void Draw_Tertimino()
        {
            Random r = new Random();
            int random_color = r.Next(0, 10);
            tertimino_color = Colors_Table[random_color];

            figure = new Figure();

            for (int i = 0; i < figure.Coordinate().Length; i++)
            {
                if (Single_pixel[figure.Coordinate()[i], figure.Coordinate()[i + 1]].Get_color() != Background_Color)
                {
                    game_over = true;
                }
                i++;
            }

            if (game_over != true)
            {

                for (int i = 0; i < figure.Coordinate().Length; i++)
                {
                    Single_pixel[figure.Coordinate()[i], figure.Coordinate()[i + 1]].Change_color(Colors_Table[random_color]);
                    i++;
                }
            }
        }

        public int Figure_down()
        {
            try
            {
                //for (int j = 0; j < figure.Check_floor().Length; j++)
                //{
                //    Single_pixel[figure.Check_floor()[j], figure.Check_floor()[j + 1]].Change_color(Single_pixel[figure.Check_floor()[j], figure.Check_floor()[j + 1]].Get_color());
                //    j++;
                //}
                for (int l = 0; l < figure.Check_floor().Length; l++)
                {
                    if (Single_pixel[figure.Check_floor()[l], figure.Check_floor()[l + 1]].Get_color() != Background_Color)
                    {
                        stop_falling = true;
                    }
                    l++;

                }
                if (stop_falling == false)
                {
                    for (int i = 0; i < figure.Coordinate().Length; i++)
                    {
                        Single_pixel[figure.Coordinate()[i], figure.Coordinate()[i + 1]].Change_color(Background_Color);
                        i++;
                    }
                    figure.Coordinates_down();

                    for (int i = 0; i < figure.Coordinate().Length; i++)
                    {
                        Single_pixel[figure.Coordinate()[i], figure.Coordinate()[i + 1]].Change_color(tertimino_color);
                        i++;
                    }
                }
                else
                {
                    stop_falling = false;
                    Line_by_line();
                    Draw_Tertimino();
                }
            }
            catch (System.IndexOutOfRangeException)
            {
                Line_by_line();
                Draw_Tertimino();
            }

            return Score;
        }


        public void Figure_left()
        {
            try
            {
                //for (int j = 0; j < figure.Check_left().Length - 1; j++)
                //{
                //    //Single_pixel[figure.Check_left()[j], figure.Check_left()[j + 1]].Change_color(Single_pixel[figure.Check_left()[j], figure.Check_left()[j + 1]].Get_color());
                //    //j++;
                //    if (Single_pixel[figure.Check_left()[l], figure.check_sides_left_left()[l + 1]].get_color() != "Black")
                //    {
                //        move_left = false;
                //    }
                //    l++;

                //}
                for (int l = 0; l < figure.Check_left().Length; l++)
                {
                    if (Single_pixel[figure.Check_left()[l], figure.Check_left()[l + 1]].Get_color() != Background_Color)
                    {
                        move_availble = false;
                    }
                    l++;

                }
                if (move_availble == true)
                {
                    for (int i = 0; i < figure.Coordinate().Length; i++)
                    {
                        Single_pixel[figure.Coordinate()[i], figure.Coordinate()[i + 1]].Change_color(Background_Color);
                        i++;
                    }

                    figure.Coordinates_left();

                    for (int i = 0; i < figure.Coordinate().Length; i++)
                    {
                        Single_pixel[figure.Coordinate()[i], figure.Coordinate()[i + 1]].Change_color(tertimino_color);
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
                //for (int j = 0; j < figure.Check_right().Length - 1; j++)
                //{
                //    Single_pixel[figure.Check_right()[j], figure.Check_right()[j + 1]].Change_color(Single_pixel[figure.Check_right()[j], figure.Check_right()[j + 1]].Get_color());
                //    j++;
                //}
                for (int l = 0; l < figure.Check_right().Length; l++)
                {
                    if (Single_pixel[figure.Check_right()[l], figure.Check_right()[l + 1]].Get_color() != Background_Color)
                    {
                        move_availble = false;
                    }
                    l++;

                }
                if (move_availble == true)
                {
                    for (int i = 0; i < figure.Coordinate().Length; i++)
                    {
                        Single_pixel[figure.Coordinate()[i], figure.Coordinate()[i + 1]].Change_color(Background_Color);
                        i++;
                    }

                    figure.Coordinates_right();

                    for (int i = 0; i < figure.Coordinate().Length; i++)
                    {
                        Single_pixel[figure.Coordinate()[i], figure.Coordinate()[i + 1]].Change_color(tertimino_color);
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
