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

namespace TurRehberi
{
    public partial class Kaydol : Form
    {
        public Kaydol()
        {
            InitializeComponent();

            cmbCinsiyet.Items.Add("Erkek");
            cmbCinsiyet.Items.Add("Kadın");
        }

        //Burada "TurRehberim"adlı bir metod oluşturup bu metod ile görüntülüyoruz ve bu metod içine ekleyeceklerimizi ekleyip okutuyoruz;
        SqlConnection Kayit = new SqlConnection(@"Data Source=DESKTOP-SERVET-\SQLEXPRESS;Initial Catalog=TurRehberi;Integrated Security=True");
        //SqlConnection Kayıt = new SqlConnection("Data Source=MHMTENS13\\MHMTENS13;Initial Catalog=TurRehberi;Integrated Security=True");
        private void btnKaydol_Click(object sender, EventArgs e)
        {   //KAYIT OLMAK İÇİN GİRİLEN BİLGİLERİ SİSTEME KAYDETMEMİZİ SAĞLAYACAK KODLARI YAZDIM;
            Kayit.Open();
            SqlCommand KytOll = new SqlCommand("Insert into Kullanici(AdSoyad,KullaniciAdi,KullaniciSifre,Eposta,CepTelefonu,Cinsiyet)values(@AdSoyad1,@KullaniciAdi1,@KullaniciSifre1,@Eposta1,@CepTelefonu1,@Cinsiyet1)", Kayit);
            KytOll.Parameters.AddWithValue("@AdSoyad1", txtAdSoyad.Text);
            KytOll.Parameters.AddWithValue("@KullaniciAdi1", txtKayıtID.Text);
            KytOll.Parameters.AddWithValue("@KullaniciSifre1", txtKayıtŞifre.Text);
            KytOll.Parameters.AddWithValue("@Eposta1", txtEposta.Text);
            KytOll.Parameters.AddWithValue("@CepTelefonu1", mskCepTel.Text);
            KytOll.Parameters.AddWithValue("@Cinsiyet1", cmbCinsiyet.Text);
            KytOll.ExecuteNonQuery();
            Kayit.Close();

            //Yeni bir kayıt oluşturmak için kutuların içini CLEAR komutu ile temizliyoruz;
            txtAdSoyad.Clear();
            txtKayıtID.Clear();
            txtKayıtŞifre.Clear();
            txtEposta.Clear();
            mskCepTel.Text = "";
            cmbCinsiyet.Text = "";

            //Kayıtımız gerçekleştikten sonra bize "Kayıdınız gerçekleşmiştir."diye bilgi mesajı vermesini sağlayacağımız kodu yazdım;
            MessageBox.Show("Kaydınız gerçekleşmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
