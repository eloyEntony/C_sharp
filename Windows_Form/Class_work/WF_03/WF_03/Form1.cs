using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;


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
        //List<Event> myEvents = new List<Event>();
        public Event_planer()
        {
            InitializeComponent();
            eventBox.Text = String.Empty;
            dateTime.Value = DateTime.Today.AddDays(1);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(dateTime.Value < DateTime.Today)
            {
                MessageBox.Show("Incorrect date. Try again");
            }
            else
            {
                listBox.Items.Add(eventBox.Text);
                listBox.Items.Add(eventBox2.Text);
                listBox.Items.Add(dateTime.Value);
                listBox.Items.Add(priorityBox.Text);
                //listBox.Items.Add("---------------------");

                Event tmp = new Event(eventBox.Text, eventBox2.Text, dateTime.Value, priorityBox.Text);
                //myEvents.Add(tmp);
                Event.eventList.Add(tmp);

                eventBox.Text = String.Empty;
                eventBox2.Text = String.Empty;
                eventBox.Focus();
            }
            
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            listBox.Items.Clear();
        }

        private void btnAdd_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(btnAdd.Text))
            {
                this.btnAdd.Focus();
            }            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string path = @"C:\Users\Anton\Cod\C#\Windows_Form\Class_work\WF_03\WF_03\data.xml";

            XDocument xmlDocument = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement("Events", from events in Event.GetEvent()
                                         select new XElement("Event", events.Title,
                                         new XElement("EventPlace", events.Event_place),
                                         new XElement("Date", events.Date.ToString()),
                                         new XElement("Priority", events.Priority))

                )) ;
            xmlDocument.Save(path);
        }
    }
}
