namespace KutuphaneOtomasyon
{
    partial class Form5
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
            this.UyeNoTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.UyeAdiTB = new System.Windows.Forms.TextBox();
            this.UyeList = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.KitapTB = new System.Windows.Forms.TextBox();
            this.HasarCB = new System.Windows.Forms.CheckBox();
            this.UcretTB = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Close = new System.Windows.Forms.Button();
            this.Finish = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Üye No :";
            // 
            // UyeNoTB
            // 
            this.UyeNoTB.Location = new System.Drawing.Point(12, 25);
            this.UyeNoTB.Name = "UyeNoTB";
            this.UyeNoTB.Size = new System.Drawing.Size(121, 20);
            this.UyeNoTB.TabIndex = 1;
            this.UyeNoTB.TextChanged += new System.EventHandler(this.UyeNoTB_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(136, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Üye Adı :";
            // 
            // UyeAdiTB
            // 
            this.UyeAdiTB.Location = new System.Drawing.Point(139, 25);
            this.UyeAdiTB.Name = "UyeAdiTB";
            this.UyeAdiTB.Size = new System.Drawing.Size(120, 20);
            this.UyeAdiTB.TabIndex = 4;
            this.UyeAdiTB.TextChanged += new System.EventHandler(this.UyeAdiTB_TextChanged);
            // 
            // UyeList
            // 
            this.UyeList.FormattingEnabled = true;
            this.UyeList.Location = new System.Drawing.Point(12, 64);
            this.UyeList.Name = "UyeList";
            this.UyeList.Size = new System.Drawing.Size(247, 95);
            this.UyeList.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Üyeler :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Kitap :";
            // 
            // KitapTB
            // 
            this.KitapTB.Enabled = false;
            this.KitapTB.Location = new System.Drawing.Point(12, 178);
            this.KitapTB.Name = "KitapTB";
            this.KitapTB.Size = new System.Drawing.Size(247, 20);
            this.KitapTB.TabIndex = 8;
            // 
            // HasarCB
            // 
            this.HasarCB.AutoSize = true;
            this.HasarCB.Location = new System.Drawing.Point(12, 207);
            this.HasarCB.Name = "HasarCB";
            this.HasarCB.Size = new System.Drawing.Size(58, 17);
            this.HasarCB.TabIndex = 9;
            this.HasarCB.Text = "Hasarlı";
            this.HasarCB.UseVisualStyleBackColor = true;
            this.HasarCB.CheckedChanged += new System.EventHandler(this.HasarCB_CheckedChanged);
            // 
            // UcretTB
            // 
            this.UcretTB.Enabled = false;
            this.UcretTB.Location = new System.Drawing.Point(139, 205);
            this.UcretTB.Name = "UcretTB";
            this.UcretTB.Size = new System.Drawing.Size(100, 20);
            this.UcretTB.TabIndex = 10;
            this.UcretTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(239, 208);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "TL";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(94, 208);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Ücret :";
            // 
            // Close
            // 
            this.Close.Location = new System.Drawing.Point(139, 231);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(75, 23);
            this.Close.TabIndex = 13;
            this.Close.Text = "Kapat";
            this.Close.UseVisualStyleBackColor = true;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // Finish
            // 
            this.Finish.Location = new System.Drawing.Point(58, 231);
            this.Finish.Name = "Finish";
            this.Finish.Size = new System.Drawing.Size(75, 23);
            this.Finish.TabIndex = 14;
            this.Finish.Text = "button1";
            this.Finish.UseVisualStyleBackColor = true;
            this.Finish.Click += new System.EventHandler(this.Finish_Click);
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.Finish);
            this.Controls.Add(this.Close);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.UcretTB);
            this.Controls.Add(this.HasarCB);
            this.Controls.Add(this.KitapTB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.UyeList);
            this.Controls.Add(this.UyeAdiTB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.UyeNoTB);
            this.Controls.Add(this.label1);
            this.Name = "Form5";
            this.Text = "Form5";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox UyeNoTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox UyeAdiTB;
        private System.Windows.Forms.ListBox UyeList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox KitapTB;
        private System.Windows.Forms.CheckBox HasarCB;
        private System.Windows.Forms.TextBox UcretTB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button Close;
        private System.Windows.Forms.Button Finish;
    }
}