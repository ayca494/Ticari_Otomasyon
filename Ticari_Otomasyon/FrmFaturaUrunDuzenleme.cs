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
    public partial class FrmFaturaUrunDuzenleme : DevExpress.XtraEditors.XtraForm
    {
        public FrmFaturaUrunDuzenleme()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        public string urunid;
        private void FrmFaturaUrunDuzenleme_Load(object sender, EventArgs e)
        {
            TxtUrunId.Text = urunid;

            SqlCommand komut = new SqlCommand("SELECT * FROM TBL_FATURADETAY WHERE FATURAURUNID=@FATURAURUNID", bgl.baglanti());
            komut.Parameters.AddWithValue("@FATURAURUNID", urunid);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                TxtFiyat.Text = dr[3].ToString();
                TxtMiktar.Text = dr[2].ToString();
                TxtTutar.Text = dr[4].ToString();
                TxtUrunAd.Text = dr[1].ToString();
                bgl.baglanti().Close();
            }
        }

        private void Guncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("UPDATE TBL_FATURADETAY SET URUNAD=@URUNAD,MIKTAR=@MIKTAR,FIYAT=@FIYAT,TUTAR=@TUTAR WHERE FATURAURUNID=@FATURAURUNID", bgl.baglanti());
            komut.Parameters.AddWithValue("@URUNAD", TxtUrunAd.Text);
            komut.Parameters.AddWithValue("@MIKTAR", TxtMiktar.Text);
            komut.Parameters.AddWithValue("@FIYAT", decimal.Parse(TxtFiyat.Text));
            komut.Parameters.AddWithValue("@TUTAR", decimal.Parse(TxtTutar.Text));
            komut.Parameters.AddWithValue("@FATURAURUNID", TxtUrunId.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Değişiklikler Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void Sil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("DELETE FROM TBL_FATURADETAY WHERE FATURAURUNID=@FATURAURUNID", bgl.baglanti());
            komut.Parameters.AddWithValue("@FATURAURUNID", TxtUrunId.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ürün Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FrmFaturaUrunDuzenleme_FormClosing(object sender, FormClosingEventArgs e)
        {
            FrmFaturaUrunler fr = (FrmFaturaUrunler)Application.OpenForms["FrmFaturaUrunler"];
            fr.listele();
        }
    }
}
