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

namespace Ticari_Otomasyon
{
    public partial class FrmPersonelEkle : DevExpress.XtraEditors.XtraForm
    {
        public FrmPersonelEkle()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        void temizle()
        {
            TxtId.Text = "";
            TxtAd.Text = "";
            TxtSoyad.Text = "";
            TxtGorev.Text = "";
            Txtmail.Text = "";
            MskTc.Text = "";
            MskTelefon.Text = "";
            Cmbil.Text = "";
            CmbIlce.Text = "";
            RchAdres.Text = "";
        }
        void sehirListesi()
        {
            SqlCommand komut = new SqlCommand("SELECT SEHIR FROM TBL_ILLER", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                Cmbil.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }
        public string PersonelID;
        void Bilgiler()
        {
            SqlCommand komut = new SqlCommand("SELECT * FROM TBL_PERSONELLER WHERE ID="+PersonelID+"",bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                TxtId.Text = PersonelID;
                TxtAd.Text = dr["AD"].ToString();
                TxtSoyad.Text = dr["SOYAD"].ToString();
                MskTelefon.Text = dr["TELEFON"].ToString();
                MskTc.Text = dr["TC"].ToString();
                Txtmail.Text = dr["MAIL"].ToString();
                Cmbil.Text = dr["IL"].ToString();
                CmbIlce.Text = dr["ILCE"].ToString();
                RchAdres.Text = dr["ADRES"].ToString();
                TxtGorev.Text = dr["GOREV"].ToString();
            }
        }
   
        private void Cmbil_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbIlce.Items.Clear();
            SqlCommand komut = new SqlCommand("SELECT ILCE FROM TBL_ILCELER WHERE SEHIR=@SEHIR", bgl.baglanti());
            komut.Parameters.AddWithValue("@SEHIR", Cmbil.SelectedIndex + 1);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                CmbIlce.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("INSERT INTO TBL_PERSONELLER (AD,SOYAD,TELEFON,TC,MAIL,IL,ILCE,ADRES,GOREV) VALUES(@AD,@SOYAD,@TELEFON,@TC,@MAIL,@IL,@ILCE,@ADRES,@GOREV)", bgl.baglanti());
            komut.Parameters.AddWithValue("@AD", TxtAd.Text);
            komut.Parameters.AddWithValue("@SOYAD", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@TELEFON", MskTelefon.Text);
            komut.Parameters.AddWithValue("@TC", MskTc.Text);
            komut.Parameters.AddWithValue("@MAIL", Txtmail.Text);
            komut.Parameters.AddWithValue("@IL", Cmbil.Text);
            komut.Parameters.AddWithValue("@ILCE", CmbIlce.Text);
            komut.Parameters.AddWithValue("@ADRES", RchAdres.Text);
            komut.Parameters.AddWithValue("@GOREV", TxtGorev.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Personel bilgileri kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("UPDATE TBL_PERSONELLER SET AD=@AD,SOYAD=@SOYAD,TELEFON=@TELEFON,TC=@TC,MAIL=@MAIL,IL=@IL,ILCE=@ILCE,ADRES=@ADRES,GOREV=@GOREV WHERE ID=@ID", bgl.baglanti());
            komut.Parameters.AddWithValue("@AD", TxtAd.Text);
            komut.Parameters.AddWithValue("@SOYAD", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@TELEFON", MskTelefon.Text);
            komut.Parameters.AddWithValue("@TC", MskTc.Text);
            komut.Parameters.AddWithValue("@MAIL", Txtmail.Text);
            komut.Parameters.AddWithValue("@IL", Cmbil.Text);
            komut.Parameters.AddWithValue("@ILCE", CmbIlce.Text);
            komut.Parameters.AddWithValue("@ADRES", RchAdres.Text);
            komut.Parameters.AddWithValue("@GOREV", TxtGorev.Text);
            komut.Parameters.AddWithValue("@ID", TxtId.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Personel bilgileri güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("DELETE FROM TBL_PERSONELLER WHERE ID=@ID", bgl.baglanti());
            komut.Parameters.AddWithValue("@ID", TxtId.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Personel Listeden Silindi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.None);
            temizle();
        }

        private void FrmPersonelEkle_Load(object sender, EventArgs e)
        {
            sehirListesi();
            if (PersonelID!=null)
            {
                Bilgiler();
            }
        }

        private void FrmPersonelEkle_FormClosing(object sender, FormClosingEventArgs e)
        {
            FrmPersonel fr = (FrmPersonel)Application.OpenForms["FrmPersonel"];
            fr.personelliste();
        }


    }
}
