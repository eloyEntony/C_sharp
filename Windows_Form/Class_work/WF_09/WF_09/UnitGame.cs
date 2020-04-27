using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

/*

ListBox with DataSource.
Створити програму для вибору персонажів гри з деякого "складу" персонажів у 2 команди(Білі та Чорні чи ін.).
На формі розмістити
    - 4 ListBox-и(склад, 1-а команда, 2-а команда, Перегляд команди)
    - кнопку для додавання персонажу зі стоку у команду
    - (вибір команди - через RadioButton або DomainUpDown)
    - кнопку для видалення персонажу з команди(в прикладі форми не намалювала) 
    - перегляд команди відбувається у ListBox4 відповідно до вибору команди з DomainUpDown (чи RadioButton по бажанню)
Дозволяти додавання певної кількості персонажів. Обмеження встановити за допомогою NumericUpDown.
Кожен персонаж є обєктом класу Unit. Створити у програмі список(списки) персонажів. Повязувати ListBox-и зі списками гравців.
Додати дві кнопки, для запису команд у файл (серіалізація об'єктів)
*/

namespace WF_09
{
    public partial class UnitGame : Form
    {
        List<Unit> Units;
        List<Unit> RedComand = new List<Unit>();
        List<Unit> BlueComand = new List<Unit>();
        int counter;

        public UnitGame()
        {
            InitializeComponent();

            Units = new List<Unit>
            {
               new Unit{ Name = "Swordsman"},
               new Unit{ Name = "Arrow archer"},
               new Unit{ Name = "Wizard"},
               new Unit{ Name = "Horseman"}
            };

            lbAll.DataSource = Units;
            lbAll.DisplayMember = "Name";
        }

        private void numUnitCounter_ValueChanged(object sender, EventArgs e)
        {
            counter = Convert.ToInt32(numUnitCounter.Value);            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Unit temp = lbAll.SelectedItem as Unit;

            if (btn.Name == btnAdd1.Name && RedComand.Count < counter)                           
                RedComand.Add(temp);                
         
            else if(btn.Name == btnAdd2.Name && BlueComand.Count < counter)            
                BlueComand.Add(temp);
                
            Reload_data_sourse();
        }

        private void Reload_data_sourse()
        {
            lbREDcomand.DataSource = null;
            lbREDcomand.DataSource = RedComand;
            lbREDcomand.DisplayMember = "Name";
            lbREDcomand.SelectedIndex = -1;
            lbREDcomand.SelectedItem = null;

            lbBLUEcomand.DataSource = null;
            lbBLUEcomand.DataSource = BlueComand;
            lbBLUEcomand.DisplayMember = "Name";
            lbBLUEcomand.SelectedIndex = -1;
            lbBLUEcomand.SelectedItem = null;
        }

        private void lbAll_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            switch (lbAll.SelectedIndex)
            {
                case 0:
                    pbUnit.Image = Image.FromFile("../../img/unit_1.png");
                    break;
                case 1:
                    pbUnit.Image = Image.FromFile("../../img/unit_2.png");
                    break;
                case 2:
                    pbUnit.Image = Image.FromFile("../../img/unit_3.png");
                    break;
                case 3:
                    pbUnit.Image = Image.FromFile("../../img/unit_4.png");
                    break;
                default:
                    break;
            }
        }

        private void btnDelete1_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if(btn.Name == btnDelete1.Name && lbREDcomand.SelectedIndex != -1)
            {
                int count1 = lbREDcomand.SelectedIndex;
                RedComand.RemoveAt(count1);
            }
            else if(btn.Name == btnDelete2.Name && lbBLUEcomand.SelectedIndex != -1)
            {
                int count2 = lbBLUEcomand.SelectedIndex;
                BlueComand.RemoveAt(count2);
            }
            Reload_data_sourse();
        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {            
            lbShowComand.DataSource = null;
            lbShowComand.DisplayMember = "Name";           

            switch (domainUpDown1.SelectedIndex)
            {
                case 0:                    
                    lbShowComand.DataSource = RedComand;                    
                    break;
                case 1:
                    lbShowComand.DataSource = BlueComand;                  
                    break;
            }            
        }

        private void btnSave1_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string file = "";
            List<Unit> tmpList = null;

            if (btn.Name == btnSave1.Name){
                file = "RED.xml";
                tmpList = RedComand;
            }
                
            else if (btn.Name == btnSave2.Name){
                file = "BLUE.xml";
                tmpList = BlueComand;
            }               

            XmlSerializer xml = new XmlSerializer(tmpList.GetType());  // (typeof(Event_List));
            using (Stream stream = new FileStream(file, FileMode.Create, FileAccess.Write))
            {
                xml.Serialize(stream, tmpList);
                MessageBox.Show("Completed!");
            }
        }
    }
}
