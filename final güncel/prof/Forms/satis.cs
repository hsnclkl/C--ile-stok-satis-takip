using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace prof.Forms
{
    public partial class satis : Form
    {
        public satis()
        {
            InitializeComponent();
        }
        SqlConnection bagla = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=stok;Integrated Security=True");
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(textBox5.Text))
            {
                MessageBox.Show("Lütfen gerekli alanları doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int n1 = int.Parse(textBox3.Text);
            int n2 = int.Parse(textBox4.Text);
            int n3 = int.Parse(textBox5.Text);
            textBox6.Text = (n3 - n2 - n1).ToString();




        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(textBox5.Text) || string.IsNullOrEmpty(textBox6.Text))
            {
                MessageBox.Show("Lütfen gerekli alanları doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            bagla.Open();
            SqlCommand komut2 = new SqlCommand("Insert into rapor (alisfiyat,masraflar,satisfiyat,netkar,tarih,plaka) values (@alisfiyat,@masraflar,@satisfiyat,@netkar,@tarih,@plaka)", bagla);
            komut2.Parameters.AddWithValue("@alisfiyat", textBox3.Text);
            komut2.Parameters.AddWithValue("@masraflar", textBox4.Text);
            komut2.Parameters.AddWithValue("@satisfiyat", textBox5.Text);
            komut2.Parameters.AddWithValue("@netkar", textBox6.Text);
            komut2.Parameters.AddWithValue("@tarih", textBox2.Text);
            komut2.Parameters.AddWithValue("@plaka", textBox1.Text);
            komut2.ExecuteNonQuery();

            bagla.Close();
            MessageBox.Show("Satış işlemi başarılı!");


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }

        private void satis_Load(object sender, EventArgs e)
        {

        }
    }
}
