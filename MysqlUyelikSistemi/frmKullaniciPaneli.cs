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
    public partial class frmKullaniciPaneli : Form
    {
        public frmKullaniciPaneli()
        {
            InitializeComponent();
        }

        public bool gYonetici = false, gDoku = false, gAs = false;
        public string kendiKullanici = "", kendiSifre = "", kendiPosta = "";
        public int kendiID = 0;
        string server = svsettings.Default.server, database = svsettings.Default.database, username = svsettings.Default.username, password = svsettings.Default.password, users = "uyeler", admins = "yoneticiler";

        private MySqlConnection baglantiYap()
        {
            MySqlConnection con = new MySqlConnection("Server=" + server + ";Database=" + database + ";Uid=" + username + ";Pwd=" + password + ";");
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }

        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                frmKullaniciIslemleri islemler = new frmKullaniciIslemleri();
                islemler.islem = frmKullaniciIslemleri.IslemTuru.Duzenleme;
                if (listView1.SelectedItems[0].SubItems[7].Text == "Üye")
                {
                    islemler.Uye = frmKullaniciIslemleri.KullaniciTuru.Uye;
                }
                else if (listView1.SelectedItems[0].SubItems[7].Text == "Yönetici")
                {
                    islemler.Uye = frmKullaniciIslemleri.KullaniciTuru.Yonetici;
                }

                if (!gDoku)
                {
                    islemler.comboBox1.Items.RemoveAt(1);
                }
                islemler.button1.Text = "Düzenle";
                islemler.idText.Text = listView1.SelectedItems[0].Text;
                islemler.kullaniciText.Text = listView1.SelectedItems[0].SubItems[1].Text;
                islemler.postaText.Text = listView1.SelectedItems[0].SubItems[3].Text;
                islemler.yasakliText.Text = listView1.SelectedItems[0].SubItems[4].Text;
                islemler.dokuText.Text = listView1.SelectedItems[0].SubItems[5].Text;
                islemler.ShowDialog();
            }
        }

        private void yasaklaButton_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                int id = Convert.ToInt32(listView1.SelectedItems[0].Text);
                bool doku = ToBoolean(listView1.SelectedItems[0].SubItems[5].Text), asyonetici = ToBoolean(listView1.SelectedItems[0].SubItems[6].Text);
                if (!(doku || asyonetici))
                {
                    DialogResult soru = MessageBox.Show("\"" + listView1.SelectedItems[0].SubItems[1].Text + "\" adlı kullanıcıyı yasaklama/kaldırmak istediğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (soru == DialogResult.Yes)
                    {
                        string table = "", uyeturu = listView1.SelectedItems[0].SubItems[7].Text;
                        if (uyeturu == "Üye")
                        {
                            table = users;
                        }
                        else if (uyeturu == "Yönetici")
                        {
                            table = admins;
                        }

                        bool yasak = Convert.ToBoolean(listView1.SelectedItems[0].SubItems[4].Text);
                        MySqlConnection con = baglantiYap();
                        MySqlCommand komut = new MySqlCommand("UPDATE " + table + " SET yasakli=" + !yasak, con);
                        komut.ExecuteNonQuery();
                        komut.Dispose();
                        con.Close();
                        string kullanici = listView1.SelectedItems[0].SubItems[1].Text;
                        yenile();
                        MessageBox.Show("\"" + kullanici + "\" adlı kullanıcı başarıyla yasaklandı/kaldırıldı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Bu kullanıcıyı yasaklama/kaldırma yetkiniz bulunmamaktadır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dokuButton_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                int id = Convert.ToInt32(listView1.SelectedItems[0].Text);
                bool doku = ToBoolean(listView1.SelectedItems[0].SubItems[5].Text), asyonetici = ToBoolean(listView1.SelectedItems[0].SubItems[6].Text);
                if (!(doku || asyonetici))
                {
                    DialogResult soru = MessageBox.Show("\"" + listView1.SelectedItems[0].SubItems[1].Text + "\" adlı kullanıcıyı doku vermek/almak istediğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (soru == DialogResult.Yes)
                    {
                        string table = "", uyeturu = listView1.SelectedItems[0].SubItems[7].Text;
                        if (uyeturu == "Üye")
                        {
                            table = users;
                        }
                        else if (uyeturu == "Yönetici")
                        {
                            table = admins;
                        }

                        bool dokunulmaz = Convert.ToBoolean(listView1.SelectedItems[0].SubItems[5].Text);

                        MySqlConnection con = baglantiYap();
                        MySqlCommand komut = new MySqlCommand("UPDATE " + table + " SET doku=" + !dokunulmaz, con);
                        komut.ExecuteNonQuery();
                        komut.Dispose();
                        con.Close();
                        yenile();
                        MessageBox.Show("\"" + listView1.SelectedItems[0].SubItems[1].Text + "\" adlı kullanıcıya başarıyla doku verdiniz/aldınız.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Bu kullanıcıya doku verme/alma yetkiniz bulunmamaktadır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void silButton_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                int id = Convert.ToInt32(listView1.SelectedItems[0].Text);
                string kullanici = listView1.SelectedItems[0].SubItems[1].Text;
                bool doku = ToBoolean(listView1.SelectedItems[0].SubItems[5].Text), asyonetici = ToBoolean(listView1.SelectedItems[0].SubItems[6].Text);
                if (!(doku || asyonetici))
                {
                    DialogResult soru = MessageBox.Show("\"" + listView1.SelectedItems[0].SubItems[1].Text + "\" adlı kullanıcıyı silmek istediğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (soru == DialogResult.Yes)
                    {
                        string table = "", uyeturu = listView1.SelectedItems[0].SubItems[7].Text;
                        if (uyeturu == "Üye")
                        {
                            table = users;
                        }
                        else if (uyeturu == "Yönetici")
                        {
                            table = admins;
                        }

                        MySqlConnection con = baglantiYap();
                        MySqlCommand komut = new MySqlCommand("DELETE FROM " + table + " WHERE id=" + id + "", con);
                        komut.ExecuteNonQuery();
                        komut.Dispose();
                        con.Close();
                        yenile();
                        MessageBox.Show("\"" + kullanici + "\" adlı kullanıcı başarıyla silinmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Bu kullanıcıyı silme yetkiniz bulunmamaktadır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void sunucuAyarlarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSunucuAyarlari sunucuayar = new frmSunucuAyarlari();
            sunucuayar.ShowDialog();
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                int id = Convert.ToInt32(listView1.SelectedItems[0].Text);
                string kullanici = listView1.SelectedItems[0].SubItems[1].Text;
                bool doku = ToBoolean(listView1.SelectedItems[0].SubItems[5].Text), asyonetici = ToBoolean(listView1.SelectedItems[0].SubItems[6].Text);
                if (!(doku || asyonetici))
                {
                    DialogResult soru = MessageBox.Show("\"" + listView1.SelectedItems[0].SubItems[1].Text + "\" adlı kullanıcıyı silmek istediğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (soru == DialogResult.Yes)
                    {
                        string table = "", uyeturu = listView1.SelectedItems[0].SubItems[7].Text;
                        if (uyeturu == "Üye")
                        {
                            table = users;
                        }
                        else if (uyeturu == "Yönetici")
                        {
                            table = admins;
                        }

                        MySqlConnection con = baglantiYap();
                        MySqlCommand komut = new MySqlCommand("DELETE FROM " + table + " WHERE id=" + id + "", con);
                        komut.ExecuteNonQuery();
                        komut.Dispose();
                        con.Close();
                        yenile();
                        MessageBox.Show("\"" + kullanici + "\" adlı kullanıcı başarıyla silinmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Bu kullanıcıyı silme yetkiniz bulunmamaktadır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void yasaklakaldirclick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                int id = Convert.ToInt32(listView1.SelectedItems[0].Text);
                bool doku = ToBoolean(listView1.SelectedItems[0].SubItems[5].Text), asyonetici = ToBoolean(listView1.SelectedItems[0].SubItems[6].Text);
                if (!(doku || asyonetici))
                {
                    DialogResult soru = MessageBox.Show("\"" + listView1.SelectedItems[0].SubItems[1].Text + "\" adlı kullanıcıyı yasaklama/kaldırmak istediğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (soru == DialogResult.Yes)
                    {
                        string table = "", uyeturu = listView1.SelectedItems[0].SubItems[7].Text;
                        if (uyeturu == "Üye")
                        {
                            table = users;
                        }
                        else if (uyeturu == "Yönetici")
                        {
                            table = admins;
                        }

                        bool yasak = Convert.ToBoolean(listView1.SelectedItems[0].SubItems[4].Text);
                        MySqlConnection con = baglantiYap();
                        MySqlCommand komut = new MySqlCommand("UPDATE " + table + " SET yasakli=" + !yasak, con);
                        komut.ExecuteNonQuery();
                        komut.Dispose();
                        con.Close();
                        string kullanici = listView1.SelectedItems[0].SubItems[1].Text;
                        yenile();
                        MessageBox.Show("\"" + kullanici + "\" adlı kullanıcı başarıyla yasaklandı/kaldırıldı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Bu kullanıcıyı yasaklama/kaldırma yetkiniz bulunmamaktadır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dokuVerAlToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                int id = Convert.ToInt32(listView1.SelectedItems[0].Text);
                bool doku = ToBoolean(listView1.SelectedItems[0].SubItems[5].Text), asyonetici = ToBoolean(listView1.SelectedItems[0].SubItems[6].Text);
                if (!(doku || asyonetici))
                {
                    DialogResult soru = MessageBox.Show("\"" + listView1.SelectedItems[0].SubItems[1].Text + "\" adlı kullanıcıyı doku vermek/almak istediğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (soru == DialogResult.Yes)
                    {
                        string table = "", uyeturu = listView1.SelectedItems[0].SubItems[7].Text;
                        if (uyeturu == "Üye")
                        {
                            table = users;
                        }
                        else if (uyeturu == "Yönetici")
                        {
                            table = admins;
                        }

                        bool dokunulmaz = Convert.ToBoolean(listView1.SelectedItems[0].SubItems[5].Text);

                        MySqlConnection con = baglantiYap();
                        MySqlCommand komut = new MySqlCommand("UPDATE " + table + " SET doku=" + !dokunulmaz, con);
                        komut.ExecuteNonQuery();
                        komut.Dispose();
                        con.Close();
                        yenile();
                        MessageBox.Show("\"" + listView1.SelectedItems[0].SubItems[1].Text + "\" adlı kullanıcıya başarıyla doku verdiniz/aldınız.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Bu kullanıcıya doku verme/alma yetkiniz bulunmamaktadır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ekleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKullaniciIslemleri islemler = new frmKullaniciIslemleri();
            islemler.islem = frmKullaniciIslemleri.IslemTuru.Ekleme;
            islemler.comboBox1.SelectedIndex = 0;
            if (!gDoku)
            {
                islemler.comboBox1.Items.RemoveAt(1);
            }
            islemler.button1.Text = "Ekle";
            islemler.ShowDialog();
        }

        private void duzenleButton_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                frmKullaniciIslemleri islemler = new frmKullaniciIslemleri();
                islemler.islem = frmKullaniciIslemleri.IslemTuru.Duzenleme;
                if (listView1.SelectedItems[0].SubItems[7].Text == "Üye")
                {
                    islemler.Uye = frmKullaniciIslemleri.KullaniciTuru.Uye;
                }
                else if (listView1.SelectedItems[0].SubItems[7].Text == "Yönetici")
                {
                    islemler.Uye = frmKullaniciIslemleri.KullaniciTuru.Yonetici;
                }
                
                if (!gDoku)
                {
                    islemler.comboBox1.Items.RemoveAt(1);
                }
                islemler.button1.Text = "Düzenle";
                islemler.idText.Text = listView1.SelectedItems[0].Text;
                islemler.kullaniciText.Text = listView1.SelectedItems[0].SubItems[1].Text;
                islemler.postaText.Text = listView1.SelectedItems[0].SubItems[3].Text;
                islemler.yasakliText.Text = listView1.SelectedItems[0].SubItems[4].Text;
                islemler.dokuText.Text = listView1.SelectedItems[0].SubItems[5].Text;
                islemler.ShowDialog();
            }
        }

        private void ekleButton_Click(object sender, EventArgs e)
        {
            frmKullaniciIslemleri islemler = new frmKullaniciIslemleri();
            islemler.islem = frmKullaniciIslemleri.IslemTuru.Ekleme;
            islemler.comboBox1.SelectedIndex = 0;
            if (!gDoku)
            {
                islemler.comboBox1.Items.RemoveAt(1);
            }
            islemler.button1.Text = "Ekle";
            islemler.ShowDialog();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                string kullanici = listView1.SelectedItems[0].SubItems[1].Text, sifre = listView1.SelectedItems[0].SubItems[2].Text, posta = listView1.SelectedItems[0].SubItems[3].Text, uyelikturu = listView1.SelectedItems[0].SubItems[7].Text;
                int id = Convert.ToInt32(listView1.SelectedItems[0].Text);
                bool yasakli = Convert.ToBoolean(listView1.SelectedItems[0].SubItems[4].Text), doku = Convert.ToBoolean(listView1.SelectedItems[0].SubItems[5].Text), asyonetici = Convert.ToBoolean(listView1.SelectedItems[0].SubItems[6].Text);
                if (yasakli)
                {
                    yasaklaButton.Text = "Yasağı Kaldır";
                }
                else
                {
                    yasaklaButton.Text = "Yasakla";
                }

                if (doku)
                {

                    silButton.Enabled = false;
                    duzenleButton.Enabled = false;
                    yasaklaButton.Enabled = false;
                    if (!gAs)
                    {
                        dokuButton.Enabled = false;
                    }
                    dokuButton.Text = "Doku Al";
                }
                else
                {
                    silButton.Enabled = true;
                    duzenleButton.Enabled = true;
                    yasaklaButton.Enabled = true;
                    if (!gAs)
                    {
                        dokuButton.Enabled = true;
                    }
                    dokuButton.Text = "Doku Ver";
                }

                if (asyonetici)
                {
                    silButton.Enabled = false;
                    duzenleButton.Enabled = false;
                    yasaklaButton.Enabled = false;
                    dokuButton.Enabled = false;
                }
                else
                {
                    silButton.Enabled = true;
                    duzenleButton.Enabled = true;
                    yasaklaButton.Enabled = true;
                    dokuButton.Enabled = true;
                }

                if (uyelikturu == "Üye")
                {
                    dokuButton.Enabled = false;
                }
                else if (uyelikturu == "Yönetici")
                {
                    dokuButton.Enabled = true;
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
            MessageBox.Show("veri = " + veri + "\ndonus = " + donus);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                string kullanici = listView1.SelectedItems[0].SubItems[1].Text, sifre = listView1.SelectedItems[0].SubItems[2].Text, posta = listView1.SelectedItems[0].SubItems[3].Text, uyelikturu = listView1.SelectedItems[0].SubItems[7].Text;
                int id = Convert.ToInt32(listView1.SelectedItems[0].Text);
                bool yasakli = Convert.ToBoolean(listView1.SelectedItems[0].SubItems[4].Text), doku = ToBoolean(listView1.SelectedItems[0].SubItems[5].Text), asyonetici = ToBoolean(listView1.SelectedItems[0].SubItems[6].Text);
                if (yasakli)
                {
                    contextMenuStrip1.Items[4].Text = "Yasağı Kaldır";
                }
                else
                {
                    contextMenuStrip1.Items[4].Text = "Yasakla";
                }

                if (doku)
                {
                    
                    contextMenuStrip1.Items[1].Enabled = false;
                    contextMenuStrip1.Items[2].Enabled = false;
                    contextMenuStrip1.Items[4].Enabled = false;
                    if (!gAs)
                    {
                        contextMenuStrip1.Items[5].Enabled = false;
                    }
                    contextMenuStrip1.Items[5].Text = "Doku Al";
                }
                else
                {
                    contextMenuStrip1.Items[1].Enabled = true;
                    contextMenuStrip1.Items[2].Enabled = true;
                    contextMenuStrip1.Items[4].Enabled = true;
                    if (!gAs)
                    {
                        contextMenuStrip1.Items[5].Enabled = true;
                    }
                    contextMenuStrip1.Items[5].Text = "Doku Ver";
                }

                if (asyonetici)
                {
                    contextMenuStrip1.Items[1].Enabled = false;
                    contextMenuStrip1.Items[2].Enabled = false;
                    contextMenuStrip1.Items[4].Enabled = false;
                    contextMenuStrip1.Items[5].Enabled = false;
                }
                else
                {
                    contextMenuStrip1.Items[1].Enabled = true;
                    contextMenuStrip1.Items[2].Enabled = true;
                    contextMenuStrip1.Items[4].Enabled = true;
                    contextMenuStrip1.Items[5].Enabled = true;
                }
            }
            else
            {
                contextMenuStrip1.Items[1].Enabled = false;
                contextMenuStrip1.Items[2].Enabled = false;
                contextMenuStrip1.Items[4].Enabled = false;
                contextMenuStrip1.Items[5].Enabled = false;
            }
        }

        public void yenile()
        {
            if (listView1.Visible == true)
            {
                listView1.Items.Clear();
                MySqlConnection con = baglantiYap();
                MySqlCommand oku = new MySqlCommand("SELECT * FROM " + users, con);
                MySqlDataReader okuyucu = oku.ExecuteReader();
                while (okuyucu.Read())
                {
                    int count = listView1.Items.Count;
                    listView1.Items.Add(okuyucu["id"].ToString());
                    listView1.Items[count].SubItems.Add(okuyucu["kullanici"].ToString());
                    listView1.Items[count].SubItems.Add(okuyucu["sifre"].ToString());
                    listView1.Items[count].SubItems.Add(okuyucu["posta"].ToString());
                    listView1.Items[count].SubItems.Add(okuyucu["yasakli"].ToString());
                    listView1.Items[count].SubItems.Add("False");
                    listView1.Items[count].SubItems.Add("False");
                    listView1.Items[count].SubItems.Add("Üye");
                }
                oku.Dispose();
                okuyucu.Dispose();
                MySqlCommand readadmins = new MySqlCommand("SELECT * FROM " + admins, con);
                MySqlDataReader reader = readadmins.ExecuteReader();
                while (reader.Read())
                {
                    int count = listView1.Items.Count;
                    listView1.Items.Add(reader["id"].ToString());
                    listView1.Items[count].SubItems.Add(reader["kullanici"].ToString());
                    listView1.Items[count].SubItems.Add(reader["sifre"].ToString());
                    listView1.Items[count].SubItems.Add(reader["posta"].ToString());
                    listView1.Items[count].SubItems.Add(reader["yasakli"].ToString());
                    listView1.Items[count].SubItems.Add(reader["doku"].ToString());
                    listView1.Items[count].SubItems.Add(reader["asyonetici"].ToString());
                    listView1.Items[count].SubItems.Add("Yönetici");
                }
                readadmins.Dispose();
                reader.Dispose();
                con.Close();
            }
        }

        private void frmKullaniciPaneli_Load(object sender, EventArgs e)
        {
            listView1.Columns.Add("ID");
            listView1.Columns.Add("Kullanıcı Adı");
            listView1.Columns.Add("Şifre");
            listView1.Columns.Add("e-Posta");
            listView1.Columns.Add("Yasaklı");
            listView1.Columns.Add("Doku");
            listView1.Columns.Add("AsYönetici");
            listView1.Columns.Add("Üyelik Türü");
            yenile();
        }

        private void frmKullaniciPaneli_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.Show();
            frmKullaniciPaneli panel1 = (frmKullaniciPaneli)Application.OpenForms["frmKullaniciPaneli"];
            panel1.Hide();
        }
    }
}
