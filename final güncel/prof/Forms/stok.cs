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
    public partial class stok : Form
    {
        public stok()
        {
            InitializeComponent();
        }
        SqlConnection bagla = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=stok;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(textBox5.Text))
            {
                MessageBox.Show("Lütfen gerekli alanları doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            bagla.Open();
            SqlCommand komut = new SqlCommand("Insert into stoku (plaka,model,renk,tarih,alisfiyat,marka,masraflar,tel) values (@plaka,@model,@renk,@tarih,@alisfiyat,@marka,@masraflar,@tel)", bagla);
            komut.Parameters.AddWithValue("@plaka", textBox1.Text);
            komut.Parameters.AddWithValue("@model", textBox2.Text);
            komut.Parameters.AddWithValue("@renk", textBox3.Text);
            komut.Parameters.AddWithValue("@tarih", textBox4.Text);
            komut.Parameters.AddWithValue("@alisfiyat", textBox5.Text);
            komut.Parameters.AddWithValue("@marka", textBox6.Text);
            komut.Parameters.AddWithValue("@masraflar", textBox7.Text);
            komut.Parameters.AddWithValue("@tel", textBox8.Text);
            komut.ExecuteNonQuery();
            bagla.Close();
            MessageBox.Show("Başarıyla stok eklendi");

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
        }

        private void stok_Load(object sender, EventArgs e)
        {

        }
    }
}
