using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using FontFamily = System.Drawing.FontFamily;
/*
* 
На основі RichTextBox зробити текстовий редактор, 
		здатний працювати ( відкривати, редагувати і зберігати ) з простим текстом( *.txt, *.cs, *.html ) та форматованим текстом ( *.rtf )
Меню:
		Файл: Відкрити, Зберегти, Зберегти як, Вихід
		Редагувати: Вставити, Вирізати, Копіювати, Виділити все

		Відкриття і збереження файлу має бути доступне:
		кнопкою панелі інструментів (із зображенням)
		пунктом меню
		клавіатурним поєднанням ( Ctrl+O, Ctrl+S )

При спробі відкрити інший файл, якщо є незбережені зміни -- має бути запитано підтвердження дії.

Крім того, на панелі інструментів мають бути кнопки форматування виділеного тексту:
		увімкнути / вимкнути жирне начертання
		увімкнути / вимкнути курсивне начертання
		увімкнути / вимкнути підкреслення
		кнопки вибору вирівнювання абзацу ( по лівому, по правому, по центру)
		список вибору розміру шрифта
		кнопка збільшення розміру шрифта
		кнопка зменшення розміру шрифта
		кнопка вибору кольору символів (відкриває стандартний діалог вибору кольору)
		кнопка вибору тла символів (відкриває стандартний діалог вибору кольору)
		кнопка включення/виключення форматування абзаців як списку
		на панелі інструментів є список з доступними у системі шрифтами 
		-- при виборі шрифта змінюється форматування виділеного тексту


Додати контекстне меню з пунктами
		Copy
		Cut
		Paste
		Clear all

		На рядку стану зображувати інформацію про відкритий  файл(назву)*/


namespace WF_11
{
	public partial class TextEdit : Form
	{
		public TextEdit()
		{
			InitializeComponent();

			cbFont.Items.AddRange(FontFamily.Families.Select(f => f.Name).ToArray());
			for (int i = 8; i < 72; i += 2)
			{
				cbSize.Items.Add(i);
			}
			//cbFont.Text = cbFont.Font.Name;
			//cbSize.Text = "8";
		}

		bool saveRepead = false;
		bool style_on = false;
		bool save = false;
		bool open = false;
		string openFileName = "";

