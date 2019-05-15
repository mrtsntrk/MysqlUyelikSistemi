namespace MysqlUyelikSistemi
{
    partial class frmKullaniciPaneli
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKullaniciPaneli));
            this.listView1 = new System.Windows.Forms.ListView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ekleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.silToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.düzenleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.dokuVerAlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dokuVerAlToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ekleButton = new System.Windows.Forms.Button();
            this.silButton = new System.Windows.Forms.Button();
            this.duzenleButton = new System.Windows.Forms.Button();
            this.yasaklaButton = new System.Windows.Forms.Button();
            this.dokuButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.yönetimToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sunucuAyarlarıToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.ContextMenuStrip = this.contextMenuStrip1;
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(12, 51);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(237, 236);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.Visible = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ekleToolStripMenuItem,
            this.silToolStripMenuItem,
            this.düzenleToolStripMenuItem,
            this.toolStripSeparator1,
            this.dokuVerAlToolStripMenuItem,
            this.dokuVerAlToolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(148, 120);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // ekleToolStripMenuItem
            // 
            this.ekleToolStripMenuItem.Name = "ekleToolStripMenuItem";
            this.ekleToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.ekleToolStripMenuItem.Text = "Ekle";
            this.ekleToolStripMenuItem.Click += new System.EventHandler(this.ekleToolStripMenuItem_Click);
            // 
            // silToolStripMenuItem
            // 
            this.silToolStripMenuItem.Name = "silToolStripMenuItem";
            this.silToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.silToolStripMenuItem.Text = "Sil";
            this.silToolStripMenuItem.Click += new System.EventHandler(this.silToolStripMenuItem_Click);
            // 
            // düzenleToolStripMenuItem
            // 
            this.düzenleToolStripMenuItem.Name = "düzenleToolStripMenuItem";
            this.düzenleToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.düzenleToolStripMenuItem.Text = "Düzenle";
            this.düzenleToolStripMenuItem.Click += new System.EventHandler(this.düzenleToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // dokuVerAlToolStripMenuItem
            // 
            this.dokuVerAlToolStripMenuItem.Name = "dokuVerAlToolStripMenuItem";
            this.dokuVerAlToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.dokuVerAlToolStripMenuItem.Text = "Yasakla/Kaldır";
            this.dokuVerAlToolStripMenuItem.Click += new System.EventHandler(this.yasaklakaldirclick);
            // 
            // dokuVerAlToolStripMenuItem1
            // 
            this.dokuVerAlToolStripMenuItem1.Name = "dokuVerAlToolStripMenuItem1";
            this.dokuVerAlToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.dokuVerAlToolStripMenuItem1.Text = "Doku Ver/Al";
            this.dokuVerAlToolStripMenuItem1.Click += new System.EventHandler(this.dokuVerAlToolStripMenuItem1_Click);
            // 
            // ekleButton
            // 
            this.ekleButton.Location = new System.Drawing.Point(12, 293);
            this.ekleButton.Name = "ekleButton";
            this.ekleButton.Size = new System.Drawing.Size(75, 23);
            this.ekleButton.TabIndex = 1;
            this.ekleButton.Text = "Ekle";
            this.ekleButton.UseVisualStyleBackColor = true;
            this.ekleButton.Visible = false;
            this.ekleButton.Click += new System.EventHandler(this.ekleButton_Click);
            // 
            // silButton
            // 
            this.silButton.Location = new System.Drawing.Point(93, 293);
            this.silButton.Name = "silButton";
            this.silButton.Size = new System.Drawing.Size(75, 23);
            this.silButton.TabIndex = 1;
            this.silButton.Text = "Sil";
            this.silButton.UseVisualStyleBackColor = true;
            this.silButton.Visible = false;
            this.silButton.Click += new System.EventHandler(this.silButton_Click);
            // 
            // duzenleButton
            // 
            this.duzenleButton.Location = new System.Drawing.Point(174, 293);
            this.duzenleButton.Name = "duzenleButton";
            this.duzenleButton.Size = new System.Drawing.Size(75, 23);
            this.duzenleButton.TabIndex = 1;
            this.duzenleButton.Text = "Düzenle";
            this.duzenleButton.UseVisualStyleBackColor = true;
            this.duzenleButton.Visible = false;
            this.duzenleButton.Click += new System.EventHandler(this.duzenleButton_Click);
            // 
            // yasaklaButton
            // 
            this.yasaklaButton.Location = new System.Drawing.Point(44, 322);
            this.yasaklaButton.Name = "yasaklaButton";
            this.yasaklaButton.Size = new System.Drawing.Size(85, 23);
            this.yasaklaButton.TabIndex = 1;
            this.yasaklaButton.Text = "Yasakla/Kaldır";
            this.yasaklaButton.UseVisualStyleBackColor = true;
            this.yasaklaButton.Visible = false;
            this.yasaklaButton.Click += new System.EventHandler(this.yasaklaButton_Click);
            // 
            // dokuButton
            // 
            this.dokuButton.Location = new System.Drawing.Point(135, 322);
            this.dokuButton.Name = "dokuButton";
            this.dokuButton.Size = new System.Drawing.Size(85, 23);
            this.dokuButton.TabIndex = 1;
            this.dokuButton.Text = "Doku Ver/Al";
            this.dokuButton.UseVisualStyleBackColor = true;
            this.dokuButton.Visible = false;
            this.dokuButton.Click += new System.EventHandler(this.dokuButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Hoşgeldiniz sayın kullanıcı";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.yönetimToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(260, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // yönetimToolStripMenuItem
            // 
            this.yönetimToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sunucuAyarlarıToolStripMenuItem});
            this.yönetimToolStripMenuItem.Name = "yönetimToolStripMenuItem";
            this.yönetimToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.yönetimToolStripMenuItem.Text = "Yönetim";
            // 
            // sunucuAyarlarıToolStripMenuItem
            // 
            this.sunucuAyarlarıToolStripMenuItem.Name = "sunucuAyarlarıToolStripMenuItem";
            this.sunucuAyarlarıToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.sunucuAyarlarıToolStripMenuItem.Text = "Sunucu Ayarları";
            this.sunucuAyarlarıToolStripMenuItem.Click += new System.EventHandler(this.sunucuAyarlarıToolStripMenuItem_Click);
            // 
            // frmKullaniciPaneli
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 357);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.duzenleButton);
            this.Controls.Add(this.silButton);
            this.Controls.Add(this.dokuButton);
            this.Controls.Add(this.yasaklaButton);
            this.Controls.Add(this.ekleButton);
            this.Controls.Add(this.listView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmKullaniciPaneli";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Üyelik Sistemi Mysql | Kullanıcı Paneli";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmKullaniciPaneli_FormClosing);
            this.Load += new System.EventHandler(this.frmKullaniciPaneli_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ekleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem silToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem düzenleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dokuVerAlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dokuVerAlToolStripMenuItem1;
        public System.Windows.Forms.ListView listView1;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button ekleButton;
        public System.Windows.Forms.Button silButton;
        public System.Windows.Forms.Button duzenleButton;
        public System.Windows.Forms.Button yasaklaButton;
        public System.Windows.Forms.Button dokuButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem yönetimToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sunucuAyarlarıToolStripMenuItem;
        public System.Windows.Forms.MenuStrip menuStrip1;
    }
}