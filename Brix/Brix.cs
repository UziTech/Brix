using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Brix
{
    public partial class Brix : Form
    {
        #region Gloabal Variables
        int _V = -3;
        int _H = 2;
        Brixx _null = new Brixx(Brushes.Transparent, 0, 0, 0);
        Brixx _easyBrixx = new Brixx(Brushes.LawnGreen, 75, 20, 1);
        Brixx _mediumBrixx = new Brixx(Brushes.RoyalBlue, 75, 20, 3);
        Brixx _hardBrixx = new Brixx(Brushes.Magenta, 75, 20, 5);
        Brixx _impossibleBrixx = new Brixx(Brushes.Black, 75, 20, 0);
        Rectangle[] _brixArray = new Rectangle[30];
        int[] _levels = new int[20];
        Level[,] _levelArray = new Level[30, 20];
        int _level = 0;
        #endregion
        struct Brixx
        {
            public Image Image;
            public Brush Color;
            public int Width;
            public int Height;
            public int Hits;
            public int MaxHits;
            public Brixx(Brush color, int width, int height, int maxHits)
            {
                this.Image = null;
                this.Color = color;
                this.Width = width;
                this.Height = height;
                this.Hits = 0;
                this.MaxHits = maxHits;
            }
            public Brixx(Image img, int width, int height, int maxHits)
            {
                this.Image = img;
                this.Color = null;
                this.Width = width;
                this.Height = height;
                this.Hits = 0;
                this.MaxHits = maxHits;
            }
            public static bool operator ==(Brixx left, Brixx right)
            {
                if (left.Color == right.Color && left.Height == right.Height && left.Width == right.Width && left.Image == right.Image && left.MaxHits == right.MaxHits)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public static bool operator !=(Brixx left, Brixx right)
            {
                if (left.Color == right.Color && left.Height == right.Height && left.Width == right.Width && left.Image == right.Image && left.MaxHits == right.MaxHits)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            public override int GetHashCode()
            {
                return this.GetHashCode();
            }
            public override bool Equals(object obj)
            {
                if (obj.Equals(this))
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }
        struct Level
        {
            public Brixx Brick;
            public int Top;
            public int Left;
            public int Bottom;
            public int Right;

            public Level(Brixx brick, int top, int left)
            {
                this.Top = top;
                this.Left = left;
                this.Brick = brick;
                this.Bottom = top + brick.Height;
                this.Right = left + brick.Width;
            }
        }
        public Brix()
        {
            InitializeComponent();
            InitializeLevels();
            InitializeBrix();
            Invalidate();
            pad.Image.RotateFlip(RotateFlipType.RotateNoneFlipY);
        }
        private void Brix_Paint(object sender, PaintEventArgs e)
        {
            DrawBrix(e.Graphics);
        }
        private void InitializeLevels()
        {
            _levelArray[0, 0] = new Level(_easyBrixx, 60, 60);
            _levelArray[0, 1] = new Level(_easyBrixx, 60, 135);
            _levelArray[0, 2] = new Level(_easyBrixx, 60, 210);
            _levelArray[0, 3] = new Level(_easyBrixx, 60, 285);
            _levelArray[0, 4] = new Level(_easyBrixx, 60, 360);
            _levelArray[0, 5] = new Level(_easyBrixx, 60, 435);
            _levelArray[0, 6] = new Level(_easyBrixx, 80, 98);
            _levelArray[0, 7] = new Level(_easyBrixx, 80, 173);
            _levelArray[0, 8] = new Level(_easyBrixx, 80, 248);
            _levelArray[0, 9] = new Level(_easyBrixx, 80, 323);
            _levelArray[0, 10] = new Level(_easyBrixx, 80, 398);
            _levelArray[0, 11] = new Level(_easyBrixx, 100, 60);
            _levelArray[0, 12] = new Level(_easyBrixx, 100, 135);
            _levelArray[0, 13] = new Level(_easyBrixx, 100, 210);
            _levelArray[0, 14] = new Level(_easyBrixx, 100, 285);
            _levelArray[0, 15] = new Level(_easyBrixx, 100, 360);
            _levelArray[0, 16] = new Level(_easyBrixx, 100, 435);
            _levels[0] = 17;
        }
        private void InitializeBrix()
        {
            for (int i = 0; i < _levels[_level]; i++)
            {
                _brixArray[i] = new Rectangle(_levelArray[_level, i].Left, _levelArray[_level, i].Top, _levelArray[_level, i].Brick.Width, _levelArray[_level, i].Brick.Height);
            }
        }
        private void DrawBrix(Graphics g)
        {
            for (int i = 0; i < _levels[_level]; i++)
            {
                if (_levelArray[_level, i].Brick != _null)
                {
                    g.FillRectangle(_levelArray[_level, i].Brick.Color, _brixArray[i]);
                    g.DrawRectangle(Pens.Black, _brixArray[i]);
                }
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (ball.Left < ClientRectangle.Left)
            {
                _H = Math.Abs(_H);
            }
            else if (ball.Right > ClientRectangle.Right)
            {
                _H = -Math.Abs(_H);
            }
            else if (ball.Bottom > ClientRectangle.Bottom)
            {
                ball.Location = new Point(pad.Left + pad.Width / 2 - ball.Width / 2, 386);
                Random rand = new Random((int)System.DateTime.Now.Ticks);
                _H = rand.Next(-3, 3);
                _V = -3;
            }
            else if (ball.Top < ClientRectangle.Top)
            {
                _V = Math.Abs(_V);
            }
            else if (ball.Bottom > pad.Top && ball.Left + ball.Width / 2 > pad.Left && ball.Right - ball.Width / 2 < pad.Right)
            {
                _V = -Math.Abs(_V);
                int center = ball.Left + ball.Width / 2;
                if (center < pad.Left + pad.Width / 5)
                {
                    _H -= 2;
                }
                else if (center < pad.Left + (2 * pad.Width) / 5)
                {
                    _H -= 1;
                }
                else if (center < pad.Left + (3 * pad.Width) / 5)
                {
                }
                else if (center < pad.Left + (4 * pad.Width) / 5)
                {
                    _H += 1;
                }
                else
                {
                    _H += 2;
                }
            }
            bool v = false;
            bool h = false;
            for (int i = 0; i < _levels[_level]; i++)
            {
                if (ball.Top < _levelArray[_level, i].Bottom && ball.Right > _levelArray[_level, i].Left && ball.Left < _levelArray[_level, i].Right && ball.Bottom > _levelArray[_level, i].Top)
                {
                    _levelArray[_level, i].Brick.Hits++;
                    //if (_levelArray[_level, i].Brick.Hits == _levelArray[_level, i].Brick.MaxHits)
                    //{
                        if (Math.Abs(ball.Left - _levelArray[_level, i].Right) <= Math.Abs(_H) || Math.Abs(ball.Right - _levelArray[_level, i].Left) <= Math.Abs(_H))
                        {
                            h = true;
                        }
                        if (Math.Abs(ball.Top - _levelArray[_level, i].Bottom) <= Math.Abs(_V) || Math.Abs(ball.Bottom - _levelArray[_level, i].Top) <= Math.Abs(_V))
                        {
                            v = true;
                        }
                        _levelArray[_level, i] = new Level(_null, _levelArray[_level, i].Top, _levelArray[_level, i].Left);
                        _brixArray[i] = new Rectangle(_brixArray[i].Left - 1, _brixArray[i].Top - 1, _brixArray[i].Width + 2, _brixArray[i].Height + 2);
                        Invalidate(_brixArray[i]);
                        _levels[_level]--;
                    //}
                }
            }
            if (_levels[_level] == 0)
            {
                InitializeLevels();
                InitializeBrix();
                Invalidate();
            }
            if (v)
            {
                _V = -_V;
            }
            if (h)
            {
                _H = -_H;
            }
            ball.Left += _H;
            ball.Top += _V;
        }
        private void Brix_MouseMove(object sender, MouseEventArgs e)
        {
            pad.Left = e.X - pad.Width / 2;
        }
    }
}