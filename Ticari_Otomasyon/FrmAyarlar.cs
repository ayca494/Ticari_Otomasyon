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
    public partial class FrmAyarlar : Form
    {
        public FrmAyarlar()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();

        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM TBL_ADMIN", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        private void FrmAyarlar_Load(object sender, EventArgs e)
        {
            listele();
            temizle();
        }
        void temizle()
        {
            TxtKullaniciAd.Text = "";
            TxtSifre.Text = "";
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (BtnKaydet.Text=="Kaydet")
            {
                SqlCommand komut = new SqlCommand("INSERT INTO TBL_ADMIN (KULLANICIAD,SIFRE) VALUES (@KULLANICIAD,@SIFRE)", bgl.baglanti());
                komut.Parameters.AddWithValue("@KULLANICIAD", TxtKullaniciAd.Text);
                komut.Parameters.AddWithValue("@SIFRE", TxtSifre.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Yeni Admin Sisteme Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele(); 
            }
            if (BtnKaydet.Text=="Güncelle")
            {
                SqlCommand komut1 = new SqlCommand("UPDATE TBL_ADMIN SET SIFRE=@SIFRE WHERE KULLANICIAD=@KULLANICIAD", bgl.baglanti());
                komut1.Parameters.AddWithValue("@KULLANICIAD",TxtKullaniciAd.Text);
                komut1.Parameters.AddWithValue("@SIFRE",TxtSifre.Text);
                komut1.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Güncellendi", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                TxtKullaniciAd.Text = dr["KULLANICIAD"].ToString();
                TxtSifre.Text = dr["SIFRE"].ToString();
            }
        }

        private void TxtKullaniciAd_TextChanged(object sender, EventArgs e)
        {
            if (TxtKullaniciAd.Text != "")
            {
                BtnKaydet.Text = "Güncelle";
                BtnKaydet.BackColor = System.Drawing.Color.FromArgb(255, 128, 128);
            }
            else
            {
                BtnKaydet.Text = "Kaydet";
                BtnKaydet.BackColor = System.Drawing.Color.FromArgb(128, 128, 255);
            }
        }
    }
}
