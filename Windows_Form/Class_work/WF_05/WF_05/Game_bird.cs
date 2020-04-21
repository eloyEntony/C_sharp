using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 [12:45] Присяжнюк Валентина Романівна
    
1 - лівий верхній куток
2 - правий верх куток
3 низ право
4 низ ліво


вихід за межі - з'являється з протилежної сторони (як у змійці)
обмеження по масштабу - не менше певного фіксованого розміру
                        не більше розміру вікна
     
     */

namespace WF_05
{
    public partial class Game_bird : Form
    {
        const string iconPath = "../../bird.ico";
        int size = 64;
        int x, y;
        Icon icon = new Icon(iconPath);
        const int smallStep = 5;
        const int largeStep = 50;

        public Game_bird()
        {
            InitializeComponent();
            x = ClientSize.Width / 2 - size / 2;
            y = ClientSize.Height / 2 - size / 2;
        }

        private void Game_bird_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawIcon(icon, new Rectangle(x, y, size, size));
        }

        private void Game_bird_KeyDown_1(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    if (e.Alt)
                        y -= largeStep;
                    else
                        y -= smallStep;
                    if (y <= 0)
                    {
                        y = ClientSize.Height;
                    }

                    break;
                case Keys.Down:
                    if (e.Alt)
                        y += largeStep;
                    else
                        y += smallStep;

                    if (y >= ClientSize.Height)
                    {
                        y = 0;
                    }
                    break;
                case Keys.Left:
                    if (e.Alt)
                        x -= largeStep;
                    else
                        x -= smallStep;
                    if (x <=0)
                    {
                        x = ClientSize.Width;
                    }
                    break;
                case Keys.Right:
                    if (e.Alt)
                        x += largeStep;
                    else
                        x += smallStep;

                    if (x >= ClientSize.Width)
                    {
                        x = 0;
                    }

                    break;

                case Keys.Oemplus:                    
                    if (size >= ClientSize.Height)
                    {
                        size = ClientSize.Height;
                    }
                    size += smallStep;                    
                    break;

                case Keys.OemMinus:
                    if (size <= 64)
                    {
                        size = 64;                            
                    }
                    size -= smallStep;
                    break;

                case Keys.Escape:
                    this.Close();
                    break;
                case Keys.D1:
                    x = y = 0;
                    break;
                case Keys.D2:
                    x = ClientSize.Width - size;
                    y = 0;
                    break;
                case Keys.D3:
                    x = ClientSize.Width - size;
                    y = ClientSize.Height -size;
                    break;
                case Keys.D4:
                    x = 0;
                    y = ClientSize.Height - size;
                    break;

            }
            this.Refresh();
        }        
    }
}
