using MySql.Data.MySqlClient;
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
    public partial class frmTabloVerileriAktarma : Form
    {
        public frmTabloVerileriAktarma()
        {
            InitializeComponent();
        }

        public string oServer = "", oDatabase = "", oUsername = "", oPassword = "";

        private MySqlConnection baglantiYap()
        {
            MySqlConnection con = new MySqlConnection("Server=" + serverText + ";Database=" + databaseText + ";Uid=" + usernameText + ";Pwd=" + passwordText + ";");
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
            }
            catch
            {
                if (!(svsettings.Default.server == "" && svsettings.Default.database == "" && svsettings.Default.username == "" && svsettings.Default.password == ""))
                {
                    Application.ExitThread();
                }
            }
            return con;
        }

        private MySqlConnection oBaglantiYap()
        {
            MySqlConnection con = new MySqlConnection("Server=" + oServer + ";Database=" + oDatabase + ";Uid=" + oUsername + ";Pwd=" + oPassword + ";");
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }

        private void yoneticilerOlustur()
        {
            MySqlConnection con = baglantiYap();
            MySqlCommand komut = new MySqlCommand("CREATE TABLE IF NOT EXISTS `yoneticiler` (" +
  "`id` int(11) NOT NULL AUTO_INCREMENT," +
  "`kullanici` varchar(255) CHARACTER SET utf8 NOT NULL," +
  "`sifre` varchar(255) CHARACTER SET utf8 NOT NULL," +
  "`posta` varchar(255) CHARACTER SET utf8 NOT NULL," +
  "`yasakli` tinyint(1) NOT NULL DEFAULT '0'," +
  "`asyonetici` tinyint(1) NOT NULL DEFAULT '0'," +
  "`doku` tinyint(1) NOT NULL DEFAULT '0'," +
  "PRIMARY KEY(`id`))" +
  "ENGINE = InnoDB DEFAULT CHARSET = utf8 AUTO_INCREMENT = 1;", con);
            komut.ExecuteNonQuery();
            komut.Dispose();
            con.Close();
        }

        private void uyelerOlustur()
        {
            MySqlConnection con = baglantiYap();
            MySqlCommand komut = new MySqlCommand("CREATE TABLE IF NOT EXISTS `uyeler` (" +
              "`id` int(11) NOT NULL AUTO_INCREMENT," +
              "`kullanici` varchar(255) CHARACTER SET utf8 DEFAULT NULL," +
              "`sifre` varchar(255) CHARACTER SET utf8 DEFAULT NULL," +
              "`posta` varchar(255) CHARACTER SET utf8 DEFAULT NULL," +
              "`yasakli` tinyint(1) DEFAULT '0'," +
              "PRIMARY KEY(`id`))" +
              "ENGINE = InnoDB DEFAULT CHARSET = utf8 AUTO_INCREMENT = 1;", con);
            komut.ExecuteNonQuery();
            komut.Dispose();
            con.Close();
        }

        private void frmTabloVerileriAktarma_Load(object sender, EventArgs e)
        {
            if (!(svsettings.Default.server == "" && svsettings.Default.database == "" && svsettings.Default.username == "" && svsettings.Default.password == ""))
            {
                int uyeSayisi = veriSayisi("uyeler");
                int yoneticiSayisi = veriSayisi("yoneticiler");
                if (!(uyeSayisi > 0 || yoneticiSayisi > 1))
                {
                    button3.Visible = true;
                    button1.Visible = false;
                    button2.Visible = false;
                }
            }
            else
            {
                label1.Text = "Üyeler ve Yöneticiler tablolarında herhangi bir kullanıcı bulunmamaktadır. İleri'ye basınız.";
                button3.Visible = true;
                button1.Visible = false;
                button2.Visible = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            uyelerOlustur();
            groupBox1.Visible = true;
            label2.Visible = true;
            label4.Visible = true;
            yoneticilerOlustur();
            label3.Visible = true;
            label5.Visible = true;
            button4.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            uyelerOlustur();
            groupBox1.Visible = true;
            label2.Visible = true;
            label4.Visible = true;
            yoneticilerOlustur();
            label3.Visible = true;
            label5.Visible = true;
            button4.Visible = true;
        }

        public string serverText = "", databaseText = "", usernameText = "", passwordText = "";

        private int veriSayisi(string tabloAdi)
        {
            int sayisi = 0;
            try
            {
                MySqlConnection con = new MySqlConnection("Server=" + oServer + ";Database=" + oDatabase + ";Uid=" + oUsername + ";Pwd=" + oPassword + ";");
                con.Open();
                MySqlCommand uyeOku = new MySqlCommand("SELECT * FROM " + tabloAdi, con);
                MySqlDataReader uyeOkuyucu = uyeOku.ExecuteReader();
                while (uyeOkuyucu.Read())
                {
                    sayisi++;
                }
            }
            catch
            {
                if (!(svsettings.Default.server == "" && svsettings.Default.database == "" && svsettings.Default.username == "" && svsettings.Default.password == ""))
                {
                    sayisi = 0;
                }
            }
            return sayisi;
        }

        private void frmTabloVerileriAktarma_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult soru = MessageBox.Show("Artık işlemi iptal edemezsiniz. Eğer işlem beklenmedik bir anda kapanırsa tüm üyeler ve yöneticiler kayıp olabilir ve aynı zamanda tüm sunucu bilgileri kaybolabilir. Kurulumu yeniden gerçekleştirmeniz gerekebilir.\n\nYine de çıkmak istediğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (soru == DialogResult.Yes)
            {
                Application.ExitThread();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            svsettings.Default.server = serverText.Trim();
            svsettings.Default.database = databaseText.Trim();
            svsettings.Default.username = usernameText.Trim();
            svsettings.Default.password = passwordText.Trim();
            svsettings.Default.Save();
            frmYoneticiEkleme yoneticiEkleme = new frmYoneticiEkleme();
            yoneticiEkleme.Show();
            this.Hide();
        }

        private void UyeleriAktar()
        {
            MySqlConnection con = oBaglantiYap();
            MySqlConnection yeniCon = baglantiYap();
            if (veriSayisi("uyeler") > 0)
            {
                MySqlCommand uyeOku = new MySqlCommand("SELECT * FROM uyeler", con);
                MySqlDataReader uyeOkuyucu = uyeOku.ExecuteReader();
                uyeOku.Dispose();
                while (uyeOkuyucu.Read())
                {
                    string kullanici = uyeOkuyucu["kullanici"].ToString(), sifre = uyeOkuyucu["sifre"].ToString(), posta = uyeOkuyucu["posta"].ToString(), yasakli = uyeOkuyucu["yasakli"].ToString();
                    MySqlCommand komut = new MySqlCommand("INSERT INTO uyeler (kullanici, sifre, posta, yasakli) VALUES ('" + kullanici + "', '" + sifre + "', '" + posta + "', '" + yasakli + "')", yeniCon);
                    komut.ExecuteNonQuery();
                    komut.Dispose();
                }
                con.Close();
                uyeOkuyucu.Dispose();
            }
        }

        private void YoneticileriAktar()
        {
            MySqlConnection con = oBaglantiYap();
            MySqlConnection yeniCon = baglantiYap();
            if (veriSayisi("yoneticiler") > 0)
            {
                MySqlCommand uyeOku = new MySqlCommand("SELECT * FROM yoneticiler", con);
                MySqlDataReader uyeOkuyucu = uyeOku.ExecuteReader();
                uyeOku.Dispose();
                while (uyeOkuyucu.Read())
                {
                    string kullanici = uyeOkuyucu["kullanici"].ToString(), sifre = uyeOkuyucu["sifre"].ToString(), posta = uyeOkuyucu["posta"].ToString(), yasakli = uyeOkuyucu["yasakli"].ToString(), asyonetici = uyeOkuyucu["asyonetici"].ToString(), doku = uyeOkuyucu["doku"].ToString();
                    MySqlCommand komut = new MySqlCommand("INSERT INTO yoneticiler (kullanici, sifre, posta, yasakli, asyonetici, doku) VALUES ('" + kullanici + "', '" + sifre + "', '" + posta + "', '" + yasakli + "', " + asyonetici + ", " + doku + ")", yeniCon);
                    komut.ExecuteNonQuery();
                    komut.Dispose();
                }
                uyeOkuyucu.Dispose();
                con.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            uyelerOlustur();
            groupBox1.Visible = true;
            label2.Visible = true;
            label4.Visible = true;
            yoneticilerOlustur();
            label3.Visible = true;
            label5.Visible = true;
            UyeleriAktar();
            YoneticileriAktar();
            button4.Visible = true;
        }
    }
}
