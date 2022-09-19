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
    public partial class FrmAdmin : DevExpress.XtraEditors.XtraForm
    {
        public FrmAdmin()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();

        private void simpleButton1_MouseHover(object sender, EventArgs e)
        {
            BtnGiris.BackColor = Color.Red;
        }

        private void simpleButton1_MouseLeave(object sender, EventArgs e)
        {
            BtnGiris.BackColor = Color.White;
        }

        private void BtnGiris_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("SELECT * FROM TBL_ADMIN WHERE KULLANICIAD=@KULLANICIAD AND SIFRE=@SIFRE",bgl.baglanti());
            komut.Parameters.AddWithValue("@KULLANICIAD", txtKullanici.Text);
            komut.Parameters.AddWithValue("@SIFRE",txtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                Anasayfa fr = new Anasayfa();
                fr.kullanici = txtKullanici.Text;
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı veya Şifre Hatalı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            bgl.baglanti().Close();
        }

       
    }
}
