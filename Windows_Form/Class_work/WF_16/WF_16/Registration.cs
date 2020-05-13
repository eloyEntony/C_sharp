using System;
using System.ComponentModel;
using System.Windows.Forms;

/*
 Створити форму для реєстрації у соцмережі з текстовими полями
	Ім"я(тільки букви)
	Прізвище(тільки букви)
	Рік народження(з віку 12 років вважати валідно)
	Телефон
та кнопкою Зареєеструвати.
Перевіряти валідність введених даних.
Використати у програмі ErrorProvider для сигналізації про помилки у введених даних.
     */

namespace WF_16
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }
        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (String.IsNullOrEmpty(textBox.Text))
            {
                e.Cancel = true;
                textBox.Focus();
                errorProvider1.SetError(textBox, "Empty field");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void dateTimePicker1_Validating(object sender, CancelEventArgs e)
        {
            DateTimePicker data = sender as DateTimePicker;

            if ((DateTime.Now.Year - data.Value.Year) <= 12)
            {
                e.Cancel = true;
                errorProvider1.SetError(data, "Age cannot be less than 12 years");
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                pictureBox1.Visible = false;
                panelDone.Visible = true;
            }

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
