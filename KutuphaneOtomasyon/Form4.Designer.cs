namespace KutuphaneOtomasyon
{
    partial class Form4
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
            this.AdTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SoyadTB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TCKimlikTB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TelefonTB = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.AdresRTB = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.UyeCB = new System.Windows.Forms.ComboBox();
            this.Save = new System.Windows.Forms.Button();
            this.Close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ad :";
            // 
            // AdTB
            // 
            this.AdTB.Location = new System.Drawing.Point(118, 39);
            this.AdTB.Name = "AdTB";
            this.AdTB.Size = new System.Drawing.Size(126, 20);
            this.AdTB.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(69, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Soyad :";
            // 
            // SoyadTB
            // 
            this.SoyadTB.Location = new System.Drawing.Point(118, 65);
            this.SoyadTB.Name = "SoyadTB";
            this.SoyadTB.Size = new System.Drawing.Size(126, 20);
            this.SoyadTB.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "T.C. Kimlik No :";
            // 
            // TCKimlikTB
            // 
            this.TCKimlikTB.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.TCKimlikTB.Location = new System.Drawing.Point(118, 91);
            this.TCKimlikTB.Name = "TCKimlikTB";
            this.TCKimlikTB.Size = new System.Drawing.Size(126, 20);
            this.TCKimlikTB.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(63, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Telefon :";
            // 
            // TelefonTB
            // 
            this.TelefonTB.Location = new System.Drawing.Point(118, 117);
            this.TelefonTB.Name = "TelefonTB";
            this.TelefonTB.Size = new System.Drawing.Size(126, 20);
            this.TelefonTB.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(72, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Adres :";
            // 
            // AdresRTB
            // 
            this.AdresRTB.Location = new System.Drawing.Point(118, 144);
            this.AdresRTB.Name = "AdresRTB";
            this.AdresRTB.Size = new System.Drawing.Size(126, 78);
            this.AdresRTB.TabIndex = 3;
            this.AdresRTB.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(80, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Üye :";
            // 
            // UyeCB
            // 
            this.UyeCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.UyeCB.FormattingEnabled = true;
            this.UyeCB.Location = new System.Drawing.Point(118, 12);
            this.UyeCB.Name = "UyeCB";
            this.UyeCB.Size = new System.Drawing.Size(126, 21);
            this.UyeCB.TabIndex = 5;
            this.UyeCB.SelectedIndexChanged += new System.EventHandler(this.UyeCB_SelectedIndexChanged);
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(37, 228);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(75, 23);
            this.Save.TabIndex = 6;
            this.Save.Text = "Kaydet";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Close
            // 
            this.Close.Location = new System.Drawing.Point(118, 228);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(75, 23);
            this.Close.TabIndex = 7;
            this.Close.Text = "Kapat";
            this.Close.UseVisualStyleBackColor = true;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.Close);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.UyeCB);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.AdresRTB);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TelefonTB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TCKimlikTB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SoyadTB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.AdTB);
            this.Controls.Add(this.label1);
            this.Name = "Form4";
            this.Text = "Üye Düzenle";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox AdTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox SoyadTB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TCKimlikTB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TelefonTB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox AdresRTB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox UyeCB;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button Close;
    }
}