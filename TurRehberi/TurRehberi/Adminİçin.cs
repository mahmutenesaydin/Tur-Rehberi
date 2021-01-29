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
    public partial class Adminİçin : Form
    {
        public Adminİçin()
        {   //SİSTEMDEKİ ÜLKELERİ GİRİYORUZ;
            InitializeComponent();
            cmbUlkeAdı.Items.Add("ABD");
            cmbUlkeAdı.Items.Add("Almanya");
            cmbUlkeAdı.Items.Add("Avusturalya");
            cmbUlkeAdı.Items.Add("Belçika");
            cmbUlkeAdı.Items.Add("Brezilya");
            cmbUlkeAdı.Items.Add("Fransa");
            cmbUlkeAdı.Items.Add("Hollanda");
            cmbUlkeAdı.Items.Add("İtalya");
            cmbUlkeAdı.Items.Add("İngiltere");
            cmbUlkeAdı.Items.Add("İsviçre");
            cmbUlkeAdı.Items.Add("İspanya");
            cmbUlkeAdı.Items.Add("Portekiz");
            cmbUlkeAdı.Items.Add("Rusya");
            cmbUlkeAdı.Items.Add("Türkiye");
            //ÜLKELERİN HANGİ KITAYA AİT OLDUĞUNU BELİRLEMEK İÇİN COMBOBOXLARA KITALAR DAHİL EDİYORUZ;
            cmbKıtası.Items.Add("Asya");
            cmbKıtası.Items.Add("Avrupa");
            cmbKıtası.Items.Add("Afrika");
            cmbKıtası.Items.Add("Antartika");
            cmbKıtası.Items.Add("Kuzey Amerika");
            cmbKıtası.Items.Add("Güney Amerika");
            cmbKıtası.Items.Add("Okyanusya");
        }
        //GİRİLEN BİLGİLERİN OTOMATİK OLARAK TEMİZLENMESİNİ SAĞLIYORUZ
        private void temizleUlke()
        {
            txtBaşkent.Clear();
            txtDini.Clear();
            txtParaBrm.Clear();
            txtDili.Clear();
            txtUlkeNufus.Clear();
            cmbKıtası.Text = "";
            txtYonetimŞekli.Clear();
        }
        private void temizleSehir()
        {
            txtUlkeID.Clear();
            txtPlakaKodu.Clear();
            txtNufus.Clear();
            txtNesiMeshur.Clear();
            txtTuristlikYer.Clear();

            cmbUlkeAdı.Focus();
        }


        //Sql Bağlantısını yapıyoruz. İsmini verdiğimiz "TrRhberi" ile işlemlerimizi yapıyoruz;
        SqlConnection TrRhbri = new SqlConnection(@"Data Source=DESKTOP-SERVET-\SQLEXPRESS;Initial Catalog=TurRehberi;Integrated Security=True");
        //SqlConnection TrRhberi = new SqlConnection("Data Source=MHMTENS13\\MHMTENS13;Initial Catalog=TurRehberi;Integrated Security=True");
        //Burada "TurRehberim"adlı bir metod oluşturup bu metod ile görüntülüyoruz ve bu metod içine ekleyeceklerimizi ekleyip okutuyoruz;
        private void TurRehberim()
        {   //Command komudu ile komut verip, sql'imizdeki ülke tablosunu çekiyor sonrada DATAREADER komudu ile de onları sisteme okutuyoruz(Exe);
            TrRhbri.Open();
            SqlCommand goruntuleUlke = new SqlCommand("Select * from Ulke", TrRhbri);
            SqlDataReader okuUlke = goruntuleUlke.ExecuteReader();
            //Girdiğimiz bilgiler tekrar tekrar gözükmesin diye Ülke ve Şehiri temizliyoruz ki her bilgi tek tek gözüksün;
            listViewÜlke.Items.Clear();
            listViewŞehir.Items.Clear();

            //LİSTVİEW'LERE GİRİLEN BİLGİLERİ YAZDIRIYORUZ.
            while (okuUlke.Read())
            {
                ListViewItem ekleUlke = new ListViewItem();
                ekleUlke.Text = okuUlke["UlkeID"].ToString();
                ekleUlke.SubItems.Add(okuUlke["UlkeAdı"].ToString());
                ekleUlke.SubItems.Add(okuUlke["Başkenti"].ToString());
                ekleUlke.SubItems.Add(okuUlke["Dini"].ToString());
                ekleUlke.SubItems.Add(okuUlke["ParaBirimi"].ToString());
                ekleUlke.SubItems.Add(okuUlke["Nufusu"].ToString());
                ekleUlke.SubItems.Add(okuUlke["ResmiDili"].ToString());
                ekleUlke.SubItems.Add(okuUlke["Kitasi"].ToString());
                ekleUlke.SubItems.Add(okuUlke["YonetimŞekli"].ToString());
                listViewÜlke.Items.Add(ekleUlke);
            }
            TrRhbri.Close();

            TrRhbri.Open();
            SqlCommand goruntuleSehir = new SqlCommand("Select * from Sehir", TrRhbri);
            SqlDataReader okuSehir = goruntuleSehir.ExecuteReader();
            listViewŞehir.Items.Clear();

            while (okuSehir.Read())
            {
                ListViewItem ekleSehir = new ListViewItem();
                ekleSehir.Text = okuSehir["SehirID"].ToString();
                ekleSehir.SubItems.Add(okuSehir["PlakaKodu"].ToString());
                ekleSehir.SubItems.Add(okuSehir["SehirAdi"].ToString());
                ekleSehir.SubItems.Add(okuSehir["Nufusu"].ToString());
                ekleSehir.SubItems.Add(okuSehir["NesiMeshur"].ToString());
                ekleSehir.SubItems.Add(okuSehir["TuristlikYerler"].ToString());
                listViewŞehir.Items.Add(ekleSehir);
            }
            TrRhbri.Close();
        }


        private void btnGörüntüle_Click(object sender, EventArgs e)
        {
            //Yukarıda gerçekleştirdiğimiz TurRehberim metodumuzu bu buton sayesinde görüntülüyoruz;
            TurRehberim();
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {   //BU KOMUTLAR SAYESİNDE GİRİLEN ÜLKEYİ SİSTEME KAYDEDİYORUZ;
            TrRhbri.Open();
            SqlCommand kaydetUlke = new SqlCommand("Insert into Ulke(UlkeAdı,Başkenti,Dini,ParaBirimi,Nufusu,ResmiDili,Kitasi,YonetimŞekli)values(@UlkeAdı1,@Başkenti1,@Dini1,@ParaBirimi1,@Nufusu1,@ResmiDili1,@Kitasi1,@YonetimŞekli1)", TrRhbri);
            kaydetUlke.Parameters.AddWithValue("@UlkeAdı1", cmbUlkeAdı.Text);
            kaydetUlke.Parameters.AddWithValue("@Başkenti1", txtBaşkent.Text);
            kaydetUlke.Parameters.AddWithValue("@Dini1", txtDini.Text);
            kaydetUlke.Parameters.AddWithValue("@ParaBirimi1", txtParaBrm.Text);
            kaydetUlke.Parameters.AddWithValue("@Nufusu1", txtUlkeNufus.Text);
            kaydetUlke.Parameters.AddWithValue("@ResmiDili1", txtDili.Text);
            kaydetUlke.Parameters.AddWithValue("@Kitasi1", cmbKıtası.Text);
            kaydetUlke.Parameters.AddWithValue("@YonetimŞekli1", txtYonetimŞekli.Text);
            kaydetUlke.ExecuteNonQuery();
            temizleUlke();
            TrRhbri.Close();
            TurRehberim();

            MessageBox.Show("Bir kayıt yaptınız.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSil_Click(object sender, EventArgs e)
        {   //GİRİLEN ÜLKE VEYA ŞEHİR'İ İSMİNE GÖRE SİLEBİLİYORUZ.
            TrRhbri.Open();
            SqlCommand silUlke = new SqlCommand("Delete from Ulke where UlkeAdı=@UlkeAdı3", TrRhbri);
            silUlke.Parameters.AddWithValue("@UlkeAdı3", cmbUlkeAdı.Text);
            silUlke.ExecuteNonQuery();
            TrRhbri.Close();
            TurRehberim();

            //TrRhberi'ni kapattığımız için tekrardan açmamız gerekiyor(.Open);
            TrRhbri.Open();
            SqlCommand silSehir = new SqlCommand("Delete from Sehir where SehirAdi=@SehirAdi4", TrRhbri);
            silSehir.Parameters.AddWithValue("@SehirAdi4", cmbŞehirAdı.Text);
            silSehir.ExecuteNonQuery();
            TrRhbri.Close();
            TurRehberim();
        }
        // LİSTVİEW ÜZERİNE ÇİFT TIKLADIĞIMIZ ZAMAN ORADAKİ BİLGİLER COMBOBOX VE TEXTBOXLARDA GÖZÜKMESİNİ SAĞLIYORUZ.
        private void listViewÜlke_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            cmbUlkeAdı.Text = listViewÜlke.SelectedItems[0].SubItems[1].Text;
            txtBaşkent.Text = listViewÜlke.SelectedItems[0].SubItems[2].Text;
            txtDini.Text = listViewÜlke.SelectedItems[0].SubItems[3].Text;
            txtParaBrm.Text = listViewÜlke.SelectedItems[0].SubItems[4].Text;
            txtUlkeNufus.Text = listViewÜlke.SelectedItems[0].SubItems[5].Text;
            txtDili.Text = listViewÜlke.SelectedItems[0].SubItems[6].Text;
            cmbKıtası.Text = listViewÜlke.SelectedItems[0].SubItems[7].Text;
            txtYonetimŞekli.Text = listViewÜlke.SelectedItems[0].SubItems[8].Text;

        }

        private void listViewŞehir_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txtPlakaKodu.Text = listViewŞehir.SelectedItems[0].SubItems[1].Text;
            cmbŞehirAdı.Text = listViewŞehir.SelectedItems[0].SubItems[2].Text;
            txtNufus.Text = listViewŞehir.SelectedItems[0].SubItems[3].Text;
            txtNesiMeshur.Text = listViewŞehir.SelectedItems[0].SubItems[4].Text;
            txtTuristlikYer.Text = listViewŞehir.SelectedItems[0].SubItems[5].Text;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {   //SİSTEME KAYIT EDİLEN ÜLKE VEYA ŞEHİR'İN BİLGİLERİNİ GÜNCELLEMESİNİ SAĞLIYORUZ;
            TrRhbri.Open();
            SqlCommand guncelleUlke = new SqlCommand("Update Ulke set Başkenti='" + txtBaşkent.Text.ToString() + "',Dini='" + txtDini.Text.ToString() + "',ParaBirimi='" + txtParaBrm.Text.ToString() + "',Nufusu='" + txtUlkeNufus.Text.ToString() + "',ResmiDili='" + txtDili.Text.ToString() + "',Kitasi='" + cmbKıtası.Text.ToString() + "',YonetimŞekli='" + txtYonetimŞekli.Text.ToString() + "'where UlkeAdı='" + cmbUlkeAdı.Text.ToString() + "'", TrRhbri);
            guncelleUlke.ExecuteNonQuery();
            TrRhbri.Close();
            TurRehberim();

            TrRhbri.Open();
            SqlCommand guncelleSehir = new SqlCommand("Update Sehir set PlakaKodu='" + txtPlakaKodu.Text.ToString() + "',Nufusu='" + txtNufus.Text.ToString() + "',NesiMeshur='" + txtNesiMeshur.Text.ToString() + "',TuristlikYerler='" + txtTuristlikYer.Text.ToString() + "'where SehirAdi='" + cmbŞehirAdı.Text.ToString() + "'", TrRhbri);
            guncelleSehir.ExecuteNonQuery();
            TrRhbri.Close();
            TurRehberim();
        }

        private void btnKaydetSehir_Click(object sender, EventArgs e)
        {
            //BU KOMUTLAR SAYESİNDE GİRİLEN ŞEHRİ SİSTEME KAYDEDİYORUZ;
            TrRhbri.Open();
            SqlCommand kaydetSehir = new SqlCommand("Insert into Sehir(UlkeID,PlakaKodu,SehirAdi,Nufusu,NesiMeshur,TuristlikYerler)values(@UlkeID2,@PlakaKodu2,@SehirAdi2,@Nufusu2,@NesiMeshur2,@TuristlikYerler2)", TrRhbri);
            kaydetSehir.Parameters.AddWithValue("@UlkeID2", txtUlkeID.Text);
            kaydetSehir.Parameters.AddWithValue("@PlakaKodu2", txtPlakaKodu.Text);
            kaydetSehir.Parameters.AddWithValue("@SehirAdi2", cmbŞehirAdı.Text);
            kaydetSehir.Parameters.AddWithValue("@Nufusu2", txtNufus.Text);
            kaydetSehir.Parameters.AddWithValue("@NesiMeshur2", txtNesiMeshur.Text);
            kaydetSehir.Parameters.AddWithValue("@TuristlikYerler2", txtTuristlikYer.Text);
            kaydetSehir.ExecuteNonQuery();
            temizleSehir();
            TrRhbri.Close();
            TurRehberim();

            MessageBox.Show("Bir kayıt yaptınız.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        private void btnResimEkle_Click(object sender, EventArgs e)
        {
            //GİTMEK İSTEDİĞİMİZ ŞEHRİN RESMİNİ SİSTEME KAYDETİP PİCTUREBOX'DAN GÖZÜKMESİNİ SAĞLIYORUZ.
            switch (cmbŞehirAdı.Text)
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

        private void cmbUlkeAdı_SelectedIndexChanged_1(object sender, EventArgs e)
        {   //BURADA HANGİ ŞEHRİN HANGİ ÜLKEYE AİT OLDUĞUNU BELİYORUZ;
            if (cmbUlkeAdı.Text == "ABD")
            {
                cmbŞehirAdı.Items.Add("Boston");
                cmbŞehirAdı.Items.Add("California");
                cmbŞehirAdı.Items.Add("Chicago");
                cmbŞehirAdı.Items.Add("Los Angeles");
                cmbŞehirAdı.Items.Add("Miami");
                cmbŞehirAdı.Items.Add("New York");
                cmbŞehirAdı.Items.Add("Washington");

            }
            if (cmbUlkeAdı.Text == "Almanya")
            {
                cmbŞehirAdı.Items.Clear();
                cmbŞehirAdı.Items.Add("Berlin");
                cmbŞehirAdı.Items.Add("Hamburg");
                cmbŞehirAdı.Items.Add("Köln");
                cmbŞehirAdı.Items.Add("Münih");
            }
            if (cmbUlkeAdı.Text == "Avusturalya")
            {
                cmbŞehirAdı.Items.Clear();
                cmbŞehirAdı.Items.Add("Canderra");
                cmbŞehirAdı.Items.Add("Melbourne");
                cmbŞehirAdı.Items.Add("Sydney");
            }
            if (cmbUlkeAdı.Text == "Belçika")
            {
                cmbŞehirAdı.Items.Clear();
                cmbŞehirAdı.Items.Add("Antwerp");
                cmbŞehirAdı.Items.Add("Brugge");
                cmbŞehirAdı.Items.Add("Brüksel");
                cmbŞehirAdı.Items.Add("Gent");
            }
            if (cmbUlkeAdı.SelectedIndex == 4)
            {
                cmbŞehirAdı.Items.Clear();
                cmbŞehirAdı.Items.Add("Brasilia");
                cmbŞehirAdı.Items.Add("Fortoleza");
                cmbŞehirAdı.Items.Add("Rio de Janeiro");
                cmbŞehirAdı.Items.Add("Sao Paulo");
                cmbŞehirAdı.Items.Add("Salvador");
            }
            if (cmbUlkeAdı.SelectedIndex == 5)
            {
                cmbŞehirAdı.Items.Clear();
                cmbŞehirAdı.Items.Add("Bordeux");
                cmbŞehirAdı.Items.Add("Lyon");
                cmbŞehirAdı.Items.Add("Paris");
                cmbŞehirAdı.Items.Add("Marsilya");
                cmbŞehirAdı.Items.Add("Nice");
            }
            if (cmbUlkeAdı.Text == "Hollanda")
            {
                cmbŞehirAdı.Items.Clear();
                cmbŞehirAdı.Items.Add("Amsterdam");
                cmbŞehirAdı.Items.Add("Rotterdam");
                cmbŞehirAdı.Items.Add("Eindhoven");
            }
            if (cmbUlkeAdı.Text == "İtalya")
            {
                cmbŞehirAdı.Items.Clear();
                cmbŞehirAdı.Items.Add("Napoli");
                cmbŞehirAdı.Items.Add("Pisa");
                cmbŞehirAdı.Items.Add("Roma");
                cmbŞehirAdı.Items.Add("Venedik");
            }
            if (cmbUlkeAdı.Text == "İngiltere")
            {
                cmbŞehirAdı.Items.Clear();
                cmbŞehirAdı.Items.Add("Liverpool");
                cmbŞehirAdı.Items.Add("Oxford");
                cmbŞehirAdı.Items.Add("Londra");
                cmbŞehirAdı.Items.Add("Manchester");
            }
            if (cmbUlkeAdı.Text == "İspanya")
            {
                cmbŞehirAdı.Items.Clear();
                cmbŞehirAdı.Items.Add("Barselona");
                cmbŞehirAdı.Items.Add("Bilbao");
                cmbŞehirAdı.Items.Add("Madrid");
                cmbŞehirAdı.Items.Add("Sevilla");
                cmbŞehirAdı.Items.Add("Valencia");
                cmbŞehirAdı.Items.Add("İbiza");
            }
            if (cmbUlkeAdı.Text == "İsviçre")
            {
                cmbŞehirAdı.Items.Clear();
                cmbŞehirAdı.Items.Add("Basel");
                cmbŞehirAdı.Items.Add("Bern");
                cmbŞehirAdı.Items.Add("Zürih");
            }
            if (cmbUlkeAdı.Text == "Portekiz")
            {
                cmbŞehirAdı.Items.Clear();
                cmbŞehirAdı.Items.Add("Madeira");
                cmbŞehirAdı.Items.Add("Porto");
                cmbŞehirAdı.Items.Add("Lizbon");
            }
            if (cmbUlkeAdı.Text == "Rusya")
            {
                cmbŞehirAdı.Items.Clear();
                cmbŞehirAdı.Items.Add("Kazan");
                cmbŞehirAdı.Items.Add("Moskova");
                cmbŞehirAdı.Items.Add("St.Petersburg");
            }
            if (cmbUlkeAdı.Text == "Türkiye")
            {
                cmbŞehirAdı.Items.Clear();
                cmbŞehirAdı.Items.Add("Ankara");
                cmbŞehirAdı.Items.Add("Antalya");
                cmbŞehirAdı.Items.Add("Artvin");
                cmbŞehirAdı.Items.Add("Çanakkale");
                cmbŞehirAdı.Items.Add("Eskişehir");
                cmbŞehirAdı.Items.Add("Kayseri");
                cmbŞehirAdı.Items.Add("İstanbul");
                cmbŞehirAdı.Items.Add("İzmir");
                cmbŞehirAdı.Items.Add("Konya");
                cmbŞehirAdı.Items.Add("Sivas");
                cmbŞehirAdı.Items.Add("Şanlıurfa");
                cmbŞehirAdı.Items.Add("Trabzon");
                cmbŞehirAdı.Items.Add("Muğla");
            }
        }

    }
}


