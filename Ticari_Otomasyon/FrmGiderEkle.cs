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
    public partial class FrmGiderEkle : DevExpress.XtraEditors.XtraForm
    {
        public FrmGiderEkle()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
  
        void temizle()
        {
            TxtId.Text = "";
            TxtDogalgaz.Text = "";
            TxtEkstra.Text = "";
            TxtElektrik.Text = "";
            TxtInternet.Text = "";
            TxtMaaslar.Text = "";
            TxtSu.Text = "";
            RchNotlar.Text = "";
            CmbAy.Text = "";
            CmbYil.Text = "";
        }
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("INSERT INTO TBL_GIDERLER (ELEKTRIK,SU,DOGALGAZ,INTERNET,MAASLAR,EKSTRA,NOTLAR,AY,YIL) VALUES (@ELEKTRIK,@SU,@DOGALGAZ,@INTERNET,@MAASLAR,@EKSTRA,@NOTLAR,@AY,@YIL)", bgl.baglanti());
            komut.Parameters.AddWithValue("@AY", CmbAy.Text);
            komut.Parameters.AddWithValue("@YIL", CmbYil.Text);
            if (TxtElektrik.Text == "" || TxtElektrik.Text == null)
            {
                TxtElektrik.Text = "0";
            }
            komut.Parameters.AddWithValue("@ELEKTRIK", Convert.ToDouble(TxtElektrik.Text));
            if (TxtSu.Text == "" || TxtSu.Text == null)
            {
                TxtSu.Text = "0";
            }
            komut.Parameters.AddWithValue("@SU", Convert.ToDouble(TxtSu.Text));
            if (TxtDogalgaz.Text == "" || TxtDogalgaz.Text == null)
            {
                TxtDogalgaz.Text = "0";
            }
            komut.Parameters.AddWithValue("@DOGALGAZ", Convert.ToDouble(TxtDogalgaz.Text));
            if (TxtInternet.Text == "" || TxtInternet.Text == null)
            {
                TxtInternet.Text = "0";
            }
            komut.Parameters.AddWithValue("@INTERNET", Convert.ToDouble(TxtInternet.Text));
            if (TxtMaaslar.Text == "" || TxtMaaslar.Text == null)
            {
                TxtMaaslar.Text = "0";
            }
            komut.Parameters.AddWithValue("@MAASLAR", Convert.ToDouble(TxtMaaslar.Text));
            if (TxtEkstra.Text == "" || TxtEkstra.Text == null)
            {
                TxtEkstra.Text = "0";
            }
            komut.Parameters.AddWithValue("@EKSTRA", Convert.ToDouble(TxtEkstra.Text));
            komut.Parameters.AddWithValue("@NOTLAR", RchNotlar.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Gider tabloya eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            temizle();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komutsil = new SqlCommand("DELETE FROM TBL_GIDERLER WHERE ID=@ID", bgl.baglanti());
            komutsil.Parameters.AddWithValue("@ID", TxtId.Text);
            komutsil.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Giderler Tablosundan Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            temizle();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komutGuncelle = new SqlCommand("UPDATE TBL_GIDERLER SET ELEKTRIK=@ELEKTRIK,SU=@SU,DOGALGAZ=@DOGALGAZ,INTERNET=@INTERNET,MAASLAR=@MAASLAR,EKSTRA=@EKSTRA,NOTLAR=@NOTLAR,AY=@AY,YIL=@YIL WHERE ID=@ID", bgl.baglanti());
            komutGuncelle.Parameters.AddWithValue("@ID", TxtId.Text);
            komutGuncelle.Parameters.AddWithValue("@AY", CmbAy.Text);
            komutGuncelle.Parameters.AddWithValue("@YIL", CmbYil.Text);
            komutGuncelle.Parameters.AddWithValue("@ELEKTRIK", Convert.ToDouble(TxtElektrik.Text));
            komutGuncelle.Parameters.AddWithValue("@SU", Convert.ToDouble(TxtSu.Text));
            komutGuncelle.Parameters.AddWithValue("@DOGALGAZ", Convert.ToDouble(TxtDogalgaz.Text));
            komutGuncelle.Parameters.AddWithValue("@INTERNET", Convert.ToDouble(TxtInternet.Text));
            komutGuncelle.Parameters.AddWithValue("@MAASLAR", Convert.ToDouble(TxtMaaslar.Text));
            komutGuncelle.Parameters.AddWithValue("@EKSTRA", Convert.ToDouble(TxtEkstra.Text));
            komutGuncelle.Parameters.AddWithValue("@NOTLAR", RchNotlar.Text);
            komutGuncelle.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Gider bilgisi güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            temizle();
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        public string GiderID;

        void Bilgiler()
        {
            SqlCommand komut = new SqlCommand("SELECT * FROM TBL_GIDERLER WHERE ID ="+GiderID+"", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                TxtId.Text = dr["ID"].ToString();
                TxtElektrik.Text = dr["ELEKTRIK"].ToString();
                TxtSu.Text = dr["SU"].ToString();
                TxtDogalgaz.Text = dr["DOGALGAZ"].ToString();
                TxtInternet.Text = dr["INTERNET"].ToString();
                TxtMaaslar.Text = dr["MAASLAR"].ToString();
                TxtEkstra.Text = dr["EKSTRA"].ToString();
                RchNotlar.Text = dr["NOTLAR"].ToString();
                CmbAy.Text = dr["AY"].ToString();
                CmbYil.Text = dr["YIL"].ToString();
            }
        }
        private void FrmGiderEkle_Load(object sender, EventArgs e)
        {
            if (GiderID!=null)
            {
                Bilgiler();
            }
        }

        private void FrmGiderEkle_FormClosing(object sender, FormClosingEventArgs e)
        {
            FrmGiderler fr = (FrmGiderler)Application.OpenForms["FrmGiderler"];
            fr.giderlistesi();
        }
    }
}
