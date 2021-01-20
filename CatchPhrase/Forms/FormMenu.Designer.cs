
namespace CatchPhrase
{
    partial class FormMenu
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMenu));
            this.authors = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.types = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // authors
            // 
            this.authors.Dock = System.Windows.Forms.DockStyle.Top;
            this.authors.Location = new System.Drawing.Point(10, 10);
            this.authors.Name = "authors";
            this.authors.Size = new System.Drawing.Size(239, 92);
            this.authors.TabIndex = 0;
            this.authors.Text = "Авторы";
            this.authors.UseVisualStyleBackColor = true;
            this.authors.Click += new System.EventHandler(this.authors_Click);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(10, 102);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(239, 10);
            this.panel1.TabIndex = 1;
            // 
            // types
            // 
            this.types.Dock = System.Windows.Forms.DockStyle.Top;
            this.types.Location = new System.Drawing.Point(10, 112);
            this.types.Name = "types";
            this.types.Size = new System.Drawing.Size(239, 92);
            this.types.TabIndex = 2;
            this.types.Text = "Типы и виды фраз";
            this.types.UseVisualStyleBackColor = true;
            this.types.Click += new System.EventHandler(this.types_Click);
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Top;
            this.button2.Location = new System.Drawing.Point(10, 214);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(239, 92);
            this.button2.TabIndex = 4;
            this.button2.Text = "Фразы";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(10, 204);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(239, 10);
            this.panel2.TabIndex = 3;
            // 
            // FormMenu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(259, 316);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.types);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.authors);
            this.Font = new System.Drawing.Font("Arial Narrow", 12F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(275, 355);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(275, 355);
            this.Name = "FormMenu";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Крылатые фразы";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button authors;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button types;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel2;
    }
}

