using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;


/*
    _____ListView.
_____Права частина Провідника_____________

    Створити програму, яка дозволить обирати папку(FolderBrowserDialog) і буде відображувати
    вміст папки(файли та підпапки) подібно програмі Провідник. 

    Передбачити можливість зміни способу перегляду списку файлів (список, деталі, малі значки, великі значки).
    Передбачити можливість впорядкувувати по 
		по іменах		
		по розміру 
		по даті

    При виборі у ListView нової папки(подвійний клік) поновлювати список файлів(папок) з обраної папки.
    При виділенні мишею певного елемента(файлу чи папки) у рядку стану показувати інформацію про файл(папку)

* При натисненні  клавіші Del - видаляти виділені файли та папки при підтвердженні видалення
* При натисненні  клавіші BackSpace - повертатися назад
     */

namespace WF_14
{
    public partial class Folder : Form
    {
        public Folder()
        {
            InitializeComponent();
        }
        List<string> list = new List<string>();
        List<string> bufer = new List<string>();
        FileInfo fileInfo;
        DateTime creationTime;
        String extensionFile;
        FolderBrowserDialog of;
        int tmp;
        private void btnOpen_Click(object sender, EventArgs e)
        {
            of = new FolderBrowserDialog();
            var dialogResult = of.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                CreateListView(of.SelectedPath);
                bufer.Add(of.SelectedPath);
            }
        }
        private void CreateListView(string path)
        {
            listView1.Items.Clear();
            list.Clear();
            textBox1.Text = path;

            list.AddRange(Directory.EnumerateFileSystemEntries(path));

            for (int i = 0; i < list.Count; i++)
            {
                listView1.Items.Add(new ListViewItem(Path.GetFileName(list[i])));// додає в масив імена папок і файлів
            }
            int j = 0;
            foreach (ListViewItem item in listView1.Items)
            {
                fileInfo = new FileInfo(list[j]);
                creationTime = fileInfo.LastWriteTime;
                try
                {
                    extensionFile = fileInfo.Extension;
                    long tmp = fileInfo.Length / 1000;
                    ListViewItem lvi = new ListViewItem(new string[] { item.Text, creationTime.ToString(), extensionFile, tmp.ToString() + " KB" }, 1);
                    listView1.Items[j] = lvi;
                    j++;
                }
                catch
                {
                    ListViewItem lvi = new ListViewItem(new string[] { item.Text, creationTime.ToString(), "Folder", "" }, 0);
                    listView1.Items[j] = lvi;
                    j++;
                }
            }
        }
        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            foreach (RadioButton item in groupBox1.Controls)
            {
                if (item.Checked)
                {
                    View view = (View)Enum.Parse(typeof(View), item.Text);
                    listView1.View = view;
                    break;
                }
            }
        }
        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            tmp = e.ItemIndex;
            listBox1.Items.Clear();
            foreach (ListViewItem.ListViewSubItem sub in e.Item.SubItems)
            {
                listBox1.Items.Add(sub.Text);
            }
        }
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            string row = null;
            textBox1.Text = tmp.ToString();

            for (int i = 0; i < list.Count; i++)// переход в вибрану папку
            {
                if (i == tmp)
                    row = list[i];
            }
            FileInfo fi = new FileInfo(row);
            try
            {
                if (fi.Length != 0)
                    return;
            }
            catch
            {
                textBox1.Text = row;
                bufer.Add(row);
                CreateListView(row);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int i = bufer.Count - 2;
            int j = 0;
            string tmp = null;
            foreach (string item in bufer)
            {
                if (i == j)
                    tmp = item;
                j++;
            }

            if (bufer.Count != 1)
            {
                bufer.RemoveAt(bufer.Count - 1);
                CreateListView(tmp);
            }
            else
                CreateListView(of.SelectedPath);
        }
        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            listView1.ListViewItemSorter = new ListViewItemComparer(e.Column);
        }
        private void listView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                int i = 0;
                string paths = null;
                foreach (var item in list)
                {
                    if (i == tmp)
                        paths = item;
                    i++;
                }

                DialogResult = MessageBox.Show("Delete ?", "delete", MessageBoxButtons.YesNo);
                if (DialogResult == DialogResult.Yes)
                {
                    list.RemoveAt(tmp);
                    listView1.Items.RemoveAt(tmp);
                    try
                    {
                        Directory.Delete(paths, true);
                    }
                    catch
                    {
                        File.Delete(paths);
                    }
                    Refresh();
                    return;
                }
            }
            if (e.KeyCode == Keys.Back)
                button1_Click(null, null);
        }
    }


}
