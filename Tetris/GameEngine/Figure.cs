using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tetris
{
    class Figure
    {
        //private Color color = Color.White;
        private int index_figury;
        private int[] wspolrzedne_startowe;
        private int[] check_field;
        private int[] check_sides_left;
        private int[] check_sides_right;
        public Figure()
        {
            //Draw_figure();
            Random rand = new Random();
            int k = rand.Next(0, 6);
            //int k = 6;
            index_figury = k;
            figura_wspolrzedne();
        }

        private void figura_wspolrzedne()
        {
                    // Tertimino "l"
                    wspolrzedne_startowe = new int[8] { 4, 0, 4, 1, 4, 2, 4, 3 };
                    check_field = new int[2] { 4, 4 };
                    check_sides_left = new int[8] { 3, 0, 3, 1, 3, 2, 3, 3 };
                    check_sides_right = new int[8] { 5, 0, 5, 1, 5, 2, 5, 3, };
    
        }
        public void figura_wspolrzedne_down()
        {
            for (int j =0; j < check_field.Length; j++)
            {
                j++;
                this.check_field[j] += 1;

            }
            for (int k = 0; k < check_sides_left.Length; k++)
            {
                k++;
                check_sides_left[k] = check_sides_left[k] + 1;
                check_sides_right[k] = check_sides_right[k] + 1;
            }
            for (int i = 0; i < 8; i++)
            { 
                i++;
                this.wspolrzedne_startowe[i] = wspolrzedne_startowe[i] + 1;
                
            }
        }
        public void figura_wspolrzedne_left()
        {
            for (int j = 0; j < check_sides_left.Length-1; j++)
            {
                check_sides_left[j] = check_sides_left[j] - 1;
                check_sides_right[j] = check_sides_right[j] - 1;
                j++;

            }
            for (int k = 0; k < check_field.Length; k++)
            {

                check_field[k] = check_field[k] - 1;
                k++;
            }

            for (int i = 0; i < 7; i++)
            {
                this.wspolrzedne_startowe[i] = wspolrzedne_startowe[i] -1;
                i++;
            }
        }
        public void figura_wspolrzedne_right()
        {
            for (int j = 0; j < check_sides_left.Length - 1; j++)
            {
                check_sides_left[j] = check_sides_left[j] +1;
                check_sides_right[j] = check_sides_right[j] +1;
                j++;

            }
            for (int k = 0; k < check_field.Length; k++)
            {

                check_field[k] = check_field[k] +1;
                k++;
            }

            for (int i = 0; i < 7; i++)
            {
                this.wspolrzedne_startowe[i] = wspolrzedne_startowe[i] +1;
                i++;
            }
        }

        public int[] wspolrzedne()
        {
            return wspolrzedne_startowe;
        }
        public int[] check_field_down()
        {
            return check_field;
        }
        public int[] check_sides_left_left()
        {
            return check_sides_left;
        }
        public int[] check_sides_right_right()
        {
            return check_sides_right;
        }
        public int get_index_figury()
        {
            return index_figury;
        }
            

    }
}
