using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Tetris
{
    public partial class Tetris : Form, IView
    {
        #region interface
        public Rectangle[] Rec { get; set; }
        public Color[] Color { get; set; }
        public bool Game_over { get; set; }

        public int Score {
            get
            {
                return int.Parse(scoreboard.Text);
            }
            set
            {
                scoreboard.Text = value.ToString();
            }
        }

        SolidBrush brush;
        Pen pen;
        #endregion

        #region private var
        private int speed = 200;
        private int WxH = 220;
        private bool timerticks = false;

        #endregion

        public Tetris()
        {
            InitializeComponent();
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, 
                null, panel_field, new object[] { true }); 
            string path = Directory.GetCurrentDirectory();
            Console.WriteLine(path);

            //ograniczenie migotania ekranu

        }

        #region events
        public event Action Load_Panel;
        public event Action Start_game;
        public event Action Move_Figure_down;
        public event Action End_game_check;
        public event Action Left_Arrow;
        public event Action Right_Arrow;

        #endregion

        #region private

        private void Tetris_Load(object sender, EventArgs e)
        {
            Load_Panel?.Invoke();
        }

        private void Panel_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < WxH; i++)
            {
                pen = new Pen(Color[i]);
                brush = new SolidBrush(Color[i]);
                e.Graphics.DrawRectangle(pen, Rec[i]);
                e.Graphics.FillRectangle(brush, Rec[i]);
                pen.Dispose();
            }
        }

        private void Button_start_game_Click(object sender, EventArgs e)
        {
            button_start.Enabled = false;
            scoreboard.Text = ("0");
            Game_over = false;
            Start_game?.Invoke();
            panel_field.Invalidate();
            timer1.Interval = speed;
            timer1.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            End_game_check?.Invoke();

            if (Game_over == false)
            {
                timerticks = true;
                if (timerticks == true)
                {
                    Move_Figure_down?.Invoke();
                    panel_field.Invalidate();
                    timerticks = false;
                }
            }
            else
            {
                panel_field.Invalidate();
                Load_Panel?.Invoke();
                timer1.Stop();
                panel_field.Invalidate();
                button_start.Enabled = true;
            }

        }

        private void Tetris_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                e.SuppressKeyPress = true;
                Left_Arrow?.Invoke();
                panel_field.Invalidate();
            }
            else if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                e.SuppressKeyPress = true;
                Right_Arrow?.Invoke();
                panel_field.Invalidate();
            }
        }
    }
    #endregion
}
