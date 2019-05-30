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

namespace Ciftlik
{
    public partial class Form1 : Form
    {        
        public string id;
        public Form1()
        {
            InitializeComponent();
        }
        System.Data.SqlClient.SqlConnection Baglanti = new System.Data.SqlClient.SqlConnection();
        private void Form1_Load(object sender, EventArgs e)
        {            
            Baglanti.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\DB.mdf;Integrated Security=True";
        }
        private void Btn_Giris_Click(object sender, EventArgs e)
        {            
            Baglanti.Open();
            string query = "SELECT * FROM Kullanici";
            SqlCommand cmd = new SqlCommand(query, Baglanti);
            SqlDataReader vo = cmd.ExecuteReader();
            Boolean giris = false;
            while (vo.Read())
            {
                if (vo[1].ToString() == txt_KAdi.Text && vo[2].ToString() == txt_Sifre.Text)
                {
                    id = vo[0].ToString();
                    giris = true;
                    Form2 frm = new Form2(id);
                    frm.Show(); 
                    this.Hide();
                    break;
                }
            }
            if (!giris)
            {
                lbl_Hata.ForeColor = Color.Red;
                lbl_Hata.Text = "Hatalı Giriş.";
                lbl_Hata.Visible = true;
            }
            Baglanti.Close();
        }
        private void Btn_KOlustur_Click(object sender, EventArgs e)
        {
            int test;
            string KullaniciEkle = "INSERT INTO Kullanici (Kullanici_Adi,Sifre)values ('" + txt_KAdi.Text + "','" + txt_Sifre.Text + "')";
            Baglanti.Open();
            SqlCommand komut1 = new SqlCommand(KullaniciEkle,Baglanti);
            test = komut1.ExecuteNonQuery();
            Baglanti.Close();
            if (test > 0)//Kullanıcı eklendi mi diye kontrol ediyor
            {
                lbl_Hata.ForeColor = Color.Green;
                lbl_Hata.Visible = true;
                lbl_Hata.Text = "Kullanıcı Eklendi";
                Baglanti.Open();
                //Son eklenen kullanıcının id'sini alıyor
                string komutsatiri = "SELECT TOP 1 Id FROM Kullanici ORDER BY Id DESC";
                SqlCommand komut2 = new SqlCommand(komutsatiri, Baglanti);
                SqlDataReader vo = komut2.ExecuteReader();
                vo.Read();
                id = Convert.ToString(vo[0]);
                vo.Close();
                //Alınan id için Depo tablosunda satır oluşturuyor
                KullaniciEkle = "INSERT INTO Depo (Kullanici_Id)values ("+id+")";
                SqlCommand komut3 = new SqlCommand(KullaniciEkle, Baglanti);
                komut3.ExecuteNonQuery();
                //Alınan id için Hayvan tablosunda satır oluşturuyor
                KullaniciEkle = "INSERT INTO Hayvan (Kullanici_Id)values (" + id + ")";
                SqlCommand komut4 = new SqlCommand(KullaniciEkle, Baglanti);
                komut4.ExecuteNonQuery();
                Baglanti.Close();
            }            
        }        
    }
}
