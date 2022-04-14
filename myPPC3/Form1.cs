using System;
using System.IO;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.Data;
using System.Threading;



using Microsoft.WindowsCE.Forms;
using System.Reflection;
using System.Text;


namespace myPPC3
{
    public partial class Form1 : Form
    {
        public Action<string> returnedPassword_Changed;
        private bool isMapSelected;
        private int nowMapSize;
        Bitmap bmp;

        //System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        Point temp = new Point();
        private Boolean dragInProgress = false;
        int MouseDownX = 0;
        int MouseDownY = 0;

        public Form1()
        {
            InitializeComponent();

           // tabPage1.Size = 

            isMapSelected = true;
            nowMapSize = 3;
            returnedPassword_Changed += CheckPassword;
           
            //timer.Interval = 3000;
            //timer.Enabled = false;
            //timer.Tick += new EventHandler(timer_Tick);
        }

        //void timer_Tick(object sender, EventArgs e)
        //{
        //    ShowLabel("tets");

            //timer.Enabled = false;
        //}

        private void Form1_Load(object sender, EventArgs e)
        {
            bmp = new Bitmap("\\Storage Card\\IMAGES\\0000.png");
            pictureBox1.Height = 297;
            pictureBox1.Width = 240;
            pictureBox1.Image = bmp;

            tabPage1.Text = "          ÊÀÐÒÀ          ";
            tabPage2.Text = "          ÌÅÍÞ          ";
        }

        private void ChangePage(object sender, EventArgs e)
        {
            if (isMapSelected)
            {

            }
        }
        private void DrawMap()
        {

        }
        private void DrawMenu()
        {

        }



        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (!this.dragInProgress)
            {
                this.dragInProgress = true;
                this.MouseDownX = e.X;
                this.MouseDownY = e.Y;
            }
            return;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            temp.X = this.pictureBox1.Location.X + (e.X - MouseDownX);
            temp.Y = this.pictureBox1.Location.Y + (e.Y - MouseDownY);
            if (temp.X > 0) temp.X = 0;
            if (temp.X < -(pictureBox1.Width - 240)) temp.X = -(pictureBox1.Width - 240);
            if (temp.Y > 0) temp.Y = 0;
            if (temp.Y < -(pictureBox1.Height - 297)) temp.Y = -(pictureBox1.Height - 297);

            this.pictureBox1.Location = temp;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.dragInProgress = false;
            }
            return;
        }

        private void MapZoomIn(object sender, EventArgs e)
        {
            // ñäåëàòü êàðòó êðóïíåé
            if (nowMapSize > 1)
            {
                pictureBox1.Height = pictureBox1.Height * 2;
                pictureBox1.Width = pictureBox1.Width * 2;
                temp.X = -(pictureBox1.Width / 2);
                temp.Y = -(pictureBox1.Height / 2);
                pictureBox1.Location = temp;
                pictureBox1.Visible = true;
                //MessageBox.Show("/2");

                nowMapSize--;
            }
        }

        private void MapZoomOut(object sender, EventArgs e)
        {
            // ñäåëàòü êàðòó ìåëü÷å
            if (nowMapSize < 3)
            {
                //MessageBox.Show("297 240");
                pictureBox1.Height = pictureBox1.Height / 2;
                pictureBox1.Width = pictureBox1.Width / 2;
                if (pictureBox1.Height == 297)
                {
                    temp.X = 0;
                    temp.Y = 0;
                }
                else
                {
                    temp.X = -(pictureBox1.Width / 2);
                    temp.Y = -(pictureBox1.Height / 2);
                }
                pictureBox1.Location = temp;
                pictureBox1.Visible = true;

                nowMapSize++;
            }
        }

        private void OpenPassword(object sender, EventArgs e)
        {
            //this.Hide();
            PasswordWindow pass = new PasswordWindow(this);
            pass.Show();
        }

        delegate void MyAction(string x);

        private void CheckPassword(string pass)
        {
            if (pass == "7632")
            {
                Application.Exit();
            }
            //timer.Enabled = true;



            string fullpath = "\\Storage Card\\IMAGES\\" + pass + ".PNG";
            string[] allFiles = Directory.GetFiles("\\Storage Card\\IMAGES\\");


            for (int i = 0; i < allFiles.Length; i++)
            {
                //t2 += allFiles[i] + "\n";
                if (fullpath == allFiles[i])
                {
                    bmp = new Bitmap(fullpath);
                    pictureBox1.Height = 297;
                    pictureBox1.Width = 240;
                    pictureBox1.Image = bmp;
                    temp.X = 0;
                    temp.Y = 0;
                    pictureBox1.Location = temp;
                    nowMapSize = 3;
                    //tabPage2.Hide();

                    //tabControl1.SelectedIndex = 0;
                    
                    //tabPage1.Show();
                    //tabPage1.Focus();
                    tabControl1.SelectedIndex = 0;
                    //tabControl1.
                    //MyAction a = ShowLabel("ÊÀÐÒÀ ÎÁÍÎÂËÅÍÀ");
                    //ShowLabel("ÊÀÐÒÀ ÎÁÍÎÂËÅÍÀ");

                    return;
                }
            }
            //ShowLabel("ÍÅÂÅÐÍÛÉ ÊÎÄ");
            //caption.BringToFront();
            //caption.Parent = tabPage2;
            //caption.Text = "ÍÅÂÅÐÍÛÉ ÊÎÄ";
            //caption.Show();
            //Thread.Sleep(3000);
            //notification1.


            /*switch (pass)
            {
                case "1986":
                    bmp = new Bitmap("\\Storage Card\\IMAGES\\1986.png");
                    pictureBox1.Height = 297;
                    pictureBox1.Width = 240;
                    pictureBox1.Image = bmp;

                    tabControl1.SelectedIndex = 0;
                    //MessageBox.Show("ÄÀÍÍÛÅ ÎÁÍÎÂËÅÍÛ","ÓÂÅÄÎÌËÅÍÈÅ");
                    //Thread showl = new Thread(ShowLabel);
                    //showl.Start();



                    break;
                case "1112":

                    break;
                case "1113":

                    break;
                case "7632":
                    Application.Exit();

                    break;
                default:

                    //MessageBox.Show("ÎØÈÁÊÀ ÑÂßÇÈ", "ÓÂÅÄÎÌËÅÍÈÅ");
                    break;
            }*/

        }
        public void ShowLabel(string text)
        {
            Label caption = new Label();

            caption.Location = new Point(0, 0);
            caption.BackColor = Color.Red;
            caption.Height = 50;
            caption.Width = 140;
            caption.TextAlign = ContentAlignment.TopCenter;
            //caption.Text = "TEST";
            caption.Visible = true;
            caption.Parent = this.tabPage1;
            //Thread.Sleep(2000);

            caption.BringToFront();
            caption.Text = text;
            caption.Show();

            Thread.Sleep(3000);
            caption.Dispose();
            tabPage2.Show();
            MessageBox.Show("end label");
        }

       

        private void Exit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void ArchiveOpen(object sender, EventArgs e)
        {
            ArchiveCPC pass = new ArchiveCPC();
            pass.Show();
        }
    }
}