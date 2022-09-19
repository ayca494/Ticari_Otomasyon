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
    public partial class FrmBankalar : Form
    {
        public FrmBankalar()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();

        public void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Execute BankaBilgileri", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        private void FrmBankalar_Load(object sender, EventArgs e)
        {
            listele();
        }
        private void bankaEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBankaEkle fr = new FrmBankaEkle();
            fr.ShowDialog();
        }

        private void güncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBankaEkle fr = new FrmBankaEkle();
            fr.BankaID = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID").ToString();
            fr.ShowDialog();
        }
    }
}
