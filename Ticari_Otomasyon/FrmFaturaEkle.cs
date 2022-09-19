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
    public partial class FrmFaturaEkle : DevExpress.XtraEditors.XtraForm
    {
        public FrmFaturaEkle()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        public string Tab;
        void Temizle()
        {
            TxtAlici.Text = "";
            TxtId.Text = "";
            TxtSeri.Text = "";
            TxtSiraNo.Text = "";
            TxtTeslimAlan.Text = "";
            TxtTeslimEden.Text = "";
            TxtVergiDairesi.Text = "";
            MskTarih.Text = "";
            MskSaat.Text = "";
        }
        void DetayTemizle()
        {
            TxtUrunId.Text = "";
            TxtUrunAd.Text = "";
            TxtFiyat.Text = "";
            TxtTutar.Text = "";
            TxtFirma.Text = "";
            TxtMiktar.Text = "";
            TxtPersonel.Text = "";
        }
        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("DELETE FROM TBL_FATURABILGI WHERE FATURABILGIID=@FATURABILGIID", bgl.baglanti());
            komut.Parameters.AddWithValue("@FATURABILGIID", TxtId.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Fatura Sistemden Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Question);
            Temizle();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("UPDATE TBL_FATURABILGI SET SERI=@SERI,SIRANO=@SIRANO,TARIH=@TARIH,SAAT=@SAAT,VERGIDAIRE=@VERGIDAIRE,ALICI=@ALICI,TESLIMEDEN=@TESLIMEDEN,TESLIMALAN=@TESLIMALAN WHERE FATURABILGIID=@FATURABILGIID", bgl.baglanti());
            komut.Parameters.AddWithValue("@SERI", TxtSeri.Text);
            komut.Parameters.AddWithValue("@SIRANO", TxtSiraNo.Text);
            komut.Parameters.AddWithValue("@TARIH", MskTarih.Text);
            komut.Parameters.AddWithValue("@SAAT", MskSaat.Text);
            komut.Parameters.AddWithValue("@VERGIDAIRE", TxtVergiDairesi.Text);
            komut.Parameters.AddWithValue("@ALICI", TxtAlici.Text);
            komut.Parameters.AddWithValue("@TESLIMEDEN", TxtTeslimEden.Text);
            komut.Parameters.AddWithValue("@TESLIMALAN", TxtTeslimAlan.Text);
            komut.Parameters.AddWithValue("@FATURABILGIID", TxtId.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Fatura Bilgisi Güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {

            SqlCommand komut = new SqlCommand("INSERT INTO TBL_FATURABILGI (SERI,SIRANO,TARIH,SAAT,VERGIDAIRE,ALICI,TESLIMEDEN,TESLIMALAN) " +
                "VALUES (@SERI,@SIRANO,@TARIH,@SAAT,@VERGIDAIRE,@ALICI,@TESLIMEDEN,@TESLIMALAN)", bgl.baglanti());
            komut.Parameters.AddWithValue("@SERI", TxtSeri.Text);
            komut.Parameters.AddWithValue("@SIRANO", TxtSiraNo.Text);
            komut.Parameters.AddWithValue("@TARIH", MskTarih.Text);
            komut.Parameters.AddWithValue("@SAAT", MskSaat.Text);
            komut.Parameters.AddWithValue("@VERGIDAIRE", TxtVergiDairesi.Text);
            komut.Parameters.AddWithValue("@ALICI", TxtAlici.Text);
            komut.Parameters.AddWithValue("@TESLIMEDEN", TxtTeslimEden.Text);
            komut.Parameters.AddWithValue("@TESLIMALAN", TxtTeslimAlan.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Fatura Bilgisi Sisteme Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void BtnBul_Click(object sender, EventArgs e)
        {

            SqlCommand komut = new SqlCommand("SELECT URUNAD,SATISFIYAT FROM TBL_URUNLER WHERE ID=@ID", bgl.baglanti());
            komut.Parameters.AddWithValue("@ID", TxtUrunId.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                TxtUrunAd.Text = dr[0].ToString();
                TxtFiyat.Text = dr[1].ToString();
            }
            bgl.baglanti().Close();
        }

        public string FaturaID;
        void Bilgiler()
        {
            SqlCommand komut = new SqlCommand("SELECT * FROM TBL_FATURABILGI WHERE FATURABILGIID=" + FaturaID + "", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                TxtId.Text = FaturaID;
                TxtSeri.Text = dr["SERI"].ToString();
                TxtSiraNo.Text = dr["SIRANO"].ToString();
                MskTarih.Text = dr["TARIH"].ToString();
                MskSaat.Text = dr["SAAT"].ToString();
                TxtAlici.Text = dr["ALICI"].ToString();
                TxtTeslimEden.Text = dr["TESLIMEDEN"].ToString();
                TxtTeslimAlan.Text = dr["TESLIMALAN"].ToString();
                TxtVergiDairesi.Text = dr["VERGIDAIRE"].ToString();
            }
        }
        private void FrmFaturaEkle_Load(object sender, EventArgs e)
        {
            if (FaturaID != null)
            {
                Bilgiler();
            }
            if (Tab=="FD")
            {
                xtraTabControl1.SelectedTabPage= xtraTabPage2;
            }
        }

        private void FrmFaturaEkle_FormClosing(object sender, FormClosingEventArgs e)
        {
            FrmFaturalar fr = (FrmFaturalar)Application.OpenForms["FrmFaturalar"];
            fr.listele();
        }

        private void TxtMiktar_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                TxtTutar.Text = (Convert.ToDouble(TxtFiyat.Text) * int.Parse(TxtMiktar.Text)).ToString();
            }
            catch (Exception)
            {
            }
        }

        private void TxtUrunId_EditValueChanged(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("SELECT URUNAD,SATISFIYAT FROM TBL_URUNLER WHERE ID=" + TxtId.Text + "", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                TxtUrunAd.Text = dr[0].ToString();
                TxtFiyat.Text = dr[1].ToString();
            }
            bgl.baglanti().Close();
        }

        private void BtnDetayKaydet_Click(object sender, EventArgs e)
        {
            try
            {

                SqlCommand komut2 = new SqlCommand("INSERT INTO TBL_FATURADETAY (URUNAD,MIKTAR,FIYAT,TUTAR,FATURAID) VALUES (@URUNAD,@MIKTAR,@FIYAT,@TUTAR,@FATURAID)", bgl.baglanti());
                komut2.Parameters.AddWithValue("@URUNAD", TxtUrunAd.Text);
                komut2.Parameters.AddWithValue("@MIKTAR", TxtMiktar.Text);
                komut2.Parameters.AddWithValue("@FIYAT", decimal.Parse(TxtFiyat.Text));
                komut2.Parameters.AddWithValue("@TUTAR", decimal.Parse(TxtTutar.Text));
                komut2.Parameters.AddWithValue("@FATURAID", FaturaID);
                komut2.ExecuteNonQuery();
                bgl.baglanti().Close();
            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.Message);
            }

            //Hareket Tablosuna Veri Girişi
            SqlCommand komut3 = new SqlCommand("INSERT INTO TBL_FIRMAHAREKETLER (URUNID,ADET,PERSONEL,FIRMA,FIYAT,TOPLAM,FATURAID,TARIH) VALUES (@URUNID,@ADET,@PERSONEL,@FIRMA,@FIYAT,@TOPLAM,@FATURAID,@TARIH)", bgl.baglanti());
            komut3.Parameters.AddWithValue("@URUNID", TxtUrunId.Text);
            komut3.Parameters.AddWithValue("@ADET", TxtMiktar.Text);
            komut3.Parameters.AddWithValue("@PERSONEL", TxtPersonel.Text);
            komut3.Parameters.AddWithValue("@FIRMA", TxtFirma.Text);
            komut3.Parameters.AddWithValue("@FIYAT", decimal.Parse(TxtFiyat.Text));
            komut3.Parameters.AddWithValue("@TOPLAM", decimal.Parse(TxtTutar.Text));
            komut3.Parameters.AddWithValue("@FATURAID", FaturaID);
            komut3.Parameters.AddWithValue("@TARIH", MskTarih.Text);
            komut3.ExecuteNonQuery();
            bgl.baglanti().Close();

            //Stok sayısı Azaltma
            SqlCommand komut4 = new SqlCommand("UPDATE TBL_URUNLER SET ADET=ADET-@MIKTAR WHERE ID=@ID", bgl.baglanti());
            komut4.Parameters.AddWithValue("@MIKTAR", TxtMiktar.Text);
            komut4.Parameters.AddWithValue("@ID", TxtUrunId.Text);
            komut4.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Fatura Ait Ürün Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            DetayTemizle();
        }
    }
}
