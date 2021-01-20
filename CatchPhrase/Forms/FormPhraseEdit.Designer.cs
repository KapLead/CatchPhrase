
namespace CatchPhrase
{
    partial class FormPhraseEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPhraseEdit));
            this.label1 = new System.Windows.Forms.Label();
            this.authors = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.types = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Value = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Автор";
            // 
            // authors
            // 
            this.authors.Dock = System.Windows.Forms.DockStyle.Top;
            this.authors.FormattingEnabled = true;
            this.authors.Location = new System.Drawing.Point(10, 30);
            this.authors.Name = "authors";
            this.authors.Size = new System.Drawing.Size(313, 28);
            this.authors.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(10, 58);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.label2.Size = new System.Drawing.Size(30, 30);
            this.label2.TabIndex = 2;
            this.label2.Text = "Тип";
            // 
            // types
            // 
            this.types.Dock = System.Windows.Forms.DockStyle.Top;
            this.types.FormattingEnabled = true;
            this.types.Location = new System.Drawing.Point(10, 88);
            this.types.Name = "types";
            this.types.Size = new System.Drawing.Size(313, 28);
            this.types.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(10, 116);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.label3.Size = new System.Drawing.Size(47, 30);
            this.label3.TabIndex = 4;
            this.label3.Text = "Фраза";
            // 
            // Value
            // 
            this.Value.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Value.Location = new System.Drawing.Point(10, 146);
            this.Value.Multiline = true;
            this.Value.Name = "Value";
            this.Value.Size = new System.Drawing.Size(313, 158);
            this.Value.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button1.Font = new System.Drawing.Font("Arial Narrow", 14F);
            this.button1.Location = new System.Drawing.Point(10, 314);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(313, 80);
            this.button1.TabIndex = 6;
            this.button1.Text = "Сохранить";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(10, 304);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(313, 10);
            this.panel1.TabIndex = 7;
            // 
            // FormPhraseEdit
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(333, 404);
            this.Controls.Add(this.Value);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.types);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.authors);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial Narrow", 12F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPhraseEdit";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "Изменить фразу";
            this.Load += new System.EventHandler(this.FormPhraseEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox authors;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox types;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Value;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
    }
}