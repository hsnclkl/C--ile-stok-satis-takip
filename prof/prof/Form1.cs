using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.SqlClient;


namespace prof
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            this.Text = string.Empty;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

        }
        SqlConnection bagla = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=stok;Integrated Security=True");

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            label4.Text = DateTime.Now.ToLongDateString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Forms.satis satisForm = new Forms.satis();
            satisForm.TopLevel = false;
            satisForm.FormBorderStyle = FormBorderStyle.None;
            satisForm.Dock = DockStyle.Fill;

            panelhome.Controls.Clear();
            panelhome.Controls.Add(satisForm);
            satisForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Forms.stok satisForm = new Forms.stok();
            satisForm.TopLevel = false;
            satisForm.FormBorderStyle = FormBorderStyle.None;
            satisForm.Dock = DockStyle.Fill;

            panelhome.Controls.Clear();
            panelhome.Controls.Add(satisForm);
            satisForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Forms.envanter satisForm = new Forms.envanter();
            satisForm.TopLevel = false;
            satisForm.FormBorderStyle = FormBorderStyle.None;
            satisForm.Dock = DockStyle.Fill;

            panelhome.Controls.Clear();
            panelhome.Controls.Add(satisForm);
            satisForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Forms.rapor satisForm = new Forms.rapor();
            satisForm.TopLevel = false;
            satisForm.FormBorderStyle = FormBorderStyle.None;
            satisForm.Dock = DockStyle.Fill;

            panelhome.Controls.Clear();
            panelhome.Controls.Add(satisForm);
            satisForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Forms.about satisForm = new Forms.about();
            satisForm.TopLevel = false;
            satisForm.FormBorderStyle = FormBorderStyle.None;
            satisForm.Dock = DockStyle.Fill;

            panelhome.Controls.Clear();
            panelhome.Controls.Add(satisForm);
            satisForm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Forms.temiz satisForm = new Forms.temiz();
            satisForm.TopLevel = false;
            satisForm.FormBorderStyle = FormBorderStyle.None;
            satisForm.Dock = DockStyle.Fill;

            panelhome.Controls.Clear();
            panelhome.Controls.Add(satisForm);
            satisForm.Show();
        }

        private void panelBaslik_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
            {

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = DateTime.Now.ToString("hh:mm:ss");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }

}

