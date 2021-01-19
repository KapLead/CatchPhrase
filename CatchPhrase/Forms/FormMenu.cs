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

        private void authors_Click(object sender, EventArgs e)
        {
            Hide();
            new FormAuthors().ShowDialog();
            Show();
        }
    }
}
