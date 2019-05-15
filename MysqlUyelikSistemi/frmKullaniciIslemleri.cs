using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MysqlUyelikSistemi
{
    public partial class frmKullaniciIslemleri : Form
    {
        public frmKullaniciIslemleri()
        {
            InitializeComponent();
        }

        public IslemTuru islem;
        string server = svsettings.Default.server, database = svsettings.Default.database, username = svsettings.Default.username, password = svsettings.Default.password, users = "uyeler", admins = "yoneticiler";
        static Regex ValidEmailRegex = CreateValidEmailRegex();
        public KullaniciTuru Uye = KullaniciTuru.Uye;

        public enum KullaniciTuru
        {
            Uye,
            Yonetici
        }


        public enum IslemTuru
        {
            Ekleme,
            Duzenleme
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

        private void frmKullaniciIslemleri_Load(object sender, EventArgs e)
        {
            comboBox1.Text = "Üye";
            dokuText.Text = "False";
            yasakliText.Text = "False";
            if (Uye == KullaniciTuru.Uye)
            {
                comboBox1.Text = "Üye";
            }
            else if (Uye == KullaniciTuru.Yonetici)
            {
                comboBox1.Text = "Yönetici";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Ekle")
            {
                string kullanici = kullaniciText.Text.Trim(), sifre = MD5Sifrele(sifreText.Text.Trim()), posta = postaText.Text.Trim();
                bool yasakli = Convert.ToBoolean(yasakliText.Text), doku = Convert.ToBoolean(dokuText.Text);
                if (kullanici != "" && sifre != "" && EmailIsValid(posta) && !(Convert.ToBoolean(varMi(kullanici, sifre)[0])))
                {
                    string table = "";
                    if (comboBox1.Text == "Üye")
                    {
                        table = users;
                    }
                    else if (comboBox1.Text == "Yönetici")
                    {
                        table = admins;
                    }
                    MySqlConnection con = baglantiYap();
                    MySqlCommand komut = new MySqlCommand();
                    if (table == users)
                    {
                        komut.CommandText = "INSERT INTO " + table + " (kullanici, sifre, posta, yasakli) VALUES ('" + kullanici + "', '" + sifre + "', '" + posta + "', " + yasakli + ")";
                    }
                    else if (table == admins)
                    {
                        komut.CommandText = "INSERT INTO " + table + " (kullanici, sifre, posta, yasakli, doku) VALUES ('" + kullanici + "', '" + sifre + "', '" + posta + "', " + yasakli + ", " + doku + ")";
                    }
                    komut.Connection = con;
                    komut.ExecuteNonQuery();
                    komut.Dispose();
                    con.Close();
                    frmKullaniciPaneli panel = (frmKullaniciPaneli)Application.OpenForms["frmKullaniciPaneli"];
                    panel.yenile();
                    MessageBox.Show("\"" + kullanici + "\" adlı kullanıcı başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                }
            }
            else if (button1.Text == "Düzenle")
            {
                string kullanici = kullaniciText.Text.Trim(), sifre = sifreText.Text.Trim(), posta = postaText.Text.Trim();
                int id = Convert.ToInt32(idText.Text);
                bool yasakli = Convert.ToBoolean(yasakliText.Text), doku = Convert.ToBoolean(dokuText.Text);
                if (kullanici != "" && EmailIsValid(posta) && !(Convert.ToBoolean(varMi(kullanici, sifre)[0])) || Convert.ToInt32(varMi(kullanici, sifre)[1]) == id)
                {
                    sifre = MD5Sifrele(sifre);
                    string table = "";
                    if (comboBox1.Text == "Üye")
                    {
                        table = users;
                    }
                    else if (comboBox1.Text == "Yönetici")
                    {
                        table = admins;
                    }

                    MySqlConnection con = baglantiYap();
                    MySqlCommand komut = new MySqlCommand();
                    if (sifreText.Text.Trim() == "")
                    {
                        if (table == users)
                        {
                            komut.CommandText = "UPDATE " + table + " SET kullanici='" + kullanici + "', posta='" + posta + "', yasakli=" + yasakli + " WHERE id=" + id + "";
                        }
                        else if (table == admins)
                        {
                            komut.CommandText = "UPDATE " + table + " SET kullanici='" + kullanici + "', posta='" + posta + "', yasakli=" + yasakli + ", doku=" + doku + " WHERE id=" + id + "";
                        }
                    }
                    else
                    {
                        if (table == users)
                        {
                            komut.CommandText = "UPDATE " + table + " SET kullanici='" + kullanici + "', sifre='" + sifre + "', posta='" + posta + "', yasakli=" + yasakli + " WHERE id=" + id + "";
                        }
                        else if (table == admins)
                        {
                            komut.CommandText = "UPDATE " + table + " SET kullanici='" + kullanici + "', sifre='" + sifre + "', posta='" + posta + "', yasakli=" + yasakli + ", doku=" + doku + " WHERE id=" + id + "";
                        }
                    }
                    komut.Connection = con;
                    komut.ExecuteNonQuery();
                    komut.Dispose();
                    con.Close();
                    frmKullaniciPaneli panel = (frmKullaniciPaneli)Application.OpenForms["frmKullaniciPaneli"];
                    panel.yenile();
                    MessageBox.Show("\"" + kullanici + "\" adlı kullanıcı başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                }
            }
        }

        private object[] varMi(string bKullanici, string bPosta)
        {
            bool sonuc = false;
            int id = 0;
            MySqlConnection con = baglantiYap();
            MySqlCommand oku = new MySqlCommand("SELECT id, kullanici, sifre FROM " + users + " WHERE kullanici='" + bKullanici + "' OR posta='" + bPosta + "'", con);
            MySqlDataReader okuyucu = oku.ExecuteReader();
            if (okuyucu.Read())
            {
                sonuc = true;
                id = Convert.ToInt32(okuyucu["id"]);
            }
            else
            {
                oku.Dispose();
                okuyucu.Dispose();
                MySqlCommand readadmins = new MySqlCommand("SELECT id, kullanici, sifre FROM " + admins + " WHERE kullanici='" + bKullanici + "' OR posta='" + bPosta + "'", con);
                MySqlDataReader reader = readadmins.ExecuteReader();
                if (reader.Read())
                {
                    sonuc = true;
                    id = Convert.ToInt32(reader["id"]);
                }
                else
                {
                    sonuc = false;
                }
            }
            object[] dizi = { sonuc, id };
            return dizi;
        }

        private string[] IdBul(string sKullanici, string sSifre)
        {
            string id = "0", turu = "";
            MySqlConnection con = baglantiYap();
            MySqlCommand oku = new MySqlCommand("SELECT id, kullanici, sifre FROM " + users + " WHERE kullanici='" + sKullanici + "' AND sifre='" + sSifre + "'", con);
            MySqlDataReader okuyucu = oku.ExecuteReader();
            if (okuyucu.Read())
            {
                id = okuyucu["id"].ToString();
                turu = "Üye";
            }
            else
            {
                oku.Dispose();
                okuyucu.Dispose();
                MySqlCommand readadmins = new MySqlCommand("SELECT id, kullanici, sifre FROM " + admins + " WHERE kullanici='" + sKullanici + "' AND sifre='" + sSifre + "'", con);
                MySqlDataReader reader = readadmins.ExecuteReader();
                if (reader.Read())
                {
                    id = okuyucu[id].ToString();
                    turu = "Yönetici";
                }
                else
                {
                    id = "-1";
                    turu = "-";
                }
            }
            string[] dizi = { id, turu };
            return dizi;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Üye")
            {
                dokuText.Enabled = false;
            }
            else if (comboBox1.Text == "Yönetici")
            {
                dokuText.Enabled = true;
            }
        }
    }
}
