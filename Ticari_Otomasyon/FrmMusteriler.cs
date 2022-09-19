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
    public partial class FrmMusteriler : Form
    {
        public FrmMusteriler()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();

        public void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM TBL_MUSTERILER", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

      
        private void FrmMusteriler_Load(object sender, EventArgs e)
        {
            listele();
        }


        private void müşteriEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMusteriEkle fr = new FrmMusteriEkle();
            fr.ShowDialog();
        }

        private void güncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMusteriEkle fr = new FrmMusteriEkle();
            fr.MusteriID = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID").ToString();
            fr.ShowDialog();
        }
    }
}
