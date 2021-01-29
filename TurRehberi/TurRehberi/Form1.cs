using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TurRehberi
{
    public partial class frmTurRehberi : Form
    {
        public frmTurRehberi()
        {
            InitializeComponent();
        }
        //BURADAN ADMİN VEYA KULLANICI İSEK SEÇİM YAPIP UYGUN FORMA GİTMEMİZİ SAĞLAYACAK BUTONLARI EKLİYİP KODLARI DÖKTÜM.
        private void btnAdminGiriş_Click(object sender, EventArgs e)
        {
            AdminGiriş AdminGirişi = new AdminGiriş();
            AdminGirişi.Show();
            this.Hide();
        }

        private void btnKullanıcıGiriş_Click(object sender, EventArgs e)
        {
            KullanıcıGiriş KullanıcıGirişi = new KullanıcıGiriş();
            KullanıcıGirişi.Show();
            this.Hide();
        }

        //Hakkımızda bilgi almak isteyenler için MessageBox komutuna gerekli bilgileri yazdım;
        private void btnHakkımızda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Dünya turuna çıkmayı,gezmeyi,anılarımı fotoğraflamayı ve paylaşmayı çok seviyorum. Ve bir gün bunları en güzel bu şekilde sizi daha iyi bilgilendirerek paylaşabileceğim. Bol bol gezin :)                                                                                                       İrtibat İçin = 0534 602 91 93                                                                                                 Gmail=mahmutenes123@gmail.com ");
        }
    }
}
