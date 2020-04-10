using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

/*    
Анкета:

Поля для вводу Імені, Прізвище, Хобі
               Комбобокс - для статі
		DateTimePicker - Дата народження
		Label - на лейбу розраховується автоматично вік студента

Кнопка - Зберегти - серіалізує об'єкт Студента в файл
Кнопка - Завантажити - десеріалізує збереженого студента із файла (Бажано останнього)
Кнопка - Очистити - очищає всі текстові поля
Після десеріалізації "розкидати" по елементам керування відповідні дані (Дата народження, на текстбокси ім'я, прізвище, хобі )...

ЗАУВАЖЕННЯ***
Обов'язково використати клас Student
     */

namespace WF_04
{
    public partial class Form1 : Form
    {
        string fullPath;
        public Form1()
        {
            InitializeComponent();
            tbName.Focus();
        }
        private void btnSaveXml_Click(object sender, EventArgs e)
        {            
            Student student = new Student
            {
                Name = tbName.Text,
                Surname = tbSurname.Text,
                Birthday = dtBirsday.Value.Date,
                Gender = cbGender.SelectedIndex,
                Hobby = tbHobby.Text
            };

            listBox1.Items.Add(student);
            Save_to_XML(student);
        }

        private void Save_to_XML(Student s)
        {
            string file = Path.Combine(fullPath, tbName.Text + ".xml");
            XmlSerializer xml = new XmlSerializer(typeof(Student));

            using (Stream stream = new FileStream(file, FileMode.Create, FileAccess.Write))
            {
                xml.Serialize(stream, s);
            }
            MessageBox.Show("Completed!");
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            string tmp = "";
            string[] fullfilesPath = Directory.GetFiles(fullPath, "*.xml"); //пошук всіх xml файлів в папці

            try
            {
                foreach (var item in fullfilesPath)
                {
                    DateTime time = Convert.ToDateTime(File.GetCreationTime(item));
                    foreach (var i in fullfilesPath)
                    {
                        DateTime nextTime = Convert.ToDateTime(File.GetCreationTime(i)); //пошук останього файлу
                        if (time > nextTime || time == nextTime)
                            tmp = item;
                    }
                }

                listBox1.Items.Add(tmp);
                Student s;
                XmlSerializer xml = new XmlSerializer(typeof(Student));

                using (Stream stream = new FileStream(tmp, FileMode.Open, FileAccess.Read))
                {
                    // Десеріалізація - отримуємо ОБ'ЄКТ з файла                
                    s = (Student)xml.Deserialize(stream);

                    tbName.Text = s.Name;
                    tbSurname.Text = s.Surname;
                    dtBirsday.Value = s.Birthday;
                    tbHobby.Text = s.Hobby;
                    cbGender.SelectedIndex = s.Gender;
                }
                MessageBox.Show("Completed!");
                listBox1.Items.Add(s);
            }
            catch (ArgumentException exc) {             
                MessageBox.Show("Create a survey", "No profiles found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
                
                      
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbName.Text = String.Empty;
            tbName.Focus();
            tbHobby.Text = String.Empty;
            tbSurname.Text = String.Empty;
            cbGender.SelectedIndex = -1;
            dtBirsday.Value = DateTime.Now;
            listBox1.Items.Clear();
        }

        private void dtBirsday_ValueChanged(object sender, EventArgs e)
        {
            label6.Text = "YEARS : " + Convert.ToString(DateTime.Today.Year - dtBirsday.Value.Year);
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); //стрюю папку на робочому столі для файлів
            string folderName = "Это новая папка";
            fullPath = Path.Combine(desktopPath, folderName);
            Directory.CreateDirectory(fullPath);
        }
    }
}
