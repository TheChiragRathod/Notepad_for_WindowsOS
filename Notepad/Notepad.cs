using System;
using System.IO;
using System.Windows.Forms;

namespace Notepad
{
    public partial class Notepad : Form
    {
        string path=null;
        string filename = null;
        String Title= "Untitled - Notepad";

        public Notepad()
        {
            InitializeComponent();
            this.Text = Title;
        }
        public void changeTitle()
        {
            if (filename == null)
                this.Text = "*Untitled - Notepad";
            else
                this.Text = "*" + filename;
        }
        


        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
                path = String.Empty;
                richTextBox.Clear();
                this.Text = "Untitled - Notepad";
            
                
            
           
        }

        private  void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFD.InitialDirectory = "C:";
            openFD.Title = "Open text file";
            openFD.FileName = "";
            openFD.Filter = "Text file | *.txt";
            if(openFD.ShowDialog()!=DialogResult.Cancel)
            {
                StreamReader sr = new StreamReader(openFD.FileName);
                path = openFD.FileName;
                richTextBox.Text = sr.ReadToEnd();
                sr.Dispose();
                Title= split_filename(path) + " - Notepad";
                this.Text = Title;
                filename = Title;
            }
        }

        private  void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(path))
                {
                    saveFD.InitialDirectory = "C:";
                    saveFD.FileName = "";
                    saveFD.Title = "Save File";
                    saveFD.Filter = "Text file | *.txt";
                    if (saveFD.ShowDialog() == DialogResult.OK)
                    {
                        path = saveFD.FileName;
                        richTextBox.SaveFile(saveFD.FileName, RichTextBoxStreamType.PlainText);
                        Title = split_filename(path) + " - Notepad";
                        this.Text = Title;
                        filename = Title;
                    }


                }
                else
                {
                    path = saveFD.FileName;
                    richTextBox.SaveFile(path, RichTextBoxStreamType.PlainText);
                    Title = split_filename(path) + " - Notepad";
                    this.Text = Title;
                    filename = Title;
                }
            }
            catch(Exception objExc)
            {
                MessageBox.Show(objExc.Message);
            }
      
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFD.InitialDirectory = "C:";
            saveFD.FileName = "";
            saveFD.Title = "Save File";
            saveFD.Filter = "Text file | *.txt";


            if (saveFD.ShowDialog() == DialogResult.OK)
            {
                path = saveFD.FileName;
                richTextBox.SaveFile(saveFD.FileName, RichTextBoxStreamType.PlainText);
                Title = split_filename(path) + " - Notepad";
                this.Text = Title;
                filename = Title;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.Show();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();

            if(fd.ShowDialog()==DialogResult.OK)
            {
                richTextBox.Font = fd.Font;
            }
        }
        public String split_filename(string path)
        {
            char[] backSlash= {'\\'};
            String[] strlist = path.Split(backSlash);
            return strlist[(strlist.Length) - 1];
        }

        private void TextChanged(object sender, EventArgs e)
        {
            changeTitle();
        }
    }
}