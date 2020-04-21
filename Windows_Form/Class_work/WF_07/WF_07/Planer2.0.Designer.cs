namespace WF_07
{
    partial class Planer
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
            this.tbEvent = new System.Windows.Forms.TextBox();
            this.dateEvent = new System.Windows.Forms.MonthCalendar();
            this.lbEvent = new System.Windows.Forms.ListBox();
            this.cbListPriority = new System.Windows.Forms.CheckedListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCleanList = new System.Windows.Forms.Button();
            this.btnSerch = new System.Windows.Forms.Button();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbEvent
            // 
            this.tbEvent.Location = new System.Drawing.Point(24, 37);
            this.tbEvent.Name = "tbEvent";
            this.tbEvent.Size = new System.Drawing.Size(164, 20);
            this.tbEvent.TabIndex = 0;
            // 
            // dateEvent
            // 
            this.dateEvent.Location = new System.Drawing.Point(24, 86);
            this.dateEvent.MinDate = new System.DateTime(2020, 4, 15, 0, 0, 0, 0);
            this.dateEvent.Name = "dateEvent";
            this.dateEvent.TabIndex = 1;
            // 
            // lbEvent
            // 
            this.lbEvent.FormattingEnabled = true;
            this.lbEvent.Location = new System.Drawing.Point(218, 22);
            this.lbEvent.Name = "lbEvent";
            this.lbEvent.Size = new System.Drawing.Size(387, 303);
            this.lbEvent.TabIndex = 2;
            this.lbEvent.SelectedIndexChanged += new System.EventHandler(this.lbEvent_SelectedIndexChanged);
            // 
            // cbListPriority
            // 
            this.cbListPriority.CheckOnClick = true;
            this.cbListPriority.FormattingEnabled = true;
            this.cbListPriority.Items.AddRange(new object[] {
            "Low",
            "Middle",
            "High"});
            this.cbListPriority.Location = new System.Drawing.Point(24, 276);
            this.cbListPriority.Name = "cbListPriority";
            this.cbListPriority.Size = new System.Drawing.Size(164, 49);
            this.cbListPriority.TabIndex = 3;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(24, 341);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(164, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add event";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCleanList
            // 
            this.btnCleanList.Location = new System.Drawing.Point(495, 289);
            this.btnCleanList.Name = "btnCleanList";
            this.btnCleanList.Size = new System.Drawing.Size(91, 23);
            this.btnCleanList.TabIndex = 5;
            this.btnCleanList.Text = "Clean list";
            this.btnCleanList.UseVisualStyleBackColor = true;
            this.btnCleanList.Click += new System.EventHandler(this.btnCleanList_Click);
            // 
            // btnSerch
            // 
            this.btnSerch.Location = new System.Drawing.Point(24, 393);
            this.btnSerch.Name = "btnSerch";
            this.btnSerch.Size = new System.Drawing.Size(75, 23);
            this.btnSerch.TabIndex = 6;
            this.btnSerch.Text = "Search event";
            this.btnSerch.UseVisualStyleBackColor = true;
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(105, 393);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(165, 20);
            this.tbSearch.TabIndex = 7;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(495, 341);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(91, 23);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Delete event";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(218, 341);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 9;
            this.btnEdit.Text = "Edit event";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Event :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Date event :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 257);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Priority :";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(495, 393);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(91, 23);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Save to XML";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(295, 374);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "label4";
            // 
            // Planer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.btnSerch);
            this.Controls.Add(this.btnCleanList);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.cbListPriority);
            this.Controls.Add(this.lbEvent);
            this.Controls.Add(this.dateEvent);
            this.Controls.Add(this.tbEvent);
            this.Name = "Planer";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbEvent;
        private System.Windows.Forms.MonthCalendar dateEvent;
        private System.Windows.Forms.ListBox lbEvent;
        private System.Windows.Forms.CheckedListBox cbListPriority;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCleanList;
        private System.Windows.Forms.Button btnSerch;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label4;
    }
}

