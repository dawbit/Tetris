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
        private int[] start;
        private int[] check_floor;
        private int[] check_left;
        private int[] check_right;

        public Figure()
        {
            Random rand = new Random();
            int k = rand.Next(0, 6);
            coordinates(k);
        }

        private void coordinates(int k)
        {
            switch (k)
            {
                case 0:
                    // Tertimino "l"
                    start = new int[8] { 4, 0, 4, 1, 4, 2, 4, 3 };
                    check_floor = new int[2] { 4, 4 };
                    check_left = new int[8] { 3, 0, 3, 1, 3, 2, 3, 3 };
                    check_right = new int[8] { 5, 0, 5, 1, 5, 2, 5, 3, };

                    break;
                case 1:
                    // Tertimino "O"
                    start = new int[8] { 4, 0, 5, 0, 4, 1, 5, 1 };
                    check_floor = new int[4] { 4, 2, 5, 2 };
                    check_left = new int[4] { 3, 0, 3, 1 };
                    check_right = new int[4] { 6, 0, 6, 1 };
                    break;
                case 2:
                    // Tertimino "T"
                    start = new int[8] { 4, 0, 5, 0, 6, 0, 5, 1 };
                    check_floor = new int[6] { 4, 1, 6, 1, 5, 2 };
                    check_left = new int[4] { 3, 0, 4, 1 };
                    check_right = new int[4] { 7, 0, 6, 1 };
                    break;
                case 3:
                    // Tertimino "" do poprawy
                    start = new int[8] { 4, 0, 5, 0, 5, 1, 5, 2 };
                    check_floor = new int[4] { 4, 1, 5, 3 };
                    check_left = new int[6] { 3, 0, 4, 1, 4, 2 };
                    check_right = new int[6] { 6, 0, 6, 1, 6, 2 };
                    break;
                case 4:
                    // Tertimino "do poprawy
                    start = new int[8] { 5, 0, 4, 0, 4, 1, 4, 2 };
                    check_floor = new int[4] { 4, 3, 5, 1 };
                    check_left = new int[6] { 3, 0, 3, 1, 3, 2 };
                    check_right = new int[6] { 6, 0, 5, 1, 5, 2 };
                    break;
                case 5:
                    // Tertimino "Z"
                    start = new int[8] { 4, 0, 5, 0, 5, 1, 6, 1 };
                    check_floor = new int[6] { 4, 1, 5, 2, 6, 2 };
                    check_left = new int[4] { 3, 0, 4, 1 };
                    check_right = new int[4] { 6, 0, 7, 1 };
                    break;
                case 6:
                    // Tertimino "S"
                    start = new int[8] { 5, 0, 4, 0, 4, 1, 3, 1 };
                    check_floor = new int[6] { 3, 2, 4, 2, 5, 1 };
                    check_left = new int[4] { 3, 0, 2, 1 };
                    check_right = new int[4] { 6, 0, 5, 1 };
                    break;

            }
        }
        public void coordinates_down()
        {
            for (int j = 0; j < check_floor.Length; j++)
            {
                j++;
                this.check_floor[j] += 1;

            }
            for (int k = 0; k < check_left.Length; k++)
            {
                k++;
                check_left[k] = check_left[k] + 1;
                check_right[k] = check_right[k] + 1;
            }
            for (int i = 0; i < 8; i++)
            {
                i++;
                this.start[i] = start[i] + 1;

            }
        }
        public void coordinates_left()
        {
            for (int j = 0; j < check_left.Length - 1; j++)
            {
                check_left[j] = check_left[j] - 1;
                check_right[j] = check_right[j] - 1;
                j++;

            }
            for (int k = 0; k < check_floor.Length; k++)
            {

                check_floor[k] = check_floor[k] - 1;
                k++;
            }

            for (int i = 0; i < start.Length; i++)
            {
                this.start[i] = start[i] - 1;
                i++;
            }
        }
        public void coordinates_right()
        {
            for (int j = 0; j < check_left.Length - 1; j++)
            {
                check_left[j] = check_left[j] + 1;
                check_right[j] = check_right[j] + 1;
                j++;

            }
            for (int k = 0; k < check_floor.Length; k++)
            {

                check_floor[k] = check_floor[k] + 1;
                k++;
            }

            for (int i = 0; i < start.Length; i++)
            {
                this.start[i] = start[i] + 1;
                i++;
            }
        }

        public int[] coordinate()
        {
            return start;
        }

        public int[] check_floor_down()
        {
            return check_floor;
        }

        public int[] check_left_left()
        {
            return check_left;
        }

        public int[] check_right_right()
        {
            return check_right;
        }
    }
}
