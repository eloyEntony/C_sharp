using System;
using System.Windows.Forms;

/*
 Написати програму «Калькулятор»
__________________________________________________________________________________
Форма калькулятора повинна містити: 
        10 кнопок з цифрами (0..9), 
        кнопку десяткової коми, 
        кнопку зміни знаку 
        чотири кнопки арифметичних дій
        кнопку «дорівнює»
        кнопку видалення останнього символу (BackSpace)
        кнопку очищення дисплею
        кнопку повного очищення
        TextBox, котрий відіграє роль дисплею

Калькулятор може перебувати у трьох режимах: 
        режим введення першого операнда
        режим введення другого операнда
        режим відображення результату.

Режим введення першого операнда
        Калькулятор переходить в цей режим одразу після запуску, а також після натискання кнопки очищення дисплею.
        Дисплей містить символ 0, котрий буде замінений першою натисненою цифрою. 
        Якщо першою буде натиснена кнопки десяткової коми -- вона додається до вмісту одразу після нуля.
        Подальше натискання цифрових кнопок доповнює вміст дисплею -- цифра, що відповідає натисненій кнопці, дописується в кінець. 
        При натисканні кнопки десяткової коми -- вона додається до вмісту лише, якщо її там досі не було (тобто, кома може бути лише одна).
        Натискання кнопки зміни знаку у будь-який момент змінює знак на протилежний (можна повторювати безліч разів)

Режим введення другого операнда
        Калькулятор переходить в цей режим з режиму введення першого операнда або режиму відображення результату після натискання кнопки арифметичної дії.
        Значення, що містилося на дисплеї десь запам'ятовується, натомість на дисплеї відображається 0.
        Подальша поведінка -- як у режимі введення першого операнда, з однією відмінністю -- натискання кнопки "дорівнює" обчислює результат дії, 
        а натискання кнопки арифметичної дії обчислює результат попередньої дії, запам'ятовує його як перший операнд нової дії і переводить калькулятор
        знову у режим введення другого операнда.

Режим відображення результату 
        Калькулятор переходить в цей режим після натискання кнопки "дорівнює", або обчислення тригонометричної функції (див. нижче).
        У цьому режимі при натисканні цифрових кнопок чи  кнопки десяткової коми дисплей очищається і калькулятор переходить в режим введення операнда та вводиться символ, 
        що відповідає натисненій кнопці. 
        Натискання кнопки зміни знаку змінює знак на протилежний (можна повторювати безліч разів) але не переводить калькулятор у режим введення операнда (тобто, не можна дописати цифри)

        Слід передбачити, щоби вміст «дисплея» змінювався лише "в кінці", тобто, нові цифри додавалися в кінець наявного тексту і при 
        натисканні BackSpace видалалася остання цифра. Крім того, «дисплей» може містити лише цифри, кому і знак "мінус".
        Це -- умова на 10.

        калькулятор має також обробляти натискання на клавіші:
        клавіші  «з цифрами», «крапку» та «кому», 
        клавіші з символами арифметичних операцій, 
        клавішу «Enter» для «дорівнює»
        клавішу «F9» для зміни знаку.
     */

