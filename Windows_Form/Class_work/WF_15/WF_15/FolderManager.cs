using System;
using System.IO;
using System.Windows.Forms;

/*
 Створити форму.
На формі - Меню.
В меню - 2 пункти:
Browse - при клікові відкривається FolderBrowseDialog. Обираємо каталог - всі папки з нього відображуються в TreeView
View - при клікові встановлюється режим перегляду ListView

В робочій області форми - зліва TreeView, справа - ListView
Після розгортання вузлів TreeView отримуємо дочірні вузли - підпапки обраного каталога
При виборі певного вузла (DoubleClick) - в ListView бачимо вміст даного каталога у вигляді ListViewItem-s 
(вигляд Item-a придумати: іконка для папки, іконка для файла, назва...)
     
     
     */

namespace WF_15
{
    public partial class FolderManager : Form
    {
        public FolderManager()
        {
            InitializeComponent();
            listView1.ContextMenuStrip = contextMenuStrip1;
        }
        private void browseToolStripMenuItem1_Click(object sender, EventArgs e) //створення діалогового вікна для вибору дерикторії
        {
            FolderBrowserDialog of = new FolderBrowserDialog();
            var dialogResult = of.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                textBox1.Text = of.SelectedPath;
                GreateTree(of.SelectedPath);
            }
        }
        TreeNode rootNode;
        private void GreateTree(string path)
        {
            DirectoryInfo info = new DirectoryInfo(path); // отримання інформації про діректорію
            if (info.Exists)
            {
                rootNode = new TreeNode(info.Name); // створення головних нод 
                rootNode.Tag = info;
                GetDirectories(info.GetDirectories(), rootNode); // отримання файлі і папок що є в дерикторії
                treeView1.Nodes.Add(rootNode);
            }
        }
        DirectoryInfo[] subSubDirs;
        private void GetDirectories(DirectoryInfo[] subDirs, TreeNode nodeToAddTo)
        {
            TreeNode aNode;
            
            foreach (DirectoryInfo subDir in subDirs)
            {
                aNode = new TreeNode(subDir.Name, 0, 0); // створення нової гілки
                aNode.Tag = subDir;
                aNode.ImageKey = "folder";
                subSubDirs = subDir.GetDirectories();
                if (subSubDirs.Length != 0)
                    GetDirectories(subSubDirs, aNode); //рекурсивний обхід папок, якщо папки є функція спрацьовує ще раз               
                nodeToAddTo.Nodes.Add(aNode);
            }
        }

        void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)//додавання файлів і папок в listView
        {
            TreeNode newSelected = e.Node;
            listView1.Items.Clear();
            DirectoryInfo nodeDirInfo = (DirectoryInfo)newSelected.Tag;
            ListViewItem.ListViewSubItem[] subItems;
            ListViewItem item = null;

            foreach (DirectoryInfo dir in nodeDirInfo.GetDirectories())
            {
                item = new ListViewItem(dir.Name, 1);
                subItems = new ListViewItem.ListViewSubItem[] { new ListViewItem.ListViewSubItem(item, "Directory") };
                item.SubItems.AddRange(subItems);
                listView1.Items.Add(item);
            }

            foreach (FileInfo file in nodeDirInfo.GetFiles())
            {
                item = new ListViewItem(new string[] { file.Name, "File", (file.Length / 1000).ToString() + " KB" }, 0);
                subItems = new ListViewItem.ListViewSubItem[] { new ListViewItem.ListViewSubItem(item, "File") };
                item.SubItems.AddRange(subItems);
                listView1.Items.Add(item);
            }
        }

        private void smallIconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.View = View.SmallIcon;
        }

        private void largeIconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.View = View.LargeIcon;
        }

        private void listToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.View = View.List;
        }

        private void detailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.View = View.Details;
            listView1.Columns.Add("File name");
            listView1.Columns.Add("Type");
            listView1.Columns.Add("Size");
        }

        private void tileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.View = View.Tile;
        }

    }
}
