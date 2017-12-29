using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GetFilePath;

namespace GetFilePath
{
    public partial class Form1 : Form
    {
        GetFilePath.GetFilePathLib  path_getter;
        public Form1()
        {
            InitializeComponent();
            path_getter = new GetFilePathLib();
        }


        private void filepathtext_DragDrop(object sender, DragEventArgs e)
        {
            string[] file_names =(string[])e.Data.GetData(DataFormats.FileDrop, false);
            List<string> file_paths = path_getter.getPaths(file_names);
            this.file_paths.Text = string.Join("\r\n", file_paths);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(file_paths.Text);
        }

        private void Form1_Shown(object sender, EventArgs e)
        {

        }
    }
}
