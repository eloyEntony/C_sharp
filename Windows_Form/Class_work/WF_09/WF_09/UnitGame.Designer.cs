namespace WF_09
{
    partial class UnitGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UnitGame));
            this.lbREDcomand = new System.Windows.Forms.ListBox();
            this.lbAll = new System.Windows.Forms.ListBox();
            this.lbBLUEcomand = new System.Windows.Forms.ListBox();
            this.lbShowComand = new System.Windows.Forms.ListBox();
            this.btnAdd1 = new System.Windows.Forms.Button();
            this.btnAdd2 = new System.Windows.Forms.Button();
            this.btnSave1 = new System.Windows.Forms.Button();
            this.btnSave2 = new System.Windows.Forms.Button();
            this.numUnitCounter = new System.Windows.Forms.NumericUpDown();
            this.domainUpDown1 = new System.Windows.Forms.DomainUpDown();
            this.btnDelete1 = new System.Windows.Forms.Button();
            this.btnDelete2 = new System.Windows.Forms.Button();
            this.pbUnit = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numUnitCounter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // lbREDcomand
            // 
            this.lbREDcomand.BackColor = System.Drawing.Color.Black;
            this.lbREDcomand.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbREDcomand.ForeColor = System.Drawing.Color.White;
            this.lbREDcomand.FormattingEnabled = true;
            this.lbREDcomand.ItemHeight = 21;
            this.lbREDcomand.Location = new System.Drawing.Point(12, 13);
            this.lbREDcomand.Name = "lbREDcomand";
            this.lbREDcomand.Size = new System.Drawing.Size(156, 130);
            this.lbREDcomand.TabIndex = 0;
            // 
            // lbAll
            // 
            this.lbAll.BackColor = System.Drawing.Color.Black;
            this.lbAll.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbAll.ForeColor = System.Drawing.Color.White;
            this.lbAll.FormattingEnabled = true;
            this.lbAll.ItemHeight = 21;
            this.lbAll.Location = new System.Drawing.Point(172, 225);
            this.lbAll.Name = "lbAll";
            this.lbAll.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbAll.Size = new System.Drawing.Size(286, 88);
            this.lbAll.TabIndex = 1;
            this.lbAll.SelectedIndexChanged += new System.EventHandler(this.lbAll_SelectedIndexChanged);
            // 
            // lbBLUEcomand
            // 
            this.lbBLUEcomand.BackColor = System.Drawing.Color.Black;
            this.lbBLUEcomand.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbBLUEcomand.ForeColor = System.Drawing.Color.White;
            this.lbBLUEcomand.FormattingEnabled = true;
            this.lbBLUEcomand.ItemHeight = 21;
            this.lbBLUEcomand.Location = new System.Drawing.Point(466, 13);
            this.lbBLUEcomand.Name = "lbBLUEcomand";
            this.lbBLUEcomand.Size = new System.Drawing.Size(156, 130);
            this.lbBLUEcomand.TabIndex = 2;
            // 
            // lbShowComand
            // 
            this.lbShowComand.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbShowComand.BackColor = System.Drawing.Color.Black;
            this.lbShowComand.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbShowComand.ForeColor = System.Drawing.Color.White;
            this.lbShowComand.FormattingEnabled = true;
            this.lbShowComand.ItemHeight = 21;
            this.lbShowComand.Location = new System.Drawing.Point(172, 452);
            this.lbShowComand.Name = "lbShowComand";
            this.lbShowComand.Size = new System.Drawing.Size(286, 109);
            this.lbShowComand.TabIndex = 3;
            // 
            // btnAdd1
            // 
            this.btnAdd1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd1.Font = new System.Drawing.Font("Book Antiqua", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAdd1.ForeColor = System.Drawing.Color.White;
            this.btnAdd1.Location = new System.Drawing.Point(174, 13);
            this.btnAdd1.Name = "btnAdd1";
            this.btnAdd1.Size = new System.Drawing.Size(45, 186);
            this.btnAdd1.TabIndex = 4;
            this.btnAdd1.Text = "<";
            this.btnAdd1.UseVisualStyleBackColor = true;
            this.btnAdd1.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnAdd2
            // 
            this.btnAdd2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd2.Font = new System.Drawing.Font("Book Antiqua", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAdd2.ForeColor = System.Drawing.Color.White;
            this.btnAdd2.Location = new System.Drawing.Point(415, 12);
            this.btnAdd2.Name = "btnAdd2";
            this.btnAdd2.Size = new System.Drawing.Size(45, 187);
            this.btnAdd2.TabIndex = 5;
            this.btnAdd2.Text = ">";
            this.btnAdd2.UseVisualStyleBackColor = true;
            this.btnAdd2.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSave1
            // 
            this.btnSave1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave1.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSave1.ForeColor = System.Drawing.Color.White;
            this.btnSave1.Location = new System.Drawing.Point(12, 149);
            this.btnSave1.Name = "btnSave1";
            this.btnSave1.Size = new System.Drawing.Size(75, 50);
            this.btnSave1.TabIndex = 6;
            this.btnSave1.TabStop = false;
            this.btnSave1.Text = "Save";
            this.btnSave1.UseVisualStyleBackColor = true;
            this.btnSave1.Click += new System.EventHandler(this.btnSave1_Click);
            // 
            // btnSave2
            // 
            this.btnSave2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave2.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSave2.ForeColor = System.Drawing.Color.White;
            this.btnSave2.Location = new System.Drawing.Point(466, 149);
            this.btnSave2.Name = "btnSave2";
            this.btnSave2.Size = new System.Drawing.Size(75, 50);
            this.btnSave2.TabIndex = 7;
            this.btnSave2.Text = "Save";
            this.btnSave2.UseVisualStyleBackColor = true;
            this.btnSave2.Click += new System.EventHandler(this.btnSave1_Click);
            // 
            // numUnitCounter
            // 
            this.numUnitCounter.BackColor = System.Drawing.Color.Black;
            this.numUnitCounter.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numUnitCounter.ForeColor = System.Drawing.Color.White;
            this.numUnitCounter.Location = new System.Drawing.Point(174, 329);
            this.numUnitCounter.Name = "numUnitCounter";
            this.numUnitCounter.Size = new System.Drawing.Size(284, 27);
            this.numUnitCounter.TabIndex = 8;
            this.numUnitCounter.ValueChanged += new System.EventHandler(this.numUnitCounter_ValueChanged);
            // 
            // domainUpDown1
            // 
            this.domainUpDown1.BackColor = System.Drawing.Color.Black;
            this.domainUpDown1.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.domainUpDown1.ForeColor = System.Drawing.Color.White;
            this.domainUpDown1.Items.Add("RED");
            this.domainUpDown1.Items.Add("BLUE");
            this.domainUpDown1.Location = new System.Drawing.Point(174, 389);
            this.domainUpDown1.Name = "domainUpDown1";
            this.domainUpDown1.Size = new System.Drawing.Size(286, 27);
            this.domainUpDown1.TabIndex = 9;
            this.domainUpDown1.SelectedItemChanged += new System.EventHandler(this.domainUpDown1_SelectedItemChanged);
            // 
            // btnDelete1
            // 
            this.btnDelete1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete1.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDelete1.ForeColor = System.Drawing.Color.White;
            this.btnDelete1.Location = new System.Drawing.Point(93, 149);
            this.btnDelete1.Name = "btnDelete1";
            this.btnDelete1.Size = new System.Drawing.Size(75, 50);
            this.btnDelete1.TabIndex = 10;
            this.btnDelete1.Text = "Delete";
            this.btnDelete1.UseVisualStyleBackColor = true;
            this.btnDelete1.Click += new System.EventHandler(this.btnDelete1_Click);
            // 
            // btnDelete2
            // 
            this.btnDelete2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete2.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDelete2.ForeColor = System.Drawing.Color.White;
            this.btnDelete2.Location = new System.Drawing.Point(547, 149);
            this.btnDelete2.Name = "btnDelete2";
            this.btnDelete2.Size = new System.Drawing.Size(75, 50);
            this.btnDelete2.TabIndex = 11;
            this.btnDelete2.Text = "Delete";
            this.btnDelete2.UseVisualStyleBackColor = true;
            this.btnDelete2.Click += new System.EventHandler(this.btnDelete1_Click);
            // 
            // pbUnit
            // 
            this.pbUnit.Image = ((System.Drawing.Image)(resources.GetObject("pbUnit.Image")));
            this.pbUnit.Location = new System.Drawing.Point(225, 13);
            this.pbUnit.Name = "pbUnit";
            this.pbUnit.Size = new System.Drawing.Size(184, 186);
            this.pbUnit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbUnit.TabIndex = 12;
            this.pbUnit.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(466, 205);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(156, 356);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 14;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pictureBox4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(12, 205);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(156, 356);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 15;
            this.pictureBox4.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(251, 316);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 21);
            this.label1.TabIndex = 16;
            this.label1.Text = "Size of the team ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(271, 379);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 21);
            this.label2.TabIndex = 17;
            this.label2.Text = "Select team";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(281, 201);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 21);
            this.label3.TabIndex = 18;
            this.label3.Text = "Warriors";
            // 
            // UnitGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(634, 573);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pbUnit);
            this.Controls.Add(this.btnDelete2);
            this.Controls.Add(this.btnDelete1);
            this.Controls.Add(this.domainUpDown1);
            this.Controls.Add(this.numUnitCounter);
            this.Controls.Add(this.btnSave2);
            this.Controls.Add(this.btnSave1);
            this.Controls.Add(this.btnAdd2);
            this.Controls.Add(this.btnAdd1);
            this.Controls.Add(this.lbShowComand);
            this.Controls.Add(this.lbBLUEcomand);
            this.Controls.Add(this.lbAll);
            this.Controls.Add(this.lbREDcomand);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UnitGame";
            this.Text = "UNIT GAME";
            ((System.ComponentModel.ISupportInitialize)(this.numUnitCounter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbREDcomand;
        private System.Windows.Forms.ListBox lbAll;
        private System.Windows.Forms.ListBox lbBLUEcomand;
        private System.Windows.Forms.ListBox lbShowComand;
        private System.Windows.Forms.Button btnAdd1;
        private System.Windows.Forms.Button btnAdd2;
        private System.Windows.Forms.Button btnSave1;
        private System.Windows.Forms.Button btnSave2;
        private System.Windows.Forms.NumericUpDown numUnitCounter;
        private System.Windows.Forms.DomainUpDown domainUpDown1;
        private System.Windows.Forms.Button btnDelete1;
        private System.Windows.Forms.Button btnDelete2;
        private System.Windows.Forms.PictureBox pbUnit;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

