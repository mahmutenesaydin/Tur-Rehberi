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
    public partial class SifremiUnuttum : Form
    {
        public SifremiUnuttum()
        {
            InitializeComponent();
        }
        //Sql Bağlantısı ==>
        SqlConnection Güncelle = new SqlConnection(@"Data Source=DESKTOP-SERVET-\SQLEXPRESS;Initial Catalog=TurRehberi;Integrated Security=True");
        //SqlConnection Güncelle = new SqlConnection("Data Source=MHMTENS13\\MHMTENS13;Initial Catalog=TurRehberi;Integrated Security=True");

        private void btnŞifreGüncelle_Click(object sender, EventArgs e)
        {   //Şifreyi güncellemek için gerekli kodları UPDATE komutu ile yazıyoruz;
            Güncelle.Open();
            SqlCommand sifreguncelle = new SqlCommand("Update Kullanici set KullaniciSifre='" + txtYeniSifre.Text.ToString() + "'where KullaniciAdi='" + txtSifreGuncelleID.Text.ToString() + "'", Güncelle);
            sifreguncelle.ExecuteNonQuery();
            Güncelle.Close();
            //Şifre güncellendikten sonra bize mesaj vermesi için kodları yazdırıyoruz;
            MessageBox.Show("Şifreniz Başarıyla Güncellendi", "GÜNCELLEME BAŞARILI");
            this.Close();
        }
    }
}
