namespace MysqlUyelikSistemi
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.girisButton = new System.Windows.Forms.Button();
            this.girisSifre = new System.Windows.Forms.TextBox();
            this.girisKullanici = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.uyeKullanici = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.uyeSifreTekrar = new System.Windows.Forms.TextBox();
            this.uyeSifre = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.uyePosta = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.girisButton);
            this.groupBox1.Controls.Add(this.girisSifre);
            this.groupBox1.Controls.Add(this.girisKullanici);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(222, 159);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Giriş Yap";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Şifre:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Kullanıcı Adı:";
            // 
            // girisButton
            // 
            this.girisButton.Location = new System.Drawing.Point(129, 77);
            this.girisButton.Name = "girisButton";
            this.girisButton.Size = new System.Drawing.Size(75, 26);
            this.girisButton.TabIndex = 1;
            this.girisButton.Text = "Giriş Yap";
            this.girisButton.UseVisualStyleBackColor = true;
            this.girisButton.Click += new System.EventHandler(this.girisButton_Click);
            // 
            // girisSifre
            // 
            this.girisSifre.Location = new System.Drawing.Point(116, 51);
            this.girisSifre.Name = "girisSifre";
            this.girisSifre.PasswordChar = '*';
            this.girisSifre.Size = new System.Drawing.Size(100, 22);
            this.girisSifre.TabIndex = 0;
            // 
            // girisKullanici
            // 
            this.girisKullanici.Location = new System.Drawing.Point(116, 25);
            this.girisKullanici.Name = "girisKullanici";
            this.girisKullanici.Size = new System.Drawing.Size(100, 22);
            this.girisKullanici.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.uyeKullanici);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.uyeSifreTekrar);
            this.groupBox2.Controls.Add(this.uyeSifre);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.uyePosta);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox2.Location = new System.Drawing.Point(240, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(222, 159);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Üye Ol";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "E-Posta";
            // 
            // uyeKullanici
            // 
            this.uyeKullanici.Location = new System.Drawing.Point(116, 18);
            this.uyeKullanici.Name = "uyeKullanici";
            this.uyeKullanici.Size = new System.Drawing.Size(100, 22);
            this.uyeKullanici.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Şifre Tekrar:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Şifre:";
            // 
            // uyeSifreTekrar
            // 
            this.uyeSifreTekrar.Location = new System.Drawing.Point(116, 70);
            this.uyeSifreTekrar.Name = "uyeSifreTekrar";
            this.uyeSifreTekrar.PasswordChar = '*';
            this.uyeSifreTekrar.Size = new System.Drawing.Size(100, 22);
            this.uyeSifreTekrar.TabIndex = 0;
            // 
            // uyeSifre
            // 
            this.uyeSifre.Location = new System.Drawing.Point(116, 44);
            this.uyeSifre.Name = "uyeSifre";
            this.uyeSifre.PasswordChar = '*';
            this.uyeSifre.Size = new System.Drawing.Size(100, 22);
            this.uyeSifre.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Kullanıcı Adı:";
            // 
            // uyePosta
            // 
            this.uyePosta.Location = new System.Drawing.Point(116, 96);
            this.uyePosta.Name = "uyePosta";
            this.uyePosta.Size = new System.Drawing.Size(100, 22);
            this.uyePosta.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(128, 122);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 26);
            this.button2.TabIndex = 1;
            this.button2.Text = "Üye Ol";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 181);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Üyelik Sistemi Mysql";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button girisButton;
        private System.Windows.Forms.TextBox girisSifre;
        private System.Windows.Forms.TextBox girisKullanici;
        private System.Windows.Forms.TextBox uyeKullanici;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox uyeSifreTekrar;
        private System.Windows.Forms.TextBox uyeSifre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox uyePosta;
    }
}

