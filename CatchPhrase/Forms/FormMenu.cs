using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CatchPhrase
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        /// <summary> Открыть форму авторов </summary>
        private void authors_Click(object sender, EventArgs e)
        {
            new FormAuthors().ShowDialog();
        }

        /// <summary> Открыть форму типов </summary>
        private void types_Click(object sender, EventArgs e)
        {
            new FormTypePhrases().ShowDialog();
        }

        /// <summary> Открыть форму фраз </summary>
        private void phrase_Click(object sender, EventArgs e)
        {
            new FormPhrase().ShowDialog();
        }

        private void about_Click(object sender, EventArgs e)
        {
            new FormAbout().ShowDialog();
        }
    }
}
