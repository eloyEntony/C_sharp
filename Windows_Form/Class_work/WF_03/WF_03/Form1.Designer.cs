namespace WF_03
{
    partial class Event_planer
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.priorityBox = new System.Windows.Forms.TextBox();
            this.dateTime = new System.Windows.Forms.DateTimePicker();
            this.eventBox2 = new System.Windows.Forms.TextBox();
            this.eventBox = new System.Windows.Forms.TextBox();
            this.listBox = new System.Windows.Forms.ListBox();
            this.btnClean = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.priorityBox);
            this.panel1.Controls.Add(this.dateTime);
            this.panel1.Controls.Add(this.eventBox2);
            this.panel1.Controls.Add(this.eventBox);
            this.panel1.Location = new System.Drawing.Point(15, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(266, 251);
            this.panel1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Priority :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Event date : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Event place :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Event :";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(96, 225);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            this.btnAdd.Leave += new System.EventHandler(this.btnAdd_Leave);
            // 
            // priorityBox
            // 
            this.priorityBox.AutoCompleteCustomSource.AddRange(new string[] {
            "high",
            "medium",
            "low"});
            this.priorityBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.priorityBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.priorityBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.priorityBox.Location = new System.Drawing.Point(15, 158);
            this.priorityBox.Name = "priorityBox";
            this.priorityBox.Size = new System.Drawing.Size(231, 20);
            this.priorityBox.TabIndex = 3;
            this.priorityBox.Text = "medium";
            // 
            // dateTime
            // 
            this.dateTime.Location = new System.Drawing.Point(15, 115);
            this.dateTime.MaxDate = new System.DateTime(2020, 12, 31, 0, 0, 0, 0);
            this.dateTime.MinDate = new System.DateTime(1753, 1, 9, 0, 0, 0, 0);
            this.dateTime.Name = "dateTime";
            this.dateTime.Size = new System.Drawing.Size(231, 20);
            this.dateTime.TabIndex = 2;
            this.dateTime.Value = new System.DateTime(2020, 4, 9, 0, 0, 0, 0);
            // 
            // eventBox2
            // 
            this.eventBox2.Location = new System.Drawing.Point(15, 72);
            this.eventBox2.Name = "eventBox2";
            this.eventBox2.Size = new System.Drawing.Size(231, 20);
            this.eventBox2.TabIndex = 1;
            // 
            // eventBox
            // 
            this.eventBox.Location = new System.Drawing.Point(15, 29);
            this.eventBox.Name = "eventBox";
            this.eventBox.Size = new System.Drawing.Size(231, 20);
            this.eventBox.TabIndex = 0;
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(287, 31);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(340, 251);
            this.listBox.TabIndex = 1;
            // 
            // btnClean
            // 
            this.btnClean.Location = new System.Drawing.Point(552, 303);
            this.btnClean.Name = "btnClean";
            this.btnClean.Size = new System.Drawing.Size(75, 23);
            this.btnClean.TabIndex = 2;
            this.btnClean.Text = "Clean list";
            this.btnClean.UseVisualStyleBackColor = true;
            this.btnClean.Click += new System.EventHandler(this.btnClean_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(437, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Event list";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(126, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Event";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(287, 303);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save to file";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // Event_planer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 337);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnClean);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.panel1);
            this.Name = "Event_planer";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox priorityBox;
        private System.Windows.Forms.DateTimePicker dateTime;
        private System.Windows.Forms.TextBox eventBox2;
        private System.Windows.Forms.TextBox eventBox;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Button btnClean;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSave;
    }
}

