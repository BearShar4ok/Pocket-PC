using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.WindowsCE.Forms;
using System.Reflection;

namespace myPPC3
{
    public partial class ArchiveCPC : Form
    {
        public ArchiveCPC()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            Focus();
            BringToFront();
            //string fullpath = "\\Storage Card\\ARCHIVE\\" + pass + ".PNG";
            string[] allFiles = Directory.GetFiles("\\Storage Card\\ARCHIVE\\");

            for (int i = 0; i < allFiles.Length; i++)
            {
                //t2 += allFiles[i] + "\n";

                string[] template = allFiles[i].Split('\\');
                string text = (template[template.Length - 1].Split('.'))[0];

                listBox1.Items.Add(text);
                //bmp = new Bitmap(fullpath);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}