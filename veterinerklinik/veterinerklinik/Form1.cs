using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace veterinerklinik
{
    public partial class Form1 : Form
    {
        string connectionString = @"Server=LAPTOP-CRT4S7MC\SQLEXPRESS;Database=VeterinerKlinik;Trusted_Connection=True;TrustServerCertificate=True;";
        public Form1()
        {
            InitializeComponent();
        }
        private void SahipleriGetir()
        {
            using (SqlConnection baglanti=new SqlConnection(connectionString))
            {
                string sorgu = "SELECT SahipID,AdSoyad,Telefon,Eposta,Adres From Sahipler";

                SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);

                DataTable dt = new DataTable();

                da.Fill(dt);

                dgvSahipler.DataSource = dt;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            SahipleriGetir();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            using (SqlConnection baglanti = new SqlConnection(connectionString))
            {
                string sorgu = "SELECT SahipID, AdSoyad, Telefon, Eposta, Adres " +
                       "FROM Sahipler WHERE AdSoyad LIKE @arama";

                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@arama", "%" + txtArama.Text + "%");

                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();

                da.Fill(dt);

                dgvSahipler.DataSource = dt; 
            }
        }
    }
}
