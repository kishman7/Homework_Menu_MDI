using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Windows.Media;
using System.Drawing.Text;
using System.Linq;

namespace MenuDemo
{
    public partial class Parent : Form
    {
        public Parent()
        {
            InitializeComponent();
            for (int i = 2; i < 70; i+=2)
            {
                toolStripComboBox1.Items.Add(i);
            }
            toolStripComboBox1.Text = "10";

            //прописуємо назву формату тексту в ComboBox
            var fonts = new InstalledFontCollection();
            toolStripComboBox2.Items.AddRange(fonts.Families.Select(x => x.Name).ToArray());
        }
        // налаштування кольору тексту
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            // FontDialog
            // ColorDialog
            // SaveFileDialog
            // OpenFileDialog
            // FolderBrowserDialog

            //налаштовуємо втиснення клавіши
            var fontColorBtn = (sender as ToolStripButton);
            fontColorBtn.Checked = !fontColorBtn.Checked;

            var fontDialog = new FontDialog();
            fontDialog.ShowColor = true;

            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                if ((this.ActiveMdiChild as Child).RichTextBoxChild.SelectedText.Length > 0)
                {
                    (this.ActiveMdiChild as Child).RichTextBoxChild.SelectionFont = fontDialog.Font;
                    (this.ActiveMdiChild as Child).RichTextBoxChild.SelectionColor = fontDialog.Color;
                }
                else
                {
                    //(this.ActiveMdiChild as Child).RichTextBoxChild.SelectAll();
                    (this.ActiveMdiChild as Child).RichTextBoxChild.Font = fontDialog.Font;
                    (this.ActiveMdiChild as Child).RichTextBoxChild.ForeColor = fontDialog.Color;
                }
            }
        }
        // пункт меню збереження файла
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var saveDialog = new SaveFileDialog();
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                if (Path.GetExtension(saveDialog.FileName) == ".txt") // перевірка на розширення файла
                {
                    (this.ActiveMdiChild as Child).RichTextBoxChild.SaveFile(saveDialog.FileName, RichTextBoxStreamType.UnicodePlainText); //enum RichTextBoxStreamType - дозволяє зберегти різний формат тексту
                }
                else
                {
                    (this.ActiveMdiChild as Child).RichTextBoxChild.SaveFile(saveDialog.FileName);
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openDialog = new OpenFileDialog();
            openDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); // відкриття вікна OpenFileDialog, де по замовчуванням відкриваються "Мої документи"
            openDialog.Filter = "All files|*.*|Text documents|*.txt|RTF|*.rtf"; // фільтри для OpenFileDialog
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                (this.ActiveMdiChild as Child).RichTextBoxChild.LoadFile(openDialog.FileName);
            }
        }
        // курсивний текст
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //налаштовуємо втиснення клавіши
            var italicBtn = (sender as ToolStripButton);
            italicBtn.Checked = !italicBtn.Checked;
            if ((this.ActiveMdiChild as Child).RichTextBoxChild.SelectedText.Length > 0)
            {
                if ((this.ActiveMdiChild as Child).RichTextBoxChild.SelectionFont.Italic)
                {
                    (this.ActiveMdiChild as Child).RichTextBoxChild.SelectionFont = new Font((this.ActiveMdiChild as Child).RichTextBoxChild.SelectionFont, (this.ActiveMdiChild as Child).RichTextBoxChild.SelectionFont.Style & ~FontStyle.Italic);
                }
                else
                {
                    (this.ActiveMdiChild as Child).RichTextBoxChild.SelectionFont = new Font((this.ActiveMdiChild as Child).RichTextBoxChild.SelectionFont, (this.ActiveMdiChild as Child).RichTextBoxChild.SelectionFont.Style | FontStyle.Italic);
                }
            }
            else
            {
                (this.ActiveMdiChild as Child).RichTextBoxChild.Font = new Font((this.ActiveMdiChild as Child).RichTextBoxChild.Font, FontStyle.Italic);
            }
        }
        // жирний текст
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            // FontStyle.Regular
            // enum 0 1 2
            // 00000000 regular
            // 00000001 italic
            // 00000010 bold

            // italic | bold
            // 11111100
            //налаштовуємо втиснення клавіши
            var boldBtn = (sender as ToolStripButton);
            boldBtn.Checked = !boldBtn.Checked;

            if ((this.ActiveMdiChild as Child).RichTextBoxChild.SelectedText.Length > 0)
            {
                if ((this.ActiveMdiChild as Child).RichTextBoxChild.SelectionFont.Bold)
                {
                    (this.ActiveMdiChild as Child).RichTextBoxChild.SelectionFont = new Font((this.ActiveMdiChild as Child).RichTextBoxChild.SelectionFont, (this.ActiveMdiChild as Child).RichTextBoxChild.SelectionFont.Style & ~FontStyle.Bold);
                }
                else
                {
                    (this.ActiveMdiChild as Child).RichTextBoxChild.SelectionFont = new Font((this.ActiveMdiChild as Child).RichTextBoxChild.SelectionFont, (this.ActiveMdiChild as Child).RichTextBoxChild.SelectionFont.Style | FontStyle.Bold);
                }
            }
            else
            {
                (this.ActiveMdiChild as Child).RichTextBoxChild.Font = new Font((this.ActiveMdiChild as Child).RichTextBoxChild.Font, FontStyle.Bold);
            }
        }
        //підкреслювання тексту
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            //налаштовуємо втиснення клавіши
            var underlineBtn = (sender as ToolStripButton);
            underlineBtn.Checked = !underlineBtn.Checked;

            if ((this.ActiveMdiChild as Child).RichTextBoxChild.SelectedText.Length > 0)
            {
                if ((this.ActiveMdiChild as Child).RichTextBoxChild.SelectionFont.Underline)
                {
                    (this.ActiveMdiChild as Child).RichTextBoxChild.SelectionFont = new Font((this.ActiveMdiChild as Child).RichTextBoxChild.SelectionFont, (this.ActiveMdiChild as Child).RichTextBoxChild.SelectionFont.Style & ~FontStyle.Underline);
                }
                else
                {
                    (this.ActiveMdiChild as Child).RichTextBoxChild.SelectionFont = new Font((this.ActiveMdiChild as Child).RichTextBoxChild.SelectionFont, (this.ActiveMdiChild as Child).RichTextBoxChild.SelectionFont.Style | FontStyle.Underline);
                }
            }
            else
            {
                (this.ActiveMdiChild as Child).RichTextBoxChild.Font = new Font((this.ActiveMdiChild as Child).RichTextBoxChild.Font, FontStyle.Underline);
            }
        }
        //пункт меню, який закриває форму
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private int id = 0;
        public int COUNT_ITEMS => 8;

        public ToolStripItemCollection WindowDropDownItems => windowToolStripMenuItem.DropDownItems;

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var child = new Child();
            child.MdiParent = this;
            child.Text = $"Child {++id}";

            if(windowToolStripMenuItem.DropDownItems.Count == COUNT_ITEMS - 1)
            {
                var separator = new ToolStripSeparator();
                windowToolStripMenuItem.DropDownItems.Add(separator);
            }

            var item = new ToolStripMenuItem(child.Text, null, new EventHandler((o, s) =>
            {
                child.Activate();
            }));

            windowToolStripMenuItem.DropDownItems.Add(item);

            child.Show();
            
        }
        //зміна кольору фону текста
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            //налаштовуємо втиснення клавіши
            var backColorBtn = (sender as ToolStripButton);
            backColorBtn.Checked = !backColorBtn.Checked;

            var colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                if ((this.ActiveMdiChild as Child).RichTextBoxChild.SelectedText.Length > 0) //(this.ActiveMdiChild as Child).RichTextBoxChild - використовуємо richTextBox для дочірньої форми через властивість RichTextBoxChild
                {
                    (this.ActiveMdiChild as Child).RichTextBoxChild.SelectionBackColor = colorDialog.Color;
                }
                else
                {
                    (this.ActiveMdiChild as Child).RichTextBoxChild.BackColor = colorDialog.Color;
                }
            }
        }

        // Пункт меню, який очищає (this.ActiveMdiChild as Child).RichTextBoxChild
        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (this.ActiveMdiChild as Child).RichTextBoxChild.Clear();
        }
        //Розмір шрифта через подію
        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //var length = (this.ActiveMdiChild as Child).RichTextBoxChild.SelectedText.Length;
            if ((this.ActiveMdiChild as Child).RichTextBoxChild.SelectedText.Length > 0)
            {
                (this.ActiveMdiChild as Child).RichTextBoxChild.SelectionFont = new Font((this.ActiveMdiChild as Child).RichTextBoxChild.SelectionFont.FontFamily, float.Parse(toolStripComboBox1.Text), (this.ActiveMdiChild as Child).RichTextBoxChild.SelectionFont.Style);
            }
            else
            {
                (this.ActiveMdiChild as Child).RichTextBoxChild.Font = new Font((this.ActiveMdiChild as Child).RichTextBoxChild.SelectionFont.FontFamily, float.Parse(toolStripComboBox1.Text), (this.ActiveMdiChild as Child).RichTextBoxChild.SelectionFont.Style);
            }
        }
        // відображення тексту з ліва
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            //налаштовуємо втиснення клавіши
            var leftTextBtn = (sender as ToolStripButton);
            leftTextBtn.Checked = !leftTextBtn.Checked;
            if ((this.ActiveMdiChild as Child).RichTextBoxChild.SelectedText.Length > 0)
            {
                //(this.ActiveMdiChild as Child).RichTextBoxChild.SelectAll();
                (this.ActiveMdiChild as Child).RichTextBoxChild.SelectionAlignment = HorizontalAlignment.Left;
            }
        }

        // відображення тексту по центру
        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            //налаштовуємо втиснення клавіши
            var centerTextBtn = (sender as ToolStripButton);
            centerTextBtn.Checked = !centerTextBtn.Checked;
            if ((this.ActiveMdiChild as Child).RichTextBoxChild.SelectedText.Length > 0)
            {
                //(this.ActiveMdiChild as Child).RichTextBoxChild.SelectAll();
                (this.ActiveMdiChild as Child).RichTextBoxChild.SelectionAlignment = HorizontalAlignment.Center;
            }
        }

        // відображення тексту з права
        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            //налаштовуємо втиснення клавіши
            var leftTextBtn = (sender as ToolStripButton);
            leftTextBtn.Checked = !leftTextBtn.Checked;
            if ((this.ActiveMdiChild as Child).RichTextBoxChild.SelectedText.Length > 0)
            {
                //(this.ActiveMdiChild as Child).RichTextBoxChild.SelectAll();
                (this.ActiveMdiChild as Child).RichTextBoxChild.SelectionAlignment = HorizontalAlignment.Right;
            }
        }
        //за допомогою події в toolStripComboBox2 виділеному тексту змінюємо формат тексту
        private void toolStripComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            (this.ActiveMdiChild as Child).RichTextBoxChild.SelectionFont = new Font(toolStripComboBox2.SelectedItem.ToString(), (this.ActiveMdiChild as Child).RichTextBoxChild.SelectionFont.Size);
        }
        //кнопка включення/виключення форматування абзаців як списку
        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            //налаштовуємо втиснення клавіши
            var abzacTextBtn = sender as ToolStripButton;
            abzacTextBtn.Checked = !abzacTextBtn.Checked;
            (this.ActiveMdiChild as Child).RichTextBoxChild.SelectionIndent += 20;
        }

        //пункт меню Copy
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText((this.ActiveMdiChild as Child).RichTextBoxChild.SelectedText);
        }

        //пункт меню Paste
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (this.ActiveMdiChild as Child).RichTextBoxChild.SelectedText = Clipboard.GetText();
        }

        //пункт меню CutOut (вирізати)
        private void coutOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (this.ActiveMdiChild as Child).RichTextBoxChild.Cut();
        }

        //пункт меню SelectAll (Виділити все)
        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (this.ActiveMdiChild as Child).RichTextBoxChild.SelectAll();
        }
    }
}
