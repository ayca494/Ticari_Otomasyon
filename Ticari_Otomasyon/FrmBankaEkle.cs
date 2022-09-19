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
    public partial class FrmBankaEkle : DevExpress.XtraEditors.XtraForm
    {
        public FrmBankaEkle()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        void firmalistesi()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM TBL_FIRMALAR", bgl.baglanti());
            da.Fill(dt);
            cmbFirma.ValueMember = "ID";
            cmbFirma.DisplayMember = "AD";
            cmbFirma.DataSource = dt;
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
            TxtBankaAd.Text = "";
            cmbFirma.Text = "";
            TxtHesapNo.Text = "";
            TxtHesapTuru.Text = "";
            TxtIBAN.Text = "";
            TxtId.Text = "";
            TxtSube.Text = "";
            TxtYetkili.Text = "";
            MskTarih.Text = "";
            MskTelefon.Text = "";
            Cmbil.Text = "";
            CmbIlce.Text = "";
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("INSERT INTO TBL_BANKALAR (BANKAADI,IL,ILCE,SUBE,IBAN,HESAPNO,YETKILI,TELEFON,TARIH,HESAPTURU,FIRMAID) VALUES (@BANKAADI,@IL,@ILCE,@SUBE,@IBAN,@HESAPNO,@YETKILI,@TELEFON,@TARIH,@HESAPTURU,@FIRMAID)", bgl.baglanti());
            komut.Parameters.AddWithValue("@BANKAADI", TxtBankaAd.Text);
            komut.Parameters.AddWithValue("@IL", Cmbil.Text);
            komut.Parameters.AddWithValue("@ILCE", CmbIlce.Text);
            komut.Parameters.AddWithValue("@SUBE", TxtSube.Text);
            komut.Parameters.AddWithValue("@IBAN", TxtIBAN.Text);
            komut.Parameters.AddWithValue("@HESAPNO", TxtHesapNo.Text);
            komut.Parameters.AddWithValue("@YETKILI", TxtYetkili.Text);
            komut.Parameters.AddWithValue("@TELEFON", MskTelefon.Text);
            komut.Parameters.AddWithValue("@TARIH", MskTarih.Text);
            komut.Parameters.AddWithValue("@HESAPTURU", TxtHesapTuru.Text);
            komut.Parameters.AddWithValue("@FIRMAID", cmbFirma.SelectedValue.ToString());
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Bankala Bilgisi Sisteme Kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("DELETE FROM TBL_BANKALAR WHERE ID=@ID", bgl.baglanti());
            komut.Parameters.AddWithValue("ID", TxtId.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            temizle();
            MessageBox.Show("Banka Bilgisi Sistemden Silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("UPDATE TBL_BANKALAR SET BANKAADI=@BANKAADI,IL=@IL,ILCE=@ILCE,SUBE=@SUBE,IBAN=@IBAN,HESAPNO=@HESAPNO,YETKILI=@YETKILI,TELEFON=@TELEFON,TARIH=@TARIH,HESAPTURU=@HESAPTURU,FIRMAID=@FIRMAID WHERE ID=@ID", bgl.baglanti());
            komut.Parameters.AddWithValue("@BANKAADI", TxtBankaAd.Text);
            komut.Parameters.AddWithValue("@IL", Cmbil.Text);
            komut.Parameters.AddWithValue("@ILCE", CmbIlce.Text);
            komut.Parameters.AddWithValue("@SUBE", TxtSube.Text);
            komut.Parameters.AddWithValue("@IBAN", TxtIBAN.Text);
            komut.Parameters.AddWithValue("@HESAPNO", TxtHesapNo.Text);
            komut.Parameters.AddWithValue("@YETKILI", TxtYetkili.Text);
            komut.Parameters.AddWithValue("@TELEFON", MskTelefon.Text);
            komut.Parameters.AddWithValue("@TARIH", MskTarih.Text);
            komut.Parameters.AddWithValue("@HESAPTURU", TxtHesapTuru.Text);
            komut.Parameters.AddWithValue("@FIRMAID", cmbFirma.SelectedValue.ToString());
            komut.Parameters.AddWithValue("@ID", TxtId.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Bankala Bilgisi Güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public string BankaID;
        void Bilgiler()
        {
            SqlCommand komut = new SqlCommand("SELECT * FROM TBL_BANKALAR WHERE ID="+BankaID+"",bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                TxtId.Text = BankaID;
                TxtBankaAd.Text = dr["BANKAADI"].ToString();
                Cmbil.Text = dr["IL"].ToString();
                CmbIlce.Text = dr["ILCE"].ToString();
                TxtSube.Text = dr["SUBE"].ToString();
                TxtIBAN.Text = dr["IBAN"].ToString();
                TxtHesapNo.Text = dr["HESAPNO"].ToString();
                TxtYetkili.Text = dr["YETKILI"].ToString();
                MskTelefon.Text = dr["TELEFON"].ToString();
                MskTarih.Text = dr["TARIH"].ToString();
                TxtHesapTuru.Text = dr["HESAPTURU"].ToString();
            }
        }
        private void FrmBankaEkle_Load(object sender, EventArgs e)
        {
            sehirListesi();
            firmalistesi();
            if (BankaID!=null)
            {
                Bilgiler();
            }
        }

        private void FrmBankaEkle_FormClosing(object sender, FormClosingEventArgs e)
        {
            FrmBankalar fr = (FrmBankalar)Application.OpenForms["FrmBankalar"];
            fr.listele();
        }
    }
}
