using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace Ticari_Otomasyon
{
    public partial class FrmMail : DevExpress.XtraEditors.XtraForm
    {
        public FrmMail()
        {
            InitializeComponent();
        }

        public string mail;
        private void FrmMail_Load(object sender, EventArgs e)
        {
            TxtMailAdres.Text = mail;
        }

        private void BtnGonder_Click(object sender, EventArgs e)
        {
            //    MailMessage mesajim = new MailMessage();
            //    SmtpClient istemci = new SmtpClient();
            //    istemci.Credentials = new System.Net.NetworkCredential();
            //    istemci.Port = 587;
            //    istemci.Host = "smtp.gmail.com";
            //    istemci.EnableSsl = true;
            //    mesajim.To.Add(TxtMesaj.Text);
            //    mesajim.From = new MailAddress("aycaturkmen46@gmail.com");
            //    mesajim.Subject = TxtKonu.Text;
            //    mesajim.Body = TxtMesaj.Text;
            //    istemci.Send(mesajim);
        }
    }
}
