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
    public partial class FrmGiderler : Form
    {
        public FrmGiderler()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        public void giderlistesi()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM TBL_GIDERLER", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        private void FrmGiderler_Load(object sender, EventArgs e)
        {
            giderlistesi();
        }
        private void giderEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGiderEkle fr = new FrmGiderEkle();
            fr.ShowDialog();
        }

        private void güncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGiderEkle fr = new FrmGiderEkle();
            fr.GiderID = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID").ToString();
            fr.ShowDialog();
        }
    }
}
