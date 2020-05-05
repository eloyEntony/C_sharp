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
    "Телефонний довідник"

Є дві форми. Одна батьківська, інша дочірня
На першій показати список контактів (ListBox)
Кнопки:
Додати контакт
Редагувати
Видалити - видаляє вибраний елемент із лістбокса
Очистити все - очищає лістбокс

Коли натискаємо кнопку "Додати контакт" - з'являється дочірня форма
з двома полями для вводу (textBox) імені та номеру телефона
Також є кнопка Додати
По клікові на конопку додати, з полів "збирається" об'єкт Contact, та додається в список контактів на батьківській формі

При виборі кнопки "Редагувати контакт" - відкривається форма (та сама, що і при додаванні),
 але вибраний контакт в лістбоксі має показатись в відповідних текстових полях дочірньої форми. Кнопка на формі набуває вигляд "Змінити"
Якщо були зміни - контакт має змінитись у відповідному item лістбокса на батьківській формі.
Якщо поля змінились, але користувач закрив дочірню форму - лістбокс на формі не змінюється

Передбачити наступні моменти:
- Можна редагувати та видаляти тільки вибраний елемент в лістбоксі
- поле для номеру не може містити літери та інші символи не по формату номера
- поле "Ім'я" не може бути порожнім
     
     */

namespace WF_12
{
    public partial class Telefon : Form
    {
        Contact contact = null;
        public Telefon()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            contact = new Contact();
            Telefon_2 addNew = new Telefon_2(contact, true);
            if(addNew.ShowDialog() == DialogResult.OK)
            {
                listBox1.Items.Add(contact);
            }
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            label1.Text = String.Empty;
            pictureBox1.Image = null;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1){
                MessageBox.Show("No select contact ...");
                return;
            }
               
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            label1.Text = String.Empty;
            pictureBox1.Image = null;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1){
                MessageBox.Show("No select contact...");
                return;
            }
            int i = listBox1.SelectedIndex;
            contact = (Contact)listBox1.Items[i];
            Telefon_2 edit = new Telefon_2(contact, false);
            edit.ShowDialog();
            listBox1.Items.RemoveAt(i);
            listBox1.Items.Insert(i, contact);
            listBox1.SelectedIndex = i;           
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex != -1)
            {
                contact = (Contact)listBox1.Items[listBox1.SelectedIndex];
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox1.Image = contact.Image;
                label1.Text = contact.Name;
            }
            
        }
    }
}
