using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

/*Створити програму "Планування подій(справ) 2.0".

На головній формі розмістити 

 	    - текстове поле для введення назви події(справи)
	    - DateTimePicker або MonthCalendar для вибору дати події
	    - тристановий прапорець(CheckBox) для вибору пріорітету події(високий, середній, низький)
	- кнопку Додати, що додає відповідну подію у  listbox( бажано, щоб події впорядковувалися по даті)	
	    - кнопку очищення списку подій
	    - кнопку для видалення виділених подій у списку подій
	- кнопку для  пошуку події у списку за назвою(переміщати курсор на подію у списку: SetSelected(int index,bool value)	
	- кнопку для  редагування події(якщо обрано декілька - редагувати першу). 
    При натисненні на кнопці Редагувати форма збільшується у розмірі або(і) зявляється група з елементів для редагування(GroupBox, Panel).
	Дозволяти редагувати назву події, дату події, пріоритет.	  
	    - кнопку збереження плану подій у текстовому файлі(xml краще) з назвою, що містить поточну дату.

        Зауваження. Не дозволяти планування на "вчора"
    
     */

namespace WF_07
{
    public partial class Planer : Form
    {
        Event_List list = new Event_List();
        Event newEvent;
        public Planer()
        {
            InitializeComponent();
            lbEvent_SelectedIndexChanged(null, null);
        }

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            newEvent = new Event();
            newEvent.Name = tbEvent.Text;
            newEvent.Date = dateEvent.SelectionStart;
            foreach (int index in cbListPriority.CheckedIndices)
                newEvent.Priority += cbListPriority.Items[index];
           

            list.AddEvent(newEvent);
            lbEvent.Items.Add(newEvent);
        }
        

        private void btnCleanList_Click(object sender, System.EventArgs e)
        {
            lbEvent.Items.Clear();
            list.Clear();
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            string file = dateEvent.SelectionStart.ToShortDateString() + ".xml";
            XmlSerializer xml = new XmlSerializer(list.GetType());  // (typeof(Event_List));
            using (Stream stream = new FileStream(file, FileMode.Create, FileAccess.Write))
            {
                xml.Serialize(stream, list);
                MessageBox.Show("Completed!");
            }
                      
        }

        private void lbEvent_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            label4.Text = "";
            if (lbEvent.SelectedIndices.Count == 0)
            {
                label4.Text = "Не обрано жодного елемента";
                return;
            }
            foreach (int index in lbEvent.SelectedIndices) 
            {
                label4.Text += $"Обрано елемент {lbEvent.Items[index]} з індексом: {index}\n";
            }
        }

        private void btnDelete_Click(object sender, System.EventArgs e)
        {
            while (lbEvent.SelectedIndices.Count != 0)
                lbEvent.Items.RemoveAt(lbEvent.SelectedIndices[0]); 
        }

        
    }
}
