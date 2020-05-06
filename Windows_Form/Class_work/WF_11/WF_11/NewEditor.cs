using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_11
{
    public partial class NewEditor : Form
    {

        public NewEditor()
        {
            InitializeComponent();  
        }

        public float FontSize
        {
            get
            {
                return this.richTextBox1.Font.Size;
            }
            set
            {
                //this.richTextBox1.Font = new Font();
            }
        }

        public RichTextBox TextBox
        {
            get
            {
                return this.richTextBox1;
            }
            set 
            {
                this.richTextBox1 = value; 
            }
        }

        private void NewEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            string title = this.Text;

            var puncts = ((TextEdit)this.MdiParent).menuItem.DropDownItems; // доступ до всіх пунктів меню Window
            for (int i = 0; i < puncts.Count; i++)
            {
                if (puncts[i].Text.Equals(title))
                {
                    puncts.RemoveAt(i);
                    break;
                }
            }
            if (puncts.Count == TextEdit.fileMenuCounter)
            {
                puncts.RemoveAt(puncts.Count - 1);
            }
        }
    }
}
