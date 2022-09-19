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
    public partial class FrmFirmaEkle : DevExpress.XtraEditors.XtraForm
    {
        public FrmFirmaEkle()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        private void FrmFirmaEkle_Load(object sender, EventArgs e)
        {
            sehirListesi();
            if (FirmaID!=null)
            {
                Bilgiler();
            }
        }

        void temizle()
        {
            TxtAd.Text = "";
            TxtId.Text = "";
            Txtmail.Text = "";
            TxtSektor.Text = "";
            TxtVergi.Text = "";
            TxtYetkili.Text = "";
            TxtYetkiliGorev.Text = "";
            MskFax.Text = "";
            MskTelefon1.Text = "";
            MskTelefon2.Text = "";
            MskTelefon3.Text = "";
            MskYetkiliTc.Text = "";
            RchAdres.Text = "";
        }
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("INSERT INTO TBL_FIRMALAR (AD,YETKILISTATU,YETKILIADISOYADI,YETKILITC,SEKTOR,TELEFON1,TELEFON2,TELEFON3,FAX,MAIL,IL,ILCE,VERGIDAIRE,ADRES) VALUES(@AD,@YETKILISTATU,@YETKILIADISOYADI,@YETKILITC,@SEKTOR,@TELEFON1,@TELEFON2,@TELEFON3,@FAX,@MAIL,@IL,@ILCE,@VERGIDAIRE,@ADRES) ", bgl.baglanti());
            komut.Parameters.AddWithValue("@AD", TxtAd.Text);
            komut.Parameters.AddWithValue("@YETKILISTATU", TxtYetkiliGorev.Text);
            komut.Parameters.AddWithValue("@YETKILIADISOYADI", TxtYetkili.Text);
            komut.Parameters.AddWithValue("@YETKILITC", MskYetkiliTc.Text);
            komut.Parameters.AddWithValue("@SEKTOR", TxtSektor.Text);
            komut.Parameters.AddWithValue("@TELEFON1", MskTelefon1.Text);
            komut.Parameters.AddWithValue("@TELEFON2", MskTelefon2.Text);
            komut.Parameters.AddWithValue("@TELEFON3", MskTelefon3.Text);
            komut.Parameters.AddWithValue("@FAX", MskFax.Text);
            komut.Parameters.AddWithValue("@MAIL", Txtmail.Text);
            komut.Parameters.AddWithValue("@IL", Cmbil.Text);
            komut.Parameters.AddWithValue("@ILCE", CmbIlce.Text);
            komut.Parameters.AddWithValue("@VERGIDAIRE", TxtVergi.Text);
            komut.Parameters.AddWithValue("@ADRES", RchAdres.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Firma Sisteme Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            temizle();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("DELETE FROM TBL_FIRMALAR WHERE ID=@ID", bgl.baglanti());
            komut.Parameters.AddWithValue("@ID", TxtId.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Firma listeden silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            temizle();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("UPDATE TBL_FIRMALAR SET AD=@AD,YETKILISTATU=@YETKILISTATU,YETKILIADISOYADI=@YETKILIADISOYADI,YETKILITC=@YETKILITC,SEKTOR=@SEKTOR,TELEFON1=@TELEFON1,TELEFON2=@TELEFON2,TELEFON3=@TELEFON3,FAX=@FAX,MAIL=@MAIL,IL=@IL,ILCE=@ILCE,VERGIDAIRE=@VERGIDAIRE,ADRES=@ADRES WHERE ID=@ID", bgl.baglanti());
            komut.Parameters.AddWithValue("@AD", TxtAd.Text);
            komut.Parameters.AddWithValue("@YETKILISTATU", TxtYetkiliGorev.Text);
            komut.Parameters.AddWithValue("@YETKILIADISOYADI", TxtYetkili.Text);
            komut.Parameters.AddWithValue("@YETKILITC", MskYetkiliTc.Text);
            komut.Parameters.AddWithValue("@SEKTOR", TxtSektor.Text);
            komut.Parameters.AddWithValue("@TELEFON1", MskTelefon1.Text);
            komut.Parameters.AddWithValue("@TELEFON2", MskTelefon2.Text);
            komut.Parameters.AddWithValue("@TELEFON3", MskTelefon3.Text);
            komut.Parameters.AddWithValue("@FAX", MskFax.Text);
            komut.Parameters.AddWithValue("@MAIL", Txtmail.Text);
            komut.Parameters.AddWithValue("@IL", Cmbil.Text);
            komut.Parameters.AddWithValue("@ILCE", CmbIlce.Text);
            komut.Parameters.AddWithValue("@VERGIDAIRE", TxtVergi.Text);
            komut.Parameters.AddWithValue("@ADRES", RchAdres.Text);
            komut.Parameters.AddWithValue("@ID", TxtId.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Firma Bilgileri Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            temizle();
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
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
        private void Cmbil_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        public string FirmaID;
        void Bilgiler()
        {
            SqlCommand komut = new SqlCommand("SELECT * FROM TBL_FIRMALAR WHERE ID="+FirmaID+"", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                TxtId.Text = FirmaID;
                TxtAd.Text = dr["AD"].ToString();
                TxtSektor.Text = dr["SEKTOR"].ToString();
                TxtYetkili.Text = dr["YETKILIADISOYADI"].ToString();
                TxtYetkiliGorev.Text = dr["YETKILISTATU"].ToString();
                MskYetkiliTc.Text = dr["YETKILITC"].ToString();
                MskTelefon1.Text = dr["TELEFON1"].ToString();
                MskTelefon2.Text = dr["TELEFON2"].ToString();
                MskTelefon3.Text = dr["TELEFON3"].ToString();
                MskFax.Text = dr["FAX"].ToString();
                Txtmail.Text = dr["MAIL"].ToString();
                Cmbil.Text = dr["IL"].ToString();
                CmbIlce.Text = dr["ILCE"].ToString();
                TxtVergi.Text = dr["VERGIDAIRE"].ToString();
                RchAdres.Text = dr["ADRES"].ToString();
            }
        }

        private void FrmFirmaEkle_FormClosing(object sender, FormClosingEventArgs e)
        {
            FrmFirmalar fr = (FrmFirmalar)Application.OpenForms["FrmFirmalar"];
            fr.firmalistesi();
        }

        private void Cmbil_SelectedIndexChanged_1(object sender, EventArgs e)
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
    }
}
