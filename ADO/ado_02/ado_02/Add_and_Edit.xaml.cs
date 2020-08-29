using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ado_02
{
    public partial class Add_and_Edit : Window
    {
        List<Group> groups;
        DbConnection connection;
        DbProviderFactory factory;
        public Student student { get; set; }
        bool addNew;
        public Add_and_Edit(Student student, bool addNew, DbConnection conn, DbProviderFactory factory)
        {
            InitializeComponent();
            this.addNew = addNew;
            this.student = student;
            this.connection = conn;
            this.factory = factory;
            groups = new List<Group>();
            GetGroups();
            cbGroup.ItemsSource = groups;

            if (!addNew)
            {
                tbName.Text = student.Name;
                tbSurname.Text = student.Surname;
                cbGroup.SelectedIndex = groups.FindIndex(x => x.ID == student.IDGroup);
            }
        }

        private void GetGroups()
        {
            using (DbCommand command = factory.CreateCommand())
            {
                command.CommandText = "select * from Groups";
                command.Connection = connection;

                using (DbDataReader dr = command.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        while(dr.Read())
                        {
                            groups.Add(new Group { ID = dr.GetInt32(0), Name = dr.GetString(1)});
                        }
                    }
                }
            }            
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            student = student ?? new Student();

            if (String.IsNullOrWhiteSpace(tbName.Text) || String.IsNullOrWhiteSpace(tbSurname.Text) || cbGroup.SelectedIndex == -1)
                return;

            string tmp = cbGroup.SelectedItem.ToString();
            int id = 0;

            student.Name = tbName.Text;
            student.Surname = tbSurname.Text;

            for (int i = 0; i < groups.Count; i++)
                if (tmp == groups[i].Name)
                    id = groups[i].ID;
            
            student.IDGroup = id;

            if (addNew)
                AddStudent();
            else
                EditStudent();

            this.DialogResult = true;
        }

        private void AddStudent()
        {
            DbCommand cmd = factory.CreateCommand();
            cmd.CommandText = $"insert into student values(@name, @surname, @idGroup)";
            cmd.Connection = connection;

            DbParameter pName = factory.CreateParameter();
            pName.ParameterName = "@name";
            pName.Value = student.Name;

            DbParameter pSurname = factory.CreateParameter();
            pSurname.ParameterName = "@surname";
            pSurname.Value = student.Surname;

            DbParameter pidGroup = factory.CreateParameter();
            pidGroup.ParameterName = "@idGroup";
            pidGroup.Value = student.IDGroup;

            cmd.Parameters.Add(pName);
            cmd.Parameters.Add(pSurname);
            cmd.Parameters.Add(pidGroup);
            //помилка на 6 групу обробити
            cmd.ExecuteNonQuery();
        }

        private void EditStudent()
        {
            DbCommand cmd = factory.CreateCommand();
            cmd.CommandText = $"update student set Name = @name, Surname = @surname, IdGroup = @idGroup where id = @id";
            cmd.Connection = connection;

            DbParameter pID = factory.CreateParameter();
            pID.ParameterName = "@id";
            pID.Value = student.ID;

            DbParameter pName = factory.CreateParameter();
            pName.ParameterName = "@name";
            pName.Value = student.Name;

            DbParameter pSurname = factory.CreateParameter();
            pSurname.ParameterName = "@surname";
            pSurname.Value = student.Surname;

            DbParameter pGroup = factory.CreateParameter();
            pGroup.ParameterName = "@idGroup";
            pGroup.Value = student.IDGroup;


            cmd.Parameters.Add(pID);
            cmd.Parameters.Add(pName);
            cmd.Parameters.Add(pSurname);
            cmd.Parameters.Add(pGroup);
            cmd.ExecuteNonQuery();
        }
    }
}


