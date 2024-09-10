using Business;
using Domain;
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
    public partial class FormAdd : Form
    {
        private Article article = null;
        public FormAdd()
        {
            InitializeComponent();
        }

        public FormAdd(Article article)
        {
            InitializeComponent();
            this.article = article;
        }

        private void FormAdd_Load(object sender, EventArgs e)
        {
            BrandBusiness brandBusiness = new BrandBusiness();
            CategoryBusiness categoryBusiness = new CategoryBusiness();
            try
            {
                comboboxBrand.DataSource = brandBusiness.Brands();
                comboboxCategory.DataSource = categoryBusiness.Categories();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnDecline_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAcept_Click(object sender, EventArgs e)
        {

        }

    }
}
