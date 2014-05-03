namespace KutuphaneOtomasyon
{
    partial class Form7
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
            this.PeriyotCB = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TypeCB = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimeFirst = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimeLast = new System.Windows.Forms.DateTimePicker();
            this.Raporla = new System.Windows.Forms.Button();
            this.ResultList = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.OdemeTipiCB = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // PeriyotCB
            // 
            this.PeriyotCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PeriyotCB.FormattingEnabled = true;
            this.PeriyotCB.Items.AddRange(new object[] {
            "",
            "Günlük",
            "Haftalık",
            "Aylık",
            "Yıllık"});
            this.PeriyotCB.Location = new System.Drawing.Point(109, 73);
            this.PeriyotCB.Name = "PeriyotCB";
            this.PeriyotCB.Size = new System.Drawing.Size(121, 21);
            this.PeriyotCB.TabIndex = 0;
            this.PeriyotCB.SelectedIndexChanged += new System.EventHandler(this.PeriyotCB_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Periyot : ";
            // 
            // TypeCB
            // 
            this.TypeCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TypeCB.FormattingEnabled = true;
            this.TypeCB.Items.AddRange(new object[] {
            "En fazla kiralanan kitap",
            "En fazla kitap kiralayan üye",
            "En çok tercih edilen yazar",
            "En çok tercih edilen yayınevi",
            "Ödeme tutarları"});
            this.TypeCB.Location = new System.Drawing.Point(109, 14);
            this.TypeCB.Name = "TypeCB";
            this.TypeCB.Size = new System.Drawing.Size(166, 21);
            this.TypeCB.TabIndex = 0;
            this.TypeCB.SelectedIndexChanged += new System.EventHandler(this.TypeCB_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Rapor Türü : ";
            // 
            // dateTimeFirst
            // 
            this.dateTimeFirst.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeFirst.Location = new System.Drawing.Point(109, 129);
            this.dateTimeFirst.MinDate = new System.DateTime(2014, 1, 1, 0, 0, 0, 0);
            this.dateTimeFirst.Name = "dateTimeFirst";
            this.dateTimeFirst.Size = new System.Drawing.Size(121, 20);
            this.dateTimeFirst.TabIndex = 2;
            this.dateTimeFirst.Value = new System.DateTime(2014, 1, 1, 0, 0, 0, 0);
            this.dateTimeFirst.ValueChanged += new System.EventHandler(this.dateTimeFirst_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Başlangıç Tarihi :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 183);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Bitiş Tarihi :";
            // 
            // dateTimeLast
            // 
            this.dateTimeLast.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeLast.Location = new System.Drawing.Point(109, 180);
            this.dateTimeLast.MinDate = new System.DateTime(2014, 1, 1, 0, 0, 0, 0);
            this.dateTimeLast.Name = "dateTimeLast";
            this.dateTimeLast.Size = new System.Drawing.Size(121, 20);
            this.dateTimeLast.TabIndex = 2;
            this.dateTimeLast.Value = new System.DateTime(2014, 1, 1, 0, 0, 0, 0);
            // 
            // Raporla
            // 
            this.Raporla.Location = new System.Drawing.Point(155, 228);
            this.Raporla.Name = "Raporla";
            this.Raporla.Size = new System.Drawing.Size(75, 23);
            this.Raporla.TabIndex = 3;
            this.Raporla.Text = "Raporla";
            this.Raporla.UseVisualStyleBackColor = true;
            this.Raporla.Click += new System.EventHandler(this.Raporla_Click);
            // 
            // ResultList
            // 
            this.ResultList.FormattingEnabled = true;
            this.ResultList.Location = new System.Drawing.Point(279, 13);
            this.ResultList.Name = "ResultList";
            this.ResultList.Size = new System.Drawing.Size(293, 238);
            this.ResultList.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Ödeme Tipi :";
            // 
            // OdemeTipiCB
            // 
            this.OdemeTipiCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.OdemeTipiCB.FormattingEnabled = true;
            this.OdemeTipiCB.Location = new System.Drawing.Point(109, 44);
            this.OdemeTipiCB.Name = "OdemeTipiCB";
            this.OdemeTipiCB.Size = new System.Drawing.Size(121, 21);
            this.OdemeTipiCB.TabIndex = 6;
            // 
            // Form7
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 261);
            this.Controls.Add(this.OdemeTipiCB);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ResultList);
            this.Controls.Add(this.Raporla);
            this.Controls.Add(this.dateTimeLast);
            this.Controls.Add(this.dateTimeFirst);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TypeCB);
            this.Controls.Add(this.PeriyotCB);
            this.Name = "Form7";
            this.Text = "Rapor Al";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox PeriyotCB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox TypeCB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimeFirst;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimeLast;
        private System.Windows.Forms.Button Raporla;
        private System.Windows.Forms.ListBox ResultList;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox OdemeTipiCB;
    }
}