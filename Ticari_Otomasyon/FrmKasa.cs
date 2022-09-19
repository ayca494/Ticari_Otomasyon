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
using DevExpress.Charts;

namespace Ticari_Otomasyon
{
    public partial class FrmKasa : Form
    {
        public FrmKasa()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();

        void musteriHareket()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Execute MusteriHareketler", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        void firmaHareket()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Execute FirmaHareketler", bgl.baglanti());
            da.Fill(dt);
            gridControl3.DataSource = dt;
        }
        void Giderler()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM TBL_GIDERLER", bgl.baglanti());
            da.Fill(dt);
            gridControl2.DataSource = dt;
        }

        public string ad;
        private void FrmKasa_Load(object sender, EventArgs e)
        {
            LblAktifKullanici.Text = ad;
            musteriHareket();
            firmaHareket();
            Giderler();

            //Toplam Tutar 
            SqlCommand komut = new SqlCommand("SELECT SUM(TUTAR) FROM TBL_FATURADETAY", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                LblToplamTutar.Text = dr[0].ToString() + "TL";
            }
            bgl.baglanti().Close();

            //Son ayın faturaları
            SqlCommand komut1 = new SqlCommand("SELECT (ELEKTRIK+SU+DOGALGAZ+INTERNET+EKSTRA) FROM TBL_GIDERLER ORDER BY ID ASC", bgl.baglanti());
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                LblOdemeler.Text = dr1[0].ToString() + "TL";
            }
            bgl.baglanti().Close();

            //Son ayın Personel Maaşları
            SqlCommand komut2 = new SqlCommand("SELECT MAASLAR FROM TBL_GIDERLER ORDER BY ID ASC", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                LblPersonelMaas.Text = dr2[0].ToString() + "TL";
            }
            bgl.baglanti().Close();

            //Toplam Müşteri Sayısı
            SqlCommand komut3 = new SqlCommand("SELECT COUNT(*) FROM TBL_MUSTERILER", bgl.baglanti());
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                LblMusteriSayisi.Text = dr3[0].ToString();
            }
            bgl.baglanti().Close();

            //Toplam Firma Sayısı
            SqlCommand komut4 = new SqlCommand("SELECT COUNT(*) FROM TBL_FIRMALAR", bgl.baglanti());
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                LblFirmaSayisi.Text = dr4[0].ToString();
            }
            bgl.baglanti().Close();

            //Firma Şehir Sayısı
            SqlCommand komut5 = new SqlCommand("SELECT COUNT(DISTINCT(IL)) FROM TBL_FIRMALAR", bgl.baglanti());
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                LblSehirSayisi.Text = dr5[0].ToString();
            }
            bgl.baglanti().Close();

            //Toplam Personeller Sayısı
            SqlCommand komut6 = new SqlCommand("SELECT COUNT(*) FROM TBL_PERSONELLER", bgl.baglanti());
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                LblPersonelSayisi.Text = dr6[0].ToString();
            }
            bgl.baglanti().Close();

            //Toplam Ürün Sayısı
            SqlCommand komut7 = new SqlCommand("SELECT SUM(ADET) FROM TBL_URUNLER", bgl.baglanti());
            SqlDataReader dr7 = komut7.ExecuteReader();
            while (dr7.Read())
            {
                LblStokSayisi.Text = dr7[0].ToString();
            }
            bgl.baglanti().Close();
        }
        int sayac = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            sayac++;
            //Elektrik
            if(sayac>0 && sayac <= 5)
            {
                groupControl10.Text = "Elektrik";
                chartControl1.Series["Aylar"].Points.Clear();
                SqlCommand komut8 = new SqlCommand("SELECT TOP 4 AY,ELEKTRIK FROM TBL_GIDERLER ORDER BY ID DESC", bgl.baglanti());
                SqlDataReader dr8 = komut8.ExecuteReader();
                while (dr8.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr8[0], dr8[1]));
                }
                bgl.baglanti().Close();
            }
            //Su
            if (sayac>5 && sayac<=10)
            {
                groupControl10.Text = "Su";
                chartControl1.Series["Aylar"].Points.Clear();
                SqlCommand komut9 = new SqlCommand("SELECT TOP 4 AY,SU FROM TBL_GIDERLER ORDER BY ID DESC", bgl.baglanti());
                SqlDataReader dr9 = komut9.ExecuteReader();
                while (dr9.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr9[0], dr9[1]));
                }
                bgl.baglanti().Close();
            }
            //Doğalgaz
            if (sayac > 10 && sayac <= 15)
            {
                groupControl10.Text = "Doğalgaz";
                chartControl1.Series["Aylar"].Points.Clear();
                SqlCommand komut9 = new SqlCommand("SELECT TOP 4 AY,DOGALGAZ FROM TBL_GIDERLER ORDER BY ID DESC", bgl.baglanti());
                SqlDataReader dr9 = komut9.ExecuteReader();
                while (dr9.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr9[0], dr9[1]));
                }
                bgl.baglanti().Close();
            }

            //İnternet
            if (sayac > 15 && sayac <= 20)
            {
                groupControl10.Text = "İnternet";
                chartControl1.Series["Aylar"].Points.Clear();
                SqlCommand komut9 = new SqlCommand("SELECT TOP 4 AY,INTERNET FROM TBL_GIDERLER ORDER BY ID DESC", bgl.baglanti());
                SqlDataReader dr9 = komut9.ExecuteReader();
                while (dr9.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr9[0], dr9[1]));
                }
                bgl.baglanti().Close();
            }
            //Ekstra
            if (sayac > 20 && sayac <= 25)
            {
                groupControl10.Text = "Ekstra";
                chartControl1.Series["Aylar"].Points.Clear();
                SqlCommand komut9 = new SqlCommand("SELECT TOP 4 AY,EKSTRA FROM TBL_GIDERLER ORDER BY ID DESC", bgl.baglanti());
                SqlDataReader dr9 = komut9.ExecuteReader();
                while (dr9.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr9[0], dr9[1]));
                }
                bgl.baglanti().Close();
            }
            if (sayac==26)
            {
                sayac = 0;
            }
        }
        int sayac2;
        private void timer2_Tick(object sender, EventArgs e)
        {
            sayac2++;
            //Elektrik
            if (sayac2 > 0 && sayac2 <= 5)
            {
                groupControl11.Text = "Elektrik";
                chartControl2.Series["Aylar"].Points.Clear();
                SqlCommand komut8 = new SqlCommand("SELECT TOP 4 AY,ELEKTRIK FROM TBL_GIDERLER ORDER BY ID DESC", bgl.baglanti());
                SqlDataReader dr8 = komut8.ExecuteReader();
                while (dr8.Read())
                {
                    chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr8[0], dr8[1]));
                }
                bgl.baglanti().Close();
            }
            //Su
            if (sayac2 > 5 && sayac2 <= 10)
            {
                groupControl11.Text = "Su";
                chartControl2.Series["Aylar"].Points.Clear();
                SqlCommand komut9 = new SqlCommand("SELECT TOP 4 AY,SU FROM TBL_GIDERLER ORDER BY ID DESC", bgl.baglanti());
                SqlDataReader dr9 = komut9.ExecuteReader();
                while (dr9.Read())
                {
                    chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr9[0], dr9[1]));
                }
                bgl.baglanti().Close();
            }
            //Doğalgaz
            if (sayac2 > 10 && sayac2 <= 15)
            {
                groupControl11.Text = "Doğalgaz";
                chartControl2.Series["Aylar"].Points.Clear();
                SqlCommand komut9 = new SqlCommand("SELECT TOP 4 AY,DOGALGAZ FROM TBL_GIDERLER ORDER BY ID DESC", bgl.baglanti());
                SqlDataReader dr9 = komut9.ExecuteReader();
                while (dr9.Read())
                {
                    chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr9[0], dr9[1]));
                }
                bgl.baglanti().Close();
            }

            //İnternet
            if (sayac2 > 15 && sayac2 <= 20)
            {
                groupControl11.Text = "İnternet";
                chartControl2.Series["Aylar"].Points.Clear();
                SqlCommand komut9 = new SqlCommand("SELECT TOP 4 AY,INTERNET FROM TBL_GIDERLER ORDER BY ID DESC", bgl.baglanti());
                SqlDataReader dr9 = komut9.ExecuteReader();
                while (dr9.Read())
                {
                    chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr9[0], dr9[1]));
                }
                bgl.baglanti().Close();
            }
            //Ekstra
            if (sayac2 > 20 && sayac2 <= 25)
            {
                groupControl11.Text = "Ekstra";
                chartControl2.Series["Aylar"].Points.Clear();
                SqlCommand komut9 = new SqlCommand("SELECT TOP 4 AY,EKSTRA FROM TBL_GIDERLER ORDER BY ID DESC", bgl.baglanti());
                SqlDataReader dr9 = komut9.ExecuteReader();
                while (dr9.Read())
                {
                    chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr9[0], dr9[1]));
                }
                bgl.baglanti().Close();
            }
            if (sayac2 == 26)
            {
                sayac2 = 0;
            }
        }
    }
}
