using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace MysqlUyelikSistemi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string server = svsettings.Default.server, database = svsettings.Default.database, username = svsettings.Default.username, password = svsettings.Default.password, users = "uyeler", admins = "yoneticiler";
        static Regex ValidEmailRegex = CreateValidEmailRegex();

        private MySqlConnection baglantiYap()
        {
            MySqlConnection con = new MySqlConnection("Server=" + server + ";Database=" + database + ";Uid=" + username + ";Pwd=" + password + ";");
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }

        private void girisButton_Click(object sender, EventArgs e)
        {
            if (girisKullanici.Text.Trim() != "" && girisSifre.Text.Trim() != "")
            {
                string kullanici = girisKullanici.Text.Trim(), sifre = MD5Sifrele(girisSifre.Text.Trim());
                MySqlConnection con = baglantiYap();
                MySqlCommand oku = new MySqlCommand("SELECT * FROM " + users + " WHERE kullanici='" + kullanici + "' AND sifre='" + sifre + "'", con);
                MySqlDataReader okuyucu = oku.ExecuteReader();
                if (okuyucu.Read())
                {
                    if (!Convert.ToBoolean(okuyucu["yasakli"]))
                    {
                        frmKullaniciPaneli panel = new frmKullaniciPaneli();
                        panel.kendiID = Convert.ToInt32(okuyucu["id"]);
                        panel.kendiKullanici = okuyucu["kullanici"].ToString();
                        panel.kendiSifre = okuyucu["sifre"].ToString();
                        panel.kendiPosta = okuyucu["posta"].ToString();
                        panel.gYonetici = false;
                        panel.label1.Text = "Hoşgeldiniz sayın " + kullanici;
                        panel.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Sayın " + kullanici + ", yönetici tarafında yasaklandınız.\nSisteme artık giriş yapamazsınız.\nLütfen yöneticiye başvurun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    oku.Dispose();
                    okuyucu.Dispose();
                    MySqlCommand readadmin = new MySqlCommand("SELECT * FROM " + admins + " WHERE kullanici='" + kullanici + "' AND sifre='" + sifre + "'", con);
                    MySqlDataReader reader = readadmin.ExecuteReader();
                    if (reader.Read())
                    {
                        if (!Convert.ToBoolean(reader["yasakli"]))
                        {
                            frmKullaniciPaneli panel = new frmKullaniciPaneli();
                            panel.label1.Text = "Hoşgeldiniz sayın " + kullanici;
                            panel.ekleButton.Visible = true;
                            panel.silButton.Visible = true;
                            panel.duzenleButton.Visible = true;
                            panel.yasaklaButton.Visible = true;
                            panel.dokuButton.Visible = true;
                            panel.listView1.Visible = true;
                            panel.kendiID = Convert.ToInt32(reader["id"]);
                            panel.kendiKullanici = reader["kullanici"].ToString();
                            panel.kendiSifre = reader["sifre"].ToString();
                            panel.kendiPosta = reader["posta"].ToString();
                            panel.gDoku = Convert.ToBoolean(reader["doku"]);
                            if (Convert.ToBoolean(reader["doku"]))
                            {
                                panel.menuStrip1.Visible = true;
                            }
                            panel.gAs = Convert.ToBoolean(reader["asyonetici"]);
                            panel.gYonetici = true;
                            panel.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Sayın "+kullanici+" yöneticimiz, maalesef yasaklandınız.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı adınız veya şifreniz yanlış.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        enum Kontrol
        {
            Hatali,
            Calisiyor
        }

        public List<string> MySqlCollectionQuery(MySqlConnection connection, string cmd)
        {
            List<string> QueryResult = new List<string>();
            MySqlCommand cmdName = new MySqlCommand(cmd, connection);
            MySqlDataReader reader = cmdName.ExecuteReader();
            while (reader.Read())
            {
                QueryResult.Add(reader.GetString(0));
            }
            reader.Close();
            return QueryResult;
        }

        private Kontrol sunucuKontrol()
        {
            Kontrol sunucu = Kontrol.Hatali;
            try
            {
                MySqlConnection con = baglantiYap();
                List<string> veri = MySqlCollectionQuery(con, "SHOW TABLES FROM " + svsettings.Default.database);
                if (veri.Count == 2)
                {
                    MySqlCommand readAdmins = new MySqlCommand("SELECT * FROM yoneticiler WHERE asyonetici=1", con);
                    MySqlDataReader reader = readAdmins.ExecuteReader();
                    if (reader.Read())
                    {
                        sunucu = Kontrol.Calisiyor;
                    }
                    else
                    {
                        sunucu = Kontrol.Hatali;
                    }
                }
                else
                {
                    sunucu = Kontrol.Hatali;
                }
            }
            catch
            {
                sunucu = Kontrol.Hatali;
            }
            return sunucu;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            if (svsettings.Default.server == "" && svsettings.Default.database == "" && svsettings.Default.username == "" && svsettings.Default.password == "")
            {
                DialogResult soru = MessageBox.Show("Sunucu ayarları yapılandırılmamış.\n\nYapılandırmak ister misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (soru == DialogResult.Yes)
                {
                    this.Hide();
                    frmSunucuAyarlari sunucu = new frmSunucuAyarlari();
                    sunucu.Show();
                }
                else
                {
                    Application.ExitThread();
                }
            }
            else
            {
                Kontrol durum = sunucuKontrol();
                if (durum == Kontrol.Hatali)
                {
                    DialogResult soru = MessageBox.Show("Sunucuya bağlanılamıyor.\nYönetici ayarlarınızı doğrulayarak sunucu ayarlarını değiştirebilirsiniz.\nEğer sunucuyu kuran kişi siz değilseniz bu mesajı görmezden gelebilirsiniz.\nSunucu ayarlarına erişmek için yönetici bilgilerinizi doğrulamak ister misiniz?", "Sunucuya bağlanılamıyor", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (soru == DialogResult.Yes)
                    {
                        frmYoneticiDogrulama dogrulama = new frmYoneticiDogrulama();
                        dogrulama.Show();
                        this.Hide();
                    }
                    else
                    {
                        Application.ExitThread();
                    }
                }
            }
        }

        private bool ToBoolean(string veri)
        {
            bool donus = false;
            if (veri == "1")
            {
                donus = true;
            }
            else if (veri == "0")
            {
                donus = false;
            }
            return donus;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
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

        private static Regex CreateValidEmailRegex()
        {
            string validEmailPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            return new Regex(validEmailPattern, RegexOptions.IgnoreCase);
        }

        internal static bool EmailIsValid(string emailAddress)
        {
            bool isValid = ValidEmailRegex.IsMatch(emailAddress);

            return isValid;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (uyeKullanici.Text.Trim() != "" && uyePosta.Text.Trim() != "" && uyeSifre.Text.Trim() != "" && uyeSifreTekrar.Text.Trim() != "" && uyeSifre.Text.Trim() == uyeSifreTekrar.Text.Trim() && EmailIsValid(uyePosta.Text.Trim()))
            {
                string kullanici = uyeKullanici.Text.Trim(), sifre = MD5Sifrele(uyeSifre.Text.Trim()), posta = uyePosta.Text.Trim();
                MySqlConnection con = baglantiYap();
                MySqlCommand oku = new MySqlCommand("SELECT * FROM " + users + " WHERE kullanici='"+kullanici+"' OR posta='"+posta+"'", con);
                MySqlDataReader okuyucu = oku.ExecuteReader();
                if (!okuyucu.Read())
                {
                    MySqlCommand komut = new MySqlCommand("INSERT INTO " + users + " (kullanici, sifre, posta) VALUES ('" + kullanici + "', '" + sifre + "', '" + posta + "')", con);
                    okuyucu.Dispose();
                    oku.Dispose();
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Üyelik işlemi başarıyla tamamlandı.\nÜye olduğunuz için teşekkür ederiz.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Belirttiğiniz kullanıcı adını veya e-posta adresini kullanan bir kullanıcı var.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Lütfen gerekli alanları, doğru doldurduğunuza ve e-posta adresini geçerli girdiğinizden emin olunuz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
