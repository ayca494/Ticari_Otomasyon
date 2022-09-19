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
using System.Xml;

namespace Ticari_Otomasyon
{
    public partial class FrmAnaSayfa : Form
    {
        public FrmAnaSayfa()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();

        void Stok()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT URUNAD,SUM(ADET) AS 'Adet' FROM TBL_URUNLER GROUP BY URUNAD HAVING SUM(ADET) <= 20 ORDER BY SUM(ADET)", bgl.baglanti());
            da.Fill(dt);
            gridControlStoklar.DataSource = dt;
        }
      
        void Haberler()
        {
            XmlTextReader xmloku = new XmlTextReader("https://www.hurriyet.com.tr/rss/anasayfa");
            while (xmloku.Read())
            {
                if (xmloku.Name=="title")
                {
                    listBox1.Items.Add(xmloku.ReadString());
                }
            }
        }
        private void FrmAnaSayfa_Load(object sender, EventArgs e)
        {
            Stok();
           
            webBrowser1.Navigate("https://www.tcmb.gov.tr/kurlar/today.xml");

            Haberler();
        }
    }
}
