using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ticari_Otomasyon
{
    public partial class Anasayfa : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Anasayfa()
        {
            InitializeComponent();
        }
        FrmUrunler fr;

        private void BtnUrunler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            fr = new FrmUrunler();
            fr.MdiParent = this;
            fr.Show();

        }
        FrmMusteriler fr2;
        private void BtnMusteriler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            fr2 = new FrmMusteriler();
            fr2.MdiParent = this;
            fr2.Show();

        }
        FrmFirmalar fr3;
        private void BtnFirmalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            fr3 = new FrmFirmalar();
            fr3.MdiParent = this;
            fr3.Show();
        }
        FrmPersonel fr4;
        private void BtnPersoneller_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            fr4 = new FrmPersonel();
            fr4.MdiParent=this;
            fr4.Show();
        }
        FrmRehber fr5;
        private void BtnRehber_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            fr5 = new FrmRehber();
            fr5.MdiParent = this;
            fr5.Show();
        }

        FrmGiderler fr6;
        private void BtnGiderler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            fr6 = new FrmGiderler();
            fr6.MdiParent = this;
            fr6.Show();
        }

        FrmBankalar fr7;
        private void BtnBankalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            fr7 = new FrmBankalar();
            fr7.MdiParent = this;
            fr7.Show();
        }

        FrmFaturalar fr8;
        private void BtnFaturalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            fr8 = new FrmFaturalar();
            fr8.MdiParent = this;
            fr8.Show();
        }
        FrmNotlar fr9;
        private void BtnNotlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            fr9 = new FrmNotlar();
            fr9.MdiParent = this;
            fr9.Show();
        }
        FrmHareketler fr10;
        private void BtnHareketler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            fr10 = new FrmHareketler();
            fr10.MdiParent = this;
            fr10.Show();
        }

        FrmStoklar fr11;
        private void BtnStoklar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            fr11 = new FrmStoklar();
            fr11.MdiParent = this;
            fr11.Show();
        }

        FrmAyarlar fr12;
        private void BtnAyarlar_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            fr12 = new FrmAyarlar();
            fr12.Show();
        }

        FrmRaporlar fr13;
        private void BtnRaporlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            fr13 = new FrmRaporlar();
            fr13.MdiParent=this;
            fr13.Show();
        }

        FrmKasa fr14;
        private void BtnKasa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            fr14 = new FrmKasa();
            fr14.ad = kullanici;
            fr14.MdiParent = this;
            fr14.Show();
        }
        public string kullanici;
        private void Anasayfa_Load(object sender, EventArgs e)
        {
            fr15 = new FrmAnaSayfa();
            fr15.MdiParent = this;
            fr15.Show();
        }

        FrmAnaSayfa fr15;
        private void BtnAnaSayfa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            fr15 = new FrmAnaSayfa();
            fr15.MdiParent = this;
            fr15.Show();
        }

        void MdiChild_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((fr15.Text == "Ana Sayfa") && e.CloseReason != CloseReason.MdiFormClosing)
                e.Cancel = true;
        }
        private void xtraTabbedMdiManager1_PageAdded(object sender, DevExpress.XtraTabbedMdi.MdiTabPageEventArgs e)
        {
            e.Page.MdiChild.FormClosing += new FormClosingEventHandler(MdiChild_FormClosing);
        }
    }
}
