
namespace CatchPhrase
{
    partial class FormAuthorEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAuthorEdit));
            this.label1 = new System.Windows.Forms.Label();
            this.author = new System.Windows.Forms.TextBox();
            this.country = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.save = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Автор";
            // 
            // author
            // 
            this.author.Dock = System.Windows.Forms.DockStyle.Top;
            this.author.Location = new System.Drawing.Point(10, 30);
            this.author.Name = "author";
            this.author.Size = new System.Drawing.Size(314, 26);
            this.author.TabIndex = 2;
            // 
            // country
            // 
            this.country.Dock = System.Windows.Forms.DockStyle.Top;
            this.country.Location = new System.Drawing.Point(10, 86);
            this.country.Name = "country";
            this.country.Size = new System.Drawing.Size(314, 26);
            this.country.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(10, 56);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.label2.Size = new System.Drawing.Size(52, 30);
            this.label2.TabIndex = 3;
            this.label2.Text = "Страна";
            // 
            // save
            // 
            this.save.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.save.Font = new System.Drawing.Font("Arial Narrow", 14F);
            this.save.Location = new System.Drawing.Point(10, 151);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(314, 80);
            this.save.TabIndex = 7;
            this.save.Text = "Сохранить";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // FormAuthorEdit
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(334, 241);
            this.Controls.Add(this.save);
            this.Controls.Add(this.country);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.author);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial Narrow", 12F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(350, 280);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(350, 280);
            this.Name = "FormAuthorEdit";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Изменить автора";
            this.Load += new System.EventHandler(this.FormAuthorEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox author;
        private System.Windows.Forms.TextBox country;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button save;
    }
}