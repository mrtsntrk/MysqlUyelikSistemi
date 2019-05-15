using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MysqlUyelikSistemi
{
    public partial class frmYoneticiEkleme : Form
    {
        public frmYoneticiEkleme()
        {
            InitializeComponent();
        }

        static Regex ValidEmailRegex = CreateValidEmailRegex();

        private MySqlConnection baglantiYap()
        {
            MySqlConnection con = new MySqlConnection("Server=" + svsettings.Default.server + ";Database=" + svsettings.Default.database + ";Uid=" + svsettings.Default.username + ";Pwd=" + svsettings.Default.password + ";");
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }

        private void asAdminEkle(string kullanici, string sifre, string posta)
        {
            MySqlConnection con = baglantiYap();
            MySqlCommand komut = new MySqlCommand("INSERT INTO yoneticiler (kullanici, sifre, posta, asyonetici, doku) VALUES ('" + kullanici.Trim() + "', '" + MD5Sifrele(sifre.Trim()) + "', '" + posta.Trim() + "', 1, 1)", con);
            komut.ExecuteNonQuery();
            komut.Dispose();
            con.Close();
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != "" && textBox2.Text.Trim() != "" && textBox3.Text.Trim() != "" && EmailIsValid(textBox3.Text.Trim()))
            {
                MySqlConnection con = baglantiYap();
                MySqlCommand rotus = new MySqlCommand("DELETE FROM yoneticiler WHERE asyonetici=1", con);
                rotus.ExecuteNonQuery();
                rotus.Dispose();
                con.Close();
                localAdminSettings.Default.kullanici = textBox1.Text.Trim();
                localAdminSettings.Default.sifre = textBox2.Text.Trim();
                localAdminSettings.Default.posta = textBox3.Text.Trim();
                localAdminSettings.Default.Save();
                asAdminEkle(textBox1.Text.Trim(), textBox2.Text.Trim(), textBox3.Text.Trim());
                DialogResult soru = MessageBox.Show("Sunucuya başarılı bir şekilde geçildi.\nProgramı yeniden başlatmak istiyor musunuz?(Başlatılmazsa yeni sunucu kullanılamaz.)", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (soru == DialogResult.Yes)
                {
                    Application.ExitThread();
                }
            }
        }

        private void frmYoneticiEkleme_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult soru = MessageBox.Show("Çıkış yaparsanız sistemin as yönetici olmayacak ve tam yetkili kimse olmamış olacak.(Eski sunucudan eklenen yöneticiler hariç) Daha sonra phpmyadmin vb kontrol panellerden as yönetici ekleyebilirsiniz.\n\nYine de çıkmak istediğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (soru == DialogResult.Yes)
            {
                Application.ExitThread();
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
