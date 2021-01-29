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
    public partial class AdminGiriş : Form
    {
        public AdminGiriş()
        {
            InitializeComponent();
        }
        private void btnAdminGirişYap_Click(object sender, EventArgs e)
        {   //ADMİNİN SİSTEME DOĞRU GİRİŞ YAPMASI HALİNDE AÇILIYOR AKSİ TAKTİRDE(ELSE) BİZE HATA VERİYOR;
            if (txtAdminID.Text == "sistemegiriş" && txtAdminŞifre.Text == "12345")
            {
                AdminGiriş AdminGiriş = new AdminGiriş();
                AdminGiriş.Show();
                this.Close();

                Adminİçin Admin = new Adminİçin();
                Admin.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Giriş Yaptınız!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAdminID.Clear();
                txtAdminŞifre.Clear();
                txtAdminID.Focus();
            }
        }
        private void btnGeriAdmin_Click(object sender, EventArgs e)
        {   //Bizi Geri butonuna bastığımız zaman bir önceki forma gideceğimiz kodları yazdım;
            this.Close();
            frmTurRehberi Tr = new frmTurRehberi();
            Tr.Show();
        }

        private void chkŞifreGösterAdmin_CheckedChanged(object sender, EventArgs e)
        {
            //checkBox işaretli ise
            if (chkŞifreGösterAdmin.Checked)
            {
                //karakteri göster.
                txtAdminŞifre.PasswordChar = char.Parse("\0");
            }
            //değilse karakterlerin yerine * koy.
            else
            {
                txtAdminŞifre.PasswordChar = char.Parse("*");
            }
        }
    }
}
