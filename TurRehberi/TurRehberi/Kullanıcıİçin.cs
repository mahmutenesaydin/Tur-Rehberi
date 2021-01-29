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
    public partial class Kullanıcıİçin : Form
    {
        //Sql Bağlantısı ==> Yeni Açtığımız Class'dan(SqlConnection Class'ı) çektik;
        SqlConnection TrRhberi = new SqlConnection(Connection.sqlConnectionDB);
        public Kullanıcıİçin()
        {
            InitializeComponent();
            TrRhberi.Open();
            SqlCommand komut = new SqlCommand("select UlkeID,UlkeAdı from Ulke", TrRhberi);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ComboboxItem cmbItem = new ComboboxItem();
                cmbItem.Value = Convert.ToInt32(oku["UlkeID"].ToString());
                cmbItem.Text = oku["UlkeAdı"].ToString();
                cmbUlkeAdıKul.Items.Add(cmbItem);
            }
            TrRhberi.Close();

        }

        private void TurRehberimm()
        {   //Eğer ki Ülke seçmeden görüntülemeye kalkarsak bize hata vermesi için kodları yazıyoruz;
            Resimler();
            if (cmbUlkeAdıKul.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen ülke seçiniz");
                return;
            }
            //ListViewlerimize ülke ve şehiri yazdıran kodları yazıyoruz;
            int secilenUlkeID = ((TurRehberi.ComboboxItem)cmbUlkeAdıKul.SelectedItem).Value;
            TrRhberi.Open();
            SqlCommand komut = new SqlCommand("select * from Ulke where UlkeID = @UlkeID", TrRhberi);
            komut.Parameters.AddWithValue("@UlkeID", secilenUlkeID);

            SqlDataReader okuUlke = komut.ExecuteReader();
            listViewÜlkeKul.Items.Clear();
            listViewŞehirKul.Items.Clear();

            while (okuUlke.Read())
            {
                ListViewItem ekleUlkee = new ListViewItem();
                ekleUlkee.Text = okuUlke["UlkeID"].ToString();
                ekleUlkee.SubItems.Add(okuUlke["UlkeAdı"].ToString());
                ekleUlkee.SubItems.Add(okuUlke["Başkenti"].ToString());
                ekleUlkee.SubItems.Add(okuUlke["Dini"].ToString());
                ekleUlkee.SubItems.Add(okuUlke["ParaBirimi"].ToString());
                ekleUlkee.SubItems.Add(okuUlke["Nufusu"].ToString());
                ekleUlkee.SubItems.Add(okuUlke["ResmiDili"].ToString());
                ekleUlkee.SubItems.Add(okuUlke["Kitasi"].ToString());
                ekleUlkee.SubItems.Add(okuUlke["YonetimŞekli"].ToString());
                listViewÜlkeKul.Items.Add(ekleUlkee);
            }
            TrRhberi.Close();

            int secilenSehirId = -1;
            if (cmbŞehirAdıKul.SelectedItem != null)
            {
                secilenSehirId = ((TurRehberi.ComboboxItem)cmbŞehirAdıKul.SelectedItem).Value;
            }

            TrRhberi.Open();
            if (cmbŞehirAdıKul.SelectedIndex == -1)
            {
                komut = new SqlCommand("Select * from Sehir where UlkeID=@UlkeID", TrRhberi);
                komut.Parameters.AddWithValue("@UlkeID", secilenUlkeID);
            }
            else if (secilenSehirId > -1)
            {   //Şehiri Sql'deki FOREIGN KEY'le bağladığmız Ülke'ye göre çağırıyoruz; 
                komut = new SqlCommand("Select * from Sehir where UlkeID=@UlkeID and SehirID = @SehirID", TrRhberi);
                komut.Parameters.AddWithValue("@SehirID", secilenSehirId);
                komut.Parameters.AddWithValue("@UlkeID", secilenUlkeID);
            }
            okuUlke = komut.ExecuteReader();
            listViewŞehirKul.Items.Clear();

            while (okuUlke.Read())
            {
                ListViewItem ekleSehirr = new ListViewItem();
                ekleSehirr.Text = okuUlke["SehirID"].ToString();
                ekleSehirr.SubItems.Add(okuUlke["PlakaKodu"].ToString());
                ekleSehirr.SubItems.Add(okuUlke["SehirAdi"].ToString());
                ekleSehirr.SubItems.Add(okuUlke["Nufusu"].ToString());
                ekleSehirr.SubItems.Add(okuUlke["NesiMeshur"].ToString());
                ekleSehirr.SubItems.Add(okuUlke["TuristlikYerler"].ToString());
                listViewŞehirKul.Items.Add(ekleSehirr);
            }
            TrRhberi.Close();
        }

        private void Resimler()
        {   //GİTMEK İSTEDİĞİMİZ ŞEHRİN RESMİNİ SİSTEME KAYDETİP PİCTUREBOX'DAN GÖZÜKMESİNİ SAĞLIYORUZ;
            switch (cmbŞehirAdıKul.Text)
            {
                case "Boston":
                    {
                        pictureGörsel.Image = Properties.Resources.Boston;
                        break;
                    }
                case "California":
                    {
                        pictureGörsel.Image = Properties.Resources.California;
                        break;
                    }
                case "Chicago":
                    {
                        pictureGörsel.Image = Properties.Resources.Chicago;
                        break;
                    }
                case "Los Angeles":
                    {
                        pictureGörsel.Image = Properties.Resources.LosAngeles;
                        break;
                    }
                case "Miami":
                    {
                        pictureGörsel.Image = Properties.Resources.Miami;
                        break;
                    }
                case "New York":
                    {
                        pictureGörsel.Image = Properties.Resources.NewYork;
                        break;
                    }
                case "Washington":
                    {
                        pictureGörsel.Image = Properties.Resources.Washington;
                        break;
                    }
                case "Berlin":
                    {
                        pictureGörsel.Image = Properties.Resources.Berlin;
                        break;
                    }
                case "Hamburg":
                    {
                        pictureGörsel.Image = Properties.Resources.Hamburg;
                        break;
                    }
                case "Köln":
                    {
                        pictureGörsel.Image = Properties.Resources.Cologne;
                        break;
                    }
                case "Münih":
                    {
                        pictureGörsel.Image = Properties.Resources.Munich;
                        break;
                    }
                case "Melbourne":
                    {
                        pictureGörsel.Image = Properties.Resources.Melbourne;
                        break;
                    }
                case "Sydney":
                    {
                        pictureGörsel.Image = Properties.Resources.Sydney;
                        break;
                    }
                case "Antwerp":
                    {
                        pictureGörsel.Image = Properties.Resources.Antwerp_jpeg;
                        break;
                    }
                case "Brugge":
                    {
                        pictureGörsel.Image = Properties.Resources.Brugge;
                        break;
                    }
                case "Brüksel":
                    {
                        pictureGörsel.Image = Properties.Resources.Brüksel;
                        break;
                    }
                case "Gent":
                    {
                        pictureGörsel.Image = Properties.Resources.Gent;
                        break;
                    }
                case "Brasilia":
                    {
                        pictureGörsel.Image = Properties.Resources.Brasilia;
                        break;
                    }
                case "Fortoleza":
                    {
                        pictureGörsel.Image = Properties.Resources.Fortoleza;
                        break;
                    }
                case "Rio de Janeiro":
                    {
                        pictureGörsel.Image = Properties.Resources.RioDeJaneiro;
                        break;
                    }
                case "Sao Paulo":
                    {
                        pictureGörsel.Image = Properties.Resources.SaoPaulo;
                        break;
                    }
                case "Salvador":
                    {
                        pictureGörsel.Image = Properties.Resources.Salvador;
                        break;
                    }
                case "Bordeux":
                    {
                        pictureGörsel.Image = Properties.Resources.Bordeux;
                        break;
                    }
                case "Lyon":
                    {
                        pictureGörsel.Image = Properties.Resources.Lyon;
                        break;
                    }
                case "Paris":
                    {
                        pictureGörsel.Image = Properties.Resources.Paris;
                        break;
                    }
                case "Marsilya":
                    {
                        pictureGörsel.Image = Properties.Resources.Marsilya;
                        break;
                    }
                case "Nice":
                    {
                        pictureGörsel.Image = Properties.Resources.Nice;
                        break;
                    }
                case "Amsterdam":
                    {
                        pictureGörsel.Image = Properties.Resources.Amsterdam;
                        break;
                    }
                case "Rotterdam":
                    {
                        pictureGörsel.Image = Properties.Resources.Rotterdam;
                        break;
                    }
                case "Eindhoven":
                    {
                        pictureGörsel.Image = Properties.Resources.Eindhoven;
                        break;
                    }
                case "Napoli":
                    {
                        pictureGörsel.Image = Properties.Resources.Napoli;
                        break;
                    }
                case "Pisa":
                    {
                        pictureGörsel.Image = Properties.Resources.Pisa;
                        break;
                    }
                case "Roma":
                    {
                        pictureGörsel.Image = Properties.Resources.Roma;
                        break;
                    }
                case "Venedik":
                    {
                        pictureGörsel.Image = Properties.Resources.Venedik;
                        break;
                    }
                case "Liverpool":
                    {
                        pictureGörsel.Image = Properties.Resources.Liverpool;
                        break;
                    }
                case "Oxford":
                    {
                        pictureGörsel.Image = Properties.Resources.Oxford;
                        break;
                    }
                case "Manchester":
                    {
                        pictureGörsel.Image = Properties.Resources.Manchester;
                        break;
                    }
                case "Londra":
                    {
                        pictureGörsel.Image = Properties.Resources.Londra;
                        break;

                    }
                case "Barselona":
                    {
                        pictureGörsel.Image = Properties.Resources.Barselona;
                        break;
                    }
                case "Madrid":
                    {
                        pictureGörsel.Image = Properties.Resources.Madrid;
                        break;
                    }
                case "Valencia":
                    {
                        pictureGörsel.Image = Properties.Resources.Valencia;
                        break;
                    }
                case "Sevilla":
                    {
                        pictureGörsel.Image = Properties.Resources.Sevilla;
                        break;
                    }
                case "İbiza":
                    {
                        pictureGörsel.Image = Properties.Resources.İbiza;
                        break;
                    }
                case "Bilbao":
                    {
                        pictureGörsel.Image = Properties.Resources.Bilbao;
                        break;
                    }
                case "Basel":
                    {
                        pictureGörsel.Image = Properties.Resources.Basel;
                        break;
                    }
                case "Bern":
                    {
                        pictureGörsel.Image = Properties.Resources.Bern;
                        break;
                    }
                case "Zürih":
                    {
                        pictureGörsel.Image = Properties.Resources.Zürih;
                        break;
                    }
                case "Maderia":
                    {
                        pictureGörsel.Image = Properties.Resources.Madeira;
                        break;
                    }
                case "Porto":
                    {
                        pictureGörsel.Image = Properties.Resources.Porto;
                        break;
                    }
                case "Lizbon":
                    {
                        pictureGörsel.Image = Properties.Resources.Lizbon;
                        break;
                    }
                case "Kazan":
                    {
                        pictureGörsel.Image = Properties.Resources.Kazan1;
                        break;
                    }
                case "Moskova":
                    {
                        pictureGörsel.Image = Properties.Resources.Moskova;
                        break;
                    }
                case "St.Petersburg":
                    {
                        pictureGörsel.Image = Properties.Resources.St_Petersg;
                        break;
                    }
                case "Ankara":
                    {
                        pictureGörsel.Image = Properties.Resources.Ankara;
                        break;
                    }
                case "Antalya":
                    {
                        pictureGörsel.Image = Properties.Resources.Antalya;
                        break;
                    }
                case "Artvin":
                    {
                        pictureGörsel.Image = Properties.Resources.Artvin;
                        break;
                    }
                case "Çanakkale":
                    {
                        pictureGörsel.Image = Properties.Resources.Çanakkale;
                        break;
                    }
                case "Eskişehir":
                    {
                        pictureGörsel.Image = Properties.Resources.Eskişehir;
                        break;
                    }
                case "Kayseri":
                    {
                        pictureGörsel.Image = Properties.Resources.Kayseri;
                        break;
                    }
                case "İstanbul":
                    {
                        pictureGörsel.Image = Properties.Resources.İstanbul;
                        break;
                    }
                case "İzmir":
                    {
                        pictureGörsel.Image = Properties.Resources.İzmir;
                        break;
                    }
                case "Konya":
                    {
                        pictureGörsel.Image = Properties.Resources.Konya;
                        break;
                    }
                case "Sivas":
                    {
                        pictureGörsel.Image = Properties.Resources.Sivas;
                        break;
                    }
                case "Şanlıurfa":
                    {
                        pictureGörsel.Image = Properties.Resources.Şanlıurfa;
                        break;
                    }
                case "Trabzon":
                    {
                        pictureGörsel.Image = Properties.Resources.Trabzon;
                        break;
                    }
                case "Muğla":
                    {
                        pictureGörsel.Image = Properties.Resources.Muğla;
                        break;
                    }
                case "Rize":
                    {
                        pictureGörsel.Image = Properties.Resources.Rize;
                        break;
                    }
                default:
                    {
                        pictureGörsel.Image = null;
                        break;
                    }
            }

        }
        private void btnGörüntüleKul_Click_2(object sender, EventArgs e)
        {
            TurRehberimm();
        }
        // LİSTVİEW ÜZERİNE ÇİFT TIKLADIĞIMIZ ZAMAN ORADAKİ BİLGİLER COMBOBOX VE TEXTBOXLARDA GÖZÜKMESİNİ SAĞLIYORUZ.
        private void listViewÜlkeKul_MouseDoubleClick(object sender, MouseEventArgs e)
        {  
            cmbUlkeAdıKul.Text = listViewÜlkeKul.SelectedItems[0].SubItems[1].Text;
            txtBaşkentKul.Text = listViewÜlkeKul.SelectedItems[0].SubItems[2].Text;
            txtDiniKul.Text = listViewÜlkeKul.SelectedItems[0].SubItems[3].Text;
            txtParaBrmKul.Text = listViewÜlkeKul.SelectedItems[0].SubItems[4].Text;
            txtUlkeNufusKul.Text = listViewÜlkeKul.SelectedItems[0].SubItems[5].Text;
            txtDiliKul.Text = listViewÜlkeKul.SelectedItems[0].SubItems[6].Text;
            cmbKıtasıKul.Text = listViewÜlkeKul.SelectedItems[0].SubItems[7].Text;
            txtYonetimŞekliKul.Text = listViewÜlkeKul.SelectedItems[0].SubItems[8].Text;
        }

        private void listViewŞehirKul_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txtPlakaKoduKul.Text = listViewŞehirKul.SelectedItems[0].SubItems[1].Text;
            cmbŞehirAdıKul.Text = listViewŞehirKul.SelectedItems[0].SubItems[2].Text;
            txtNufusKul.Text = listViewŞehirKul.SelectedItems[0].SubItems[3].Text;
            txtNesiMeshurKul.Text = listViewŞehirKul.SelectedItems[0].SubItems[4].Text;
            txtTuristlikYerKul.Text = listViewŞehirKul.SelectedItems[0].SubItems[5].Text;
        }

        private void cmbUlkeAdıKul_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            int secilenUlkeID = ((TurRehberi.ComboboxItem)cmbUlkeAdıKul.SelectedItem).Value;
            TrRhberi.Open();
            SqlCommand komut = new SqlCommand("select SehirID,SehirAdi from Sehir where UlkeID = @UlkeID", TrRhberi);
            komut.Parameters.AddWithValue("@UlkeID", secilenUlkeID);
            cmbŞehirAdıKul.Items.Clear();


            SqlDataReader dataReader = komut.ExecuteReader();
            while (dataReader.Read())
            {
                ComboboxItem cmbItem = new ComboboxItem();
                cmbItem.Value = Convert.ToInt32(dataReader["SehirID"].ToString());
                cmbItem.Text = dataReader["SehirAdi"].ToString();
                cmbŞehirAdıKul.Items.Add(cmbItem);
            }
            TrRhberi.Close();
        }
    }
}