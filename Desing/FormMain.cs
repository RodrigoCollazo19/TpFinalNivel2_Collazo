using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desing
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnMyarticles_Click(object sender, EventArgs e)
        {
            FormArticles articlesWindow = new FormArticles();
            articlesWindow.ShowDialog();
        }
    }
}
