namespace TurRehberi
{
    partial class AdminGiriş
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminGiriş));
            this.btnAdminGirişYap = new System.Windows.Forms.Button();
            this.txtAdminŞifre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAdminID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGeriAdmin = new System.Windows.Forms.Button();
            this.chkŞifreGösterAdmin = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnAdminGirişYap
            // 
            this.btnAdminGirişYap.BackColor = System.Drawing.Color.Transparent;
            this.btnAdminGirişYap.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAdminGirişYap.BackgroundImage")));
            this.btnAdminGirişYap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAdminGirişYap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdminGirişYap.Font = new System.Drawing.Font("Rockwell", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdminGirişYap.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnAdminGirişYap.Location = new System.Drawing.Point(155, 393);
            this.btnAdminGirişYap.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdminGirişYap.Name = "btnAdminGirişYap";
            this.btnAdminGirişYap.Size = new System.Drawing.Size(122, 44);
            this.btnAdminGirişYap.TabIndex = 11;
            this.btnAdminGirişYap.Text = "Giriş Yap";
            this.btnAdminGirişYap.UseVisualStyleBackColor = false;
            this.btnAdminGirişYap.Click += new System.EventHandler(this.btnAdminGirişYap_Click);
            // 
            // txtAdminŞifre
            // 
            this.txtAdminŞifre.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtAdminŞifre.Location = new System.Drawing.Point(156, 348);
            this.txtAdminŞifre.Margin = new System.Windows.Forms.Padding(2);
            this.txtAdminŞifre.Name = "txtAdminŞifre";
            this.txtAdminŞifre.PasswordChar = '*';
            this.txtAdminŞifre.Size = new System.Drawing.Size(122, 27);
            this.txtAdminŞifre.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(76, 346);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 30);
            this.label3.TabIndex = 9;
            this.label3.Text = "Şifre:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(34, 110);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(381, 39);
            this.label2.TabIndex = 8;
            this.label2.Text = "** Lütfen Giriş Yapınız **";
            // 
            // txtAdminID
            // 
            this.txtAdminID.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtAdminID.Location = new System.Drawing.Point(156, 291);
            this.txtAdminID.Margin = new System.Windows.Forms.Padding(2);
            this.txtAdminID.Name = "txtAdminID";
            this.txtAdminID.Size = new System.Drawing.Size(122, 27);
            this.txtAdminID.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(7, 291);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 30);
            this.label1.TabIndex = 6;
            this.label1.Text = "Kullanıcı Adı:";
            // 
            // btnGeriAdmin
            // 
            this.btnGeriAdmin.BackColor = System.Drawing.Color.Transparent;
            this.btnGeriAdmin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGeriAdmin.BackgroundImage")));
            this.btnGeriAdmin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGeriAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGeriAdmin.Font = new System.Drawing.Font("Rockwell", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGeriAdmin.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnGeriAdmin.Location = new System.Drawing.Point(22, 24);
            this.btnGeriAdmin.Margin = new System.Windows.Forms.Padding(2);
            this.btnGeriAdmin.Name = "btnGeriAdmin";
            this.btnGeriAdmin.Size = new System.Drawing.Size(117, 35);
            this.btnGeriAdmin.TabIndex = 12;
            this.btnGeriAdmin.Text = "Geri Dön";
            this.btnGeriAdmin.UseVisualStyleBackColor = false;
            this.btnGeriAdmin.Click += new System.EventHandler(this.btnGeriAdmin_Click);
            // 
            // chkŞifreGösterAdmin
            // 
            this.chkŞifreGösterAdmin.AutoSize = true;
            this.chkŞifreGösterAdmin.BackColor = System.Drawing.Color.White;
            this.chkŞifreGösterAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.chkŞifreGösterAdmin.ForeColor = System.Drawing.Color.Black;
            this.chkŞifreGösterAdmin.Location = new System.Drawing.Point(286, 354);
            this.chkŞifreGösterAdmin.Name = "chkŞifreGösterAdmin";
            this.chkŞifreGösterAdmin.Size = new System.Drawing.Size(127, 21);
            this.chkŞifreGösterAdmin.TabIndex = 14;
            this.chkŞifreGösterAdmin.Text = "Şifreyi Göster";
            this.chkŞifreGösterAdmin.UseVisualStyleBackColor = false;
            this.chkŞifreGösterAdmin.CheckedChanged += new System.EventHandler(this.chkŞifreGösterAdmin_CheckedChanged);
            // 
            // AdminGiriş
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(432, 502);
            this.Controls.Add(this.chkŞifreGösterAdmin);
            this.Controls.Add(this.btnGeriAdmin);
            this.Controls.Add(this.btnAdminGirişYap);
            this.Controls.Add(this.txtAdminŞifre);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAdminID);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AdminGiriş";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminGiriş";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdminGirişYap;
        private System.Windows.Forms.TextBox txtAdminŞifre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAdminID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGeriAdmin;
        private System.Windows.Forms.CheckBox chkŞifreGösterAdmin;
    }
}