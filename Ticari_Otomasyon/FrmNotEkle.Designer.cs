
namespace Ticari_Otomasyon
{
    partial class FrmNotEkle
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNotEkle));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.BtnTemizle = new DevExpress.XtraEditors.SimpleButton();
            this.RchDetay = new System.Windows.Forms.RichTextBox();
            this.MskSaat = new System.Windows.Forms.MaskedTextBox();
            this.MskTarih = new System.Windows.Forms.MaskedTextBox();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.TxtOlusturan = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.BtnSil = new DevExpress.XtraEditors.SimpleButton();
            this.BtnGuncelle = new DevExpress.XtraEditors.SimpleButton();
            this.BtnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.TxtBaslık = new DevExpress.XtraEditors.TextEdit();
            this.TxtHitap = new DevExpress.XtraEditors.TextEdit();
            this.TxtId = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtOlusturan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBaslık.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtHitap.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtId.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.BtnTemizle);
            this.groupControl1.Controls.Add(this.RchDetay);
            this.groupControl1.Controls.Add(this.MskSaat);
            this.groupControl1.Controls.Add(this.MskTarih);
            this.groupControl1.Controls.Add(this.labelControl7);
            this.groupControl1.Controls.Add(this.TxtOlusturan);
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.BtnSil);
            this.groupControl1.Controls.Add(this.BtnGuncelle);
            this.groupControl1.Controls.Add(this.BtnKaydet);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.TxtBaslık);
            this.groupControl1.Controls.Add(this.TxtHitap);
            this.groupControl1.Controls.Add(this.TxtId);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(625, 816);
            this.groupControl1.TabIndex = 6;
            // 
            // BtnTemizle
            // 
            this.BtnTemizle.Appearance.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnTemizle.Appearance.Options.UseFont = true;
            this.BtnTemizle.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnTemizle.ImageOptions.Image")));
            this.BtnTemizle.Location = new System.Drawing.Point(357, 720);
            this.BtnTemizle.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.BtnTemizle.Name = "BtnTemizle";
            this.BtnTemizle.Size = new System.Drawing.Size(196, 75);
            this.BtnTemizle.TabIndex = 10;
            this.BtnTemizle.Text = "Temizle";
            this.BtnTemizle.Click += new System.EventHandler(this.BtnTemizle_Click);
            // 
            // RchDetay
            // 
            this.RchDetay.Location = new System.Drawing.Point(151, 390);
            this.RchDetay.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.RchDetay.Name = "RchDetay";
            this.RchDetay.Size = new System.Drawing.Size(406, 205);
            this.RchDetay.TabIndex = 6;
            this.RchDetay.Text = "";
            // 
            // MskSaat
            // 
            this.MskSaat.Location = new System.Drawing.Point(151, 152);
            this.MskSaat.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.MskSaat.Mask = "00:00";
            this.MskSaat.Name = "MskSaat";
            this.MskSaat.Size = new System.Drawing.Size(406, 31);
            this.MskSaat.TabIndex = 2;
            this.MskSaat.ValidatingType = typeof(System.DateTime);
            // 
            // MskTarih
            // 
            this.MskTarih.Location = new System.Drawing.Point(151, 93);
            this.MskTarih.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.MskTarih.Mask = "00/00/0000";
            this.MskTarih.Name = "MskTarih";
            this.MskTarih.Size = new System.Drawing.Size(406, 31);
            this.MskTarih.TabIndex = 1;
            this.MskTarih.ValidatingType = typeof(System.DateTime);
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Location = new System.Drawing.Point(71, 393);
            this.labelControl7.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(65, 27);
            this.labelControl7.TabIndex = 27;
            this.labelControl7.Text = "Detay:";
            // 
            // TxtOlusturan
            // 
            this.TxtOlusturan.Location = new System.Drawing.Point(151, 270);
            this.TxtOlusturan.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.TxtOlusturan.Name = "TxtOlusturan";
            this.TxtOlusturan.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtOlusturan.Properties.Appearance.Options.UseFont = true;
            this.TxtOlusturan.Size = new System.Drawing.Size(409, 34);
            this.TxtOlusturan.TabIndex = 4;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(80, 334);
            this.labelControl6.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(59, 27);
            this.labelControl6.TabIndex = 25;
            this.labelControl6.Text = "Hitap:";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(35, 274);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(102, 27);
            this.labelControl5.TabIndex = 23;
            this.labelControl5.Text = "Oluşturan:";
            // 
            // BtnSil
            // 
            this.BtnSil.Appearance.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnSil.Appearance.Options.UseFont = true;
            this.BtnSil.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnSil.ImageOptions.Image")));
            this.BtnSil.Location = new System.Drawing.Point(357, 632);
            this.BtnSil.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.BtnSil.Name = "BtnSil";
            this.BtnSil.Size = new System.Drawing.Size(196, 75);
            this.BtnSil.TabIndex = 8;
            this.BtnSil.Text = "Sil";
            this.BtnSil.Click += new System.EventHandler(this.BtnSil_Click);
            // 
            // BtnGuncelle
            // 
            this.BtnGuncelle.Appearance.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnGuncelle.Appearance.Options.UseFont = true;
            this.BtnGuncelle.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnGuncelle.ImageOptions.SvgImage")));
            this.BtnGuncelle.Location = new System.Drawing.Point(151, 720);
            this.BtnGuncelle.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.BtnGuncelle.Name = "BtnGuncelle";
            this.BtnGuncelle.Size = new System.Drawing.Size(196, 75);
            this.BtnGuncelle.TabIndex = 9;
            this.BtnGuncelle.Text = "Güncelle";
            this.BtnGuncelle.Click += new System.EventHandler(this.BtnGuncelle_Click);
            // 
            // BtnKaydet
            // 
            this.BtnKaydet.Appearance.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnKaydet.Appearance.Options.UseFont = true;
            this.BtnKaydet.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnKaydet.ImageOptions.Image")));
            this.BtnKaydet.Location = new System.Drawing.Point(151, 632);
            this.BtnKaydet.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.BtnKaydet.Name = "BtnKaydet";
            this.BtnKaydet.Size = new System.Drawing.Size(196, 75);
            this.BtnKaydet.TabIndex = 7;
            this.BtnKaydet.Text = "Kaydet";
            this.BtnKaydet.Click += new System.EventHandler(this.BtnKaydet_Click);
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(77, 214);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(64, 27);
            this.labelControl4.TabIndex = 8;
            this.labelControl4.Text = "Başlık:";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(86, 154);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(51, 27);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "Saat:";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(80, 96);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(58, 27);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "Tarih:";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(107, 38);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(31, 27);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "ID:";
            // 
            // TxtBaslık
            // 
            this.TxtBaslık.Location = new System.Drawing.Point(151, 210);
            this.TxtBaslık.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.TxtBaslık.Name = "TxtBaslık";
            this.TxtBaslık.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtBaslık.Properties.Appearance.Options.UseFont = true;
            this.TxtBaslık.Size = new System.Drawing.Size(409, 34);
            this.TxtBaslık.TabIndex = 3;
            // 
            // TxtHitap
            // 
            this.TxtHitap.Location = new System.Drawing.Point(151, 330);
            this.TxtHitap.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.TxtHitap.Name = "TxtHitap";
            this.TxtHitap.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtHitap.Properties.Appearance.Options.UseFont = true;
            this.TxtHitap.Size = new System.Drawing.Size(409, 34);
            this.TxtHitap.TabIndex = 5;
            // 
            // TxtId
            // 
            this.TxtId.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.TxtId.Location = new System.Drawing.Point(151, 33);
            this.TxtId.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.TxtId.Name = "TxtId";
            this.TxtId.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtId.Properties.Appearance.Options.UseFont = true;
            this.TxtId.Size = new System.Drawing.Size(409, 34);
            this.TxtId.TabIndex = 0;
            // 
            // FrmNotEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 816);
            this.Controls.Add(this.groupControl1);
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.MaximizeBox = false;
            this.Name = "FrmNotEkle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Not Ekle";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmNotEkle_FormClosing);
            this.Load += new System.EventHandler(this.FrmNotEkle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtOlusturan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBaslık.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtHitap.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtId.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton BtnTemizle;
        private System.Windows.Forms.RichTextBox RchDetay;
        private System.Windows.Forms.MaskedTextBox MskSaat;
        private System.Windows.Forms.MaskedTextBox MskTarih;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TextEdit TxtOlusturan;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.SimpleButton BtnSil;
        private DevExpress.XtraEditors.SimpleButton BtnGuncelle;
        private DevExpress.XtraEditors.SimpleButton BtnKaydet;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit TxtBaslık;
        private DevExpress.XtraEditors.TextEdit TxtHitap;
        private DevExpress.XtraEditors.TextEdit TxtId;
    }
}