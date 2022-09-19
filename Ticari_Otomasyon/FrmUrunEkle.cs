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
    public partial class FrmUrunEkle : DevExpress.XtraEditors.XtraForm
    {
        public FrmUrunEkle()
        {
            InitializeComponent();
        }

        public string UrunID;
        sqlbaglantisi bgl = new sqlbaglantisi();
        void temizle()
        {
            TxtId.Text = "";
            TxtAd.Text = "";
            TxtMarka.Text = "";
            TxtModel.Text = "";
            MskYil.Text = "";
            NudAdet.Text = "";
            TxtAlis.Text = "";
            TxtSatis.Text = "";
            RchDetay.Text = "";
        }

        void UrunBilgileri()
        {
            SqlCommand VeriGetir = new SqlCommand("SELECT *FROM TBL_URUNLER WHERE ID= " + UrunID + "", bgl.baglanti());
            SqlDataReader oku = VeriGetir.ExecuteReader();
            while (oku.Read())
            {
                TxtId.Text = UrunID;
                TxtAd.Text = oku["URUNAD"].ToString();
                TxtMarka.Text = oku["MARKA"].ToString();
                TxtModel.Text = oku["MODEL"].ToString();
                MskYil.Text = oku["YIL"].ToString();
                NudAdet.Text = oku["ADET"].ToString();
                TxtAlis.Text = oku["ALISFIYAT"].ToString();
                TxtSatis.Text = oku["SATISFIYAT"].ToString();
                RchDetay.Text = oku["DETAY"].ToString();
            }
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            //Verileri Kaydetme
            SqlCommand komut = new SqlCommand("INSERT INTO TBL_URUNLER (URUNAD,MARKA,MODEL,YIL,ADET,ALISFIYAT,SATISFIYAT,DETAY) VALUES(@URUNAD,@MARKA,@MODEL,@YIL,@ADET,@ALISFIYAT,@SATISFIYAT,@DETAY)", bgl.baglanti());
            komut.Parameters.AddWithValue("@URUNAD", TxtAd.Text);
            komut.Parameters.AddWithValue("@MARKA", TxtMarka.Text);
            komut.Parameters.AddWithValue("@MODEL", TxtModel.Text);
            komut.Parameters.AddWithValue("@YIL", MskYil.Text);
            komut.Parameters.AddWithValue("@ADET", int.Parse(NudAdet.Value.ToString()));
            komut.Parameters.AddWithValue("@ALISFIYAT", decimal.Parse(TxtAlis.Text).ToString());
            komut.Parameters.AddWithValue("@SATISFIYAT", decimal.Parse(TxtSatis.Text));
            komut.Parameters.AddWithValue("@DETAY", RchDetay.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ürün sisteme eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            temizle();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komutsil = new SqlCommand("DELETE FROM TBL_URUNLER WHERE ID=@ID", bgl.baglanti());
            komutsil.Parameters.AddWithValue("@ID", TxtId.Text);
            komutsil.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ürün Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("UPDATE TBL_URUNLER SET URUNAD=@URUNAD , MARKA=@MARKA, MODEL=@MODEL, YIL=@YIL, ADET=@ADET, ALISFIYAT=@ALISFIYAT, SATISFIYAT=@SATISFIYAT, DETAY=@DETAY WHERE ID=@ID", bgl.baglanti());
            komut.Parameters.AddWithValue("@URUNAD", TxtAd.Text);
            komut.Parameters.AddWithValue("@MARKA", TxtMarka.Text);
            komut.Parameters.AddWithValue("@MODEL", TxtModel.Text);
            komut.Parameters.AddWithValue("@YIL", MskYil.Text);
            komut.Parameters.AddWithValue("@ADET", int.Parse((NudAdet.Value).ToString()));
            komut.Parameters.AddWithValue("@ALISFIYAT", decimal.Parse(TxtAlis.Text));
            komut.Parameters.AddWithValue("@SATISFIYAT", decimal.Parse(TxtSatis.Text));
            komut.Parameters.AddWithValue("@DETAY", RchDetay.Text);
            komut.Parameters.AddWithValue("@ID", TxtId.Text); 
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ürün Bilgisi Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            temizle();
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void FrmUrunEkle_Load(object sender, EventArgs e)
        {
            if (UrunID!=null )
            {
                UrunBilgileri();
            }
        }

        private void FrmUrunEkle_FormClosing(object sender, FormClosingEventArgs e)
        {
            FrmUrunler fr = (FrmUrunler)Application.OpenForms["FrmUrunler"];
            fr.listele();
        }
    }
}
