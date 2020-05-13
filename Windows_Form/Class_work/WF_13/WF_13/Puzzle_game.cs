using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WF_13
{
    public partial class Puzzle_game : Form
    {
        PictureBox[] puzzle;
        PictureBox[] puzzle2;
        PictureBox select;
        List<int> randHelp = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        Random rand = new Random();
        #region
        //int i = 0;

        //Image[] list = { Image.FromFile(@"../../img/1_01.png"),
        //                    Image.FromFile(@"../../img/1_02.png"),
        //                    Image.FromFile(@"../../img/1_03.png"),
        //                    Image.FromFile(@"../../img/1_04.png"),
        //                    Image.FromFile(@"../../img/1_05.png"),
        //                    Image.FromFile(@"../../img/1_06.png"),
        //                    Image.FromFile(@"../../img/1_07.png"),
        //                    Image.FromFile(@"../../img/1_08.png"),
        //                    Image.FromFile(@"../../img/1_09.png"),
        //    };
        #endregion //for mode2
        public Puzzle_game()
        {
            InitializeComponent();

            puzzle = new PictureBox[] { pictureBox1, pictureBox2, pictureBox3, pictureBox4,
            pictureBox5, pictureBox6, pictureBox7, pictureBox8, pictureBox9};

            puzzle2 = new PictureBox[] {pictureBox10, pictureBox11, pictureBox12, pictureBox13,
            pictureBox14, pictureBox15, pictureBox16, pictureBox17, pictureBox18};

            try
            {
                Create(puzzle);
            }
            catch
            {
                MessageBox.Show("Error");
            }


            foreach (var item in puzzle)
            {
                item.AllowDrop = true;
                item.DragDrop += PictureBox_DragDrop;
                item.DragEnter += PictureBox_DragEnter;
                item.MouseClick += PictureBox_MouseClick;
                item.MouseMove += PictureBox_MouseMove;
            }

            foreach (var item in puzzle2)
            {
                item.AllowDrop = true;
                item.DragDrop += PictureBox_DragDrop;
                item.DragEnter += PictureBox_DragEnter;
                item.MouseClick += PictureBox_MouseClick;
                item.MouseMove += PictureBox_MouseMove;
            }
            #region // mode2
            //pbMode2.AllowDrop = true;
            //pbMode2.DragDrop += PictureBox_DragDrop;
            //pbMode2.DragEnter += PictureBox_DragEnter;
            //pbMode2.MouseClick += PictureBox_MouseClick;
            //pbMode2.MouseMove += PictureBox_MouseMove;
            #endregion
        }

        private void Create(PictureBox[] boxes)
        {
            foreach (var item in boxes)
            {
                int tmp = Rand();
                item.Image = Image.FromFile(@"../../img/1_0" + tmp + ".png");
            }
        }

        private int Rand()
        {
            bool exit = false;
            int tmp = 0;
            while (!exit)
            {
                tmp = rand.Next(1, 10);
                for (int i = 0; i < randHelp.Count; i++)
                {
                    if (tmp == randHelp[i])
                    {
                        randHelp.RemoveAt(i);
                        exit = true;
                    }
                }
            }
            return tmp;
        }

        private void PictureBox_DragDrop(object sender, DragEventArgs e)
        {
            PictureBox target = sender as PictureBox;
            if (e.Data.GetDataPresent(typeof(PictureBox)))
            {
                PictureBox sourse = (PictureBox)e.Data.GetData((typeof(PictureBox)));
                if (sourse != target)
                {
                    SwapImages(sourse, target);
                    select = null;
                    SelectBox(target);
                    return;
                }
            }
        }

        private void SelectBox(PictureBox target)
        {
            if (select != target)
                select = target;
            else
                select = null;
        }

        private void SwapImages(PictureBox source, PictureBox target)
        {
            if ((source.Image == null && target.Image == null))
                return;

            Image tmp = target.Image;
            target.Image = source.Image;
            source.Image = tmp;
        }

        private void PictureBox_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void PictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            SelectBox((PictureBox)sender);
        }

        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                PictureBox pb = sender as PictureBox;
                if (pb.Image != null)
                {
                    pb.DoDragDrop(pb, DragDropEffects.Move);
                }
            }
        }
        #region //hard mod have problem
        //private void toolStripMenuItem2_Click(object sender, EventArgs e)
        //{
        //    foreach (var item in puzzle)
        //    {
        //        item.Visible = true;
        //        item.Image = null;
        //    }

        //    pbMode2.Visible = false;
        //    //Create(puzzle);
        //    foreach (var item in puzzle2)
        //    {
        //        item.Image = null;
        //    }            

        //    i = 0;
        //}

        //private void toolStripMenuItem3_Click(object sender, EventArgs e)
        //{
        //    foreach (var item in puzzle)
        //    {
        //        item.Visible = false;
        //    }
        //    foreach (var item in puzzle2)
        //    {
        //        item.Image = null;
        //    }            
        //    pbMode2.Visible = true;
        //    imageList1.Images.AddRange(list);
        //    pbMode2.Image = imageList1.Images[i];
        //    i++;
        //}     
        //private void pbMode2_MouseMove(object sender, MouseEventArgs e)
        //{
        //    if (e.Button == MouseButtons.Left)
        //    {
        //        PictureBox pb = sender as PictureBox;
        //        if (pb.Image != null)
        //        {
        //            pb.DoDragDrop(pb, DragDropEffects.Move);
        //            if (i == 9)
        //                return;                    
        //            pbMode2.Image = imageList1.Images[i++];

        //        }
        //    }
        //}
        #endregion
    }
}
