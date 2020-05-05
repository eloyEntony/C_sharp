using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WF_08
{
    public partial class Gas_station : Form
    {
        Gas gas = new Gas();
        Product product;
        List<Product> products = new List<Product>();
        public Gas_station()
        {
            InitializeComponent();
        }
        private void radioButton1_CheckedChanged(object sender, System.EventArgs e)
        {
            RadioButton rb = sender as RadioButton;

            if (rb.Text == "L")
            {
                tbSumPrice.Enabled = false;
                numLiter.Enabled = true;
                numLiter.Value = 0;
            }
            else if(rb.Text == "$")
            {
                numLiter.Enabled = false;
                tbSumPrice.Enabled = true;
                tbSumPrice.Text = "0";
            }   
        }
        private void cbGas_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (cbGas.SelectedItem == null)
                return;

            radioButton1.Enabled = true;
            radioButton2.Enabled = true;
            gas.Name = cbGas.SelectedItem.ToString();

            switch (gas.Name)
            {
                case "A-92":
                    gas.Price = 0.86f;
                    break;
                case "A-95":
                    gas.Price = 0.90f;
                    break;               
                case "A-98":
                    gas.Price = 1.01f;
                    break;
                case "Disel":
                    gas.Price = 0.88f;
                    break;
                case "Gas":
                    gas.Price = 0.34f;
                    break;               
            }            
        }
        private void numLiter_ValueChanged(object sender, System.EventArgs e)
        {
            gas.Litr = (float)numLiter.Value;
            label7.Text = gas.Name + Environment.NewLine 
                + gas.Sum().ToString() + " $   " + Environment.NewLine
                + gas.Litr +" L";

            //tbSumPrice.Text = ((float)gas.Sum()).ToString();
        }
        private void tbSumPrice_TextChanged(object sender, EventArgs e)
        {            
            if (String.IsNullOrWhiteSpace(tbSumPrice.Text))            
                return;

            int money = int.Parse(tbSumPrice.Text);
            float tmp = (float) money / gas.Price;
            numLiter.Maximum = 1000000000;
            gas.Litr = tmp;
            label7.Text = gas.Name + Environment.NewLine 
                + money.ToString() + "  $" +Environment.NewLine
                + tmp + " L";            
        }
        private void tbSumPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox tmp = sender as CheckBox;
            if (tmp.Checked){
                switch (tmp.Text)
                {
                    case "Coffee":
                        numCoffee.Enabled = true;
                        break;
                    case "Hot-Dog":
                        numHotDog.Enabled = true;
                        break;
                    case "Tea":
                        numTea.Enabled = true;                        
                        break;
                    case "Coca-cola":
                        numCola.Enabled = true;
                        break;
                }
            }
            else{
                switch (tmp.Text)
                {
                    case "Coffee":
                        numCoffee.Enabled = false;
                        numCoffee.Value = 1;
                        break;
                    case "Hot-Dog":
                        numHotDog.Enabled = false;
                        numHotDog.Value = 1;
                        break;
                    case "Tea":
                        numTea.Enabled = false;
                        numTea.Value = 1;
                        break;
                    case "Coca-cola":
                        numCola.Enabled = false;
                        numTea.Value = 1;
                        break;
                }
            }            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            label8.Text = "";
            products.Clear();

            foreach (var item in this.Controls){
                if(item is GroupBox){
                    GroupBox tmp = item as GroupBox;
                    if(tmp.Text == "Cafe"){
                        foreach (var i in tmp.Controls){
                            if(i is CheckBox){
                                CheckBox tmpcheckBox = i as CheckBox;
                                if (tmpcheckBox.Checked){
                                    product = new Product();

                                    switch (tmpcheckBox.Text)
                                    {
                                        case "Coffee":                                            
                                            product.Count = (int)numCoffee.Value;
                                            product.Name = tmpcheckBox.Text;
                                            product.Price = 5;                                            
                                            break;
                                        case "Hot-Dog":
                                            product.Name = tmpcheckBox.Text;
                                            product.Price = 7;
                                            product.Count = (int)numHotDog.Value;
                                            break;
                                        case "Tea":
                                            product.Name = tmpcheckBox.Text;
                                            product.Price = 3;
                                            product.Count = (int)numTea.Value;
                                            break;
                                        case "Coca-cola":
                                            product.Name = tmpcheckBox.Text;
                                            product.Price = 5;
                                            product.Count = (int)numCola.Value;
                                            break;
                                    }
                                    products.Add(product);
                                }
                            }
                        }
                    }
                }
            }
                        
            foreach (var item in products)
            {
                label8.Text += item.ToString()+ Environment.NewLine;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            label14.Text = "";
            label15.Text = "";
            int tmp = 0;
            float sum = 0;
            foreach (var item in products){
                tmp += item.Price * item.Count;
            }
            sum = (float)(gas.Sum() + tmp);

            label14.Text = ((float)gas.Sum()).ToString() + " $ Gas "
                        + Environment.NewLine + tmp.ToString() + " $ Product";

            label15.Text = "All : " + sum.ToString() + " $";
        }
    }
}
