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
using ClosedXML;
using ClosedXML.Excel;


namespace prof.Forms
{
    public partial class rapor : Form
    {
        SqlConnection bagla = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=stok;Integrated Security=True");

        public rapor()
        {
            InitializeComponent();
        }

        public void verilerigöster(string veriler)
        {
            SqlDataAdapter da = new SqlDataAdapter(veriler, bagla);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            verilerigöster("Select * from rapor");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Lütfen gerekli alanları doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            bagla.Open();
            SqlCommand komut = new SqlCommand("DELETE FROM rapor WHERE numara=@numara", bagla);
            komut.Parameters.AddWithValue("@numara", textBox1.Text);
            komut.ExecuteNonQuery();
            verilerigöster("Select * from rapor");
            bagla.Close();
            MessageBox.Show("Kayıt Başarıyla Silindi!");
            textBox1.Clear();
        }

        private void buttonexport_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (XLWorkbook workbook = new XLWorkbook())
                        {
                            DataTable dt = (DataTable)dataGridView1.DataSource; // Bu satırı ekledik
                            if (dt != null)
                            {
                                workbook.Worksheets.Add(dt, "Rapor");
                                workbook.SaveAs(sfd.FileName);
                            }
                        }
                        MessageBox.Show("Kayıt Başarılı!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void rapor_Load(object sender, EventArgs e)
        {

        }
    }
}