namespace Ciftlik
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.txt_KAdi = new System.Windows.Forms.TextBox();
            this.txt_Sifre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Giris = new System.Windows.Forms.Button();
            this.btn_KOlustur = new System.Windows.Forms.Button();
            this.lbl_Hata = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_KAdi
            // 
            this.txt_KAdi.Location = new System.Drawing.Point(121, 106);
            this.txt_KAdi.Name = "txt_KAdi";
            this.txt_KAdi.Size = new System.Drawing.Size(174, 20);
            this.txt_KAdi.TabIndex = 0;
            // 
            // txt_Sifre
            // 
            this.txt_Sifre.Location = new System.Drawing.Point(121, 132);
            this.txt_Sifre.Name = "txt_Sifre";
            this.txt_Sifre.Size = new System.Drawing.Size(174, 20);
            this.txt_Sifre.TabIndex = 1;
            this.txt_Sifre.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(11, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Kullanıcı Adı";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(11, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Şifre";
            // 
            // btn_Giris
            // 
            this.btn_Giris.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_Giris.Location = new System.Drawing.Point(160, 205);
            this.btn_Giris.Name = "btn_Giris";
            this.btn_Giris.Size = new System.Drawing.Size(105, 44);
            this.btn_Giris.TabIndex = 2;
            this.btn_Giris.Text = "Giriş";
            this.btn_Giris.UseVisualStyleBackColor = true;
            this.btn_Giris.Click += new System.EventHandler(this.Btn_Giris_Click);
            // 
            // btn_KOlustur
            // 
            this.btn_KOlustur.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_KOlustur.Location = new System.Drawing.Point(45, 205);
            this.btn_KOlustur.Name = "btn_KOlustur";
            this.btn_KOlustur.Size = new System.Drawing.Size(105, 44);
            this.btn_KOlustur.TabIndex = 2;
            this.btn_KOlustur.Text = "Kullanıcı Oluştur";
            this.btn_KOlustur.UseVisualStyleBackColor = true;
            this.btn_KOlustur.Click += new System.EventHandler(this.Btn_KOlustur_Click);
            // 
            // lbl_Hata
            // 
            this.lbl_Hata.AutoSize = true;
            this.lbl_Hata.ForeColor = System.Drawing.Color.Red;
            this.lbl_Hata.Location = new System.Drawing.Point(15, 174);
            this.lbl_Hata.Name = "lbl_Hata";
            this.lbl_Hata.Size = new System.Drawing.Size(63, 13);
            this.lbl_Hata.TabIndex = 3;
            this.lbl_Hata.Text = "Hata Mesajı";
            this.lbl_Hata.Visible = false;
            // 
            // Form1
            // 
            this.AcceptButton = this.btn_Giris;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 343);
            this.Controls.Add(this.lbl_Hata);
            this.Controls.Add(this.btn_KOlustur);
            this.Controls.Add(this.btn_Giris);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_Sifre);
            this.Controls.Add(this.txt_KAdi);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_KAdi;
        private System.Windows.Forms.TextBox txt_Sifre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Giris;
        private System.Windows.Forms.Button btn_KOlustur;
        private System.Windows.Forms.Label lbl_Hata;
    }
}

