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
    public partial class FrmFaturalar : Form
    {
        public FrmFaturalar()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        public void listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM TBL_FATURABILGI",bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        private void FrmFaturalar_Load(object sender, EventArgs e)
        {
            listele();

            // Make the grid read-only.
            gridView1.OptionsBehavior.Editable = false;
            // Prevent the focused cell from being highlighted.
            gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            // Draw a dotted focus rectangle around the entire row.
            gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus; 
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;


        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmFaturaUrunler fr = new FrmFaturaUrunler();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dr != null)
            {
                fr.id = dr["FATURABILGIID"].ToString();
            }
            fr.ShowDialog();
        }

        private void faturaEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFaturaEkle fr = new FrmFaturaEkle();
            fr.ShowDialog();
        }

        private void güncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFaturaEkle fr = new FrmFaturaEkle();
            fr.FaturaID = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "FATURABILGIID").ToString();
            fr.ShowDialog();
        }

     
        private void faturaDetayOluşturToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FrmFaturaEkle fr = new FrmFaturaEkle();
            fr.Tab = "FD";
            fr.FaturaID = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "FATURABILGIID").ToString();
            fr.ShowDialog();
        }
    }
}
