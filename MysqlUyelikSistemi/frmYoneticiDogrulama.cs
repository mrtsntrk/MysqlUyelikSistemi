using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MysqlUyelikSistemi
{
    public partial class frmYoneticiDogrulama : Form
    {
        public frmYoneticiDogrulama()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == localAdminSettings.Default.kullanici && textBox2.Text.Trim() == localAdminSettings.Default.sifre)
            {
                MessageBox.Show("Yönetici bilgileriniz doğrulandı.\nSunucu ayarlarına yönlendiriliyorsunuz.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmSunucuAyarlari sunucu = new frmSunucuAyarlari();
                
                sunucu.Show();
                this.Hide();
            }
        }

        private void frmYoneticiDogrulama_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.ExitThread();
        }
    }
}
