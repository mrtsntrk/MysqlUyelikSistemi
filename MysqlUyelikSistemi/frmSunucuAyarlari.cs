using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MysqlUyelikSistemi
{
    public partial class frmSunucuAyarlari : Form
    {
        public frmSunucuAyarlari()
        {
            InitializeComponent();
        }

        string server = svsettings.Default.server, database = svsettings.Default.database, username = svsettings.Default.username, password = svsettings.Default.password, users = "uyeler", admins = "yoneticiler";

        private void changedinfo(object sender, EventArgs e)
        {
            TextBox changed = (TextBox)sender;
            if (changed.Name == "serverText")
            {
                if (serverText.Text.Trim() != vServer && serverText.Text.Trim() != "")
                    button1.Visible = true;
                else
                    button1.Visible = false;
            }
            else if (changed.Name == "databaseText")
            {
                if (databaseText.Text.Trim() != vDatabase && databaseText.Text.Trim() != "")
                    button1.Visible = true;
                else
                    button1.Visible = false;
            }
            else if (changed.Name == "usernameText")
            {
                if (usernameText.Text.Trim() != vUsername && usernameText.Text.Trim() != "")
                    button1.Visible = true;
                else
                    button1.Visible = false;
            }
            else if (changed.Name == "passwordText")
            {
                if (passwordText.Text.Trim() != vPassword)
                    button1.Visible = true;
                else
                    button1.Visible = false;
            }
        }

        private void frmSunucuAyarlari_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (serverText.Text.Trim() != "" && databaseText.Text.Trim() != "" && usernameText.Text.Trim() != "")
            {
                try
                {
                    MySqlConnection con = new MySqlConnection("Server=" + serverText.Text.Trim() + ";Database=" + databaseText.Text.Trim() + ";Uid=" + usernameText.Text.Trim() + ";Pwd=" + passwordText.Text.Trim() + ";");
                    con.Open();
                    DialogResult soru = MessageBox.Show("Sunucuyla başarılı bir şekilde bağlantı kuruldu.\nSunucuya gerekli tablolar eklenecek ve sizden yönetici bilgilerini girmenizi isteyeceğiz ve tam yetkili bir yönetici ekleyeceğiz.\nAynı zamanda eğer ekli kullanıcı veya yönetici(as admin hariç) var ise bunları tekrar eklemek isteyip istemediğinizi soracağız.\n\nDevam etmek istediğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (soru == DialogResult.Yes)
                    {
                        frmTabloVerileriAktarma veriAktarma = new frmTabloVerileriAktarma();
                        veriAktarma.oServer = vServer;
                        veriAktarma.oDatabase = vDatabase;
                        veriAktarma.oUsername = vUsername;
                        veriAktarma.oPassword = vPassword;
                        veriAktarma.serverText = serverText.Text.Trim();
                        veriAktarma.databaseText = databaseText.Text.Trim();
                        veriAktarma.usernameText = usernameText.Text.Trim();
                        veriAktarma.passwordText = passwordText.Text.Trim();
                        veriAktarma.Show();
                        this.Hide();
                    }
                }
                catch (Exception hata)
                {
                    MessageBox.Show("Belirttiğiniz sunucu adresi, veritabanı adı veya kullanıcı adı hatalı.\n\nŞu nedenlerden dolayı da sunucuya bağlanılamamış olabilir:\n- Sunucu adresi hatalı girilmiş ya da sunucu artık yok.\n- Veritabanı adı hatalı girilmiş ya da öyle bir veritabanı yok.\n- Kullanıcı adı hatalı girilmiş, kullanıcı adı yok ya da kullanıcı gerekli yetkiye sahip değil.\n- Şifre hatalı girilmiş.\nHata mesajı: " + hata.Message, "Sunucu hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public static string MD5Sifrele(string metin)
        {
            // MD5CryptoServiceProvider nesnenin yeni bir instance'sını oluşturalım.
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

            //Girilen veriyi bir byte dizisine dönüştürelim ve hash hesaplamasını yapalım.
            byte[] btr = Encoding.UTF8.GetBytes(metin);
            btr = md5.ComputeHash(btr);

            //byte'ları biriktirmek için yeni bir StringBuilder ve string oluşturalım.
            StringBuilder sb = new StringBuilder();


            //hash yapılmış her bir byte'ı dizi içinden alalım ve her birini hexadecimal string olarak formatlayalım.
            foreach (byte ba in btr)
            {
                sb.Append(ba.ToString("x2").ToLower());
            }

            //hexadecimal(onaltılık) stringi geri döndürelim.
            return sb.ToString();
        }

        string vServer, vDatabase, vUsername, vPassword;

        private void frmSunucuAyarlari_Load(object sender, EventArgs e)
        {
            if (!(svsettings.Default.server == "" && svsettings.Default.database == "" && svsettings.Default.username == "" && svsettings.Default.password == ""))
            {
                serverText.Text = server;
                databaseText.Text = database;
                usernameText.Text = username;
                passwordText.Text = password;
                vServer = server;
                vDatabase = database;
                vUsername = username;
                vPassword = password;
            }
        }

        private MySqlConnection baglantiYap()
        {
            MySqlConnection con = new MySqlConnection("Server=" + server + ";Database=" + database + ";Uid=" + username + ";Pwd=" + password + ";");
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }
        
    }
}
