using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace myPPC3
{
    public partial class PasswordWindow : Form
    {
        private Form1 mainWindow;
        public PasswordWindow(Form1 win)
        {
            InitializeComponent();
            mainWindow = win;
            Visible = true;
            Show();
            Location = new Point(0, 0);
            Width = 240;
            Height = 290;
            WindowState = FormWindowState.Maximized;
        }

        private void CancelButton(object sender, EventArgs e)
        {
            this.Close();
        }


        private void NumberButton(object sender, EventArgs e)
        {


            Button b = (Button)sender;
            string nowContent = "";
            for (int i = 0; i < 4; i++)
            {
                if ((label2.Text[i]) != '*')
                {
                    nowContent += label2.Text[i];
                }
            }
            if (nowContent.Length < 4)
            {

                nowContent += b.Text;
                string zvezda = "";
                for (int i = 0; i < 4 - nowContent.Length; i++)
                {
                    zvezda += "*";
                }
                label2.Text = nowContent + zvezda;
            }

        }

        private void ConfirmationButton(object sender, EventArgs e)
        {
            if (label2.Text[3] == '*')
            {
                return;
            }

            //this.SendToBack();
            //this.Hide();
            
            if (mainWindow.returnedPassword_Changed != null)
            {
                mainWindow.returnedPassword_Changed(label2.Text);
            }

            Close();
        }


    }
}