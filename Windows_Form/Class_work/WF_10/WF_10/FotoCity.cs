using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 Створити застосування, яке дозволяє обрати місто із списку міст(ComboBox)
При виборі певного міста у PictureBox виводити зображення міста(фото).
	Розмістити на формі TrackBar або HScrollBar(VScrollBar) для перегляду інших фото міста.

Інформацію про зроблений вибір показувати на рядку стану( Місто, Кількість переглядів).

Додати елемент  LinkedLabel або Label(IsLink = true)на рядку стану. 
При виборі певного міста з'являється на  LinkedLabel(Label) назва відповідного
інтернет-ресурсу. При кліку на LinkedLabel, переходити на відповідний ресурс.

!!! Для розвязку задачі визначити  клас для збереження інформації про місто(City)
	назва,
	адреса інтернет -ресурсу,
	список рядків(шляхів до файлів з фото міста)
Створити у програмі список міст(Рівне, Київ та ін.).
Заповнити список даними "вручну" або  отримати з створеного раніше текстового файлу.

  */

namespace WF_10
{
    public partial class FotoCity : Form
    {     
        ImageList tmpImageList;
        string url;
        City town1;
        City town2;
        City town3;
        City town4;

        Image[] c1 = { Image.FromFile(@"../../img/h01.jpg"),
                       Image.FromFile(@"../../img/h02.jpg"),
                       Image.FromFile(@"../../img/h03.jpg"),
                       Image.FromFile(@"../../img/h04.jpg"),
                       Image.FromFile(@"../../img/h05.jpg"),
                       Image.FromFile(@"../../img/h06.jpg"),
        };
        Image[] c2 = { Image.FromFile(@"../../img/n01.jpg"),
                       Image.FromFile(@"../../img/n02.jpg"),
                       Image.FromFile(@"../../img/n03.jpg"),
                       Image.FromFile(@"../../img/n04.jpg"),
                       Image.FromFile(@"../../img/n05.jpg"),
                       Image.FromFile(@"../../img/n06.jpg"),
        };
        Image[] c3 = { Image.FromFile(@"../../img/p01.jpg"),
                       Image.FromFile(@"../../img/p02.jpg"),
                       Image.FromFile(@"../../img/p03.jpg"),
                       Image.FromFile(@"../../img/p04.jpg"),
                       Image.FromFile(@"../../img/p05.jpg"),
                       Image.FromFile(@"../../img/p06.jpg"),
        };
        Image[] c4 = { Image.FromFile(@"../../img/r01.jpg"),
                       Image.FromFile(@"../../img/r02.jpg"),
                       Image.FromFile(@"../../img/r03.jpg"),
                       Image.FromFile(@"../../img/r04.jpg"),
                       Image.FromFile(@"../../img/r05.jpg"),
                       Image.FromFile(@"../../img/r06.jpg"),
        };


        public FotoCity()
        {
            InitializeComponent();            
            vScrollBar1.LargeChange = vScrollBar1.SmallChange = 1;
            vScrollBar1.Maximum = 5;
            vScrollBar1.Value = 0;            
        }
        
        private void FotoCity_Load(object sender, EventArgs e)
        {
            town1 = new City
            {
                Name = comboBox1.Items[0].ToString(),
                Url = "https://34travel.me/post/hongkong",
                Counter = 1,
                images = c1
            };
            town2 = new City {
                Name = comboBox1.Items[1].ToString(),
                Url = "https://34travel.me/post/nyc",
                Counter = 1,
                images = c2
            };
            town3 = new City{
                Name = comboBox1.Items[2].ToString(),
                Url = "https://34travel.me/post/parizh",
                Counter = 1,
                images = c3
            };
            town4 = new City{
                Name = comboBox1.Items[3].ToString(),
                Url = "https://34travel.me/post/rim",
                Counter = 1,
                images = c4
            };

        }        
        
        private void vScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            int j = vScrollBar1.Value;
            if (j < tmpImageList.Images.Count)                
                pictureBox1.Image = tmpImageList.Images[j];            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
           
            ImageList ff = new ImageList();
            ff.ColorDepth = ColorDepth.Depth32Bit; // створюю імедж ліст з масива картинок обєкту класа
            ff.ImageSize = new Size(256,180);          

            int count = 1;

            switch (cb.SelectedIndex)
            {
                case 0:
                    ff.Images.AddRange(town1.images);
                    url = town1.Url;
                    count = town1.Counter++;
                    break;
                case 1:
                    ff.Images.AddRange(town2.images);
                    url = town2.Url;
                    count = town2.Counter++;
                    break;
                case 2:
                    ff.Images.AddRange(town3.images);
                    url = town3.Url;
                    count = town3.Counter++;
                    break;
                case 3:
                    ff.Images.AddRange(town4.images);
                    url = town4.Url;
                    count = town4.Counter++;
                    break;
            }

            toolStripStatusLabel1.Text = cb.SelectedItem.ToString();

            tmpImageList = ff;
            pictureBox1.Image = tmpImageList.Images[0];
            vScrollBar1.Value = 0;   
            toolStripStatusLabel2.Text = count.ToString();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            Process.Start(url);           
        }

        
    }
}
