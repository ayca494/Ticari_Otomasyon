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
    public partial class FrmNotEkle : DevExpress.XtraEditors.XtraForm
    {
        public FrmNotEkle()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
   
        void temizle()
        {
            TxtId.Text = "";
            TxtBaslık.Text = "";
            TxtHitap.Text = "";
            TxtOlusturan.Text = "";
            MskSaat.Text = "";
            MskTarih.Text = "";
            RchDetay.Text = "";
        }
        public string NotID;
        void Bilgiler()
        {
            SqlCommand komut = new SqlCommand("SELECT * FROM TBL_NOTLAR WHERE NOTID = "+NotID+"",bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                TxtId.Text = NotID;
                MskTarih.Text = dr["NOTTARIH"].ToString();
                RchDetay.Text = dr["NOTDETAY"].ToString();
                MskSaat.Text = dr["NOTSAAT"].ToString();
                TxtBaslık.Text = dr["NOTBASLIK"].ToString();
                TxtOlusturan.Text = dr["NOTOLUSTURAN"].ToString();
                TxtHitap.Text = dr["NOTHITAP"].ToString();
            }
        }
        private void FrmNotEkle_Load(object sender, EventArgs e)
        {
            if (NotID != null)
            {
                Bilgiler();
            }
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("INSERT INTO TBL_NOTLAR (NOTTARIH,NOTSAAT,NOTBASLIK,NOTDETAY,NOTOLUSTURAN,NOTHITAP) VALUES (@NOTTARIH,@NOTSAAT,@NOTBASLIK,@NOTDETAY,@NOTOLUSTURAN,@NOTHITAP)", bgl.baglanti());
            komut.Parameters.AddWithValue("@NOTTARIH", MskTarih.Text);
            komut.Parameters.AddWithValue("@NOTSAAT", MskSaat.Text);
            komut.Parameters.AddWithValue("@NOTBASLIK", TxtBaslık.Text);
            komut.Parameters.AddWithValue("@NOTDETAY", RchDetay.Text);
            komut.Parameters.AddWithValue("@NOTOLUSTURAN", TxtOlusturan.Text);
            komut.Parameters.AddWithValue("@NOTHITAP", TxtHitap.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Not Bilgisi Sisteme Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("DELETE FROM TBL_NOTLAR WHERE NOTID=@NOTID", bgl.baglanti());
            komut.Parameters.AddWithValue("@NOTID", TxtId.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Not Sistemden Silindi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("UPDATE TBL_NOTLAR SET NOTTARIH=@NOTTARIH,NOTSAAT=@NOTSAAT,NOTBASLIK=@NOTBASLIK,NOTDETAY=@NOTDETAY,NOTOLUSTURAN=@NOTOLUSTURAN,NOTHITAP=@NOTHITAP WHERE NOTID=@NOTID", bgl.baglanti());
            komut.Parameters.AddWithValue("@NOTTARIH", MskTarih.Text);
            komut.Parameters.AddWithValue("@NOTSAAT", MskSaat.Text);
            komut.Parameters.AddWithValue("@NOTBASLIK", TxtBaslık.Text);
            komut.Parameters.AddWithValue("@NOTDETAY", RchDetay.Text);
            komut.Parameters.AddWithValue("@NOTOLUSTURAN", TxtOlusturan.Text);
            komut.Parameters.AddWithValue("@NOTHITAP", TxtHitap.Text);
            komut.Parameters.AddWithValue("@NOTID", TxtId.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Not Bilgisi Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void FrmNotEkle_FormClosing(object sender, FormClosingEventArgs e)
        {
            FrmNotlar fr = (FrmNotlar)Application.OpenForms["FrmNotlar"];
            fr.listele();

        }
    }
}
