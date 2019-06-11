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
            int tertimino = rand.Next(0, 6);
            Coordinates(tertimino);
        }

        private void Coordinates(int tertimino)
        {
            switch (tertimino)
            {
                case 0:
                    // Tetrimino "l"
                    start = new int[8] { 5, 0, 5, 1, 5, 2, 5, 3 };
                    check_floor = new int[2] { 5, 4 };
                    check_left = new int[8] { 4, 0, 4, 1, 4, 2, 4, 3 };
                    check_right = new int[8] { 6, 0, 6, 1, 6, 2, 6, 3 };
                    break;

                case 1:
                    // Tetrimino "T"
                    start = new int[8] { 4, 0, 5, 0, 6, 0, 5, 1 };
                    check_floor = new int[6] { 4, 1, 6, 1, 5, 2 };
                    check_left = new int[4] { 3, 0, 4, 1 };
                    check_right = new int[4] { 7, 0, 6, 1 };
                    break;

                case 2:
                    // Tetrimino "O"
                    start = new int[8] { 5, 0, 6, 0, 5, 1, 6, 1 };
                    check_floor = new int[4] { 5, 2, 6, 2 };
                    check_left = new int[4] { 4, 0, 4, 1 };
                    check_right = new int[4] { 7, 0, 7, 1 };
                    break;

                case 3:
                    // Tetrimino "L"
                    start = new int[8] { 5, 0, 5, 1, 5, 2, 6, 2 };
                    check_floor = new int[4] { 5, 3, 6, 3 };
                    check_left = new int[6] { 4, 0, 4, 1, 4, 2 };
                    check_right = new int[6] { 6, 0, 6, 1, 7, 2 };
                    break;

                case 4:
                    // Tetrimino "J"
                    start = new int[8] { 4, 2, 5, 0, 5, 1, 5, 2 };
                    check_floor = new int[4] { 4, 3, 5, 3 };
                    check_left = new int[6] { 4, 0, 4, 1, 3, 2 };
                    check_right = new int[6] { 6, 0, 6, 1, 6, 2 };
                    break;

                case 5:
                    // Tetrimino "S"
                    start = new int[8] { 4, 1, 5, 0, 5, 1, 6, 0 };
                    check_floor = new int[6] { 4, 2, 5, 2, 6, 1 };
                    check_left = new int[4] { 4, 0, 3, 1 };
                    check_right = new int[4] { 7, 0, 6, 1 };
                    break;

                case 6:
                    // Tetrimino "Z"
                    start = new int[8] { 4, 0, 5, 0, 5, 1, 6, 1 };
                    check_floor = new int[6] { 4, 1, 5, 2, 6, 2 };
                    check_left = new int[4] { 3, 0, 4, 1 };
                    check_right = new int[4] { 6, 0, 7, 1 };
                    break;

            }
        }

        public void Coordinates_down()
        {
            for (int fl = 0; fl < check_floor.Length; fl++)
            {
                fl++;
                this.check_floor[fl] += 1;

            }
            for (int l = 0; l < check_left.Length; l++)
            {
                l++;
                check_left[l] = check_left[l] + 1;
                check_right[l] = check_right[l] + 1;
            }
            for (int s = 0; s < start.Length; s++)
            {
                s++;
                this.start[s] = start[s] + 1;
            }
        }

        public void Coordinates_left()
        {
            for (int l = 0; l < check_left.Length - 1; l++)
            {
                check_left[l] = check_left[l] - 1;
                check_right[l] = check_right[l] - 1;
                l++;

            }
            for (int fl = 0; fl < check_floor.Length; fl++)
            {
                check_floor[fl] = check_floor[fl] - 1;
                fl++;
            }

            for (int s = 0; s < start.Length; s++)
            {
                this.start[s] = start[s] - 1;
                s++;
            }
        }

        public void Coordinates_right()
        {
            for (int l = 0; l < check_left.Length - 1; l++)
            {
                check_left[l] = check_left[l] + 1;
                check_right[l] = check_right[l] + 1;
                l++;

            }
            for (int fl = 0; fl < check_floor.Length; fl++)
            {
                check_floor[fl] = check_floor[fl] + 1;
                fl++;
            }

            for (int s = 0; s < start.Length; s++)
            {
                this.start[s] = start[s] + 1;
                s++;
            }
        }

        public int[] Coordinate()
        {
            return start;
        }

        public int[] Check_floor()
        {
            return check_floor;
        }

        public int[] Check_left()
        {
            return check_left;
        }

        public int[] Check_right()
        {
            return check_right;
        }
    }
}
