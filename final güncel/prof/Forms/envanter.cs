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
    public partial class envanter : Form
    {
        public envanter()
        {
            InitializeComponent();
            this.Text = string.Empty;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
        SqlConnection bagla = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=stok;Integrated Security=True");
        public void verilerigöster(string veriler)
        {
            SqlDataAdapter da = new SqlDataAdapter(veriler, bagla);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void envanter_Load(object sender, EventArgs e)
        {
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            verilerigöster("Select *from stoku");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Lütfen gerekli alanları doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            bagla.Open();
            SqlCommand komut = new SqlCommand("DELETE FROM stoku WHERE plaka='" + textBox1.Text + "'", bagla);
            komut.ExecuteNonQuery();
            verilerigöster("Select *from stoku");
            bagla.Close();
            MessageBox.Show("Kayıt Başarıyla Silindi!");
            textBox1.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
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

        private void button4_Click(object sender, EventArgs e)
        {
            textBox2.Text = "0";
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                textBox2.Text = Convert.ToString(double.Parse(textBox2.Text) + double.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString()));
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label4.Text = dataGridView1.Rows.Count.ToString();
        }
    }
}
