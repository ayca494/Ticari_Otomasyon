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
    public partial class FrmMusteriEkle : DevExpress.XtraEditors.XtraForm
    {
        public FrmMusteriEkle()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();

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


        void temizle()
        {
            TxtId.Text = "";
            TxtAd.Text = "";
            TxtSoyad.Text = "";
            MskTelefon1.Text = "";
            MskTelefon2.Text = "";
            MskTc.Text = "";
            Txtmail.Text = "";
            Cmbil.Text = "";
            CmbIlce.Text = "";
            RchAdres.Text = "";
            TxtVergi.Text = "";
        }
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("INSERT INTO TBL_MUSTERILER (AD,SOYAD,TELEFON,TELEFON2,TC,MAIL,IL,ILCE,ADRES,VERGIDAIRESI) VALUES(@AD,@SOYAD,@TELEFON,@TELEFON2,@TC,@MAIL,@IL,@ILCE,@ADRES,@VERGIDAIRESI)", bgl.baglanti());
            komut.Parameters.AddWithValue("@AD", TxtAd.Text);
            komut.Parameters.AddWithValue("@SOYAD", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@TELEFON", MskTelefon1.Text);
            komut.Parameters.AddWithValue("@TELEFON2", MskTelefon2.Text);
            komut.Parameters.AddWithValue("@TC", MskTc.Text);
            komut.Parameters.AddWithValue("@MAIL", Txtmail.Text);
            komut.Parameters.AddWithValue("@IL", Cmbil.Text);
            komut.Parameters.AddWithValue("@ILCE", CmbIlce.Text);
            komut.Parameters.AddWithValue("@ADRES", RchAdres.Text);
            komut.Parameters.AddWithValue("@VERGIDAIRESI", TxtVergi.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Mişteri sisteme eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("DELETE FROM TBL_MUSTERILER WHERE ID=@ID", bgl.baglanti());
            komut.Parameters.AddWithValue("@ID", TxtId.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Müşteri Silindi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("UPDATE TBL_MUSTERILER SET AD=@AD,SOYAD=@SOYAD,TELEFON=@TELEFON,TELEFON2=@TELEFON2,TC=@TC,MAIL=@MAIL,IL=@IL,ILCE=@ILCE,ADRES=@ADRES,VERGIDAIRESI=@VERGIDAIRESI WHERE ID=@ID", bgl.baglanti());
            komut.Parameters.AddWithValue("@AD", TxtAd.Text);
            komut.Parameters.AddWithValue("@SOYAD", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@TELEFON", MskTelefon1.Text);
            komut.Parameters.AddWithValue("@TELEFON2", MskTelefon2.Text);
            komut.Parameters.AddWithValue("@TC", MskTc.Text);
            komut.Parameters.AddWithValue("@MAIL", Txtmail.Text);
            komut.Parameters.AddWithValue("@IL", Cmbil.Text);
            komut.Parameters.AddWithValue("@ILCE", CmbIlce.Text);
            komut.Parameters.AddWithValue("@ADRES", RchAdres.Text);
            komut.Parameters.AddWithValue("@VERGIDAIRESI", TxtVergi.Text);
            komut.Parameters.AddWithValue("ID", TxtId.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Mişteri bilgileri güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }
        public string MusteriID;

        void Bilgiler()
        {
            SqlCommand komut = new SqlCommand("SELECT * FROM TBL_MUSTERILER WHERE ID="+MusteriID+"", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                TxtId.Text = dr["ID"].ToString();
                TxtAd.Text = dr["AD"].ToString();
                TxtSoyad.Text = dr["SOYAD"].ToString();
                MskTelefon1.Text = dr["TELEFON"].ToString();
                MskTelefon2.Text = dr["TELEFON2"].ToString();
                MskTc.Text = dr["TC"].ToString();
                Txtmail.Text = dr["MAIL"].ToString();
                Cmbil.Text = dr["IL"].ToString();
                CmbIlce.Text = dr["ILCE"].ToString();
                TxtVergi.Text = dr["VERGIDAIRESI"].ToString();
                RchAdres.Text = dr["ADRES"].ToString();
            }
        }

        private void FrmMusteriEkle_Load(object sender, EventArgs e)
        {
            sehirListesi();
            if (MusteriID != null)
            {
                Bilgiler();
            }
        }

        private void FrmMusteriEkle_FormClosing(object sender, FormClosingEventArgs e)
        {
            FrmMusteriler fr = (FrmMusteriler)Application.OpenForms["FrmMusteriler"];
            fr.listele();
        }
    }
}
