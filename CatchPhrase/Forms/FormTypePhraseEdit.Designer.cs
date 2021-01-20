
namespace CatchPhrase
{
    partial class FormTypePhraseEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTypePhraseEdit));
            this.label1 = new System.Windows.Forms.Label();
            this.type = new System.Windows.Forms.TextBox();
            this.save = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Тип";
            // 
            // type
            // 
            this.type.Dock = System.Windows.Forms.DockStyle.Top;
            this.type.Location = new System.Drawing.Point(10, 30);
            this.type.Name = "type";
            this.type.Size = new System.Drawing.Size(314, 26);
            this.type.TabIndex = 2;
            // 
            // save
            // 
            this.save.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.save.Font = new System.Drawing.Font("Arial Narrow", 14F);
            this.save.Location = new System.Drawing.Point(10, 81);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(314, 80);
            this.save.TabIndex = 7;
            this.save.Text = "Сохранить";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // FormTypePhraseEdit
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(334, 171);
            this.Controls.Add(this.save);
            this.Controls.Add(this.type);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial Narrow", 12F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(350, 210);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(350, 210);
            this.Name = "FormTypePhraseEdit";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Изменить тип";
            this.Load += new System.EventHandler(this.FormAuthorEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox type;
        private System.Windows.Forms.Button save;
    }
}