		//////////////////////
		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = "Rtf files(*.rtf)|*.rtf|Text files(*.txt)|*.txt|Cod(*.cs)|*.cs|Html file(*.html)|*.html|All files|*.*";
			ofd.FileName = "Type name here";
			ofd.InitialDirectory = @"C:\Users\Anton\Desktop";
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				if (Path.GetExtension(ofd.FileName) == ".rtf")
					richTextBox1.LoadFile(ofd.FileName);
				else
					richTextBox1.LoadFile(ofd.FileName, RichTextBoxStreamType.UnicodePlainText);
				toolStripLabel1.Text = ofd.FileName;
				openFileName = ofd.FileName;
				open = true;
			}
		}
		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (saveRepead == false && open == false)
			{
				saveAsToolStripMenuItem_Click(null, null);
				saveRepead = true;
				return;
			}
			if (Path.GetExtension(openFileName) == ".rtf")
				richTextBox1.SaveFile(openFileName);
			else
				richTextBox1.SaveFile(openFileName, RichTextBoxStreamType.UnicodePlainText);
			Notify_save();
		}
		private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Filter = "Rtf files(*.rtf)|*.rtf|Text files(*.txt)|*.txt|Cod(*.cs)|*.cs|Html file(*.html)|*.html|All files|*.*";
			sfd.InitialDirectory = @"C:\Users\Anton\Desktop";
			sfd.OverwritePrompt = true;
			sfd.FileName = "New text document";
			if (sfd.ShowDialog() == DialogResult.OK)
			{
				if (Path.GetExtension(sfd.FileName) == ".rtf")
					richTextBox1.SaveFile(sfd.FileName);
				else
					richTextBox1.SaveFile(sfd.FileName, RichTextBoxStreamType.UnicodePlainText);
				openFileName = sfd.FileName;
				Notify_save();
			}
		}

		//////////////////////		
		private void Notify_save()
		{
			notifyIcon1.Visible = true;
			notifyIcon1.ShowBalloonTip(100);
			save = true;
		}

		//////////////////////
		private void btnStyle_1_Click(object sender, EventArgs e)
		{
			ToolStripButton button = sender as ToolStripButton;
			if (style_on == true)
			{
				Style_back();
				style_on = false;
				return;
			}

			switch (button.Name)
			{
				case "btnStyle_1":
					Style_new(1);
					break;
				case "btnStyle_2":
					Style_new(2);
					break;
				case "btnStyle_3":
					Style_new(3);
					break;
			}
			style_on = true;
		}
		private void Style_new(int style)
		{
			FontStyle new_fontStyle = FontStyle.Regular;

			switch (style)
			{
				case 1:
					new_fontStyle = FontStyle.Bold;
					break;
				case 2:
					new_fontStyle = FontStyle.Italic;
					break;
				case 3:
					new_fontStyle = FontStyle.Underline;
					break;
			}

			if (richTextBox1.SelectionLength != 0)
			{
				richTextBox1.SelectionFont = new Font(richTextBox1.Font, new_fontStyle);
				return;
			}
			richTextBox1.Font = new Font(richTextBox1.Font, new_fontStyle);
		}
		private void Style_back()
		{
			if (richTextBox1.SelectionLength != 0)
			{
				richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
				return;
			}
			richTextBox1.Font = new Font(richTextBox1.Font, FontStyle.Regular);
		}

		//////////////////////
		private void btnFont_Click(object sender, EventArgs e)
		{
			FontDialog fd = new FontDialog();
			fd.Font = new Font("Times New Roman", 14, FontStyle.Regular);
			fd.Color = System.Drawing.Color.Black;
			fd.ShowColor = true;

			if (fd.ShowDialog() == DialogResult.OK)
			{
				if (richTextBox1.SelectionLength != 0)
				{
					richTextBox1.SelectionFont = fd.Font;
					richTextBox1.SelectionColor = fd.Color;
				}
				else
				{
					richTextBox1.Font = fd.Font;
					richTextBox1.SelectAll();
					richTextBox1.SelectionColor = fd.Color;
				}
				cbSize.Text = fd.Font.Size.ToString();
				cbFont.SelectedItem = fd.Font.FontFamily;
			}
		}		
		private void btnColor_Click(object sender, EventArgs e)
		{
			ColorDialog cd = new ColorDialog();
			if (cd.ShowDialog() == DialogResult.OK)
				if (richTextBox1.SelectionLength != 0)
					richTextBox1.SelectionColor = cd.Color;
				else
					richTextBox1.ForeColor = cd.Color;
		}
		private void btnBackColor_Click(object sender, EventArgs e)
		{
			ColorDialog cd = new ColorDialog();
			if (cd.ShowDialog() == DialogResult.OK)
				if (richTextBox1.SelectionLength != 0)
					richTextBox1.SelectionBackColor = cd.Color;
				else
					richTextBox1.BackColor = cd.Color;
		}

		//////////////////////
		private void btnUndo_Click(object sender, EventArgs e)
		{
			richTextBox1.Undo();
		}
		private void btnRedo_Click(object sender, EventArgs e)
		{
			richTextBox1.Redo();
		}

		//////////////////////
		private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			string newFont = cbFont.Text.ToString();

			if (richTextBox1.SelectionLength != 0)
				richTextBox1.SelectionFont = new Font(newFont, Convert.ToInt32(cbSize.Text));
			else
				richTextBox1.Font = new Font(newFont, Convert.ToInt32(cbSize.Text));
		}
		private void cbSize_SelectedIndexChanged(object sender, EventArgs e)
		{
			int newSize = Convert.ToInt32(cbSize.Text);

			if (richTextBox1.SelectionLength != 0)
				richTextBox1.SelectionFont = new Font(cbFont.Text.ToString(), newSize);
			else
				richTextBox1.Font = new Font(cbFont.Text.ToString(), newSize);
		}
		private void btnUpFont_Click(object sender, EventArgs e)
		{
			int newSize = Convert.ToInt32(cbSize.Text);

			if (richTextBox1.SelectionLength != 0)
				richTextBox1.SelectionFont = new Font(cbFont.Text.ToString(), newSize++);
			else
				richTextBox1.Font = new Font(cbFont.Text.ToString(), newSize++);

			cbSize.Text = newSize.ToString();
		}
		private void btnDownFont_Click(object sender, EventArgs e)
		{
			int newSize = Convert.ToInt32(cbSize.Text);

			if (richTextBox1.SelectionLength != 0)
				richTextBox1.SelectionFont = new Font(cbFont.Text.ToString(), newSize--);
			else
				richTextBox1.Font = new Font(cbFont.Text.ToString(), newSize--);

			cbSize.Text = newSize.ToString();
		}

		//////////////////////
		private void btnTextCentr_Click(object sender, EventArgs e)
		{
			richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
		}
		private void btnTextLeft_Click(object sender, EventArgs e)
		{
			richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
		}
		private void btnTextRight_Click(object sender, EventArgs e)
		{
			richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
		}
		private void btnBullet_Click(object sender, EventArgs e)
		{
			if (richTextBox1.SelectionBullet)
			{
				richTextBox1.SelectionBullet = false;
				return;
			}
			richTextBox1.SelectionBullet = true;
		}

		//////////////////////
		private void richTextBox1_TextChanged(object sender, EventArgs e)
		{
			save = false;			
		}		

		//////////////////////
		private void whiteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.BackColor = Color.Silver;
			btnUpFont.ForeColor = Color.Black;
			btnDownFont.ForeColor = Color.Black;
			btnColor.ForeColor = Color.Black;
			this.toolStrip2.BackColor = Color.Silver;
			toolStripLabel1.ForeColor = Color.Black;
			fileToolStripMenuItem.ForeColor = Color.Black;
			editToolStripMenuItem.ForeColor = Color.Black;
			windowStyleToolStripMenuItem.ForeColor = Color.Black;
			aboutToolStripMenuItem.ForeColor = Color.Black;
		}
		private void blackToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.BackColor = Color.Black;
			btnUpFont.ForeColor = Color.White;
			btnDownFont.ForeColor = Color.White;
			btnColor.ForeColor = Color.White;
			this.toolStrip2.BackColor = Color.Black;
			toolStripLabel1.ForeColor = Color.White;
			fileToolStripMenuItem.ForeColor = Color.White;
			editToolStripMenuItem.ForeColor = Color.White;
			windowStyleToolStripMenuItem.ForeColor = Color.White;
			aboutToolStripMenuItem.ForeColor = Color.White;
		}

		//////////////////////
		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (save)
			{
				this.Close();
				return;
			}

			DialogResult dialog = MessageBox.Show("SAVE FILE ?", "Saving...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

			if (dialog == DialogResult.Yes)
			{
				SaveFileDialog sfd = new SaveFileDialog();
				sfd.Filter = "Rtf files(*.rtf)|*.rtf|Text files(*.txt)|*.txt|Cod(*.cs)|*.cs|Html file(*.html)|*.html|All files|*.*";
				sfd.InitialDirectory = @"C:\Users\Anton\Desktop";
				sfd.OverwritePrompt = true;
				sfd.FileName = "New text document";
				if (sfd.ShowDialog() == DialogResult.OK)
				{
					if (Path.GetExtension(sfd.FileName) == ".rtf")
						richTextBox1.SaveFile(sfd.FileName);
					else
						richTextBox1.SaveFile(sfd.FileName, RichTextBoxStreamType.UnicodePlainText);
					openFileName = sfd.FileName;
					Notify_save();
				}
			}
			else
				this.Close();

		}
		private void TextEdit_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (save){
				e.Cancel = false;
				return;
			}

			DialogResult dialog = MessageBox.Show("SAVE FILE ?", "Saving...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

			if (dialog == DialogResult.Yes)
			{
				SaveFileDialog sfd = new SaveFileDialog();
				sfd.Filter = "Rtf files(*.rtf)|*.rtf|Text files(*.txt)|*.txt|Cod(*.cs)|*.cs|Html file(*.html)|*.html|All files|*.*";
				sfd.InitialDirectory = @"C:\Users\Anton\Desktop";
				sfd.OverwritePrompt = true;
				sfd.FileName = "New text document";
				if (sfd.ShowDialog() == DialogResult.OK)
				{
					if (Path.GetExtension(sfd.FileName) == ".rtf")
						richTextBox1.SaveFile(sfd.FileName);
					else
						richTextBox1.SaveFile(sfd.FileName, RichTextBoxStreamType.UnicodePlainText);
					openFileName = sfd.FileName;
					Notify_save();
					e.Cancel = false;
				}
				else
					e.Cancel = true;
			}
			else
				e.Cancel = false;
		}


		//////////////////////
		private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
		{
			richTextBox1.SelectAll();
		}
		private void copyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if(richTextBox1.SelectionLength != 0)
			{
				richTextBox1.Copy();
				return;
			}
			richTextBox1.SelectAll();
			richTextBox1.Copy();			
		}
		private void cutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (richTextBox1.SelectionLength != 0)
			{
				richTextBox1.Cut();
				return;
			}
			richTextBox1.SelectAll();
			richTextBox1.Cut();
		}
		private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (richTextBox1.SelectionLength != 0)
			{
				richTextBox1.Paste();
				return;
			}			
			richTextBox1.Paste();
		}
		private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
		{
			richTextBox1.Clear();
		}

		//////////////////////
		private void aboutMeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Process.Start("https://github.com/eloyEntony");
		}

		
	}
}
