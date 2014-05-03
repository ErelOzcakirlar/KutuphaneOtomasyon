namespace KutuphaneOtomasyon
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
            this.KitapList = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.KitapTB = new System.Windows.Forms.TextBox();
            this.KitapEkle = new System.Windows.Forms.Button();
            this.YazarCB = new System.Windows.Forms.ComboBox();
            this.YazarList = new System.Windows.Forms.ListBox();
            this.BasimYiliList = new System.Windows.Forms.ListBox();
            this.YazarFEB = new System.Windows.Forms.Button();
            this.BasimYiliFEB = new System.Windows.Forms.Button();
            this.YazarListSil = new System.Windows.Forms.Button();
            this.YazarListTemizle = new System.Windows.Forms.Button();
            this.BasimYiliListSil = new System.Windows.Forms.Button();
            this.BasimYiliListTemizle = new System.Windows.Forms.Button();
            this.KitapTeslimAl = new System.Windows.Forms.Button();
            this.KitapKirala = new System.Windows.Forms.Button();
            this.KitapDuzenle = new System.Windows.Forms.Button();
            this.BasimYiliNUD = new System.Windows.Forms.NumericUpDown();
            this.YazarDuzenle = new System.Windows.Forms.Button();
            this.KategoriDuzenle = new System.Windows.Forms.Button();
            this.YayineviDuzenle = new System.Windows.Forms.Button();
            this.UyeDuzenle = new System.Windows.Forms.Button();
            this.RaporAl = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.BasimYiliNUD)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // KitapList
            // 
            this.KitapList.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.KitapList.FormattingEnabled = true;
            this.KitapList.Location = new System.Drawing.Point(390, 16);
            this.KitapList.Name = "KitapList";
            this.KitapList.Size = new System.Drawing.Size(407, 407);
            this.KitapList.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(12, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Kitap Adı :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(9, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Yazar Adı :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(10, 253);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Basım Yılı :";
            // 
            // KitapTB
            // 
            this.KitapTB.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.KitapTB.Location = new System.Drawing.Point(73, 16);
            this.KitapTB.Name = "KitapTB";
            this.KitapTB.Size = new System.Drawing.Size(158, 20);
            this.KitapTB.TabIndex = 6;
            this.KitapTB.TextChanged += new System.EventHandler(this.KitapTB_TextChanged);
            // 
            // KitapEkle
            // 
            this.KitapEkle.ForeColor = System.Drawing.Color.Aqua;
            this.KitapEkle.Location = new System.Drawing.Point(132, 401);
            this.KitapEkle.Name = "KitapEkle";
            this.KitapEkle.Size = new System.Drawing.Size(99, 23);
            this.KitapEkle.TabIndex = 10;
            this.KitapEkle.Text = "Yeni Kitap Ekle";
            this.KitapEkle.UseVisualStyleBackColor = true;
            this.KitapEkle.Click += new System.EventHandler(this.KitapEkle_Click);
            // 
            // YazarCB
            // 
            this.YazarCB.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.YazarCB.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.YazarCB.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.YazarCB.FormattingEnabled = true;
            this.YazarCB.Location = new System.Drawing.Point(73, 42);
            this.YazarCB.Name = "YazarCB";
            this.YazarCB.Size = new System.Drawing.Size(158, 21);
            this.YazarCB.TabIndex = 9;
            this.YazarCB.SelectedIndexChanged += new System.EventHandler(this.YazarCB_SelectedIndexChanged);
            // 
            // YazarList
            // 
            this.YazarList.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.YazarList.FormattingEnabled = true;
            this.YazarList.Location = new System.Drawing.Point(237, 42);
            this.YazarList.Name = "YazarList";
            this.YazarList.Size = new System.Drawing.Size(140, 173);
            this.YazarList.TabIndex = 11;
            // 
            // BasimYiliList
            // 
            this.BasimYiliList.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.BasimYiliList.FormattingEnabled = true;
            this.BasimYiliList.Location = new System.Drawing.Point(237, 250);
            this.BasimYiliList.Name = "BasimYiliList";
            this.BasimYiliList.Size = new System.Drawing.Size(140, 173);
            this.BasimYiliList.TabIndex = 11;
            // 
            // YazarFEB
            // 
            this.YazarFEB.BackColor = System.Drawing.SystemColors.Control;
            this.YazarFEB.ForeColor = System.Drawing.Color.Aqua;
            this.YazarFEB.Location = new System.Drawing.Point(156, 69);
            this.YazarFEB.Name = "YazarFEB";
            this.YazarFEB.Size = new System.Drawing.Size(75, 23);
            this.YazarFEB.TabIndex = 12;
            this.YazarFEB.Text = "Filtre Ekle";
            this.YazarFEB.UseVisualStyleBackColor = false;
            this.YazarFEB.Click += new System.EventHandler(this.YazarFEB_Click);
            // 
            // BasimYiliFEB
            // 
            this.BasimYiliFEB.ForeColor = System.Drawing.Color.Aqua;
            this.BasimYiliFEB.Location = new System.Drawing.Point(156, 276);
            this.BasimYiliFEB.Name = "BasimYiliFEB";
            this.BasimYiliFEB.Size = new System.Drawing.Size(75, 23);
            this.BasimYiliFEB.TabIndex = 12;
            this.BasimYiliFEB.Text = "Filtre Ekle";
            this.BasimYiliFEB.UseVisualStyleBackColor = true;
            this.BasimYiliFEB.Click += new System.EventHandler(this.BasimYiliFEB_Click);
            // 
            // YazarListSil
            // 
            this.YazarListSil.ForeColor = System.Drawing.Color.Aqua;
            this.YazarListSil.Location = new System.Drawing.Point(237, 221);
            this.YazarListSil.Name = "YazarListSil";
            this.YazarListSil.Size = new System.Drawing.Size(63, 23);
            this.YazarListSil.TabIndex = 13;
            this.YazarListSil.Text = "Sil";
            this.YazarListSil.UseVisualStyleBackColor = true;
            this.YazarListSil.Click += new System.EventHandler(this.YazarListSil_Click);
            // 
            // YazarListTemizle
            // 
            this.YazarListTemizle.ForeColor = System.Drawing.Color.Aqua;
            this.YazarListTemizle.Location = new System.Drawing.Point(306, 221);
            this.YazarListTemizle.Name = "YazarListTemizle";
            this.YazarListTemizle.Size = new System.Drawing.Size(71, 23);
            this.YazarListTemizle.TabIndex = 14;
            this.YazarListTemizle.Text = "Temizle";
            this.YazarListTemizle.UseVisualStyleBackColor = true;
            this.YazarListTemizle.Click += new System.EventHandler(this.YazarListTemizle_Click);
            // 
            // BasimYiliListSil
            // 
            this.BasimYiliListSil.ForeColor = System.Drawing.Color.Aqua;
            this.BasimYiliListSil.Location = new System.Drawing.Point(237, 430);
            this.BasimYiliListSil.Name = "BasimYiliListSil";
            this.BasimYiliListSil.Size = new System.Drawing.Size(63, 23);
            this.BasimYiliListSil.TabIndex = 13;
            this.BasimYiliListSil.Text = "Sil";
            this.BasimYiliListSil.UseVisualStyleBackColor = true;
            this.BasimYiliListSil.Click += new System.EventHandler(this.BasimYiliListSil_Click);
            // 
            // BasimYiliListTemizle
            // 
            this.BasimYiliListTemizle.ForeColor = System.Drawing.Color.Aqua;
            this.BasimYiliListTemizle.Location = new System.Drawing.Point(306, 430);
            this.BasimYiliListTemizle.Name = "BasimYiliListTemizle";
            this.BasimYiliListTemizle.Size = new System.Drawing.Size(71, 23);
            this.BasimYiliListTemizle.TabIndex = 14;
            this.BasimYiliListTemizle.Text = "Temizle";
            this.BasimYiliListTemizle.UseVisualStyleBackColor = true;
            this.BasimYiliListTemizle.Click += new System.EventHandler(this.BasimYiliListTemizle_Click);
            // 
            // KitapTeslimAl
            // 
            this.KitapTeslimAl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.KitapTeslimAl.Location = new System.Drawing.Point(708, 429);
            this.KitapTeslimAl.Name = "KitapTeslimAl";
            this.KitapTeslimAl.Size = new System.Drawing.Size(89, 23);
            this.KitapTeslimAl.TabIndex = 15;
            this.KitapTeslimAl.Text = "Kitabı Teslim Al";
            this.KitapTeslimAl.UseVisualStyleBackColor = false;
            this.KitapTeslimAl.Click += new System.EventHandler(this.KitapTeslimAl_Click);
            // 
            // KitapKirala
            // 
            this.KitapKirala.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.KitapKirala.Location = new System.Drawing.Point(613, 429);
            this.KitapKirala.Name = "KitapKirala";
            this.KitapKirala.Size = new System.Drawing.Size(89, 23);
            this.KitapKirala.TabIndex = 16;
            this.KitapKirala.Text = "Kitabı Kirala";
            this.KitapKirala.UseVisualStyleBackColor = false;
            this.KitapKirala.Click += new System.EventHandler(this.KitapKirala_Click);
            // 
            // KitapDuzenle
            // 
            this.KitapDuzenle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.KitapDuzenle.Location = new System.Drawing.Point(518, 429);
            this.KitapDuzenle.Name = "KitapDuzenle";
            this.KitapDuzenle.Size = new System.Drawing.Size(89, 23);
            this.KitapDuzenle.TabIndex = 17;
            this.KitapDuzenle.Text = "Kitabı Düzenle";
            this.KitapDuzenle.UseVisualStyleBackColor = false;
            this.KitapDuzenle.Click += new System.EventHandler(this.KitapDuzenle_Click);
            // 
            // BasimYiliNUD
            // 
            this.BasimYiliNUD.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.BasimYiliNUD.Location = new System.Drawing.Point(73, 250);
            this.BasimYiliNUD.Maximum = new decimal(new int[] {
            2014,
            0,
            0,
            0});
            this.BasimYiliNUD.Minimum = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            this.BasimYiliNUD.Name = "BasimYiliNUD";
            this.BasimYiliNUD.Size = new System.Drawing.Size(158, 20);
            this.BasimYiliNUD.TabIndex = 18;
            this.BasimYiliNUD.Value = new decimal(new int[] {
            2014,
            0,
            0,
            0});
            // 
            // YazarDuzenle
            // 
            this.YazarDuzenle.ForeColor = System.Drawing.Color.Aqua;
            this.YazarDuzenle.Location = new System.Drawing.Point(6, 19);
            this.YazarDuzenle.Name = "YazarDuzenle";
            this.YazarDuzenle.Size = new System.Drawing.Size(99, 23);
            this.YazarDuzenle.TabIndex = 19;
            this.YazarDuzenle.Text = "Yazar";
            this.YazarDuzenle.UseVisualStyleBackColor = true;
            this.YazarDuzenle.Click += new System.EventHandler(this.YazarDuzenle_Click);
            // 
            // KategoriDuzenle
            // 
            this.KategoriDuzenle.ForeColor = System.Drawing.Color.Aqua;
            this.KategoriDuzenle.Location = new System.Drawing.Point(6, 48);
            this.KategoriDuzenle.Name = "KategoriDuzenle";
            this.KategoriDuzenle.Size = new System.Drawing.Size(99, 23);
            this.KategoriDuzenle.TabIndex = 19;
            this.KategoriDuzenle.Text = "Kategori";
            this.KategoriDuzenle.UseVisualStyleBackColor = true;
            this.KategoriDuzenle.Click += new System.EventHandler(this.KategoriDuzenle_Click);
            // 
            // YayineviDuzenle
            // 
            this.YayineviDuzenle.ForeColor = System.Drawing.Color.Aqua;
            this.YayineviDuzenle.Location = new System.Drawing.Point(6, 77);
            this.YayineviDuzenle.Name = "YayineviDuzenle";
            this.YayineviDuzenle.Size = new System.Drawing.Size(99, 23);
            this.YayineviDuzenle.TabIndex = 19;
            this.YayineviDuzenle.Text = "Yayınevi";
            this.YayineviDuzenle.UseVisualStyleBackColor = true;
            this.YayineviDuzenle.Click += new System.EventHandler(this.YayineviDuzenle_Click);
            // 
            // UyeDuzenle
            // 
            this.UyeDuzenle.ForeColor = System.Drawing.Color.Aqua;
            this.UyeDuzenle.Location = new System.Drawing.Point(6, 106);
            this.UyeDuzenle.Name = "UyeDuzenle";
            this.UyeDuzenle.Size = new System.Drawing.Size(99, 23);
            this.UyeDuzenle.TabIndex = 20;
            this.UyeDuzenle.Text = "Üye";
            this.UyeDuzenle.UseVisualStyleBackColor = true;
            this.UyeDuzenle.Click += new System.EventHandler(this.UyeDuzenle_Click);
            // 
            // RaporAl
            // 
            this.RaporAl.ForeColor = System.Drawing.Color.Aqua;
            this.RaporAl.Location = new System.Drawing.Point(132, 430);
            this.RaporAl.Name = "RaporAl";
            this.RaporAl.Size = new System.Drawing.Size(99, 23);
            this.RaporAl.TabIndex = 21;
            this.RaporAl.Text = "Rapor Al";
            this.RaporAl.UseVisualStyleBackColor = true;
            this.RaporAl.Click += new System.EventHandler(this.RaporAl_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.YazarDuzenle);
            this.groupBox1.Controls.Add(this.KategoriDuzenle);
            this.groupBox1.Controls.Add(this.UyeDuzenle);
            this.groupBox1.Controls.Add(this.YayineviDuzenle);
            this.groupBox1.Location = new System.Drawing.Point(13, 324);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(113, 133);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ekle / Düzenle ;";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(809, 471);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.RaporAl);
            this.Controls.Add(this.BasimYiliNUD);
            this.Controls.Add(this.KitapDuzenle);
            this.Controls.Add(this.KitapKirala);
            this.Controls.Add(this.KitapTeslimAl);
            this.Controls.Add(this.YazarListTemizle);
            this.Controls.Add(this.BasimYiliListTemizle);
            this.Controls.Add(this.YazarListSil);
            this.Controls.Add(this.BasimYiliListSil);
            this.Controls.Add(this.BasimYiliFEB);
            this.Controls.Add(this.YazarFEB);
            this.Controls.Add(this.YazarList);
            this.Controls.Add(this.BasimYiliList);
            this.Controls.Add(this.KitapEkle);
            this.Controls.Add(this.YazarCB);
            this.Controls.Add(this.KitapTB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.KitapList);
            this.Name = "Form1";
            this.Text = "Kitap Ara";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BasimYiliNUD)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox KitapList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox KitapTB;
        private System.Windows.Forms.Button KitapEkle;
        private System.Windows.Forms.ComboBox YazarCB;
        private System.Windows.Forms.ListBox YazarList;
        private System.Windows.Forms.ListBox BasimYiliList;
        private System.Windows.Forms.Button YazarFEB;
        private System.Windows.Forms.Button BasimYiliFEB;
        private System.Windows.Forms.Button YazarListSil;
        private System.Windows.Forms.Button YazarListTemizle;
        private System.Windows.Forms.Button BasimYiliListSil;
        private System.Windows.Forms.Button BasimYiliListTemizle;
        private System.Windows.Forms.Button KitapTeslimAl;
        private System.Windows.Forms.Button KitapKirala;
        private System.Windows.Forms.Button KitapDuzenle;
        private System.Windows.Forms.NumericUpDown BasimYiliNUD;
        private System.Windows.Forms.Button YazarDuzenle;
        private System.Windows.Forms.Button KategoriDuzenle;
        private System.Windows.Forms.Button YayineviDuzenle;
        private System.Windows.Forms.Button UyeDuzenle;
        private System.Windows.Forms.Button RaporAl;
        private System.Windows.Forms.GroupBox groupBox1;

    }
}

