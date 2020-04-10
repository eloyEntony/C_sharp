using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization;


/*
    Створити програму "Планування подій(справ)"(Version 1.0).
На головній формі розмістити 
 	- текстове поле для введення назви події(справи), обов'язкове поле
	- текстове поле для місця події(не обов'язкове)
	- DateTimePicker або MonthCalendar для вибору дати події(по замовчуванню на завтра)
	- текстове поле для вибору пріоритут події(встановити властивість для можливості автозаповнення :високий, середній, низький), по замовчуванню - середній
	- кнопку Додати, що додає відповідну подію у  статичний текст( чи ListBox: listbox1.Items.Add() - доповнення списку listbox1)
	- кнопку очищення списку подій
	- кнопку збереження плану подій у текстовому(xml чи json) файлі (з назвою, що містить поточну дату).
Зауваження. Не дозволяти планування на "вчора"
При розв"язуванні задачі визначити клас Подія(Event) з полями назва, дата-час, пріоритет, місце події.
Визначити також клас для серіалізації( десеріалізації) списку подій.
     
     */

namespace WF_03
{
    public partial class Event_planer : Form
    {
        EventList list = new EventList();
        public Event_planer()
        {
            InitializeComponent();
            eventBox.Text = String.Empty;
            dateTime.Value = DateTime.Today.AddDays(1);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Event newEvent = new Event
            {
                Title = eventBox.Text,
                Event_place = eventBox2.Text,
                Date = dateTime.Value,
                Priority = priorityBox.Text
            };
            list.AddEvent(newEvent);
            listBox.Items.Add(newEvent);
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            listBox.Items.Clear();
            list.Clear();
            
        }
        private void btnCleanEvent_Click(object sender, EventArgs e)
        {
            eventBox.Text = String.Empty;
            eventBox2.Text = String.Empty;
            dateTime.Value = DateTime.Today.AddDays(1);
            priorityBox.Text = "medium";
            eventBox.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string file = dateTime.Value.ToShortDateString() + ".xml";
            XmlSerializer xml = new XmlSerializer(list.GetType());  // typeof(EventList)
            using (Stream stream = new FileStream(file, FileMode.Create, FileAccess.Write))
            {
                xml.Serialize(stream, list);
            }
            MessageBox.Show("Completed!");
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(EventList));
                string file = dateTime.Value.ToShortDateString() + ".xml";
                using (Stream stream = new FileStream(file, FileMode.Open, FileAccess.Read))
                {
                    
                    list = (EventList)xml.Deserialize(stream);
                }                
                ShowInListBox();
            }
            catch (Exception)
            {
                MessageBox.Show("There are no events on this day", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }            
        }

        private void ShowInListBox()
        {
            listBox.Items.Clear();
            foreach (var item in list.Events)
            {
                listBox.Items.Add(item);
            }
        }

        private void btnJson_Click(object sender, EventArgs e)
        {
            list.SaveToJson();
            MessageBox.Show("Completed!");
        }

        
    }
}
