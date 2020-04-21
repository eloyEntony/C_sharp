using System;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
/*Створити додаток "Анкета".
//На формі розмістити
//			текстове поле для вводу імені(перевіряти валідність імені)
//			стать(RadioButtons)
//			вік(label) або дата народження(DateTimePicker, MonthCalendar, TextBox, MaskedTextBox)
//			знання мов програмування С++, C# чи ін.(прапорці, CheckBox-и)
//	??? знання іноземної мови (тристановий! прапорець, CheckBox з властивістю ThreeStae = true)	
//			звіт(сформована анкета, Label або TextBox або ListBox)
//			кнопку для формування анкети(виведення  на форму)  BtnSave
//			PictureBox - в залежності від обраної статі - встановити відповідне зображення (PictureBox.Image = Image.FromFile(....))

//			****  Save to file  ??  --->  Serialization
//****  Load from file  ??  --> Serialization
//*/
namespace WF_06
{
	public partial class Questionnaire : Form
	{
		public Questionnaire()
		{
			InitializeComponent();
		}
		
		HumanList list = new HumanList();
		Human human = new Human();
		bool add = false;	

		private void rbMan_CheckedChanged(object sender, System.EventArgs e)
		{
			//human = new Human();
			RadioButton rb = sender as RadioButton;			
			human.Gender = rb.Text;

			if (rb.Text == "Man" )			
				pictureBox1.Image = Image.FromFile("../../img/man.png");			
			else if(rb.Text == "Woman" )
				pictureBox1.Image = Image.FromFile("../../img/woman.png");
			
		}
		BinaryFormatter formatter = new BinaryFormatter();
		private void btnSave_Click(object sender, System.EventArgs e)
		{
			human.Name = tbName.Text;			
			human.Birthday = dtBirthday.Value.Date;

			using (FileStream fs = new FileStream("people.dat", FileMode.Open, FileAccess.Write))
			{
				formatter.Serialize(fs, list);
				MessageBox.Show("OK!");
			}

			btnSave.Enabled = false;
		}

		private void btnLoad_Click(object sender, System.EventArgs e)
		{
			try
			{
				using (FileStream fs = new FileStream("people.dat", FileMode.Open, FileAccess.Read))
				{
					HumanList deserilizePeople = (HumanList)formatter.Deserialize(fs);
					
					listBox1.Items.Clear();
					foreach (Human item in deserilizePeople.humanList)
					{
						listBox1.Items.Add(item.Name);
						listBox1.Items.Add(item.Gender);
						listBox1.Items.Add(item.Birthday);
						listBox1.Items.Add(item.ShowList(listBox1));						
					}
				}
			}
			catch (Exception)
			{
				MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		private void button1_Click(object sender, System.EventArgs e)
		{ 
			if (!add){
				btnSave.Enabled = true;
				button1.Enabled = false;
			}
			
			listBox1.Items.Add(" Name     : \t\t" + tbName.Text);
			listBox1.Items.Add(" Gender   : \t\t" + human.Gender);
			listBox1.Items.Add(" Birthday : \t\t" + dtBirthday.Value.ToShortDateString());

			foreach (Control item in this.Controls){
				if (item is GroupBox){					
					GroupBox tmp = item as GroupBox;

					if (tmp.Text == "Programming languages"){
						listBox1.Items.Add(" Programming languages : ");
						foreach (var n in item.Controls){
							if (n is CheckBox){
								CheckBox tgh = n as CheckBox;
								if (tgh.Checked)
								{
									human.program.Add(tgh.Text);
									listBox1.Items.Add("\t\t\t" + tgh.Text);
								}									
							}
						}
					}
				}
			}

			foreach (Control item in this.Controls){
				if (item is GroupBox){
					GroupBox tmp = item as GroupBox;					

					if (tmp.Text == "Foreign language"){
						listBox1.Items.Add(" Foreign language : ");
						foreach (var t in item.Controls){
							if (t is CheckBox){
								CheckBox tm = t as CheckBox;
								if (tm.Checked)
								{
									human.language.Add(tm.Text);
									listBox1.Items.Add("\t\t\t" + tm.Text);
								}									
							}
						}
					}
				}
			}
			list.Add(human);		
		}
	

		private void tbName_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsLetter(e.KeyChar) && e.KeyChar != 8)
				e.Handled = true;
		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox1.Checked)
			{
				if(tbName.Text!=String.Empty)
					button1.Enabled = true;
				else
				{
					MessageBox.Show("Fields are not filled");
					checkBox1.Checked = false;
				}
			}
			else
				button1.Enabled = false;
				
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			tbName.Text = String.Empty;
			tbName.Focus();
			dtBirthday.Value = DateTime.Today;
			rbMan.Checked = false;
			rbWoman.Checked = false;
			checkBox1.Checked = false;
			pictureBox1.Image = Image.FromFile("../../img/0.png");

			foreach (Control item in this.Controls){
				if (item is GroupBox){
					GroupBox tmp = item as GroupBox;
					foreach (var t in item.Controls){
						if (t is CheckBox){
							CheckBox tm = t as CheckBox;
							tm.Checked = false;								
						}						
					}
				}
			}
		}

		private void btnCleanList_Click(object sender, EventArgs e)
		{
			listBox1.Items.Clear();
		}	
	}
}
