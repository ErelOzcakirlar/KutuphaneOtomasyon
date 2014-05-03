namespace KutuphaneOtomasyon
{
    partial class Form2
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
            this.label1 = new System.Windows.Forms.Label();
            this.BasimYiliNUD = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.SayfaSayisiNUD = new System.Windows.Forms.NumericUpDown();
            this.Finish = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.FiyatTB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.KitapTB = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.YazarCB = new System.Windows.Forms.ComboBox();
            this.YazarEkle = new System.Windows.Forms.Button();
            this.YazarList = new System.Windows.Forms.ListBox();
            this.YazarListSil = new System.Windows.Forms.Button();
            this.YazarListTemizle = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.KategoriCB = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.YayineviCB = new System.Windows.Forms.ComboBox();
            this.YayineviDuzenle = new System.Windows.Forms.Button();
            this.Hasar = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.KategoriDuzenle = new System.Windows.Forms.Button();
            this.YazarDuzenle = new System.Windows.Forms.Button();
            this.OzetRTB = new System.Windows.Forms.RichTextBox();
            this.KapakTB = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.BasimYiliNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SayfaSayisiNUD)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Basım Yılı :";
            // 
            // BasimYiliNUD
            // 
            this.BasimYiliNUD.Location = new System.Drawing.Point(91, 41);
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
            this.BasimYiliNUD.Size = new System.Drawing.Size(120, 20);
            this.BasimYiliNUD.TabIndex = 1;
            this.BasimYiliNUD.Value = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Sayfa Sayısı  :";
            // 
            // SayfaSayisiNUD
            // 
            this.SayfaSayisiNUD.Location = new System.Drawing.Point(91, 68);
            this.SayfaSayisiNUD.Name = "SayfaSayisiNUD";
            this.SayfaSayisiNUD.Size = new System.Drawing.Size(120, 20);
            this.SayfaSayisiNUD.TabIndex = 1;
            // 
            // Finish
            // 
            this.Finish.Location = new System.Drawing.Point(229, 316);
            this.Finish.Name = "Finish";
            this.Finish.Size = new System.Drawing.Size(75, 23);
            this.Finish.TabIndex = 2;
            this.Finish.Text = "Bitti";
            this.Finish.UseVisualStyleBackColor = true;
            this.Finish.Click += new System.EventHandler(this.Finish_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(310, 316);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 3;
            this.Cancel.Text = "İptal";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Fiyat :";
            // 
            // FiyatTB
            // 
            this.FiyatTB.Location = new System.Drawing.Point(91, 95);
            this.FiyatTB.Name = "FiyatTB";
            this.FiyatTB.Size = new System.Drawing.Size(120, 20);
            this.FiyatTB.TabIndex = 5;
            this.FiyatTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(218, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "TL";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Kitap Adı :";
            // 
            // KitapTB
            // 
            this.KitapTB.Location = new System.Drawing.Point(91, 12);
            this.KitapTB.Name = "KitapTB";
            this.KitapTB.Size = new System.Drawing.Size(120, 20);
            this.KitapTB.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(328, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Yazarlar :";
            // 
            // YazarCB
            // 
            this.YazarCB.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.YazarCB.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.YazarCB.FormattingEnabled = true;
            this.YazarCB.Location = new System.Drawing.Point(258, 92);
            this.YazarCB.Name = "YazarCB";
            this.YazarCB.Size = new System.Drawing.Size(121, 21);
            this.YazarCB.TabIndex = 10;
            this.YazarCB.SelectedIndexChanged += new System.EventHandler(this.YazarCB_SelectedIndexChanged);
            // 
            // YazarEkle
            // 
            this.YazarEkle.Location = new System.Drawing.Point(304, 120);
            this.YazarEkle.Name = "YazarEkle";
            this.YazarEkle.Size = new System.Drawing.Size(75, 23);
            this.YazarEkle.TabIndex = 11;
            this.YazarEkle.Text = "Yazarı Ekle";
            this.YazarEkle.UseVisualStyleBackColor = true;
            this.YazarEkle.Click += new System.EventHandler(this.YazarEkle_Click);
            // 
            // YazarList
            // 
            this.YazarList.FormattingEnabled = true;
            this.YazarList.Location = new System.Drawing.Point(385, 67);
            this.YazarList.Name = "YazarList";
            this.YazarList.Size = new System.Drawing.Size(237, 108);
            this.YazarList.TabIndex = 12;
            // 
            // YazarListSil
            // 
            this.YazarListSil.Location = new System.Drawing.Point(466, 181);
            this.YazarListSil.Name = "YazarListSil";
            this.YazarListSil.Size = new System.Drawing.Size(75, 23);
            this.YazarListSil.TabIndex = 13;
            this.YazarListSil.Text = "Sil";
            this.YazarListSil.UseVisualStyleBackColor = true;
            this.YazarListSil.Click += new System.EventHandler(this.YazarListSil_Click);
            // 
            // YazarListTemizle
            // 
            this.YazarListTemizle.Location = new System.Drawing.Point(547, 181);
            this.YazarListTemizle.Name = "YazarListTemizle";
            this.YazarListTemizle.Size = new System.Drawing.Size(75, 23);
            this.YazarListTemizle.TabIndex = 14;
            this.YazarListTemizle.Text = "Temizle";
            this.YazarListTemizle.UseVisualStyleBackColor = true;
            this.YazarListTemizle.Click += new System.EventHandler(this.YazarListTemizle_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(327, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Kategori :";
            // 
            // KategoriCB
            // 
            this.KategoriCB.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.KategoriCB.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.KategoriCB.FormattingEnabled = true;
            this.KategoriCB.Location = new System.Drawing.Point(385, 40);
            this.KategoriCB.Name = "KategoriCB";
            this.KategoriCB.Size = new System.Drawing.Size(120, 21);
            this.KategoriCB.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(326, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Yayınevi :";
            // 
            // YayineviCB
            // 
            this.YayineviCB.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.YayineviCB.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.YayineviCB.FormattingEnabled = true;
            this.YayineviCB.Location = new System.Drawing.Point(385, 12);
            this.YayineviCB.Name = "YayineviCB";
            this.YayineviCB.Size = new System.Drawing.Size(120, 21);
            this.YayineviCB.TabIndex = 10;
            // 
            // YayineviDuzenle
            // 
            this.YayineviDuzenle.Location = new System.Drawing.Point(511, 10);
            this.YayineviDuzenle.Name = "YayineviDuzenle";
            this.YayineviDuzenle.Size = new System.Drawing.Size(75, 23);
            this.YayineviDuzenle.TabIndex = 15;
            this.YayineviDuzenle.Text = "Düzenle";
            this.YayineviDuzenle.UseVisualStyleBackColor = true;
            this.YayineviDuzenle.Click += new System.EventHandler(this.YayineviDuzenle_Click);
            // 
            // Hasar
            // 
            this.Hasar.AutoSize = true;
            this.Hasar.Location = new System.Drawing.Point(91, 125);
            this.Hasar.Name = "Hasar";
            this.Hasar.Size = new System.Drawing.Size(15, 14);
            this.Hasar.TabIndex = 16;
            this.Hasar.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(40, 125);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Hasarlı :";
            // 
            // KategoriDuzenle
            // 
            this.KategoriDuzenle.Location = new System.Drawing.Point(511, 39);
            this.KategoriDuzenle.Name = "KategoriDuzenle";
            this.KategoriDuzenle.Size = new System.Drawing.Size(75, 23);
            this.KategoriDuzenle.TabIndex = 15;
            this.KategoriDuzenle.Text = "Düzenle";
            this.KategoriDuzenle.UseVisualStyleBackColor = true;
            this.KategoriDuzenle.Click += new System.EventHandler(this.KategoriDuzenle_Click);
            // 
            // YazarDuzenle
            // 
            this.YazarDuzenle.Location = new System.Drawing.Point(385, 181);
            this.YazarDuzenle.Name = "YazarDuzenle";
            this.YazarDuzenle.Size = new System.Drawing.Size(75, 23);
            this.YazarDuzenle.TabIndex = 15;
            this.YazarDuzenle.Text = "Düzenle";
            this.YazarDuzenle.UseVisualStyleBackColor = true;
            this.YazarDuzenle.Click += new System.EventHandler(this.YazarDuzenle_Click);
            // 
            // OzetRTB
            // 
            this.OzetRTB.Location = new System.Drawing.Point(91, 176);
            this.OzetRTB.Name = "OzetRTB";
            this.OzetRTB.Size = new System.Drawing.Size(213, 129);
            this.OzetRTB.TabIndex = 18;
            this.OzetRTB.Text = "";
            // 
            // KapakTB
            // 
            this.KapakTB.Location = new System.Drawing.Point(91, 145);
            this.KapakTB.Name = "KapakTB";
            this.KapakTB.Size = new System.Drawing.Size(120, 20);
            this.KapakTB.TabIndex = 19;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(41, 148);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "Kapak :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(50, 176);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 13);
            this.label12.TabIndex = 21;
            this.label12.Text = "Özet :";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 351);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.KapakTB);
            this.Controls.Add(this.OzetRTB);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.Hasar);
            this.Controls.Add(this.KategoriDuzenle);
            this.Controls.Add(this.YazarDuzenle);
            this.Controls.Add(this.YayineviDuzenle);
            this.Controls.Add(this.YazarListTemizle);
            this.Controls.Add(this.YazarListSil);
            this.Controls.Add(this.YayineviCB);
            this.Controls.Add(this.YazarList);
            this.Controls.Add(this.KategoriCB);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.YazarEkle);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.YazarCB);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.KitapTB);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.FiyatTB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Finish);
            this.Controls.Add(this.SayfaSayisiNUD);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BasimYiliNUD);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.BasimYiliNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SayfaSayisiNUD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown BasimYiliNUD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown SayfaSayisiNUD;
        private System.Windows.Forms.Button Finish;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox FiyatTB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox KitapTB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox YazarCB;
        private System.Windows.Forms.Button YazarEkle;
        private System.Windows.Forms.ListBox YazarList;
        private System.Windows.Forms.Button YazarListSil;
        private System.Windows.Forms.Button YazarListTemizle;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox KategoriCB;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox YayineviCB;
        private System.Windows.Forms.Button YayineviDuzenle;
        private System.Windows.Forms.CheckBox Hasar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button KategoriDuzenle;
        private System.Windows.Forms.Button YazarDuzenle;
        private System.Windows.Forms.RichTextBox OzetRTB;
        private System.Windows.Forms.TextBox KapakTB;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
    }
}