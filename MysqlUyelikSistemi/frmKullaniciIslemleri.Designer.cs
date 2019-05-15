namespace MysqlUyelikSistemi
{
    partial class frmKullaniciIslemleri
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKullaniciIslemleri));
            this.idText = new System.Windows.Forms.TextBox();
            this.kullaniciText = new System.Windows.Forms.TextBox();
            this.sifreText = new System.Windows.Forms.TextBox();
            this.postaText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.yasakliText = new System.Windows.Forms.ComboBox();
            this.dokuText = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // idText
            // 
            this.idText.Enabled = false;
            this.idText.Location = new System.Drawing.Point(85, 39);
            this.idText.Name = "idText";
            this.idText.Size = new System.Drawing.Size(100, 20);
            this.idText.TabIndex = 0;
            this.idText.Text = "0";
            // 
            // kullaniciText
            // 
            this.kullaniciText.Location = new System.Drawing.Point(85, 65);
            this.kullaniciText.Name = "kullaniciText";
            this.kullaniciText.Size = new System.Drawing.Size(100, 20);
            this.kullaniciText.TabIndex = 0;
            // 
            // sifreText
            // 
            this.sifreText.Location = new System.Drawing.Point(85, 91);
            this.sifreText.Name = "sifreText";
            this.sifreText.Size = new System.Drawing.Size(100, 20);
            this.sifreText.TabIndex = 0;
            // 
            // postaText
            // 
            this.postaText.Location = new System.Drawing.Point(85, 117);
            this.postaText.Name = "postaText";
            this.postaText.Size = new System.Drawing.Size(100, 20);
            this.postaText.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Kullanıcı Adı:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Şifre:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "e-Posta:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Yasaklı:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 172);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Doku:";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Üye",
            "Yönetici"});
            this.comboBox1.Location = new System.Drawing.Point(85, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(100, 21);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(93, 195);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 32);
            this.button1.TabIndex = 3;
            this.button1.Text = "Ekle/Düzenle";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // yasakliText
            // 
            this.yasakliText.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yasakliText.FormattingEnabled = true;
            this.yasakliText.Items.AddRange(new object[] {
            "True",
            "False"});
            this.yasakliText.Location = new System.Drawing.Point(85, 142);
            this.yasakliText.Name = "yasakliText";
            this.yasakliText.Size = new System.Drawing.Size(100, 21);
            this.yasakliText.TabIndex = 4;
            // 
            // dokuText
            // 
            this.dokuText.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dokuText.FormattingEnabled = true;
            this.dokuText.Items.AddRange(new object[] {
            "True",
            "False"});
            this.dokuText.Location = new System.Drawing.Point(85, 168);
            this.dokuText.Name = "dokuText";
            this.dokuText.Size = new System.Drawing.Size(100, 21);
            this.dokuText.TabIndex = 4;
            // 
            // frmKullaniciIslemleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(194, 233);
            this.Controls.Add(this.dokuText);
            this.Controls.Add(this.yasakliText);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.postaText);
            this.Controls.Add(this.sifreText);
            this.Controls.Add(this.kullaniciText);
            this.Controls.Add(this.idText);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmKullaniciIslemleri";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kullanıcı İşlemleri";
            this.Load += new System.EventHandler(this.frmKullaniciIslemleri_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox idText;
        public System.Windows.Forms.TextBox kullaniciText;
        public System.Windows.Forms.TextBox sifreText;
        public System.Windows.Forms.TextBox postaText;
        public System.Windows.Forms.ComboBox comboBox1;
        public System.Windows.Forms.ComboBox yasakliText;
        public System.Windows.Forms.ComboBox dokuText;
        public System.Windows.Forms.Button button1;
    }
}