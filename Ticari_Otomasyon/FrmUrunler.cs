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
    public partial class FrmUrunler : DevExpress.XtraEditors.XtraForm
    {
        public FrmUrunler()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();

        public void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM TBL_URUNLER", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        private void FrmUrunler_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void yeniÜrünEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUrunEkle f = new FrmUrunEkle();
            f.ShowDialog();
        }

        private void güncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUrunEkle F = new FrmUrunEkle();
            F.UrunID = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID").ToString();
            F.ShowDialog();
        }
    }
}
