namespace ismailAgaConverter
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
            this.btnOzluSozler = new System.Windows.Forms.Button();
            this.btnTarihteBugün = new System.Windows.Forms.Button();
            this.txtjson = new System.Windows.Forms.TextBox();
            this.btnArkaSayfa = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOzluSozler
            // 
            this.btnOzluSozler.Location = new System.Drawing.Point(12, 22);
            this.btnOzluSozler.Name = "btnOzluSozler";
            this.btnOzluSozler.Size = new System.Drawing.Size(128, 23);
            this.btnOzluSozler.TabIndex = 0;
            this.btnOzluSozler.Text = "Özlü Sözler";
            this.btnOzluSozler.UseVisualStyleBackColor = true;
            this.btnOzluSozler.Click += new System.EventHandler(this.btnOzluSozler_Click);
            // 
            // btnTarihteBugün
            // 
            this.btnTarihteBugün.Location = new System.Drawing.Point(12, 61);
            this.btnTarihteBugün.Name = "btnTarihteBugün";
            this.btnTarihteBugün.Size = new System.Drawing.Size(128, 23);
            this.btnTarihteBugün.TabIndex = 1;
            this.btnTarihteBugün.Text = "Tarihte Bugün";
            this.btnTarihteBugün.UseVisualStyleBackColor = true;
            this.btnTarihteBugün.Click += new System.EventHandler(this.btnTarihteBugün_Click);
            // 
            // txtjson
            // 
            this.txtjson.Dock = System.Windows.Forms.DockStyle.Right;
            this.txtjson.Location = new System.Drawing.Point(164, 0);
            this.txtjson.Multiline = true;
            this.txtjson.Name = "txtjson";
            this.txtjson.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtjson.Size = new System.Drawing.Size(636, 450);
            this.txtjson.TabIndex = 2;
            // 
            // btnArkaSayfa
            // 
            this.btnArkaSayfa.Location = new System.Drawing.Point(12, 103);
            this.btnArkaSayfa.Name = "btnArkaSayfa";
            this.btnArkaSayfa.Size = new System.Drawing.Size(128, 23);
            this.btnArkaSayfa.TabIndex = 3;
            this.btnArkaSayfa.Text = "Arka Sayfa";
            this.btnArkaSayfa.UseVisualStyleBackColor = true;
            this.btnArkaSayfa.Click += new System.EventHandler(this.btnArkaSayfa_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnArkaSayfa);
            this.Controls.Add(this.txtjson);
            this.Controls.Add(this.btnTarihteBugün);
            this.Controls.Add(this.btnOzluSozler);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "İsmailağa Converter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOzluSozler;
        private System.Windows.Forms.Button btnTarihteBugün;
        public System.Windows.Forms.TextBox txtjson;
        private System.Windows.Forms.Button btnArkaSayfa;
    }
}

