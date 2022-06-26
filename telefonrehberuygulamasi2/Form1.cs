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

namespace telefonrehberuygulamasi2
{
    public partial class Form1 : Form
    {
        SqlConnection baglanti;
        SqlCommand komut;
        SqlDataAdapter da;

        public Form1()
        {
            InitializeComponent();
        }
        void bilgilerigetir()
        {
            baglanti = new SqlConnection("server=.;Initial Catalog =rehber;Integrated Security=SSPI");
            baglanti.Open();
            da = new SqlDataAdapter("Select * from kisiler", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'rehberDataSet.Kisiler' table. You can move, or remove it, as needed.
            this.kisilerTableAdapter.Fill(this.rehberDataSet.Kisiler);
            bilgilerigetir();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = "insert into Kisiler(Ad,Soyad,Telefon) values (@ad,@soyad,@tel)";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@ad", textBox2.Text);
            komut.Parameters.AddWithValue("@soyad", textBox3.Text);
            komut.Parameters.AddWithValue("@tel", textBox4.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            bilgilerigetir();

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sorgu = "UPDATE kisiler SET Ad = @ad, Soyad = @soyad,Telefon = @telefon WHERE Id=@id";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@id", Convert.ToInt32(textBox1.Text));
            komut.Parameters.AddWithValue("@ad", textBox2.Text);
            komut.Parameters.AddWithValue("@soyad",textBox3.Text);
            komut.Parameters.AddWithValue("@telefon",textBox4.Text);

            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            bilgilerigetir();

        }
    }
}
