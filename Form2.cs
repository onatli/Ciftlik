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
    public partial class Form2 : Form
    {
        private void EkranGuncelle()
        {
            txt_TavukSayi.Text = tavuk.sayi.ToString() + " ADET";
            txt_OrdekSayi.Text = ordek.sayi.ToString() + " ADET";
            txt_KeciSayi.Text = keci.sayi.ToString() + " ADET";
            txt_InekSayi.Text = inek.sayi.ToString() + " ADET";
            lbl_Yem.Text = yem + " KG";
            lbl_TavukYum.Text = TavukYum + " ADET";
            lbl_OrdekYum.Text = OrdekYum + " ADET";
            lbl_InekSut.Text = InekSut + " KG";
            lbl_InekSut.Text = InekSut + " KG";
            lbl_KeciSut.Text = KeciSut + " KG";
            lbl_Para.Text = para + " TL";

            bar_TavukCan.Value = tavuk.verimlilik;
            bar_OrdekCan.Value = ordek.verimlilik;
            bar_InekCan.Value = inek.verimlilik;
            bar_KeciCan.Value = keci.verimlilik;



        }

        private void VeritabaniGuncelle()
        {
            string Guncelle = "UPDATE Depo SET T_Yumurta=" + TavukYum + ", O_Yumurta=" + OrdekYum + ", I_Sut=" + InekSut + ", K_Sut=" + KeciSut + ", Yem=" + yem + ", Para=" + para + " WHERE Kullanici_Id=" + id;
            Baglanti.Open();
            SqlCommand GuncelleDepo = new SqlCommand(Guncelle, Baglanti);
            GuncelleDepo.ExecuteNonQuery();
            Baglanti.Close();
            Guncelle = "UPDATE Hayvan Set T_Sayi=" + tavuk.sayi + ", T_Can=" + tavuk.verimlilik + ", O_Sayi=" + ordek.sayi + ", O_Can=" + ordek.verimlilik + ", K_Sayi=" + keci.sayi + ", K_Can=" + keci.verimlilik + ", I_Sayi=" + inek.sayi + ", I_Can=" + inek.verimlilik + " WHERE Kullanici_Id=" + id;
            Baglanti.Open();
            SqlCommand GuncelleHayvan = new SqlCommand(Guncelle, Baglanti);
            GuncelleHayvan.ExecuteNonQuery();
            Baglanti.Close();
        }

        private void vericek()
        {
            Baglanti.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\DB.mdf;Integrated Security=True";
            string komutsatiri = "SELECT * FROM Hayvan WHERE Kullanici_Id=" + id;
            Baglanti.Open();
            SqlCommand komut = new SqlCommand(komutsatiri, Baglanti);
            SqlDataReader vo = komut.ExecuteReader();
            vo.Read();
            tavuk.sayi = Convert.ToInt32(vo[2]);
            tavuk.verimlilik = Convert.ToInt32(vo[3]);
            ordek.sayi = Convert.ToInt32(vo[4]);
            ordek.verimlilik = Convert.ToInt32(vo[5]);
            keci.sayi = Convert.ToInt32(vo[6]);
            keci.verimlilik = Convert.ToInt32(vo[7]);
            inek.sayi = Convert.ToInt32(vo[8]);
            inek.verimlilik = Convert.ToInt32(vo[9]);
            vo.Close();
            komutsatiri = "SELECT * FROM Depo WHERE Kullanici_Id=" + id;
            komut = new SqlCommand(komutsatiri, Baglanti);
            vo = komut.ExecuteReader();
            vo.Read();
            TavukYum = Convert.ToInt32(vo[2]);
            OrdekYum = Convert.ToInt32(vo[3]);
            KeciSut = Convert.ToInt32(vo[4]);
            InekSut = Convert.ToInt32(vo[5]);
            yem = Convert.ToInt32(vo[6]);
            para = Convert.ToInt32(vo[7]);
            vo.Close();
            Baglanti.Close();
        }
        public Form2(string k_id)
        {
            InitializeComponent();
            id = k_id;
        }
        SqlConnection Baglanti = new SqlConnection();
        
        
        Tavuk tavuk = new Tavuk();
        Ordek ordek = new Ordek();
        Inek inek = new Inek();
        Keci keci = new Keci();
        int saniye,yem,para,TavukYum,OrdekYum,InekSut,KeciSut;
        string id;

               
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            timer2.Start();
            vericek();
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {            
            saniye++;
                        
            if (saniye % 3 == 0 && tavuk.yasam)
            {
                TavukYum+=tavuk.sayi;                
            }
            if (saniye % 5 == 0 && ordek.yasam)
            {
                OrdekYum+=ordek.sayi;                
            }
            if (saniye % 8 == 0 && inek.yasam)
            {
                InekSut+=inek.sayi;                
            }
            if (saniye % 10 == 0 && keci.yasam)
            {
                KeciSut+=keci.sayi;                
            }
            if (saniye%10==0)
            {
                tavuk.update();
                ordek.update();
                inek.update();
                keci.update();
            }
        }
        int sayac = 0;
        private void timer2_Tick(object sender, EventArgs e)
        {
            EkranGuncelle();

            sayac++;
            if (sayac % 10 == 0)
            {
                VeritabaniGuncelle();
                sayac = 0;
            }


        }
        //BUTONLAR
        //Yem verme butonları
        private void btn_TavukYemVer_Click(object sender, EventArgs e)
        {
            if (yem >= 1 * tavuk.sayi)
            {
                tavuk.verimlilik = 100;
                yem -= 1 * tavuk.sayi;
                tavuk.yasam = true;
            }
        }
        private void btn_OrdekYemVer_Click(object sender, EventArgs e)
        {
            if (yem >= 2 * ordek.sayi)
            {
                ordek.verimlilik = 100;
                yem -= 2 * ordek.sayi;
                ordek.yasam = true;
            }
        }
        private void btn_InekYemVer_Click(object sender, EventArgs e)
        {
            if (yem >= 4 * inek.sayi)
            {
                inek.verimlilik = 100;
                yem -= 4 * inek.sayi;
                inek.yasam = true;
            }
        }
        private void btn_KeciYemVer_Click(object sender, EventArgs e)
        {
            if (yem >= 3 * keci.sayi)
            {
                keci.verimlilik = 100;
                yem -= 3 * keci.sayi;
                keci.yasam = true;
            }
        }
        //Yem satın alma butonları
        private void Btn_YemAl10_Click(object sender, EventArgs e)
        {
            if ( para>=5)
            {
                yem += 10;
                para -= 5;
            }
        }
        private void Btn_YemAl100_Click(object sender, EventArgs e)
        {
            if (para>=50)
            {
                yem += 100;
                para -= 50;
            }
        }//Hayvan satın alma butonları
        private void Btn_TavukAl_Click(object sender, EventArgs e)
        {
            if (para>=10)
            {
                tavuk.sayi++;
                para -= 10;
                txt_TavukSayi.Text = tavuk.sayi + " ADET";
            }
        }
        private void Btn_OrdekAl_Click(object sender, EventArgs e)
        {
            if (para>=30)
            {
                ordek.sayi++;
                para -= 30;
                txt_OrdekSayi.Text = ordek.sayi + " ADET";
            }
        }
        private void Btn_KeciAl_Click(object sender, EventArgs e)
        {
            if (para>=70)
            {
                keci.sayi++;
                para -= 70;
                txt_KeciSayi.Text = keci.sayi + " ADET";
            }
        }                
        private void Btn_InekAl_Click(object sender, EventArgs e)
        {
            if (para>=100)
            {
                inek.sayi++;
                para -= 100;
                txt_InekSayi.Text = inek.sayi + " ADET";
            }
        }
        //Ürün satma butonları
        private void btn_TavukYumSat_Click(object sender, EventArgs e)
        {
            para += TavukYum * 1;
            TavukYum = 0;
        }
        private void btn_OrdekYumSat_Click(object sender, EventArgs e)
        {
            para += OrdekYum * 3;
            OrdekYum = 0;
        }
        private void btn_InekSutSat_Click(object sender, EventArgs e)
        {
            para += InekSut * 5;
            InekSut = 0;
        }
        private void btn_KeciSutSat_Click(object sender, EventArgs e)
        {
            para += KeciSut * 8;
            KeciSut = 0;
        }
    }
}
