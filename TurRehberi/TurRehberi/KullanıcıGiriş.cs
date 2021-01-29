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
    public partial class KullanıcıGiriş : Form
    {
        public KullanıcıGiriş()
        {
            InitializeComponent();
        }

        //Sql Bağlantısı ==>
        SqlConnection TrRhbri = new SqlConnection(@"Data Source=DESKTOP-SERVET-\SQLEXPRESS;Initial Catalog=TurRehberi;Integrated Security=True");
        //SqlConnection TrRhbri = new SqlConnection("Data Source=MHMTENS13\\MHMTENS13;Initial Catalog=TurRehberi;Integrated Security=True");

        private void btnKullanıcıGirişYap_Click(object sender, EventArgs e)
        {   //SQL'DEKİ KAYITLI OLAN KULLANICININ BİLGİLERİNİ ÇEKİP TURREHBERİ'NE GİRMESİNE SAĞLAYACAK KODLARI YAZDIM.
            TrRhbri.Open();
            SqlCommand girisyap = new SqlCommand("select * from Kullanici where KullaniciAdi=@KullaniciAdi1 and KullaniciSifre=@KullaniciSifre1", TrRhbri);
            girisyap.Parameters.AddWithValue("@KullaniciAdi1", txtKullanıcıID.Text);
            girisyap.Parameters.AddWithValue("@KullaniciSifre1", txtKullanıcıŞifre.Text);
            SqlDataReader okugiris = girisyap.ExecuteReader();
            if (okugiris.Read())
            {
                Kullanıcıİçin KullaniciPaneli = new Kullanıcıİçin();
                KullaniciPaneli.Show();
            }
            else
            {
                MessageBox.Show("E-Posta Veya Şifre Hatalı", "HATALI GİRİŞ YAPILDI!");
            }
            TrRhbri.Close();
        }

        private void btnKullanıcıKaydol_Click(object sender, EventArgs e)
        {   //KAYIT OLMAK İÇİN GEREKLİ OLAN FORMU AÇMAMIZI SAĞLIYOR;
            Kaydol Kayıt = new Kaydol();
            Kayıt.Show();
        }

        private void btnŞifremiUnuttum_Click(object sender, EventArgs e)
        {   //ŞİFREMİ UNUTTUM ADLI FORMU AÇMAMIZI SAĞLIYORUZ;
            SifremiUnuttum YeniSifre = new SifremiUnuttum();
            YeniSifre.Show();
            this.Hide();
        }

        private void btnGeriKul_Click(object sender, EventArgs e)
        {   //Bastığımız zaman bizi bir önceki forma götürecek kodları yazdım;
            this.Close();
            frmTurRehberi Tr = new TurRehberi.frmTurRehberi();
            Tr.Show();
        }

        private void chkŞifreGösterKul_CheckedChanged(object sender, EventArgs e)
        {
            //CheckBox işaretli ise
            if (chkŞifreGösterKul.Checked)
            {
                //Karakteri göster.
                txtKullanıcıŞifre.PasswordChar = char.Parse("\0");
            }
            //Değilse karakterlerin yerine * koy.
            else
            {
                txtKullanıcıŞifre.PasswordChar = char.Parse("*");
            }
        }
    }
}