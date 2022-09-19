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
    public partial class FrmPersonel : Form
    {
        public FrmPersonel()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();

        public void personelliste()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM TBL_PERSONELLER", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
       
        private void FrmPersonel_Load(object sender, EventArgs e)
        {
            personelliste();
        }

  

        private void personelEkleToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FrmPersonelEkle fr = new FrmPersonelEkle();
            fr.ShowDialog();
        }

        private void güncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPersonelEkle F = new FrmPersonelEkle();
            F.PersonelID = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID").ToString();
            F.ShowDialog();
        }
    }
}