namespace WF_05_calc
{
    public partial class Сalculator : Form
    {
        double operant_1 = 0;
        double operant_2 = 0;
        double result = 0;
        bool znak = true;
        bool tochka = false;
        int counter;
        public Сalculator()
        {
            InitializeComponent();
            tbText.Focus();
        }
      
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.NumPad1:
                    btn1_Click(null, null);
                    break;
                case Keys.NumPad2:
                    btn2_Click(null, null);
                    break;
                case Keys.NumPad3:
                    button3_Click(null, null);
                    break;
                case Keys.NumPad4:
                    button4_Click(null, null);
                    break;
                case Keys.NumPad5:
                    button5_Click(null, null);
                    break;
                case Keys.NumPad6:
                    button6_Click(null, null);
                    break;
                case Keys.NumPad7:
                    button7_Click(null, null);
                    break;
                case Keys.NumPad8:
                    button8_Click(null, null);
                    break;
                case Keys.NumPad9:
                    button9_Click(null, null);
                    break;
                case Keys.NumPad0:
                    button0_Click(null, null);
                    break;
                case Keys.Add:
                    btnPlus_Click(null, null);
                    break;
                case Keys.Divide:
                    btnDil_Click(null, null);
                    break;
                case Keys.Multiply:
                    btnMnog_Click(null, null);
                    break;
                case Keys.Return:                    
                    btnRES_Click(null, null);
                    break;
                case Keys.Back:
                    btnClearDigit_Click(null, null);
                    break;
                case Keys.Delete:
                    btnClear_Click(null, null);
                    break;
                case Keys.F9:
                    btnPlus_Minus_Click(null, null);
                    break;
            }
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            operant_1 = double.Parse(tbText.Text);
            tbText.Text = "0";
            counter = 1;
            lbvuraz.Text = operant_1 + " + ";
            znak = true;
            tochka = false;
        }
        private void btnMinus_Click(object sender, EventArgs e)
        {
            operant_1 = double.Parse(tbText.Text);
            tbText.Text = "0";
            counter = 2;
            lbvuraz.Text = operant_1 + " - ";
            znak = true;
            tochka = false;
        }
        private void btnMnog_Click(object sender, EventArgs e)
        {
            operant_1 = double.Parse(tbText.Text);
            tbText.Text = "0";
            counter = 3;
            lbvuraz.Text = operant_1 + " * ";
            znak = true;
            tochka = false;
        }
        private void btnDil_Click(object sender, EventArgs e)
        {
            operant_1 = double.Parse(tbText.Text);
            tbText.Text = "0";
            counter = 4;
            lbvuraz.Text = operant_1 + " / ";
            znak = true;
            tochka = false;
        }

        private void btnKrapka_Click(object sender, EventArgs e)
        {
            if (tbText.Text == String.Empty && tochka)
                tbText.Text += "0,";
            else if (!tochka)
                tbText.Text += ",";

            tochka = true;
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '-')
            {
                btnMinus_Click(null, null);
            }
            if (e.KeyChar == '.' && tochka == false)
            {
                btnKrapka_Click(null, null);
            }
            if (result != 0 && (e.KeyChar == '/' || e.KeyChar == '*' || e.KeyChar == '+' || e.KeyChar == '-'))
            {
                operant_1 = result;
                tbText.Text = "0";
                result = 0;
            }
            else if (result != 0 && (char.IsDigit(e.KeyChar) || e.KeyChar == '.')) {                
                result = 0;
                operant_1 = 0;
                operant_2 = 0;
                lbvuraz.Text = null;
                tbText.Text = "0";
                //MessageBox.Show("Новий приклад");                
                //e.Handled = true;
            }
        }

        private void btnPlus_Minus_Click(object sender, EventArgs e)
        {
            if (znak == true)
            {
                tbText.Text = "-" + tbText.Text;
                znak = false;
            }
            else if (znak == false)
            {
                tbText.Text = tbText.Text.Replace("-", "");
                znak = true;
            }
        }

        private void btnRES_Click(object sender, EventArgs e)
        {            
            Calc();           
        }

        private void Calc()
        {
            operant_2 = float.Parse(tbText.Text);
            lbvuraz.Text += operant_2 + " = ";
            switch (counter)
            {
                case 1:                    
                    result = operant_1 + operant_2;
                    tbText.Text = result.ToString();
                    break;
                case 2:
                    result = operant_1 - operant_2;
                    tbText.Text = result.ToString();
                    break;
                case 3:
                    result = operant_1 * operant_2;
                    tbText.Text = result.ToString();
                    break;
                case 4:
                    if(operant_2 == 0)
                    {
                        result = 0;
                        lbvuraz.Text += "ERROR";
                        MessageBox.Show("Division for 0!");
                        lbvuraz.Text = null;
                        return;
                    }
                    result = operant_1 / operant_2;
                    tbText.Text = result.ToString();
                    break;
            }
            operant_1 = result;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbText.Text = "0";
            lbvuraz.Text = null;            
            operant_1 = 0;
            operant_2 = 0;
            result = 0;
            counter = 0;
        }

        private void btnClearDigit_Click(object sender, EventArgs e)
        {
            int lenght = tbText.Text.Length - 1;
            string text = tbText.Text;
            tbText.Clear();
            for (int i = 0; i < lenght; i++)
            {
                tbText.Text = tbText.Text + text[i];
            }
            if (tbText.Text == String.Empty)
            {
                tbText.Text = "0";
            }


        }
        private void Check()
        {
            if (tbText.Text == "0")
                tbText.Text = String.Empty;
        }

        #region
        private void btn1_Click(object sender, EventArgs e)
        {
            Check();
            tbText.Text += 1;
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            Check();
            tbText.Text += 2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Check();
            tbText.Text += 3;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Check();
            tbText.Text += 4;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Check();
            tbText.Text += 5;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Check();
            tbText.Text += 6;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Check();
            tbText.Text += 7;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Check();
            tbText.Text += 8;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Check();
            tbText.Text += 9;
        }

        private void button0_Click(object sender, EventArgs e)
        {
            Check();
            tbText.Text += 0;
        }

        #endregion

        
    }
}
