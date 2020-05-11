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

namespace ado.netCsharpuyg
{
    public partial class Form1 : Form
    {
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-2V0BFC8\SQLEXPRESS;Initial Catalog=OKULDB;Integrated Security=True");
        SqlCommand komut;
        SqlDataAdapter da;
        DataSet ds;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            griddoldur();
        }
        public void griddoldur()
        {
            da = new SqlDataAdapter("Select * from TBLogrenciyeni", baglanti);
            ds = new DataSet();
            baglanti.Open();
            da.Fill(ds, "TBLogrenciyeni");
            dataGridView1.DataSource = ds.Tables["TBLogrenciyeni"];
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            komut = new SqlCommand();
            baglanti.Open();
            komut.Connection = baglanti;
            komut.Parameters.AddWithValue("@ogrenci_no", Convert.ToInt32(textBox1.Text));
            komut.Parameters.AddWithValue("@ogrenci_ad", textBox2.Text);
            komut.Parameters.AddWithValue("@ogrenci_soyad", textBox3.Text);
            komut.Parameters.AddWithValue("@ogrenci_sehir", textBox4.Text);
            komut.CommandText =
            "insert into TBLogrenciyeni(ogrenci_no,ogrenci_ad,ogrenci_soyad,ogrenci_sehir)values(@ogrenci_no, @ogrenci_ad, @ogrenci_soyad, @ogrenci_sehir)";
            komut.ExecuteNonQuery();
            baglanti.Close();
            griddoldur();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            komut = new SqlCommand();
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "delete from TBLogrenciyeni where ogrenci_no=" + textBox1.Text + "";
            komut.ExecuteNonQuery();
            baglanti.Close();
            griddoldur();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                komut = new SqlCommand();
                baglanti.Open();
                komut.Connection = baglanti;
                komut.Parameters.AddWithValue("@ogrenci_no", Convert.ToInt32(textBox1.Text));
                komut.Parameters.AddWithValue("@ogrenci_ad", textBox2.Text);
                komut.Parameters.AddWithValue("@ogrenci_soyad", textBox3.Text);
                komut.Parameters.AddWithValue("@ogrenci_sehir", textBox4.Text);
                komut.CommandText = "update TBLogrenciyeni setogrenci_ad = @ogrenci_ad,ogrenci_soyad = @ogrenci_soyad,ogrenci_sehir = @ogrenci_sehir";
                komut.ExecuteNonQuery();
                baglanti.Close();
                griddoldur();


            }
            catch (Exception)
            {

                MessageBox.Show("Lütfen Boşlukları Doldurunuz!");
            }
            
        }
    }
}
